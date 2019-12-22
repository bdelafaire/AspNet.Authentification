using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Authentification.Cookie.Models
{
    // la classe user sera reconnu comme la classe user par identiy avec une clé primaire <int>
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
