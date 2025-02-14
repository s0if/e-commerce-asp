using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public double NetPrice { get; set; }
        public int TransactionType { get; set; }
        public int PaymentType { get; set; }

        public bool IsPosted { get; set; }
        public bool IsClosed { get; set; }
        public bool IsReviewed { get; set; }
        [ForeignKey(nameof(Users))]
        public int CustomerId { get; set; }
        public Users Users { get; set; }
        public IEnumerable<InvoiceDetails> InvoiceDetails { get; set; } = new HashSet<InvoiceDetails>();
    }
}
