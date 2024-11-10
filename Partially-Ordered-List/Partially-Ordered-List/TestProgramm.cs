internal class TestProgramm
{
	private static void Main(string[] args)
	{
		var list = new Partially_Ordered_List.Lists.LinkedList<int>();

		// Test Add method
		Console.WriteLine("Добавляем элементы:");
		list.Add(1, 10);
		list.Add(1, 20);
		list.Add(2, 30);
		foreach (var item in list)
		{
			Console.WriteLine(item);
		}

		// Test Contains
		Console.WriteLine($"Содержит 20: {list.Contains(20)}");
		Console.WriteLine($"Содержит 50: {list.Contains(50)}");

		// Test IndexOf
		Console.WriteLine($"Индекс 20: {list.IndexOf(20)}");

		// Test Insert
		list.Insert(1, 15);
		Console.WriteLine("Список после вставки:");
		foreach (var item in list)
		{
			Console.WriteLine(item);
		}

		// Test Remove
		list.Remove(10);
		Console.WriteLine("Список после удаления 10:");
		foreach (var item in list)
		{
			Console.WriteLine(item);
		}

		// Test SubList
		var subList = list.SubList(1, 2);
		Console.WriteLine("Подсписок:");
		foreach (var item in subList)
		{
			Console.WriteLine(item);
		}

		Console.WriteLine("Все методы протестированы.");
	}
}