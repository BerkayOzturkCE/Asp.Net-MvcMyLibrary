using Microsoft.EntityFrameworkCore;
using MyLibrary.Models.Entities;

namespace MyLibrary.DbOparations
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get;set; }
        DbSet<Genre> Genres { get;set; }
        DbSet<Author> Authors { get;set; }

        int SaveChanges();
    }
    
}