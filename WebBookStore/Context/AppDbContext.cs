using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebBookStore.Models;

namespace WebBookStore.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
