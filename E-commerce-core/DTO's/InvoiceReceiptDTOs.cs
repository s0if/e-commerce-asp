using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.DTO_s
{
    public class InvoiceReceiptDTOs
    {
        public int CustomerId {  get; set; }
        public int  InvoiceId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public IEnumerable<InvoiceItemsDTOs> Items { get; set; }
    }
}
