using GraphQLApi.Handlers.Interfaces;
using GraphQLApi.Repositories.Interfaces;
using GraphQLApi.Requests;
using GraphQLApi.Responses;

namespace GraphQLApi.Handlers
{
    public class GetByIdTaskHandler : IGetByIdTaskHandler
    {
        private readonly ITodoRepository _todoRepository;

        public GetByIdTaskHandler(ITodoRepository todoRepository)
        {
            _todoRepository= todoRepository;
        }

        public TaskResponse Execute(GetByIdTaskRequest request)
        {
            var task = _todoRepository.GetById(request.Id);

            if (task == null)
                throw new Exception("Tarefa não encontrada");

            return new TaskResponse
            {
                Payload = new TaskResponseItem
                {
                    Id = task.Id.Value,
                    Title = task.Title,
                    Description = task.Description,
                    Done = task.Done,
                    DoneDate = task.DoneDate,
                }
            };
        }
    }
}
