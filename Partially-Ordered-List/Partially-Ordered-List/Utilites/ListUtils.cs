using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partially_Ordered_List.Utilites
{
	public delegate bool CheckDelegate<T>(T item);
	public delegate TResult ConvertDelegate<TInput, TResult>(TInput item);
	public delegate IList<T> ListConstructorDelegate<T>();

	public static class ListUtils
	{
		public static bool Exists<T>(IList<T> list, CheckDelegate<T> match) =>
			list.Any(item => match(item));

		public static T Find<T>(IList<T> list, CheckDelegate<T> match) =>
			list.FirstOrDefault(item => match(item));

		public static T FindLast<T>(IList<T> list, CheckDelegate<T> match) =>
			list.LastOrDefault(item => match(item));

		public static int FindIndex<T>(IList<T> list, CheckDelegate<T> match)
		{
			for (int i = 0; i < list.Count; i++)
				if (match(list[i])) return i;
			return -1;
		}

		public static int FindLastIndex<T>(IList<T> list, CheckDelegate<T> match)
		{
			for (int i = list.Count - 1; i >= 0; i--)
				if (match(list[i])) return i;
			return -1;
		}

		public static IList<T> FindAll<T>(IList<T> list, CheckDelegate<T> match, ListConstructorDelegate<T> constructor)
		{
			var result = constructor();
			foreach (var item in list)
				if (match(item)) result.Add(item);
			return result;
		}
	}
}
