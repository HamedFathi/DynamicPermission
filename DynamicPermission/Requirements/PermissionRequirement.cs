using System;
using Microsoft.AspNetCore.Authorization;

namespace DynamicPermission.Requirements
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(string permission)
        {
            Permission = !string.IsNullOrEmpty(permission) ? permission : throw new ArgumentNullException(nameof(permission));
        }

        public string Permission { get; }
    }
}