using E_commerce_core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Interface
{
    public interface ICartRepository
    {
        Task<string> AddBulkQuantityToCartAsync(CartDTOs cart, int userId);
        Task<string> DeleteBulkQuantityToCartAsync(AddOrDeleteToOneItemDTOs cart, int userId);
        Task<string> AddOneQuantityToCartAsync(AddOrDeleteToOneItemDTOs cart, int userId);
        Task<string> DeleteOneQuantityToCartAsync(AddOrDeleteToOneItemDTOs cart, int userId);
        Task<IEnumerable<CartItemsDTOs>> GetAllItemInCartAsync(int userId);

    }
}
