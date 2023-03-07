using GraphQLApi.Handlers.Interfaces;
using GraphQLApi.Requests;
using GraphQLApi.Responses;

namespace GraphQLApi
{
    public class Mutations
    {
        public UpsertTaskResponse UpsertTask([Service] IUpsertTaskHandler handler, UpsertTaskRequest request)
        {
            return handler.Execute(request);
        }
    }
}
