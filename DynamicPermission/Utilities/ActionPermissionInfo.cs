using System.Collections.Generic;

namespace DynamicPermission.Utilities
{
    public class ActionPermissionInfo
    {
        public string Name { get; set; }
        public List<PermissionInfo> Permissions { get; set; }
    }
}