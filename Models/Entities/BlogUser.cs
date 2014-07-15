using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Models.Entities
{
    public class BlogUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogUserId { get; set; }
        //[Remote()]
        public String Username { get; set; }
        [StringLength(100)]
        [Display(Name="First name")]
        public String Firstname { get; set; }
        [StringLength(100)]
        [Display(Name = "Last name")]
        public String Lastname { get; set; }
        [StringLength(100)]
        [EmailAddress]
        public String Email { get; set; }
        [ScaffoldColumn(false)]
        public DateTime JointDate { get; set; }
        public virtual IEnumerable<Blog> Blogs { get; set; }

    }
}