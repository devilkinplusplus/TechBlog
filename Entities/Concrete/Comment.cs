using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int CommentId { get; set; }
        public string Message { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
