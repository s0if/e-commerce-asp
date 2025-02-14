using E_commerce_core.DTO_s;
using E_commerce_core.Interface;
using E_commerce_core.Mapping_Profiles;
using E_commerce_core.Models;
using E_commerce_Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Infrastructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //public async Task<IEnumerable<ItemDTOs>> GetItemsAsync()
        //{
        //    var items = await dbContext.items

        //         .Select(x => new ItemDTOs()
        //         {
        //             Id = x.Id,
        //             Name = x.Name,
        //             Price = x.Price,
        //             Description = x.Description,
        //             ItemUnits = x.ItemsUnits.Select(unit => unit.Units.Name).ToList() ,
        //             Stores=x.InvItemStores.Select  (stores=>stores.Stores.Name).ToList()
        //         })
        //        .ToListAsync();
        //    return items;
        //}
        public async Task<PageDTOs<ItemDTOs>> GetItemsAsync(int pageIndex,int PageSize)
        {
           var config=Mapping_Profile.Config;
            var items= dbContext.items.
                ProjectToType<ItemDTOs>(config).AsQueryable();
            var result = await PaginationAsync(items, pageIndex, PageSize);
            return result;
        }

        public async Task<PageDTOs<ItemDTOs>> PaginationAsync(IQueryable<ItemDTOs> Query, int PageIndex, int PageSize)
        {
            int totalItem=await Query.CountAsync();
            IEnumerable<ItemDTOs> item=await Query.Skip((PageIndex-1)*PageSize).Take(PageSize).ToListAsync();
           var result = new PageDTOs<ItemDTOs>()
            {
                PageSize = PageSize,
                TotalItem = totalItem,
                PageIndex = PageIndex,
                Items = item
            };
            return result;

        }
    }
}
