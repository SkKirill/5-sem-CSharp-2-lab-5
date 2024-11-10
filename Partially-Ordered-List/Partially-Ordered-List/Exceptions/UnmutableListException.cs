namespace Partially_Ordered_List.Exceptions
{
	public class UnmutableListException : ListException
	{
		public UnmutableListException() { }

		public UnmutableListException(string message) : base(message) { }
	}
}
