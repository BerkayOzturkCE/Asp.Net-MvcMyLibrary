
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.DbOparations;

namespace MyLibrary.Application.AuthorOparation.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery
    {
        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetAuthorByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public AuthorViewModel Handle()
        {

            var author = _dbcontext.Authors.SingleOrDefault(x=> x.id == AuthorId);

            if (author is null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı.");
            }

            AuthorViewModel returnObj = _mapper.Map<AuthorViewModel>(author);
            return returnObj;

        }
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }

}