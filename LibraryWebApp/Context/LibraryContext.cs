using LibraryWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Context
{
    public class LibraryContext :DbContext
    {
     public DbSet<User> User { get; set; }
     public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-UJRO3I0\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
