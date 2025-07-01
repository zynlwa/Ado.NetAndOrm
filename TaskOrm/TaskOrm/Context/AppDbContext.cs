using Microsoft.EntityFrameworkCore;
using TaskOrm.Models;

namespace TaskOrm.Context
{
    public class AppDbContext:DbContext
    {
        private const string ConnectionStr = @"Server=ZYNLVA\SQLEXPRESS;Database=PB305;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStr);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
