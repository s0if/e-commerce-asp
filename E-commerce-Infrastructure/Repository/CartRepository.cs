using Azure;
using E_commerce_core.DTO_s;
using E_commerce_core.Interface;
using E_commerce_core.Models;
using E_commerce_Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Infrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CartRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> AddBulkQuantityToCartAsync(CartDTOs cart, int userId)
        {
            Items item = await dbContext.items.FindAsync(cart.ItemId);
            Stores store = await dbContext.stores.FindAsync(cart.SoresId);
            if (store == null || item == null)
            {
                return null;
                //item or store is null
            }
            else
            {
                ShoppingCartItems existing = await dbContext.shoppingCartItems
                    .SingleOrDefaultAsync(x => x.ItemId == item.Id && x.SoresId == store.Id && x.CustomerId == userId);
                if (existing == null)
                {
                    ShoppingCartItems shoppingCartItem = new ShoppingCartItems
                    {
                        ItemId = item.Id,
                        SoresId = store.Id,
                        CustomerId = userId,
                        CreatedDate = DateTime.Now,
                        Quantity = cart.Quantity,
                        UpdateTime = null,
                        UnitId = cart.UnitId,

                    };
                    dbContext.shoppingCartItems.Add(shoppingCartItem);
                    await dbContext.SaveChangesAsync();
                    return "add successful";

                }
                else
                {
                    existing.Quantity = cart.Quantity;
                    existing.UpdateTime = DateTime.Now;
                    existing.UnitId = cart.UnitId;
                    return "update successful";
                }

            }
        }

        public async Task<string> AddOneQuantityToCartAsync(AddOrDeleteToOneItemDTOs cart, int userId)
        {
            Items item = await dbContext.items.FindAsync(cart.ItemId);
            Stores store = await dbContext.stores.FindAsync(cart.SoresId);
            if (item is not null || store is not null)
            {
                ShoppingCartItems existingItem = await dbContext.shoppingCartItems
                  .SingleOrDefaultAsync(sho => sho.ItemId == item.Id && sho.CustomerId == userId && sho.SoresId == store.Id);
                if (existingItem is not null)
                {
                    existingItem.Quantity += 1;
                    existingItem.UpdateTime = DateTime.Now;
                    await dbContext.SaveChangesAsync();
                    return "Item to add one cart successful";
                }
            }
            else
            {
                return "item or store is null";
            }
            return null;
        }

        public async Task<string> DeleteOneQuantityToCartAsync(AddOrDeleteToOneItemDTOs cart, int userId)
        {
            Items item = await dbContext.items.FindAsync(cart.ItemId);
            Stores store = await dbContext.stores.FindAsync(cart.SoresId);
            if (item is not null || store is not null)
            {
                ShoppingCartItems existingItem = await dbContext.shoppingCartItems
                  .SingleOrDefaultAsync(sho => sho.ItemId == item.Id && sho.CustomerId == userId && sho.SoresId == store.Id);
                if (existingItem is not null)
                {
                    if (existingItem.Quantity > 0) 
                    { 
                        existingItem.Quantity -= 1;
                        existingItem.UpdateTime = DateTime.Now;
                        await dbContext.SaveChangesAsync();
                        return "Item to delete one cart successful";
                    }
                    return "Don;t delete item to cart";
                }
                return "item or store is null";
            }
           
            return null;
        }
        public async Task<string> DeleteBulkQuantityToCartAsync(AddOrDeleteToOneItemDTOs cart, int userId)
        {
            Items item = await dbContext.items.FindAsync(cart.ItemId);
            Stores store = await dbContext.stores.FindAsync(cart.SoresId);
            if (item is not null || store is not null)
            {
                ShoppingCartItems existingItem = await dbContext.shoppingCartItems
                  .SingleOrDefaultAsync(sho => sho.ItemId == item.Id && sho.CustomerId == userId && sho.SoresId == store.Id);
                if (existingItem is not null)
                {
                    dbContext.shoppingCartItems.Remove(existingItem);
                    await dbContext.SaveChangesAsync();
                    return "Delete successful";
                }
                return "item or store is null";
            }

            return null;
        }

        public async Task<IEnumerable<CartItemsDTOs>> GetAllItemInCartAsync(int userId)
        {
           IEnumerable<ShoppingCartItems> CartItem=await dbContext.shoppingCartItems
                .Where(x=>x.CustomerId == userId)
                //.Include(x=>x.Items)
                .Include(x=>x.Items.ItemsUnits)
                .ThenInclude(x=>x.Units)
                .ToListAsync();
            IEnumerable<CartItemsDTOs> itemDto = CartItem.Select(x => new CartItemsDTOs
            {
                Name = x.Items.Name,
                Price = x.Items.Price,
                ItemUnuit = x.Items.ItemsUnits.Where(unit => unit.UnitId == x.UnitId&&x.ItemId==unit.ItemId).Select(unit => unit.Units.Name).FirstOrDefault()

            }).ToList();
            return itemDto;
        }
    }
}
