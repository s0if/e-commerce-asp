using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(MainGroup))]
        public int MainGroupId { get; set; }
        public MainGroup MainGroup { get; set; }

        [ForeignKey(nameof(SubGroups))]
        public int SubGroupsId { get; set; }
        public SubGroups SubGroups { get; set; }

        [ForeignKey(nameof(SubGroupTwo))]
        public int SubGroupTwoId { get; set; }
        public SubGroupTwo SubGroupTwo { get; set; }

        public IEnumerable<InvItemStores> InvItemStores { get; set; } =new HashSet<InvItemStores>();
        public IEnumerable<ItemsUnits> ItemsUnits { get; set; }=new HashSet<ItemsUnits>();
        public IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }=new HashSet<ShoppingCartItems>();
        public IEnumerable<InvoiceDetails> InvoiceDetails { get; set; } = new HashSet<InvoiceDetails>();

    }
}
