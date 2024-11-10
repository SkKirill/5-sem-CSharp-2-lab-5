using System.Collections;
using Partially_Ordered_List.Exceptions;

namespace Partially_Ordered_List.Lists
{
	public class ArrayList<T> : IList<T>
	{
		private T[] items;
		private int count;

		public ArrayList(int capacity = 10)
		{
			items = new T[capacity];
			count = 0;
		}

		public int Add(T value)
		{
			if (count >= items.Length) Array.Resize(ref items, items.Length * 2);
			items[count] = value;
			return count++;
		}

		public void Clear()
		{
			items = new T[items.Length];
			count = 0;
		}

		public bool Contains(T value) => IndexOf(value) != -1;

		public int IndexOf(T value)
		{
			for (int i = 0; i < count; i++)
				if (items[i]?.Equals(value) ?? value == null)
					return i;
			return -1;
		}

		public void Insert(int index, T value)
		{
			if (index < 0 || index > count) throw new OutOfRangeListException();
			if (count >= items.Length) Array.Resize(ref items, items.Length * 2);
			Array.Copy(items, index, items, index + 1, count - index);
			items[index] = value;
			count++;
		}

		public void Remove(T value)
		{
			int index = IndexOf(value);
			if (index == -1) throw new NotFoundListException();
			RemoveAt(index);
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= count) throw new OutOfRangeListException();
			Array.Copy(items, index + 1, items, index, count - index - 1);
			count--;
		}

		public IList<T> SubList(int fromIndex, int toIndex)
		{
			if (fromIndex < 0 || toIndex > count || fromIndex > toIndex)
				throw new OutOfRangeListException();

			var subList = new ArrayList<T>(toIndex - fromIndex);
			for (int i = fromIndex; i < toIndex; i++)
				subList.Add(items[i]);
			return subList;
		}

		public int Count => count;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= count) throw new OutOfRangeListException();
				return items[index];
			}
			set
			{
				if (index < 0 || index >= count) throw new OutOfRangeListException();
				items[index] = value;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < count; i++) yield return items[i];
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
