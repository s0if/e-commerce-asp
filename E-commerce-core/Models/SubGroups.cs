using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class SubGroups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Items>  Items { get; set; }
        [ForeignKey(nameof(MainGroup))]
        public int MainGroupId { get; set; }
        public MainGroup MainGroup { get; set; }
        public IEnumerable<SubGroupTwo> SubGroupTwo { get; set; }   =new HashSet<SubGroupTwo>();

    }
}
