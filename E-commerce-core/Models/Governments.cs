using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Governments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Users> Users { get; set; } = new HashSet<Users>();
        public IEnumerable<Cities> Cities { get; set; } = new HashSet<Cities>();
        public IEnumerable<Zones> Zones { get; set; } = new HashSet<Zones>();
        public IEnumerable<Stores> Stores { get; set; } = new HashSet<Stores>();


    }
}
