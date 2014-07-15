using MyBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class EFDbContext:DbContext
    {
        public EFDbContext():base("DefaultConnection")
        {
        }
        public DbSet<BlogUser> BlogUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}