namespace Partially_Ordered_List.Exceptions
{
	public class NotFoundException : ListException
	{
		public NotFoundException() { }

		public NotFoundException(string message) : base(message) { }
	}
}
