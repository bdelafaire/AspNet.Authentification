using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Authentification.Cookie.Requirements
{
    public class MinAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; private set; }

        public MinAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}
