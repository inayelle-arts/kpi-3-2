using System;

namespace Lab1.Classes
{
	public class PointProxy
	{
		private readonly Point _instance;

		public PointProxy(Point instance)
		{
			_instance = instance ?? throw new ArgumentNullException(nameof(instance));
		}

		public int X
		{
			get => _instance.X;
			set => throw new InvalidOperationException($"Invalid setter call in {nameof(X)}");
		}

		public int Y
		{
			get => _instance.Y;
			set => throw new InvalidOperationException($"Invalid setter call in {nameof(Y)}");
		}
	}
}