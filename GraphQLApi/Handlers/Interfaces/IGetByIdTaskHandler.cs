using GraphQLApi.Requests;
using GraphQLApi.Responses;

namespace GraphQLApi.Handlers.Interfaces
{
    public interface IGetByIdTaskHandler
    {
        public TaskResponse Execute(GetByIdTaskRequest request);
    }
}
