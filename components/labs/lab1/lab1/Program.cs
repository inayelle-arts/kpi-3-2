using System;

namespace lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			var controller = new Controller();

			Console.ForegroundColor = ConsoleColor.Red;
			controller.ShowContructors();
			
			Console.ForegroundColor = ConsoleColor.Magenta;
			controller.ShowModifiers();
			
			Console.ForegroundColor = ConsoleColor.Green;
			controller.CallMethodsWithInvokeAttribute();
			
			Console.ForegroundColor = ConsoleColor.Blue;
			controller.CallProxy();
		}
	}
}