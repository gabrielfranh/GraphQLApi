using GraphQLApi.Models;

namespace GraphQLApi.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        public IQueryable<Todo> GetAll();

        public Todo GetById(Guid id);

        public Todo Save(Todo todo);
    }
}
