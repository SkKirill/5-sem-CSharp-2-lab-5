using Partially_Ordered_List.Lists;

namespace Partially_Ordered_List.Utilites
{
	public delegate bool CheckDelegate<T>(T item);
	public delegate void ActionDelegate<T>(T item);
	public delegate int CompareDelegate<T>(T x, T y);
	public delegate TResult ConvertDelegate<TInput, TResult>(TInput item);
	public delegate Lists.IList<T> ListConstructorDelegate<T>();

	
	public static class ListUtils
	{
		public static bool Exists<T>(Lists.IList<T> list, CheckDelegate<T> match) =>
			list.Any(item => match(item));

		public static T Find<T>(Lists.IList<T> list, CheckDelegate<T> match) =>
			list.FirstOrDefault(item => match(item));

		public static T FindLast<T>(Lists.IList<T> list, CheckDelegate<T> match) =>
			list.LastOrDefault(item => match(item));

		public static int FindIndex<T>(Lists.IList<T> list, CheckDelegate<T> match)
		{
			for (int i = 0; i < list.Count; i++)
				if (match(list[i])) return i;
			return -1;
		}

		public static int FindLastIndex<T>(Lists.IList<T> list, CheckDelegate<T> match)
		{
			for (int i = list.Count - 1; i >= 0; i--)
				if (match(list[i])) return i;
			return -1;
		}

		public static Lists.IList<T> FindAll<T>(Lists.IList<T> list, CheckDelegate<T> match, ListConstructorDelegate<T> constructor)
		{
			var result = constructor();
			foreach (var item in list)
				if (match(item)) 
					result.Add(1, item);
			return result;
		}

		public static Lists.IList<TO> ConvertAll<TI, TO>(Lists.IList<TI> list, ConvertDelegate<TI, TO> convertDelegate, ListConstructorDelegate<TO> listConstructorDelegate)
		{
			var result = listConstructorDelegate();
			foreach (var item in list)
				result.Add(1, convertDelegate(item));

			return result;
		}

		public static void ForEach<T>(Lists.IList<T> list, ActionDelegate<T> actionDelegate)
		{
			foreach (T item in list)
			{
				actionDelegate(item);
			}
		}

		public static bool CheckForAll<T>(Lists.IList<T> list, CheckDelegate<T> checkDelegate)
		{
			foreach (T item in list)
			{
				if (!checkDelegate(item))
				{
					return false;
				}
			}
			return true;
		}
	}
}

