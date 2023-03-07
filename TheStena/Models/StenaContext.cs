using Microsoft.EntityFrameworkCore;

namespace TheStena.Models
{
    public class StenaContext : DbContext
    {
        public StenaContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Dog",
                    CreatedDate = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    Name = "Cat",
                    CreatedDate = DateTime.Now
                },
                new User
                {
                    Id = 3,
                    Name = "Pastor",
                    CreatedDate = new DateTime(2023, 1, 4)
                }); 

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Dog's post 1",
                    CreatedDate = DateTime.Now,
                    AuthorId = 1,
                    Upvotes = 4,
                    Downvotes = 2
                },
                new Post
                {
                    Id = 2,
                    Title = "Dog's post 2",
                    CreatedDate = DateTime.Now,
                    AuthorId = 1,
                    Upvotes = 60,
                    Downvotes = 7
                },
                new Post
                {
                    Id = 3,
                    Title = "Cat's post 1",
                    CreatedDate = DateTime.Now,
                    AuthorId = 2,
                    Upvotes = 15,
                    Downvotes = 30
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
