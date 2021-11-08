using DynamicPermission.PolicyProviders;
using DynamicPermission.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
// ReSharper disable UnusedMember.Global

namespace DynamicPermission.ServiceCollection
{
    public static class DynamicPermissionServices
    {
        public static IServiceCollection AddDynamicPermission(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionRequirementHandler>();
            return services;
        }
    }
}
