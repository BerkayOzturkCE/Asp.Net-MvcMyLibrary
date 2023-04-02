using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.DbOparations;
using MyLibrary.Models.Entities;

namespace MyLibrary.Application.AuthorOparation.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel model {get;set;}
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        { 

            var author = _dbcontext.Authors.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);
            if (author is not null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut");
            }
            author= _mapper.Map<Author>(model); 
       
            _dbcontext.Authors.Add(author);
            _dbcontext.SaveChanges();
        }


        public class CreateAuthorModel
        {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    
        }
    }


}