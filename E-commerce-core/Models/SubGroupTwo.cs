using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class SubGroupTwo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Items> Items { get; set; }=new HashSet<Items>();
        [ForeignKey(nameof(SubGroups))]
        public int SubGroupsId { get; set; }
        public SubGroups SubGroups {  get; set; }

        [ForeignKey(nameof(MainGroup))]
        public int MainGroupsId { get; set; }
        public MainGroup MainGroup { get; set; }

    }
}
