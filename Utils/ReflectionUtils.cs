using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utils
{
    //should not be static but injectable
    public static class ReflectionUtils
    {
        public static Type GetClass(Assembly assembly, string className)
        {
            return assembly.GetTypes().Single(c => c.Name == className);
        }
        public static Assembly GetAssembly(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(a => a.FullName.Split(",")[0] == name);
        }
        public static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
