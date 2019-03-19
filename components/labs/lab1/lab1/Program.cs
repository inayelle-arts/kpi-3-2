using System;
using Lab1.Classes;

namespace Lab1
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var controller = new Controller(new Instantiator(), new View());

			Console.ForegroundColor = ConsoleColor.Red;
			controller.ShowContructors();
			
			Console.ForegroundColor = ConsoleColor.Magenta;
			controller.ShowModifiers();
			
			Console.ForegroundColor = ConsoleColor.Green;
			controller.CallMethodsWithInvokeAttribute();
			
			Console.ForegroundColor = ConsoleColor.Blue;
			try
			{
				controller.CallProxy();
			}
			catch (InvalidOperationException exception)
			{
				Console.WriteLine(exception.Message);
			}
		}
	}
}