using GraphQLApi.Handlers.Interfaces;
using GraphQLApi.Requests;
using GraphQLApi.Responses;

namespace GraphQLApi
{
    public class Query
    {
        public TasksResponse GetTasks([Service] IGetAllTaskHandler handler)
        {
            return handler.Execute();
        }

        public TaskResponse GetTask([Service] IGetByIdTaskHandler handler, GetByIdTaskRequest request)
        {
            return handler.Execute(request);
        }
    }
}
