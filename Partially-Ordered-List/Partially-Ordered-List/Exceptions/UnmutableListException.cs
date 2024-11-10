namespace Partially_Ordered_List.Exceptions
{
	public class UnmutableListException : ListException
	{
		public UnmutableListException() : base("Ошибка! Вы пытаетесь изменить неизвеняемый " +
			"список, данное действие невозможно!") { }
	}
}
