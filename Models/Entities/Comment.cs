using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        [Display(Name="Full name")]
        [StringLength(100)]
        public String Fullname { get; set; }
        [StringLength(100)]
        [EmailAddress]
        public String Email { get; set; }
        [Display(Name="Comment")]
        public String CommentContent { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CommentDate { get; set; }
        [ScaffoldColumn(false)]
        public int ArticleId { get; set; }
        [ScaffoldColumn(false)]
        public bool Published { get; set; }

        public virtual Article Article { get; set; }

    }
}