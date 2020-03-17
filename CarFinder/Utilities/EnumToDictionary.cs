using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFinder.Utilities
{
    public static class EnumToDictionary
    {
       public static Dictionary<string, string> EnumToDict(this Enum value)
        {
            return Enum.GetValues(value.GetType()).Cast<string>().ToDictionary(e => e, e => Enum.GetName(value.GetType(), e));
        }
    }
}