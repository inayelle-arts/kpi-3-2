using System;

namespace Lab1.Classes
{
	public class View : IView
	{
		public virtual void WriteLine(string text)
		{
			Console.WriteLine(text);
		}
	}
}