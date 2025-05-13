using Microsoft.AspNetCore.Authorization;

namespace MyAuthApi.Requirements
{
    public class MustBeAdultRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; } = 18;
    }
}
