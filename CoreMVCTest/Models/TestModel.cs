using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCTest.Models
{
    public class TestModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage ="Please tell us your first name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [Range(1,99)]
        public string Age { get; set; }
    }
}
