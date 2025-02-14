using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class InvoiceDetails
    {
        public double Price { get; set; }
        public int UnitId { get; set; }
        public double Quantity { get; set; }
        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemId {  get; set; }
        public Items Items { get; set; }
    }
}
