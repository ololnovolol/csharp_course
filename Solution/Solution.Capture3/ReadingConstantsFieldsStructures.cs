using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3
{
    class ReadingConstantsFieldsStructures
    {
        public const double KOEF = 4.5;
        public readonly double field = 7.8;

        public ReadingConstantsFieldsStructures(int f)
        {
            this.field = KOEF * f;
        }
    }
}
