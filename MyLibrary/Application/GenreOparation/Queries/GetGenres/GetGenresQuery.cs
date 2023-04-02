using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.DbOparations;

namespace MyLibrary.Application.GenreOparation.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {

            var genres = _dbcontext.Genres.Where(genre => genre.IsActive).OrderBy(genre=>genre.Id);

            if (genres is null)
            {
                throw new InvalidOperationException("Tür Bulunamadı.");
            }

            List<GenresViewModel> returnObj=_mapper.Map<List<GenresViewModel>>(genres); 
            return returnObj;

        }
    }

    public class GenresViewModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    }

}