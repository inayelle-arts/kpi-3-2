using System;

namespace lab1.Classes
{
	public class PointProxy
	{
		private readonly Point _instance;

		public PointProxy(Point instance)
		{
			if (instance is null)
			{
				throw new ArgumentNullException(nameof(instance));
			}
			
			_instance = instance;
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