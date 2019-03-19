namespace Lab1.Classes
{
	public class Instantiator
	{
		public virtual Point CreatePoint()
		{
			return new Point(10, 5);
		}

		public virtual Ellipse CreateEllipse()
		{
			return new Ellipse(1,2,3.1,1.3);
		}

		public virtual PointProxy CreateProxy()
		{
			return new PointProxy(CreatePoint());
		}
	}
}