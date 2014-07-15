using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models.Entities
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }
        [Display(Name = "Article Title")]
        [StringLength(1000)]
        public String ArticleTitle { get; set; }
        [Display(Name = "Content")]
        [Required]
        [DataType(DataType.MultilineText)]
        public String ArticleContent { get; set; }
        [Display(Name = "Summary")]
        [Required]
        [DataType(DataType.MultilineText)]
        public String ArticleSummary { get; set; }
        [Display(Name = "Article Date")]
        [ScaffoldColumn(false)]
        public DateTime ArticleDate { get; set; }
        [StringLength(500)]
        public String ArticleKeywords { get; set; }
        [ScaffoldColumn(false)]
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }


    }
}