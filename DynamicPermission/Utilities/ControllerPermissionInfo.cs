using System.Collections.Generic;

namespace DynamicPermission.Utilities
{
    public class ControllerPermissionInfo
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }
        public List<ActionPermissionInfo> Actions { get; set; }
    }
}