namespace Solution.Capture7
{
    class PropInModificInit
    {
        public int distanceInit { get; init; }
        private int Speed;
        public int Speedy
        {
            get { return Speed; }
            init
            {
                Speed = value > 0 ? value : -1;
            }
        }
        public PropInModificInit(int distance)
        {
            distanceInit = distance;
        }

    }
}
