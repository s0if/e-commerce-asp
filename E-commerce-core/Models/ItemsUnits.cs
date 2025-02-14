using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class ItemsUnits
    {
        public int Factory { get; set; }
        [ForeignKey(nameof(Units))]
        public int UnitId { get; set; }
        public Units Units {  get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public Items Items { get; set; }
    }
}
