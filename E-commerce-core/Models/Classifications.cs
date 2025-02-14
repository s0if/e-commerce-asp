using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Classifications
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Users))]
        public int CustomerId {  get; set; }
        public Users Users { get; set; }
    }
}
