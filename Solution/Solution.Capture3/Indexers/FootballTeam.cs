using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3.Indexers
{
    class FootballTeam
    {
        private FootballPayer[] fPlayerS;

        public FootballTeam()
        {
            fPlayerS = new FootballPayer[11];
        }


        public FootballPayer this[int _numberOfPlayer]
        {

            get
            {
                if (_numberOfPlayer < 11 && _numberOfPlayer >= 0)
                {
                    return fPlayerS[_numberOfPlayer];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                {
                    if (_numberOfPlayer < 11 && _numberOfPlayer >= 0)
                    {
                        fPlayerS[_numberOfPlayer] = value;
                    }
                    else
                    {
                        fPlayerS[_numberOfPlayer] = null;
                    }

                }


            }
        }

        //public FootballPayer this[string _numberOfPlayer]
        //{
        //    get
        //    {
        //        return _numberOfPlayer;
        //    }
                        
        //    set
        //    {

        //    }
                                     
        //}             
    }
}
