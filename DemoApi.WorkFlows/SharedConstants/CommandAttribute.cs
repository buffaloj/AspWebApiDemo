using System;

namespace DemoApi.WorkFlows.Constants
{
    /// <summary>
    /// Apply this attribute to each command class so it can be auto-registered for dependency injection
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    sealed public class CommandAttribute : Attribute
    {
    }
}
