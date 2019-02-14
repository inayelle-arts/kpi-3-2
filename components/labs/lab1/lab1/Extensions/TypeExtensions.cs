using System;

namespace lab1.Extensions
{
	public static class TypeExtensions
	{
		public static string GetModifiersString(this Type type)
		{
			return String.Format("{0} has {1}", type.Name, type.Attributes.ToString());
		}
	}
}