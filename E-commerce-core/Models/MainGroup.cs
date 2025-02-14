using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class MainGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<SubGroupTwo> SubGroupTwo { get; set; }  =new HashSet<SubGroupTwo>();
        public IEnumerable<SubGroups> SubGroups { get; set; } =new HashSet<SubGroups>();
    }
}
