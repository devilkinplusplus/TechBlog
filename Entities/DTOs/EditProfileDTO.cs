using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class EditProfileDTO
    {
        public int WriterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public string Email { get; set; }
    }
}
