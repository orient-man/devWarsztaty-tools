using System;

namespace NCrunch.Framework
{
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = true)]
    public class RequiresCapabilityAttribute : Attribute
    {
        public string CapabilityName { get; private set; }

        public RequiresCapabilityAttribute(string capabilityName)
        {
            this.CapabilityName = capabilityName;
        }
    }
}