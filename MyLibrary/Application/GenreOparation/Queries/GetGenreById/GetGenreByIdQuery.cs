
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.DbOparations;

namespace MyLibrary.Application.GenreOparation.Queries.GetGenreById
{
    public class GetGenreByIdQuery
    {
        public int GenreId { get; set; }

        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetGenreByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public GenreViewModel Handle()
        {

            var genre = _dbcontext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);

            if (genre is null)
            {
                throw new InvalidOperationException("Tür Bulunamadı.");
            }

            GenreViewModel returnObj = _mapper.Map<GenreViewModel>(genre);
            return returnObj;

        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}