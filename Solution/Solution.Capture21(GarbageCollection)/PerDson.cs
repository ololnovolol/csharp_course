using System;

namespace Solution.Capture21_GarbageCollection_
{
    public class PerDson : IDisposable
    {
        public string Name { get; }
        public PerDson(string name)
        {
            this.Name = name;
        }

        public void Dispose()
        {
            Console.WriteLine($"{Name} has been deleted about Work Dispose");
        }
    }
}
