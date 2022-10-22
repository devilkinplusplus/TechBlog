using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Concrete
{
	public class User:IdentityUser<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhotoURL { get; set; }
    }
}
