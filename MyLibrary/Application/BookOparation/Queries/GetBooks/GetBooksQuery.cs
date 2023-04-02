using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.DbOparations;

namespace MyLibrary.Application.BookOparation.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {

            var booksList = _dbcontext.Books.Include(x => x.Genre).Include(y=>y.Author).OrderBy(x => x.id).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(booksList);
            //new List<BooksViewModel>();
            //foreach (var book in booksList)
            //{
            //    vm.Add(
            //        new BooksViewModel(){
            //            Title=book.Title,
            //            PageCount=book.PageCount,
            //            Genre=((GenreEnum)book.GenreId).ToString(),
            //            PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //        }
            //    ); 
            //}
            return vm;

        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }

    }

}