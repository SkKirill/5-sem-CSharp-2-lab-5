namespace Partially_Ordered_List.Exceptions
{
	public class OutOfRangeListException : ListException
	{
		public OutOfRangeListException() : base("Ошибка! Указанный индекс выходит за пределы списка!") { }
	}
}
