using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.DTO_s
{
    public class PageDTOs <itemdto>
    {
        public int TotalItem { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<ItemDTOs> Items { get; set; }
    }
}
