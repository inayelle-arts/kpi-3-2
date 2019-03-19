using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Lab1.Extensions;
using Lab1.Attributes;
using Lab1.Classes;

namespace Lab1
{
	public class Controller
	{
		private readonly Instantiator _instantiator;

		private readonly IView _view;

		public Controller(Instantiator instantiator, IView view)
		{
			_instantiator = instantiator;
			_view         = view;
		}

		public void ShowContructors()
		{
			_view.WriteLine(GetCtorsInfoString(typeof(Point)));
			_view.WriteLine(GetCtorsInfoString(typeof(Ellipse)));
		}

		public void ShowModifiers()
		{
			_view.WriteLine(typeof(Point).GetModifiersString());
			_view.WriteLine(typeof(Ellipse).GetModifiersString());
		}

		public void CallMethodsWithInvokeAttribute()
		{
			var point = _instantiator.CreatePoint();

			var type = point.GetType();

			var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
			                  .Where(m => m.GetCustomAttribute<InvokeAttribute>() != null);

			foreach (var methodInfo in methods)
			{
				methodInfo.Invoke(point, new object[0]);
			}
		}

		public void CallProxy()
		{
			_view.WriteLine("Calling proxy setter...");
			var pointProxy = _instantiator.CreateProxy();
			pointProxy.X = 322;
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