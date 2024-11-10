using Partially_Ordered_List.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace Partially_Ordered_List.Lists
{
	public class LinkedList<T> : IList<T> where T : IComparable<T>
	{
		/// <summary>
		/// Ключ словаря будет номер списка в который будем помещать значение, имитируя данным способом разные кучи с данными, которые
		/// нельзя никак между собой сравнивать.
		/// </summary>
		private Dictionary<int, LinkedListNode<T>> _partiallyLists;

		public LinkedList()
		{
			_partiallyLists = [];
			Count = 0;
		}

		public int Count { get; set; }

		public T this[int index]
		{
			get
			{
				if (index <= 0 || index > Count)
				{
					throw new IndexOutOfRangeException("индекс находится за пределами допустимого значения");
				}

				var i = 0;
				foreach (var partiallyList in _partiallyLists)
				{
					LinkedListNode<T>? current = partiallyList.Value;
					for (; i < index; i++) 
					{
						if (current == null)
							break;
						
						current = current.Next;
					}

					if (i != index)
						continue;

					if (current == null)
						throw new NullReferenceListException();

					return current.Value;
				}
				
				throw new NotFoundListException();
			}
			set 
			{
				if (index < 0 || index > Count)
				{
					throw new OutOfRangeListException();
				}

				var i = 0;
				foreach (var partiallyList in _partiallyLists)
				{
					LinkedListNode<T>? current = partiallyList.Value;
					for (; i < index; i++)
					{
						if (current == null)
							break;

						current = current.Next;
					}

					if (i != index)
						continue;

					if (current == null)
						throw new NullReferenceListException();

					current.Value = value;
					return;
				}

				throw new NotFoundListException();
			}
		}

		public int Add(int keyPartially, T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(value);
			if (_partiallyLists[keyPartially] is null)
			{
				_partiallyLists[keyPartially] = newNode;
			}
			else
			{
				var current = _partiallyLists[keyPartially];
				while (current.Next != null)
				{
					current = current.Next;
				}

				current.Next = newNode;
				newNode.Next = null;
			}
			Count++;
			return Count;
		}

		public void Clear()
		{
			_partiallyLists?.Clear();
			Count = 0;
		}

		public bool Contains(T value)
		{ 
			foreach (var particallyList in _partiallyLists)
			{
				LinkedListNode<T>? current = particallyList.Value;
				while (current != null)
				{
					if (Equals(current.Value, value))
					{
						return true;
					}
					current = current.Next;
				}
			}
			return false;
		}

		public int IndexOf(T value)
		{
			int i = 0;
			foreach (var particallyList in _partiallyLists)
			{
				LinkedListNode<T>? current = particallyList.Value;
				for (; i < Count; i++)
				{
					if (current == null)
						break;

					if (Equals(current.Value, value))
						return i;

					current = current.Next;
				}
			}

			return -1;
		}

		public void Insert(int index, T value)
		{
			if (index <= 0 || index > Count)
			{
				throw new OutOfRangeListException();
			}

			int i = 0;
			LinkedListNode<T>? current = null;
			foreach (var particallyList in _partiallyLists)
			{
				current = particallyList.Value;
				for (; i < Count; i++)
				{
					if (current == null)
						break;

					current = current.Next;
				}

				if (i == index)
					break;
			}

			if (current is null)
				throw new NullReferenceListException();

			AddToParticallyList(ref current, value);
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
			var first = false;
			foreach (var particallyList in _partiallyLists)
			{
				LinkedListNode<T>? linkedListNode = particallyList.Value;
				for (; i < index; i++)
				{
					if (linkedListNode is null)
						break;

					linkedListNode = linkedListNode.Next;
				}

				if (i != index)
					continue;

				if (!first && linkedListNode?.Next is null)
				{
					first = true;
					continue;
				}

				if (first)
				{
					_partiallyLists[particallyList.Key] = particallyList.Value.Next!;
				}
				else
				{
					linkedListNode = linkedListNode?.Next;
				}

				Count--;
				return;
			}
		}

		public IList<T> SubList(int fromIndex, int toIndex)
		{
			if (fromIndex <= 0 || toIndex > Count || fromIndex > toIndex)
			{
				throw new OutOfRangeListException();
			}

			var subList = new LinkedList<T>();
			int i = 0;
			foreach(var particallyList in _partiallyLists) 
			{
				LinkedListNode<T> current = particallyList.Value;
				for (; i <= toIndex; i++)
				{
					if (current is null)
						break;

					if (i >= fromIndex)
					{
						subList.Add(particallyList.Key, current.Value);
					}

					current = current.Next!;
				}
			}
			return subList;
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (var item in _partiallyLists.Values)
			{
				LinkedListNode<T>? current = item;
				while (current != null)
				{
					yield return current.Value;
					current = current.Next;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
