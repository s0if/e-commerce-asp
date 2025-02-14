using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Users:IdentityUser<int>
    {
        [ForeignKey(nameof(Governments))]
        public int GovernmentsId { get; set; }
        public Governments Governments { get; set; }

        [ForeignKey(nameof(Cities))]
        public int CityId { get; set; }
        public Cities Cities { get; set; }

        [ForeignKey(nameof(Zones))]
        public int ZonesId { get; set; }
        public Zones Zones { get; set; }
        public IEnumerable<Classifications> Classifications { get; set; }   =new HashSet<Classifications>();
        public IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItems>();
        public IEnumerable<Invoice> Invoice { get; set; } = new HashSet<Invoice>();
        public IEnumerable<CustomerStores> CustomerStores { get; set; }=new HashSet<CustomerStores>();
    }
}
