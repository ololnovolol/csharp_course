using System;

namespace Solution.Capture7
{
    public record Car
    {
        public int speed { get; init; }
        public string name { get; init; }
        public void Drive()
        {
            Console.WriteLine($"car {name} move with speed {speed}");
        }
        public void Deconstruct(out int speed, out string name) => (speed, name) = (this.speed, this.name);
    }
}
