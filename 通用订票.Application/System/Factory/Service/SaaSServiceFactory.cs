using Furion.LinqBuilder;
using System.Reflection;
using 通用订票.Application.System.IService.Factory;

namespace 通用订票.Application.System.Factory.Service
{
    public class SaaSServiceFactory
    {
        private static Dictionary<string, object> _cacheDictionary = new Dictionary<string, object>();
        private static object _lock = new object();
        public static IServiceFactory GetServiceFactory(string tenant_id)
        {
            if (tenant_id.IsNullOrEmpty())
            {
                return LoadDefaultFactory("DefaultFacotry");
            }
            object ect = null;
            _cacheDictionary.TryGetValue(tenant_id, out ect);
            if (ect == null)
            {
                lock (_lock)
                {
                    _cacheDictionary.TryGetValue(tenant_id, out ect);
                    if (ect != null)
                    {
                        return (IServiceFactory)ect;
                    }
                    ReadAllConfigToCache();
                    _cacheDictionary.TryGetValue(tenant_id, out ect);
                    if (ect == null)
                    {
                        return LoadDefaultFactory(tenant_id);
                    }
                }
            }
            return (IServiceFactory)ect;
        }

        private static void ReadAllConfigToCache()
        {
            int index = 0;
            string section = null;
            string nameSpace = null;
            string assemblyName = null;
            string className = null;

            section = App.Configuration["SaasUserInfos:" + index.ToString() + ":Host"];
            while (section != null)
            {
                nameSpace = App.Configuration["SaasUserInfos:" + index.ToString() + ":NameSpace"];
                assemblyName = App.Configuration["SaasUserInfos:" + index.ToString() + ":AssemblyName"];
                className = App.Configuration["SaasUserInfos:" + index.ToString() + ":ClassName"];
                index++;

                string fullName = nameSpace + "." + className;//命名空间.类型名
                var ect = Assembly.Load(assemblyName).CreateInstance(fullName);
                _cacheDictionary.Add(section, ect);
                section = App.Configuration["SaasUserInfos:" + index.ToString() + ":Host"];
            }
        }
        private static IServiceFactory LoadDefaultFactory(string key)
        {
            object ect = null;
            _cacheDictionary.TryGetValue(key, out ect);
            if (ect == null)
            {
                ect = new DefaultServiceFactory();
                _cacheDictionary.Add(key, ect);
            }
            return (IServiceFactory)ect;
        }
    }
}
