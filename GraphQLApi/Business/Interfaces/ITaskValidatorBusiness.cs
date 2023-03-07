using FluentValidation;
using GraphQLApi.Requests;

namespace GraphQLApi.Business.Interfaces
{
    public interface ITaskValidatorBusiness : IValidator<UpsertTaskRequest>
    {
    }
}
