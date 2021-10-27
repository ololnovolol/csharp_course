using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture7
{
    class PropInModificInit
    {
        public int distanceInit { get; init; }

        private int Speed;

        public int speedy
        {
            get { return Speed; }
            init 
            {
                if (value > 0)
                {
                    Speed = value;
                }
                else
                {
                    Speed = -1;
                }
            
            }
        }


        public PropInModificInit(int distance)
        {
            distanceInit = distance;
        }

    }
}
