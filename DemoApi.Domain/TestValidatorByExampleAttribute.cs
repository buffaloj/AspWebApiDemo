using FluentValidation;
using System;

namespace DemoApi.Domain
{
    /// <summary>
    /// Apply this attribute to an <see cref="IValidator"/> to test it using example values from XML comments
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TestValidatorByExampleAttribute : Attribute
    {
    }
}
