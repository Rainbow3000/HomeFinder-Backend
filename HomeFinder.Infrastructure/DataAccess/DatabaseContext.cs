using HomeFinder.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Infrastructure.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public IConfiguration _configuration { get; }

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("sql_connection_string"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình Property

            modelBuilder.Entity<Home>().Property(h => h.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Home>().Property(h => h.Description).HasMaxLength(255);
            modelBuilder.Entity<Home>().Property(h => h.Address).IsRequired().HasMaxLength(255);

            modelBuilder.Entity<Room>().Property(r => r.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Room>().Property(r => r.Description).HasMaxLength(255);
            modelBuilder.Entity<Room>().Property(r => r.NewPrice).IsRequired(); 
            modelBuilder.Entity<Room>().Property(r => r.OldPrice).IsRequired();
            modelBuilder.Entity<Room>().Property(r => r.Area).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>().Property(u => u.Phone).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<User>().Property(u => u.Address).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>().Property(u => u.IdentityId).IsRequired().HasMaxLength(30);

           modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<Order>().Property(o => o.AccountId).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Order>().Property(o => o.RoomId).IsRequired().HasMaxLength(255);
            
            

            modelBuilder.Entity<Comment>().Property(c => c.Message).HasMaxLength(255);
            modelBuilder.Entity<Comment>().Property(c => c.AccountId).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.RoomId).IsRequired();

            modelBuilder.Entity<Account>().Property(a => a.Email).IsRequired().HasMaxLength(100); 
            modelBuilder.Entity<Account>().Property(a => a.Password).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Account>().Property(a => a.Status).IsRequired();

            modelBuilder.Entity<OrderDetails>().Property(o => o.UserName).HasMaxLength(100);
            modelBuilder.Entity<OrderDetails>().Property(o => o.Phone).HasMaxLength(25);
            modelBuilder.Entity<OrderDetails>().Property(o => o.Note).HasMaxLength(255);
            modelBuilder.Entity<OrderDetails>().Property(o => o.UserIdentity).HasMaxLength(100);

            // Cấu hình Entity

            modelBuilder.Entity<Home>().ToTable("Home").HasKey(h=> h.HomeId);
            modelBuilder.Entity<Category>().ToTable("Category").HasKey(c => c.CategoryId);
            modelBuilder.Entity<Order>().ToTable("Order").HasKey(o => o.OrderId);
            modelBuilder.Entity<Room>().ToTable("Room").HasKey(r => r.RoomId);
            modelBuilder.Entity<Comment>().ToTable("Comment").HasKey(c => c.CommentId);
            modelBuilder.Entity<Account>().ToTable("Account").HasKey(a => a.AccountId);
            modelBuilder.Entity<User>().ToTable("User").HasKey(u => u.AccountId);
            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails").HasKey(o => o.OrderId);

            modelBuilder.Entity<Home>().HasOne<Category>(h => h.Category).WithMany(c => c.Homes).HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<Room>().HasOne<Home>(r => r.Home).WithMany(h => h.Rooms).HasForeignKey(r => r.HomeId);

            modelBuilder.Entity<Order>().HasOne<Room>(o => o.Room).WithMany(r => r.Orders).HasForeignKey(o => o.RoomId);
            modelBuilder.Entity<Order>().HasOne<Account>(o => o.Account).WithMany(a => a.Orders).HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<Comment>().HasOne<Account>(c => c.Account).WithMany(a => a.Comments).HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<Comment>().HasOne<Room>(c => c.Room).WithMany(r => r.Comments).HasForeignKey(c => c.RoomId);
            modelBuilder.Entity<Account>().HasOne<User>(a => a.User).WithOne(u => u.Account).HasForeignKey<User>(u => u.AccountId);
            modelBuilder.Entity<Order>().HasOne<OrderDetails>(o => o.OrderDetails).WithOne(o => o.Order).HasForeignKey<OrderDetails>(o => o.OrderId); 

        }

   
        public DbSet<Category> Categories { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
