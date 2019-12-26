using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Authentification.Cookie.Models
{
    // la classe user sera reconnu comme la classe gérant les rôles par identiy avec une clé primaire <int>
    public class Role : IdentityRole<int>
    {
        public static string[] Roles = new string[] { "Admin","Visiteur","Salarié","Directeur"};
    }
}
