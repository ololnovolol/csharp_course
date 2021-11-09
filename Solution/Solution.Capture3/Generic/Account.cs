using System;
namespace Solution.Capture3.Generic
{
    internal class Account : IAcount
    {
        public int Id { get; set; }
        public int CurrentSum { get; set; }
        //public int CurrentSum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Account(int _id)
        {
            Id = _id;
        }
    }
}
