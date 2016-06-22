using System;
using System.Reflection;

namespace CustomListMain
{
    [AttributeUsage(AttributeTargets.Struct 
        | AttributeTargets.Interface | AttributeTargets.Class 
        | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]
    class Version : System.Attribute
    {
        public double Ver { get; private set; }

        public Version(double ver)
        {
            this.Ver = ver;
        }

        //structures, classes, interfaces, enumerations and methods 
    }
}
