using FluentValidation;

namespace MyLibrary.Application.GenreOparation.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator(){

            RuleFor(command=>command.model.Name).NotEmpty().MinimumLength(4);


        }
        
    }
}