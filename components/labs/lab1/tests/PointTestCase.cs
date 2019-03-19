using System;
using Lab1.Classes;
using Xunit;

namespace tests
{
	public class PointTestCase : LabTestCaseBase
	{
		private readonly Point _instance;

		public PointTestCase()
		{
			_instance = new Point();
		}

		[Fact]
		public void MoveToTest()
		{
			var expectedX = 15;
			var expectedY = 32;

			_instance.MoveTo(expectedX, expectedY);

			Equal(expectedX, _instance.X);
			Equal(expectedY, _instance.Y);
		}

		[Fact]
		public void DistanceToTest()
		{
			var anotherX = 5;
			var anotherY = 9;

			var anotherInstance  = new Point(anotherX, anotherY);
			var expectedDistance = Math.Sqrt(Math.Pow(anotherX - _instance.X, 2) + Math.Pow(anotherY - _instance.Y, 2));

			var actualDistance = _instance.DistanceTo(anotherInstance);

			Equal(expectedDistance, actualDistance);
		}
	}
}