using BlogCodeApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BlogCodeApp.DAL
{
    public class BlogCodeAppContext : DbContext
    {
        public BlogCodeAppContext() : base("BlogCodeAppContext")
        {

        }

        public DbSet<Blogger> Bloggers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}