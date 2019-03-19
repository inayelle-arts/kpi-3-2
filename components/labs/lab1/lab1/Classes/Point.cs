using System;
using Lab1.Attributes;

namespace Lab1.Classes
{
	public class Point
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point() : this(0, 0)
		{
		}

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public virtual void MoveTo(int x, int y)
		{
			X = x;
			Y = y;

			Console.WriteLine($"{nameof(Point)} movement.");
		}

		public double DistanceTo(Point another)
		{
			var part1 = Math.Pow(another.X - this.X, 2);
			var part2 = Math.Pow(another.Y - this.Y, 2);

			return Math.Sqrt(part1 + part2);
		}

		[Invoke]
		public virtual void InvokeMe()
		{
			Console.WriteLine($"Method [{nameof(InvokeMe)}] call with {nameof(InvokeAttribute)} attribute");
		}

		[Invoke]
		public virtual void InvokeMeTo()
		{
			Console.WriteLine($"Method [{nameof(InvokeMeTo)}] call with {nameof(InvokeAttribute)} attribute");
		}
	}
}