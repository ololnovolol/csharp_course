using System;

namespace Solution.Capture3.OperatorOverloading
{
    class State
    {
        private decimal _population;
        public decimal population
        {
            get { return _population; }
            set { _population = value; }
        }

        private decimal _area;
        public decimal area
        {
            get { return _area; }
            set { _area = value; }
        }

        public static State operator + (State state1, State state2)
        {
            return new State
            {
                _population = state1._population + state2._population,
                _area = state1._area + state2._area
            };
        }
        public static bool operator > (State state1, State state2)
        {
            return state1._area > state2._area;
        }

        public static bool operator < (State state1, State state2)
        {
            return state1._area < state2._area;
        }
    }
}
