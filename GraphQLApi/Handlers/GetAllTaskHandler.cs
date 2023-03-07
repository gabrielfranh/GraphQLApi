using GraphQLApi.Handlers.Interfaces;
using GraphQLApi.Repositories.Interfaces;
using GraphQLApi.Responses;

namespace GraphQLApi.Handlers
{
    public class GetAllTaskHandler : IGetAllTaskHandler
    {
        private readonly ITodoRepository _todoRepository;

        public GetAllTaskHandler(ITodoRepository todoRepository)
        {
            _todoRepository= todoRepository;
        }

        public TasksResponse Execute()
        {
            var tasks = _todoRepository.GetAll()
                .Select(q => new TaskResponseItem
                {
                    Id= q.Id.Value,
                    Title = q.Title,
                    Description = q.Description,
                    Done = q.Done,
                    DoneDate = q.DoneDate,
                }).ToList();

            return new TasksResponse
            {
                Payload = tasks
            };
        }
    }
}
