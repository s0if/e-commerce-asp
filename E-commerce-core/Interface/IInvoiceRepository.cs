using E_commerce_core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Interface
{
    public interface IInvoiceRepository
    {
        Task<string> CreateInvoiceAsync(int customerId);
        Task<InvoiceReceiptDTOs> GetInvoiceReceiptAsync(int customerId, int invoiceId);

    }
}
