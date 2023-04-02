using Microsoft.EntityFrameworkCore;
using MyLibrary.Models.Entities;

namespace MyLibrary.DbOparations
{

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        // id = 1,
                        Title = "Lean Startup",
                        Image = "https://m.media-amazon.com/images/I/81-QB7nDh4L._AC_UF1000,1000_QL80_.jpg",
                        GenreId = 1,
                        AuthorId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        // id = 2,
                        Title = "Herland",
                        Image = "data:image/jpeg;base64,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",
                        GenreId = 2,
                        AuthorId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        // id = 3,
                        Title = "Dune",
                        Image = "https://tr.web.img4.acsta.net/pictures/21/10/13/11/52/2707524.jpg",
                        GenreId = 2,
                        AuthorId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    },
                    new Book
                    {
                        // id = 4,
                        Title = "vive de Leonor de Borbon",
                        Image = "https://m.media-amazon.com/images/I/81-QB7nDh4L._AC_UF1000,1000_QL80_.jpg",
                        GenreId = 3,
                        AuthorId = 4,
                        PageCount = 540,
                        PublishDate = new DateTime(2005, 10, 31)
                    }

                ); 
                context.Genres.AddRange(
                  new Genre
                  {
                      Name = "PersonalGrowth",
                  },
                    new Genre
                    {
                        Name = "ScienceFiction",
                    },
                    new Genre
                    {
                        Name = "ReinasVival",
                    },
                    new Genre
                    {
                        Name = "Noval",
                    },
                    new Genre
                    {
                        Name = "Historia",
                    }

                                    );


                context.Authors.AddRange(

                    new Author
                    {
                        Name = "George",
                        Surname = "Orwell",
                        Birthday = new DateTime(1903, 06, 25),
                    },
                       new Author
                       {
                           Name = "William",
                           Surname = "Shakespeare",
                           Birthday = new DateTime(1564, 04, 19),
                       },
                       new Author
                       {
                           Name = "Andy",
                           Surname = "Weir",
                           Birthday = new DateTime(1972, 06, 16),
                       },
                       new Author
                       {
                           Name = "Douglas",
                           Surname = "Adams",
                           Birthday = new DateTime(1952, 03, 11),
                       }

                );
                context.SaveChanges();
            }
        }
    }
}