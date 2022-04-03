﻿namespace Solution.Capture3.OperatorOverloading
{
    class Butter
    {
        public int Weight { get; set; }
        public static Sandwich operator +(Bread bread, Butter butter) => new Sandwich { Weight = bread.Weight + butter.Weight };
        public static Sandwich operator -(Bread bread, Butter butter) => new Sandwich { Weight = bread.Weight + butter.Weight };
    }
}
