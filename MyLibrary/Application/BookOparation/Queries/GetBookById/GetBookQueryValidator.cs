using FluentValidation;

namespace MyLibrary.Application.BookOparation.Queries.GetBookById
{
    public class GetBookByIdCommandValidator : AbstractValidator<GetBookQuery>
    {
        public GetBookByIdCommandValidator(){
            RuleFor(command=>command.BookId).GreaterThan(0);



        }
        
    }
}