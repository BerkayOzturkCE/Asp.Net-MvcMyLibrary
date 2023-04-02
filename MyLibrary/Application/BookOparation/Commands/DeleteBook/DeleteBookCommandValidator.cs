using FluentValidation;

namespace MyLibrary.Application.BookOparation.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator(){
            RuleFor(command=>command.BookTitle).NotEmpty().MinimumLength(4);
        }
        
    }
}