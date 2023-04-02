using Microsoft.AspNetCore.Mvc;
using MyLibrary.DbOparations;

namespace MyLibrary.Application.BookOparation.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        public string BookTitle { get; set; }

        private readonly IBookStoreDbContext _dbcontext;
        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {

            var book = _dbcontext.Books.Where(book => book.Title == BookTitle).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı.");
            }

              _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
            return;


        }
    }


}