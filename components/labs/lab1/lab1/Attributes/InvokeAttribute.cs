using System;

namespace Lab1.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class InvokeAttribute : Attribute
	{
		
	}
}