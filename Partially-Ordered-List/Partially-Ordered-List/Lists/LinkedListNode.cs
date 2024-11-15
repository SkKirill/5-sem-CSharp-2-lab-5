﻿namespace Partially_Ordered_List.Lists
{
	public class LinkedListNode<T> : object
	{
		public T Value { get; set; }
		public LinkedListNode<T>? Next { get; set; }

		public LinkedListNode(T value)
		{
			Value = value;
			Next = null;
		}
	}
}
