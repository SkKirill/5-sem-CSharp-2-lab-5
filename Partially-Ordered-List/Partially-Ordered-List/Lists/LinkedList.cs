using System.Collections;

namespace Partially_Ordered_List.Lists
{
	public class LinkedList<T> : IList<T>
	{
		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
