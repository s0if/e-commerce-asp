using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Users> Users { get; set; }=new HashSet<Users>();

        [ForeignKey(nameof(Governments))]
        public int governmetId { get; set; }
        public Governments Governments { get; set; }
        public IEnumerable<Zones> Zones { get; set; }
        public IEnumerable<Stores> Stores { get; set; } = new HashSet<Stores>();

    }
}
