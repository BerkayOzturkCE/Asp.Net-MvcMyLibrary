using Microsoft.AspNetCore.Mvc;
using MyLibrary.DbOparations;

namespace MyLibrary.Application.GenreOparation.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }

        private readonly IBookStoreDbContext _dbcontext;
        public DeleteGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {

            var genre = _dbcontext.Genres.Where(x => x.Id == GenreId).SingleOrDefault();

            if (genre is null)
            {
                throw new InvalidOperationException("Kitap türü Bulunamadı.");
            }

            _dbcontext.Genres.Remove(genre);
            _dbcontext.SaveChanges();
            return;


        }
    }



}