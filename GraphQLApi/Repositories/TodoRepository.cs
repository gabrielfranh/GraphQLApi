using GraphQLApi.Models;
using GraphQLApi.Models.Context;
using GraphQLApi.Repositories.Interfaces;

namespace GraphQLApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public IQueryable<Todo> GetAll()    
        {
            return _context.Tasks.AsQueryable();
        }

        public Todo GetById(Guid id)
        {
            return _context.Tasks.SingleOrDefault(x => x.Id == id);
        }

        public Todo Save(Todo todo)
        {
            if(!todo.Id.HasValue)
            {
                todo.Id = Guid.NewGuid();
                _context.Tasks.Add(todo);
            }
            
            _context.SaveChanges();

            return todo;
        }
    }
}
