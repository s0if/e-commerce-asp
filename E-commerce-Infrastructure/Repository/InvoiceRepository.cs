using E_commerce_core.DTO_s;
using E_commerce_core.Interface;
using E_commerce_core.Models;
using E_commerce_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Infrastructure.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext dbContext;

        public InvoiceRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<string> CreateInvoiceAsync(int customerId)
        {
            IEnumerable<ShoppingCartItems> CartItem = await dbContext.shoppingCartItems.Include(x => x.Items).Where(x => x.CustomerId == customerId).ToListAsync();

            if (CartItem is not null || CartItem.Any())
            {
                List<string> UnAvailableItem = new List<string>();
                double TotalNetPrice = 0;
                foreach (var item in CartItem)
                {
                    InvItemStores invItemStores = await dbContext.invItemStores.FirstOrDefaultAsync(x => x.StoresId == item.SoresId && x.ItemId == item.ItemId);

                    if (invItemStores != null)
                    {
                        UnAvailableItem.Add(item.Items.Name);
                        continue;
                    }
                    double AvailablelQuintity = invItemStores.Balance - invItemStores.ReservedQuantity;
                    if (item.Quantity > AvailablelQuintity)
                    {
                        UnAvailableItem.Add(item.Items.Name);
                        continue;
                    }
                }
                int UnAvailableItemCount = UnAvailableItem.Count();
                int NumberOfCartItem = UnAvailableItem.Count();
                if (UnAvailableItemCount == NumberOfCartItem)
                {
                    return "All Item In Cart UnAvailable";
                }

                Invoice invoice = new Invoice()
                {
                    CustomerId = customerId,
                    CreatedDate = DateTime.Now,
                    IsClosed = false,
                    IsPosted = true,
                    IsReviewed = false,
                    NetPrice = 0,
                    TransactionType = 1,
                    PaymentType = 1,
                };
                await dbContext.invoices.AddAsync(invoice);
                await dbContext.SaveChangesAsync();


                foreach (var item in CartItem)
                {
                    InvItemStores invItemStores = await dbContext.invItemStores.FirstOrDefaultAsync(x => x.StoresId == item.SoresId && x.ItemId == item.ItemId);


                    double unitPrice = item.Items.Price;
                    double ItemTotalPrice = item.Quantity * unitPrice;
                    TotalNetPrice += ItemTotalPrice;
                    InvoiceDetails invoiceDetails = new InvoiceDetails()
                    {
                        UnitId = item.UnitId,
                        Quantity = item.Quantity,
                        Price = ((int)unitPrice),
                        ItemId = item.ItemId,
                        InvoiceId = invoice.Id,
                    };
                    await dbContext.invoicesDetails.AddAsync(invoiceDetails);
                    invItemStores.ReservedQuantity += item.Quantity;
                    dbContext.invItemStores.Update(invItemStores);
                }
                invoice.NetPrice = TotalNetPrice;
                dbContext.shoppingCartItems.RemoveRange(
                   CartItem.Where(item => !UnAvailableItem.Contains(item.Items.Name))
                   );
                await dbContext.SaveChangesAsync();
                if (UnAvailableItem.Any())
                {
                    var UnAvailableItemMessage = string.Join(",", UnAvailableItem.Select
                        (item =>
                        {
                            var cartItems = CartItem.FirstOrDefault(x => x.Items.Name == item);
                            if (cartItems is not null)
                            {
                                var itemStore = dbContext.invItemStores
                                .FirstOrDefault(i => i.ItemId == cartItems.ItemId);
                                if (itemStore is not null)
                                {
                                    double availableItem = itemStore.Balance - itemStore.ReservedQuantity;
                                    return $"{item} (available quantity={availableItem})";
                                }
                            }
                            return item;
                        })
                        );
                    return $"invoice successfully with ID: {invoice.Id} and total price: {TotalNetPrice} , However the following items were unavailable item {UnAvailableItemMessage}";
                }

                return $"invoice successfully with ID: {invoice.Id} and total price: {TotalNetPrice} ";
            }
            return null;
        }

        public async Task<InvoiceReceiptDTOs> GetInvoiceReceiptAsync(int customerId, int invoiceId)
        {
            Invoice invoice = await dbContext.invoices.Include(inv => inv.InvoiceDetails).
                ThenInclude(x => x.Items).
                FirstOrDefaultAsync(inv => inv.Id == invoiceId && inv.CustomerId == customerId);
            if (invoice is not null)
            {
                double totalPrice = 0;
                foreach (InvoiceDetails item in invoice.InvoiceDetails)
                {
                    double price = item.Quantity * item.Price;
                    totalPrice += price;
                }
                invoice.NetPrice = totalPrice;
                 dbContext.UpdateRange(invoice);
                await dbContext.SaveChangesAsync();

                InvoiceReceiptDTOs Receipt = new InvoiceReceiptDTOs
                {
                    CreateAt = invoice.CreatedDate,
                    CustomerId = invoice.CustomerId,
                    InvoiceId = invoice.Id,
                    TotalPrice = invoice.NetPrice,
                    Items = invoice.InvoiceDetails.Select(details => new InvoiceItemsDTOs
                    {
                        ItemName = details.Items.Name,
                        Quantity = details.Quantity,
                        TotalPrice = totalPrice,
                        UnitName = dbContext.units.FirstOrDefault(u => u.Id == details.UnitId)?.Name ?? "unKnow"
                    })

                };
                return Receipt;
            }
            return null;
        }
    }
}
