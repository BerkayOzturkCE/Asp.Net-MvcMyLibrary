using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.DbOparations;
using MyLibrary.Models.Entities;

namespace MyLibrary.Application.GenreOparation.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel model{get;set;}
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        { 

            var genre = _dbcontext.Genres.SingleOrDefault(x => x.Name == model.Name);
            if (genre is not null)
            {
                throw new InvalidOperationException("Tür zaten mevcut");
            }
            genre= _mapper.Map<Genre>(model); 
       
            _dbcontext.Genres.Add(genre);
            _dbcontext.SaveChanges();
        }


        public class CreateGenreModel
        {
        public string Name { get; set; }
    
        }
    }


}