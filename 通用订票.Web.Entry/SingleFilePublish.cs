using Furion;
using System.Reflection;

namespace 通用订票.Web.Entry
{
    public class SingleFilePublish : ISingleFilePublish
    {
        public Assembly[] IncludeAssemblies()
        {
            return Array.Empty<Assembly>();
        }

        public string[] IncludeAssemblyNames()
        {
            return new[]
            {
            "通用订票.Application",
            "通用订票.Core",
            "通用订票.EntityFramework.Core",
            "通用订票.Web.Core"
        };
        }
    }
}