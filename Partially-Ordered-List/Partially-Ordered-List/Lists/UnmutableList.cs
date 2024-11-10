using Partially_Ordered_List.Exceptions;
using System.Collections;

namespace Partially_Ordered_List.Lists
{
	public class UnmutableList<T> : IList<T>
	{
		private readonly IList<T> innerList;

		public UnmutableList(IList<T> list) => innerList = list;
		public int Add(T value) => throw new UnmutableListException();
		public void Clear() => throw new UnmutableListException();
		public bool Contains(T value) => innerList.Contains(value);
		public int IndexOf(T value) => innerList.IndexOf(value);
		public void Insert(int index, T value) => throw new UnmutableListException();
		public void Remove(T value) => throw new UnmutableListException();
		public void RemoveAt(int index) => throw new UnmutableListException();
		public IList<T> SubList(int fromIndex, int toIndex) => innerList.SubList(fromIndex, toIndex);

		public int Count => innerList.Count;
		public T this[int index]
		{
			get => innerList[index];
			set => throw new UnmutableListException();
		}

		public IEnumerator<T> GetEnumerator() => innerList.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
