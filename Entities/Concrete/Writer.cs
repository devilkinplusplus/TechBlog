using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Writer:IEntity
    {
        public int WriterId { get; set; }
        public string Name { get; set; }
        public ICollection<Blog> Blog { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
