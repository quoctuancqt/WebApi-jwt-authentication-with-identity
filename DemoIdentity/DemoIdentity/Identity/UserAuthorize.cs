using Microsoft.AspNetCore.Authorization;

namespace DemoIdentity.Identity
{
    public class UserAuthorize : BaseAuthorize<UserAuthorize>, IAuthorizationRequirement
    {
        protected override bool IsAuthorize(AuthorizationHandlerContext context, UserAuthorize requirement)
        {
            return context.User.IsInRole("User");
        }
    }
}
