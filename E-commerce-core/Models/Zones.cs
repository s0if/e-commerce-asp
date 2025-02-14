﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Models
{
    public class Zones
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Users> Users { get; set; } = new HashSet<Users>();
        [ForeignKey(nameof(Governments))]
        public int GovernmetId { get; set; }
        public Governments Governments { get; set; }
        [ForeignKey(nameof(Cities))]
        public int CityetId { get; set; }
        public Cities Cities { get; set; }
        public IEnumerable<Stores> Stores { get; set; } = new HashSet<Stores>();


    }
}
