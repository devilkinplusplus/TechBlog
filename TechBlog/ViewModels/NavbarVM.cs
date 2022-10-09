using Entities.Concrete;

namespace TechBlog.ViewModels
{
    public class NavbarVM
    {
        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }
    }
}
