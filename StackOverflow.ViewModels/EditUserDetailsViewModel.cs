using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.ViewModels
{
    public class EditUserDetailsViewModel
    {
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public string MobileNumber { get; set; }
    }
}
