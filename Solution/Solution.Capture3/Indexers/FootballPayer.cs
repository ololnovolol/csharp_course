namespace Solution.Capture3.Indexers
{

    //Determine the class of the footballer, which contains the footballer's name and field number.
    //And define a soccer team class that stores 11 footballers in an array and provides access to those footballers through an indexer.
    class FootballPayer
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _numberOfPlayer;

        public int numberOfPlayer
        {
            get { return _numberOfPlayer; }
            set { _numberOfPlayer = value; }
        }



    }
}
