using System;
using System.Collections.Generic;

namespace DynamicPermission.Utilities
{
    public class ControllerInfo
    {
        public string Namespace { get; set; }
        public string AreaName { get; set; }
        public string Name { get; set; }
        public ICollection<Attribute> Attributes { get; set; }
        public ICollection<ActionInfo> Actions { get; set; }

    }
}