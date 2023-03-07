namespace GraphQLApi.Responses
{
    public class TaskResponseItem
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        public DateTime? DoneDate { get; set; }
    }
}
