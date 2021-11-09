
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
                return _numberOfPlayer < 11 && _numberOfPlayer >= 0 ? fPlayerS[_numberOfPlayer] : null;
            }
            set
            {
                {
                    fPlayerS[_numberOfPlayer] = _numberOfPlayer < 11 && _numberOfPlayer >= 0 ? value : null;
                }
            }
        }
    }
}
