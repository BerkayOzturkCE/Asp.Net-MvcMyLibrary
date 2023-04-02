using Microsoft.AspNetCore.Mvc;
using MyLibrary.DbOparations;
using AutoMapper;
using FluentValidation;
using MyLibrary.Application.GenreOparation.Queries.GetGenres;
using MyLibrary.Application.GenreOparation.Queries.GetGenreById;
using MyLibrary.Application.GenreOparation.Commands.CreateGenre;
using static MyLibrary.Application.GenreOparation.Commands.CreateGenre.CreateGenreCommand;
using static MyLibrary.Application.GenreOparation.Commands.UpdateGenre.UpdateGenreCommand;
using MyLibrary.Application.GenreOparation.Commands.UpdateGenre;
using MyLibrary.Application.GenreOparation.Commands.DeleteGenre;

namespace MyLibrary.Controllers
{
    public class GenresController : Controller { 


        private readonly ILogger<BooksController> _logger;
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;


        public GenresController( IBookStoreDbContext  context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return View(result);
        }

        public IActionResult GetGenreById(int id)
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper);
            query.GenreId = id;
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);


        }


        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGenre([FromForm] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.model = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return RedirectToAction("GetGenres");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdatedGenreModel updatedGenre)
        {

               UpdateGenreCommand command = new UpdateGenreCommand(_context);
               command.GenreId = id;
               command.UpdatedGenre = updatedGenre;
               UpdateGenreCommandValidator validator=new UpdateGenreCommandValidator();
               validator.ValidateAndThrow(command);
               command.Handle();
            return Ok();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {

             DeleteGenreCommand command = new DeleteGenreCommand(_context);
             command.GenreId = id;
             DeleteGenreCommandValidator validator=new DeleteGenreCommandValidator();
             validator.ValidateAndThrow(command);
             command.Handle();
            return Ok();

        }


    }
}