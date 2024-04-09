using System;

namespace DemoApi.DomainServices.Constants
{
    /// <summary>
    /// Apply this attribute to each service class so it can be auto-registered for dependency injection
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    sealed public class ServiceAttribute : Attribute
    {
    }
}
