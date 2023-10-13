using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Models
{
    public class Register
    {
        [Key]
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="This field can't be empty")]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage ="Plz mention the specified format")]
        public string Username { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        [Range(18,100)]
        public  int Age { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage ="Don't leave this field empty...")]
        public string Address { get; set; }
    }
}
