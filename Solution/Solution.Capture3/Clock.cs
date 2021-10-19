using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3
{
    class Clock
    {
        public int Hours { get; set; }
        public int Minutess { get; set; }
        public int Seconds { get; set; }
        public string CName { get; set; }

        public override string ToString()
        {
            return String.IsNullOrEmpty(CName) ? base.ToString() : CName + $" - {Hours} Hours: {Minutess} Minutes: {Seconds} Seconds";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            else
            {
                Clock clock = (Clock)obj;
                return clock.CName == CName;
            }
        }
        public override int GetHashCode()
        {
            return CName.GetHashCode();
        }
    }
}
