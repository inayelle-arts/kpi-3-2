using System;

namespace Lab1.Classes
{
	public class Ellipse : Point
	{
		public double VerticalAxis { get; set; }

		public double HorizontalAxis { get; set; }

		public Ellipse(int x, int y, double verticalAxis, double horizontalAxis) : base(x, y)
		{
			VerticalAxis   = verticalAxis;
			HorizontalAxis = horizontalAxis;
		}

		public override void MoveTo(int x, int y)
		{
			X = x;
			Y = y;

			Console.WriteLine($"{nameof(Ellipse)} movement.");
		}
	}
}