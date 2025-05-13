using Microsoft.AspNetCore.Authorization;

namespace MyAuthApi.Requirements
{
    public class MustBeFromIndiaRequirement : IAuthorizationRequirement
    {
    }
}
