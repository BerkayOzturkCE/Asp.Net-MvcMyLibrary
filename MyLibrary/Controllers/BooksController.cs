using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MyLibrary.DbOparations;
using FluentValidation;
using MyLibrary.Application.BookOparation.Queries.GetBooks;
using MyLibrary.Application.BookOparation.Queries.GetBookById;
using MyLibrary.Application.BookOparation.Commands.CreateBook;
using static MyLibrary.Application.BookOparation.Commands.CreateBook.CreateBookCommand;
using MyLibrary.Application.BookOparation.Commands.UpdateBook;
using MyLibrary.Application.BookOparation.Commands.DeleteBook;
using static MyLibrary.Application.BookOparation.Commands.UpdateBook.UpdateBookCommand;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyLibrary.Controllers
{

    public class BooksController : Controller
    {

        private readonly ILogger<BooksController> _logger;
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(ILogger<BooksController> logger, IBookStoreDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }



        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return View(result);
        }

        public IActionResult GetBooksById(int id)
        {
            GetBookQuery query = new GetBookQuery(_context, _mapper);
          
                query.BookId = id;
                GetBookByIdCommandValidator validator=new GetBookByIdCommandValidator();
                validator.ValidateAndThrow(query);
                var result = query.Handle();
                return Ok(result);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "id", "id");
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
            return View();
        }

        [HttpPost]
        public IActionResult AddBook([FromForm] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            command.model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return RedirectToAction("");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdatedBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

           
                command.id = id;
                command.UpdatedBook = updatedBook;
                UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return RedirectToAction("Books");

           
        }

        public IActionResult DeleteBook([FromForm] BookViewModel book)
        {
            
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookTitle = book.Title;
                DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            return RedirectToAction("");

        }


    }
}