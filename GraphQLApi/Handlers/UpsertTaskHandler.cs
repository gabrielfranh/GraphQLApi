using GraphQLApi.Business.Interfaces;
using GraphQLApi.Handlers.Interfaces;
using GraphQLApi.Models;
using GraphQLApi.Repositories.Interfaces;
using GraphQLApi.Requests;
using GraphQLApi.Responses;

namespace GraphQLApi.Handlers
{
    public class UpsertTaskHandler : IUpsertTaskHandler
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ITaskValidatorBusiness _validatorBusiness;

        public UpsertTaskHandler(ITodoRepository todoRepository, ITaskValidatorBusiness validatorBusiness)
        {
            _todoRepository = todoRepository;
            _validatorBusiness = validatorBusiness;
        }

        public UpsertTaskResponse Execute(UpsertTaskRequest request)
        {
            var validatorResult = _validatorBusiness.Validate(request);

            if (!validatorResult.IsValid) 
            {
                return new UpsertTaskResponse
                {
                    Errors = validatorResult.Errors,
                };
            }

            Todo entity;

            if(request.Id.HasValue)
            {
                entity = _todoRepository.GetById(request.Id.Value);

                if (entity == null)
                    throw new Exception("Tarefa não encontrada");
            }
            else
            {
                entity = new Todo();
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Done= request.Done;

            if (entity.Done)
                entity.DoneDate = DateTime.Now;
            else
                entity.DoneDate = null;

            _todoRepository.Save(entity);

            return new UpsertTaskResponse
            {
                Payload = new UpsertTaskResponsePayload
                {
                    Id = entity.Id.Value,
                    Title = entity.Title,
                    Description = entity.Description,
                    Done = entity.Done,
                    DoneDate= entity?.DoneDate
                }
            };
        }
    }
}
