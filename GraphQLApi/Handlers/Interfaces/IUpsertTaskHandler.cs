using GraphQLApi.Requests;
using GraphQLApi.Responses;

namespace GraphQLApi.Handlers.Interfaces
{
    public interface IUpsertTaskHandler
    {
        UpsertTaskResponse Execute(UpsertTaskRequest request);
    }
}
