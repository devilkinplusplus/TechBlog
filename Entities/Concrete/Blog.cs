using Core.Entity;

namespace Entities.Concrete
{
    public class Blog:IEntity
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public string Description { get; set; }

    }
}