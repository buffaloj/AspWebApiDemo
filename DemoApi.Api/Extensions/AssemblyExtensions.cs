using System.Reflection;

namespace DemoApi.Api.Extensions
{
    /// <summary>
    /// Class of extensions for Assembly
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Returns a path to XML file for Assembly, if there is one
        /// </summary>
        /// <param name="assembly">The assembly to get XML comments for</param>
        /// <returns>A full path to the XML file</returns>
        public static string ToXmlPath(this Assembly assembly)
        {
            var basePath = AppContext.BaseDirectory;
            var fileName = assembly.GetName().Name + ".xml";
            return Path.Combine(basePath, fileName);
        }
    }
}
