using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFinder
{
    [Serializable]
    public class CarSearchParams
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public ushort YearStart { get; set; }
        public ushort YearEnd { get; set; }
        public string EngineType { get; set; }
    }
}
