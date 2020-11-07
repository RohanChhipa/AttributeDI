using System;
using Microsoft.Extensions.DependencyInjection;

namespace Lib
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class InjectionComponentAttribute : Attribute
    {
        public Type ParentType { get; set; }
        public ServiceLifetime ServiceLifetime { get; set; }

        public InjectionComponentAttribute()
        {
            ParentType = null;
            ServiceLifetime = ServiceLifetime.Scoped;
        }
    }
}