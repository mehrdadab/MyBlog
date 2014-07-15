using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.ViewModel
{
    public class ContactMe
    {
        [DisplayName("Firstname")]
        [StringLength(50)]
        [Required]
        public String FirstName { get; set; }
        [DisplayName("Lastname")]
        [StringLength(50)]
        public String LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public String Message { get; set; }
    }
}