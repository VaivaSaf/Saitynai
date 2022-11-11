using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using projektas.Auth.Model;
using System.Threading.Tasks;

namespace projektas.Auth
{
    public class ResourceOwnerAuthorizationHandler : AuthorizationHandler<ResourceOwnerRequirement, IUserOwnedResource>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOwnerRequirement requirement, IUserOwnedResource resource)
        {
            if (context.User.IsInRole(ForumRoles.Admin) || context.User.FindFirstValue(JwtRegisteredClaimNames.Sub) == resource.UserId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public record ResourceOwnerRequirement : IAuthorizationRequirement;
}
