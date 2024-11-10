namespace Partially_Ordered_List.Exceptions
{
	public class IsNullException : ListException
	{
		public IsNullException() { }

		public IsNullException(string message) : base(message) { }
	}
}
