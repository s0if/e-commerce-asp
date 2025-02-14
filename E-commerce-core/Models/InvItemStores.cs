using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class InvItemStores
    {
        public double Balance {  get; set; }
        public int Factory {  get; set; }
        public double ReservedQuantity { get; set; }
        public DateTime LastUpdate { get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public Items Items { get; set; }
        [ForeignKey(nameof(Stores))]
        public int StoresId { get; set; }
        public Stores Stores { get; set; }

    }
}
