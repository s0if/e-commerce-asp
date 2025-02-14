using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Interface
{
    public interface IUnitOfWork
    {  
       IAuthRepository AuthRepository { get; }
        IItemRepository ItemRepository { get; }
        ICartRepository CartRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        Task<int> SaveAsync();
    }
}
