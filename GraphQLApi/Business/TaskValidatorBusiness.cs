using FluentValidation;
using FluentValidation.Results;
using GraphQLApi.Business.Interfaces;
using GraphQLApi.Requests;

namespace GraphQLApi.Business
{
    public class TaskValidatorBusiness : AbstractValidator<UpsertTaskRequest>, ITaskValidatorBusiness
    {
        public TaskValidatorBusiness()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Título");

            RuleFor(t => t.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithName("Descrição");
        }
    }
}
