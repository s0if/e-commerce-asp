using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.DTO_s
{
    public class ItemDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } 
        public List<string > ItemUnits { get; set; }
        public List<string> Stores { get; set; }
    }
}
