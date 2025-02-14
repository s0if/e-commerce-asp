using E_commerce_core.DTO_s;
using E_commerce_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Interface
{
    public interface IItemRepository
    {
        Task<PageDTOs<ItemDTOs>> GetItemsAsync(int pageIndex, int PageSize);
        Task<PageDTOs<ItemDTOs>> PaginationAsync(IQueryable<ItemDTOs> Query,int PageIndex,int PageSize);
    }
}
