﻿using System;

namespace Solution.Capture3.Intheritance
{
    abstract class Monkey
    {
        protected string _race = "not undefined";
        protected const string HI_HELLO = "agu";
        protected readonly bool speack = false;
        protected abstract void Cry();
        public abstract void Display();
    }
}
