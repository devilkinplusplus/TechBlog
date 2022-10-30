using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class BlogCreateVM
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
