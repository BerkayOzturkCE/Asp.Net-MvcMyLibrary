using FluentValidation;

namespace MyLibrary.Application.AuthorOparation.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator(){
            RuleFor(command=>command.AuthorId).GreaterThan(0);



        }
        
    }
}