using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public ICollection<Blog> Blog { get; set; }
    }
}
