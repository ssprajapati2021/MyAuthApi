using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MyAuthApi.Requirements
{
    public class CompositeRequirementHandler : AuthorizationHandler<CompositeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CompositeRequirement requirement)
        {
            var dob = context.User.FindFirst(ClaimTypes.DateOfBirth)?.Value;
            var country = context.User.FindFirst(ClaimTypes.Country)?.Value;

            if (dob == null || country == null)
            {
                Console.WriteLine("Missing claims:");
                foreach (var c in context.User.Claims)
                {
                    Console.WriteLine($"{c.Type} = {c.Value}");
                }
                return Task.CompletedTask;
            }

            var age = DateTime.Today.Year - DateTime.Parse(dob).Year;
            if (age >= 18 && country == "India")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
