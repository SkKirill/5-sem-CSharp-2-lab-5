namespace Partially_Ordered_List.Exceptions
{
	public class OutOfRangeException : ListException
	{
		public OutOfRangeException() { }

		public OutOfRangeException(string message) : base(message) { }
	}
}
