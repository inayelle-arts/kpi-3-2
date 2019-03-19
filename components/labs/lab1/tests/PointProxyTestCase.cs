using System;
using Lab1.Classes;
using Xunit;

namespace tests
{
	public class PointProxyTestCase : LabTestCaseBase
	{
		[Fact]
		public void CtorNullInstanceTest()
		{
			Throws<ArgumentNullException>(() => new PointProxy(null));
		}

		[Fact]
		public void ForbiddenSettersTest()
		{
			var instance = new PointProxy(new Point());

			Throws<InvalidOperationException>(() => { instance.X = 322; });
			Throws<InvalidOperationException>(() => { instance.Y = 322; });
		}
	}
}