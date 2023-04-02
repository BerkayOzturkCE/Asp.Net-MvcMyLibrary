using AutoMapper;
using MyLibrary.Application.AuthorOparation.Queries.GetAuthorById;
using MyLibrary.Application.AuthorOparation.Queries.GetAuthors;
using MyLibrary.Application.BookOparation.Queries.GetBookById;
using MyLibrary.Application.BookOparation.Queries.GetBooks;
using MyLibrary.Application.GenreOparation.Queries.GetGenreById;
using MyLibrary.Application.GenreOparation.Queries.GetGenres;
using MyLibrary.Models.Entities;
using static MyLibrary.Application.AuthorOparation.Commands.CreateAuthor.CreateAuthorCommand;
using static MyLibrary.Application.BookOparation.Commands.CreateBook.CreateBookCommand;
using static MyLibrary.Application.GenreOparation.Commands.CreateGenre.CreateGenreCommand;

namespace MyApiTrain.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name+ " " +src.Author.Surname));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name+ " " +src.Author.Surname));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author,AuthorsViewModel>();
            CreateMap<Author,AuthorViewModel>();






        }
    }
}