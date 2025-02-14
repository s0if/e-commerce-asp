using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Units
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ItemsUnits> ItemsUnits { get; set; }
    }
}
