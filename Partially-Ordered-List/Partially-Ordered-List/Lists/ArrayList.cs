using System.Collections;
using Partially_Ordered_List.Exceptions;

namespace Partially_Ordered_List.Lists
{
	public class ArrayList<T> : IList<T> where T : IComparable<T>
	{
		/// <summary>
		/// Ключ словаря будет номер списка в который будем помещать значение, имитируя данным способом разные кучи с данными, которые
		/// нельзя никак между собой сравнивать.
		/// </summary>
		private Dictionary<int, T[]> _partiallyLists;

		public ArrayList()
		{
			_partiallyLists = new Dictionary<int, T[]>();
			Count = 0;
		}

		public int Count { get; set; }

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
				{
					throw new OutOfRangeListException();
				}

				int i = 0;
				foreach (var partiallyList in _partiallyLists)
				{
					if (index < i + partiallyList.Value.Length)
						return partiallyList.Value[index - i];

					i += partiallyList.Value.Length;
				}

				throw new NotFoundListException();
			}
			set
			{
				if (index < 0 || index >= Count)
				{
					throw new OutOfRangeListException();
				}

				int i = 0;
				foreach (var partiallyList in _partiallyLists)
				{
					if (index < i + partiallyList.Value.Length)
					{
						partiallyList.Value[index - i] = value;
						return;
					}
					i += partiallyList.Value.Length;
				}

				throw new NotFoundListException();
			}
		}

		public int Add(int keyPartially, T value)
		{
			if (!_partiallyLists.TryGetValue(keyPartially, out var list))
			{
				_partiallyLists[keyPartially] = new[] { value };
			}
			else
			{
				Array.Resize(ref list, list.Length + 1);
				list[^1] = value;
				_partiallyLists[keyPartially] = list;
			}
			Count++;
			return Count;
		}

		public void Clear()
		{
			_partiallyLists.Clear();
			Count = 0;
		}

		public bool Contains(T value)
		{
			foreach (var partList in _partiallyLists.Values)
			{
				foreach (var item in partList)
				{
					if (EqualityComparer<T>.Default.Equals(item, value))
						return true;
				}
			}
			return false;
		}

		public int IndexOf(T value)
		{
			int i = 0;
			foreach (var partList in _partiallyLists.Values)
			{
				for (int j = 0; j < partList.Length; j++)
				{
					if (EqualityComparer<T>.Default.Equals(partList[j], value))
						return i;
					i++;
				}
			}
			return -1;
		}

		public void Insert(int index, T value)
		{
			if (index < 0 || index >= Count)
			{
				throw new OutOfRangeListException();
			}

			int i = 0;
			foreach (var key in _partiallyLists.Keys)
			{
				T[] list = _partiallyLists[key];

				if (index < i + list.Length)
				{
					// Массив достаточно длинный, чтобы вставить элемент
					var newList = new T[list.Length + 1];
					Array.Copy(list, newList, index - i); // копируем элементы до индекса вставки
					newList[index - i] = value; // вставляем новый элемент
					Array.Copy(list, index - i, newList, index - i + 1, list.Length - (index - i)); // копируем оставшиеся элементы

					_partiallyLists[key] = newList;
					Count++;
					return;
				}

				i += list.Length;
			}
		}

		private void AddToParticallyList(ref LinkedListNode<T> particallyList, T? value)
		{
			if (value is null)
				return;

			if (particallyList.Value.CompareTo(value) == -1)
			{
				LinkedListNode<T>? newNode = new(value)
				{
					Next = particallyList
				};

				particallyList = newNode;
			}
			else
			{
				var current = particallyList;
				while (current.Next is not null && current.Next.Value.CompareTo(value) == -1)
				{
					current = current.Next;
				}

				LinkedListNode<T>? newNode = new(value)
				{
					Next = current.Next
				};

				current.Next = newNode;
			}

		}

		public void Remove(T value)
		{
			int index = IndexOf(value);
			if (index >= 0)
			{
				RemoveAt(index);
			}
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new OutOfRangeListException();
			}

			int i = 0;
			foreach (var key in _partiallyLists.Keys)
			{
				var list = _partiallyLists[key];
				if (index < i + list.Length)
				{
					var newList = new T[list.Length - 1];
					Array.Copy(list, 0, newList, 0, index - i);
					Array.Copy(list, index - i + 1, newList, index - i, list.Length - (index - i) - 1);
					_partiallyLists[key] = newList;
					Count--;
					return;
				}
				i += list.Length;
			}
		}

		public IList<T> SubList(int fromIndex, int toIndex)
		{
			if (fromIndex < 0 || toIndex >= Count || fromIndex > toIndex)
			{
				throw new OutOfRangeListException();
			}

			var subList = new LinkedList<T>();
			int i = 0;
			foreach (var partiallyList in _partiallyLists)
			{
				foreach (var item in partiallyList.Value)
				{
					if (i >= fromIndex && i <= toIndex)
						subList.Add(partiallyList.Key, item);

					i++;
					if (i > toIndex)
						break;
				}
			}
			return subList;
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (var partList in _partiallyLists.Values)
			{
				foreach (var item in partList)
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
