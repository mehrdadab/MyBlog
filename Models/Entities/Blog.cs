using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models.Entities
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        [Display(Name = "Blog name")]
        [StringLength(200)]
        public String BlogName { get; set; }
        [Required]
        [StringLength(200)]
        public String Subject { get; set; }
        [Display(Name = "Number of Articles In First Page")]
        public int NumOfArticlesInFirstPage { get; set; }
        [Display(Name = "Summary Length")]
        public int SummaryLength { get; set; }
        [Display(Name = "Blog Date")]
        [ScaffoldColumn(false)]
        public DateTime BlogDate { get; set; }
        [ScaffoldColumn(false)]
        public int BlogUserId { get; set; }

        public virtual BlogUser BlogUser { get; set; }
        public virtual IEnumerable<Article> Articles { get; set; }


    }
}