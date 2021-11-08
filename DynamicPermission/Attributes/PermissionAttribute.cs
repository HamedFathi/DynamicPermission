using System;
using Microsoft.AspNetCore.Authorization;

namespace DynamicPermission.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        public PermissionAttribute() { }
        public PermissionAttribute(string policy) : base(policy) { }
        public PermissionAttribute(string policy, string description) : base(policy)
        {
            Description = description;
        }
        public string Description { get; set; }
    }
}