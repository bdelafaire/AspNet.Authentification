using AspNet.Authentification.Cookie.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Authentification.Cookie.Handlers
{
    public class MinAgeHandler : AuthorizationHandler<MinAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Age"))
            {
                return Task.CompletedTask;
            }

            var age = int.Parse(
                context.User.Claims.First(claim => claim.Type == "Age").Value
            );

            if (age >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
