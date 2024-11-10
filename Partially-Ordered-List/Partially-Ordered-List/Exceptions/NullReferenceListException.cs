namespace Partially_Ordered_List.Exceptions
{
	public class NullReferenceListException : ListException
	{
		public NullReferenceListException() : base("Ошибка! Вы пытаетесь обратиться к несуществующему значению!") { }
	}
}
