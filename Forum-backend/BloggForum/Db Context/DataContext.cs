using Microsoft.EntityFrameworkCore;
using Forum.Entities;
using Microsoft.SqlServer;


namespace Forum.Db_Context
{
    public class DataContext : DbContext
    {

        protected IConfiguration _Configuration;
        public DataContext(IConfiguration Configuration)
        {
            _Configuration = Configuration;
    
        }

        public DbSet<Forumpost> ForumPosts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseSqlServer(_Configuration.GetConnectionString("myConnectionString"));
            //opt.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
            
            
        }
        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    base.OnModelCreating(modelbuilder);

        //    modelbuilder.Entity<User>()
        //        .HasData(new User()
        //        {
        //            Id = 2,
        //            Username = "firstman",
        //            Password = "firstpass"

        //        });

        //    modelbuilder.Entity<Forumpost>()
        //        .HasData(new Forumpost()
        //        {
        //            Id = 1,
        //            TimePosted = DateTime.Now,
        //            Title = "First Post!",
        //            Content = "Welcome to the site!",
        //            ImageUrl = " ",
        //            Counter = 1,
        //            User


        //        }) ;


        //}


    }
}
