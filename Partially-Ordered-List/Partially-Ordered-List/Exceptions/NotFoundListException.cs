namespace Partially_Ordered_List.Exceptions
{
	public class NotFoundListException : ListException
	{
		public NotFoundListException() : base("Ошибка! Произошла ошибка при выполнении поиска элемента списка!") { }
	}
}
