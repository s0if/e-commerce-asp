using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Stores
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Governments))]
        public int GovernmentsId { get; set; }
        [ForeignKey(nameof(Cities))]
        public int CityId { get; set; }
        [ForeignKey(nameof(Zones))]

        public int ZoneId { get; set; }
        public Governments Governments { get; set; }
        public Cities Cities { get; set; }
        public Zones Zones { get; set; }
        public IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }=new HashSet<ShoppingCartItems>();
          public IEnumerable<CustomerStores> CustomerStores { get; set; } = new HashSet<CustomerStores>();
        public IEnumerable<InvItemStores> InvItemStores { get; set; } = new HashSet<InvItemStores>();

    }
}
