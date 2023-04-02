

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.AuthorOparation.Commands.CreateAuthor;
using MyLibrary.Application.AuthorOparation.Commands.DeleteAuthor;
using MyLibrary.Application.AuthorOparation.Commands.UpdateAuthor;
using MyLibrary.Application.AuthorOparation.Queries.GetAuthorById;
using MyLibrary.Application.AuthorOparation.Queries.GetAuthors;
using MyLibrary.DbOparations;
using static MyLibrary.Application.AuthorOparation.Commands.CreateAuthor.CreateAuthorCommand;
using static MyLibrary.Application.AuthorOparation.Commands.UpdateAuthor.UpdateAuthorCommand;



namespace MyLibrary.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly ILogger<BooksController> _logger;
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;


        public AuthorsController( IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return View(result);
        }

        public IActionResult GetAuthorById(int id)
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context, _mapper);
            query.AuthorId = id;
            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor([FromForm] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.model = newAuthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return RedirectToAction("GetAuthors");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdatedAuthorModel UpdatedAuthor)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.UpdatedAuthor = UpdatedAuthor;
            UpdateAuthorCommandValidator validator=new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator=new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }


    }
}