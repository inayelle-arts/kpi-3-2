using System;
using System.Linq;
using System.Reflection;
using System.Text;
using lab1.Attributes;
using lab1.Classes;
using lab1.Extensions;

namespace lab1
{
	public class Controller
	{
		public void ShowContructors()
		{
			Console.Write(GetCtorsInfoString(typeof(Point)));
			Console.Write(GetCtorsInfoString(typeof(Ellipse)));
		}

		public void ShowModifiers()
		{
			Console.WriteLine(typeof(Point).GetModifiersString());
			Console.WriteLine(typeof(Ellipse).GetModifiersString());
		}

		public void CallMethodsWithInvokeAttribute()
		{
			var point = new Point(10, 5);

			var type = point.GetType();

			foreach (var methodInfo in type.GetMethods().Where(m => m.GetCustomAttribute<InvokeAttribute>() != null))
			{
				methodInfo.Invoke(point, new object[0]);
			}
		}

		public void CallProxy()
		{
			try
			{
				var pointProxy = new PointProxy(new Point());
				pointProxy.X = 322;
			}
			catch (InvalidOperationException exception)
			{
				Console.WriteLine(exception.Message);
			}
		}

		private static string GetCtorsInfoString(Type type)
		{
			var sb = new StringBuilder();

			var className = type.Name;

			foreach (var constructor in type.GetConstructors())
			{
				sb.Append(className)
					.Append(GetCtorParameterString(constructor))
					.Append(Environment.NewLine);
			}

			return sb.ToString();
		}

		private static string GetCtorParameterString(ConstructorInfo cinfo)
		{
			var sb = new StringBuilder();

			sb.Append('(');

			foreach (var parameter in cinfo.GetParameters())
			{
				sb.Append(parameter.ParameterType.Name).Append(' ').Append(parameter.Name).Append(", ");
			}

			sb.Append(')');

			return sb.ToString();
		}
	}
}