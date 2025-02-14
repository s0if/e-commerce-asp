using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.DTO_s
{
    public class RegisterDTOs
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int GovCode { get; set; }
        [Required]
        public int CityCode { get; set; }
        [Required]
        public int ZoneCode { get; set; }
    }
}
