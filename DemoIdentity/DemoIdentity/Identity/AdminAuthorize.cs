using Microsoft.AspNetCore.Authorization;

namespace DemoIdentity.Identity
{
    public class AdminAuthorize : BaseAuthorize<AdminAuthorize>, IAuthorizationRequirement
    {
        protected override bool IsAuthorize(AuthorizationHandlerContext context, AdminAuthorize requirement)
        {
            return context.User.IsInRole("Admin");
        }
    }
}
