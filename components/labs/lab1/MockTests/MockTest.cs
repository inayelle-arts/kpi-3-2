using System;
using Lab1;
using Lab1.Classes;
using Moq;
using Xunit;

namespace MockTests
{
	public class MockTest : Assert
	{
		public MockTest()
		{
			ViewMock = new Mock<View> { CallBase = true };
			ViewMock.Setup(x => x.WriteLine(It.IsAny<string>())).Verifiable();
		}

		protected Mock<Instantiator> InstantiatorMock => new Mock<Instantiator> { CallBase = true };

		protected Mock<View> ViewMock { get; }

		[Fact]
		public void TestCallMethodsWithInvokeAttribute()
		{
			var point = new Mock<Point>();

			var instantiator = InstantiatorMock;
			instantiator.Setup(i => i.CreatePoint()).Returns(point.Object);

			var controller = new Controller(instantiator.Object, ViewMock.Object);
			controller.CallMethodsWithInvokeAttribute();

			point.Verify(p => p.InvokeMe(), Times.Once);
			point.Verify(p => p.InvokeMeTo(), Times.Once);
		}

		[Fact]
		public void TestCallProxySetter()
		{
			var instantiator = InstantiatorMock;
			instantiator.Setup(i => i.CreateProxy()).Returns(new PointProxy(new Point(5, 5)));

			var controller = new Controller(instantiator.Object, ViewMock.Object);

			Throws<InvalidOperationException>(() => controller.CallProxy());

			instantiator.Verify(i => i.CreateProxy(), Times.Once);
			ViewMock.Verify(v => v.WriteLine(It.IsAny<string>()), Times.Once);
		}

		[Fact]
		public void TestCreateProxyWithNull()
		{
			var instantiator = InstantiatorMock;
			instantiator.Setup(i => i.CreatePoint()).Returns((Point) null);

			Throws<ArgumentNullException>(() => instantiator.Object.CreateProxy());

			instantiator.Verify(i => i.CreateProxy(), Times.Once);
		}

		[Fact]
		public void TestCreateProxyWithPointInstance()
		{
			var instantiator = InstantiatorMock;
			instantiator.Setup(i => i.CreatePoint()).Returns(new Point(1, 2));

			var proxy = instantiator.Object.CreateProxy();

			Throws<InvalidOperationException>(() => proxy.X = 1);

			instantiator.Verify(i => i.CreateProxy(), Times.Once);
		}

		[Fact]
		public void TestShowModifiers()
		{
			var controller = new Controller(InstantiatorMock.Object, ViewMock.Object);
			controller.ShowModifiers();
			
			ViewMock.Verify(v => v.WriteLine(It.IsAny<string>()), Times.Exactly(2));
		}
		
		[Fact]
		public void TestShowConstructor()
		{
			var controller = new Controller(InstantiatorMock.Object, ViewMock.Object);
			controller.ShowContructors();
			
			ViewMock.Verify(v => v.WriteLine(It.IsAny<string>()), Times.Exactly(2));
		}
	}
}