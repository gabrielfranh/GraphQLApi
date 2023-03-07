using GraphQLApi.Requests;
using GraphQLApi.Responses;

namespace GraphQLApi.Handlers.Interfaces
{
    public interface IGetAllTaskHandler
    {
        TasksResponse Execute();
    }
}
