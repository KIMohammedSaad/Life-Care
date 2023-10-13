using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Models
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }

        //[DataType(DataType.Text)]
        [Required(ErrorMessage = "This field can't be empty")]
        //[MinLength(4)]
        //[RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Plz mention the specified format")]
        public string Name { get; set; }

        //[DataType(DataType.Text)]
        [Required(ErrorMessage = "This field can't be empty")]
        //[MinLength(4)]
        //[RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Plz mention the specified format")]
        public string Category { get; set; }

        [Required(ErrorMessage = "This field can't be empty")]
        //[MaxLength(4)]
        public int Quantity { get; set; }
    }
}
