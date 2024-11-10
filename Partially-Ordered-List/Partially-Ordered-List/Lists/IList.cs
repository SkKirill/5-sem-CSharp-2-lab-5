namespace Partially_Ordered_List.Lists
{
	public interface IList<T> : IEnumerable<T>
	{
		/// <summary>
		/// Метод, добавляющий новое значение в список.
		/// </summary>
		/// <param name="keyPartially">Значение ключа, с помощью которого определяется часть в которую нужно 
		/// вставить упорядочено значение.</param>
		/// <param name="value">Значение, которое требуется вставить в список.</param>
		/// <returns>Возвращает число - индекс места вставки в списке.</returns>
		int Add(int keyPartially, T value);

		/// <summary>
		/// Метод, который приводит список к изначальному состоянию. Полная очистка.
		/// </summary>
		void Clear();

		/// <summary>
		/// Метод, проверяющий вхождение значения в список.
		/// </summary>
		/// <param name="value"> Значение, которое требуется проверить на вхождение.</param>
		/// <returns>true - значение присутствует, false - значения в списке нет.</returns>
		bool Contains(T value);

		/// <summary>
		/// Метод, с помощью которого можно найти индекс элемента в списке по значению.
		/// </summary>
		/// <param name="value"> Значение, индекс которого мы пытаемся найти.</param>
		/// <returns> При получении -1 понимаем, что индекс не найден. Любое другое возвращаемое 
		/// значение является индексом.</returns>
		int IndexOf(T value);

		/// <summary>
		/// Метод, позволяющий вставить элемент в список, после заданного индекса.
		/// </summary>
		/// <param name="value">Значение, которое требуется вставить в список.</param>
		/// <param name="index">Индекс значения после которого требуется вставить элемент.</param>
		void Insert(int index, T value);

		/// <summary>
		/// Метод удаляет заданный элемент.
		/// </summary>
		/// <param name="value">Элемент, который требуется удалить.</param>
		void Remove(T value);

		/// <summary>
		/// Метод, позволяющий удалить элемент по заданному индексу.
		/// </summary>
		/// <param name="index">Индекс элемента требуемого к удалению.</param>
		void RemoveAt(int index);

		/// <summary>
		/// Возвращает подсписок, состоящий из элементов с индексами от fromIndex до toIndex
		/// </summary>
		/// <param name="fromIndex">Начальный индекс подсписка.</param>
		/// <param name="toIndex">Конечный индекс подсписка.</param>
		/// <returns>Возвращается список из элементов.</returns>
		IList<T> SubList(int fromIndex, int toIndex);

		/// <summary>
		/// Количество элементов в списке.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Управление элементом по заданному индексу.
		/// </summary>
		/// <param name="index">Индекс элемента.</param>
		/// <returns>Возвращает элемент для работы с ним или изменения.</returns>
		T this[int index] { get; set; }
	}
}
