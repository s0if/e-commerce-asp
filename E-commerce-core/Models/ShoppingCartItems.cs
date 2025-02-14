using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class ShoppingCartItems
    {
       public double Quantity {get;set;}
        public DateTime CreatedDate {get;set;}=DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public int UnitId { get; set;}
        [ForeignKey(nameof(Stores))]
        public int SoresId { get; set;}
        public Stores Stores { get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public Items Items { get; set; }

        [ForeignKey(nameof(Users))]
        public int CustomerId { get; set; }
        public Users Users { get; set; }

    }
}
