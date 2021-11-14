using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Engine.Extension
{
    public static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var o in list)
            {
                action(o);
            }
        }
    }
}
