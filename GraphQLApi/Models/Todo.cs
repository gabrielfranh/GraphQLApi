namespace GraphQLApi.Models
{
    public class Todo
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        public DateTime? DoneDate { get; set; }
    }
}
