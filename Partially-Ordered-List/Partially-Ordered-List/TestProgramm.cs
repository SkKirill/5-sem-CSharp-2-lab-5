using System.Text;

internal class TestProgramm
{
	private static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;


		Console.WriteLine("-----------------TEST LINKEDLIST------------------");
		Partially_Ordered_List.Lists.IList<int> list = new Partially_Ordered_List.Lists.LinkedList<int>();
		TestList(ref list);

		Console.WriteLine("\n----------------TEST ARRAYLIST------------------");
		list = new Partially_Ordered_List.Lists.ArrayList<int>();
		TestList(ref list);

		Console.WriteLine("\n---------------TEST UNMUTBLELIST----------------");
		list = new Partially_Ordered_List.Lists.UnmutableList<int>(list);
		TestList(ref list);


	}

	private static void TestList(ref Partially_Ordered_List.Lists.IList<int> list)
	{
		// Test Add method
		try
		{
			Console.WriteLine("Добавляем элементы:");
			list.Add(1, 10);
			list.Add(1, 21);
			list.Add(2, 18);
			list.Add(1, 3);
			list.Add(1, 18);
			list.Add(2, 30);

			foreach (var item in list)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		// Test Contains
		try
		{
			Console.WriteLine($"Содержит 21: {list.Contains(21)}");
			Console.WriteLine($"Содержит 50: {list.Contains(50)}");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		// Test IndexOf
		try
		{
			Console.WriteLine($"Индекс 3: {list.IndexOf(3)}");
			Console.WriteLine($"Индекс 20: {list.IndexOf(20)}");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		// Test Insert
		try
		{
			list.Insert(1, 15);
			Console.WriteLine("Список после вставки 15:");
			foreach (var item in list)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		// Test Remove (Использует внутри себя RemoveAt поэтому тестим только такой ремув)
		try
		{
			list.Remove(10);
			Console.WriteLine("Список после удаления 10:");
			foreach (var item in list)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		// Test SubList
		try
		{
			var subList = list.SubList(1, 2);
			Console.WriteLine("Подсписок от 1 до 2:");
			foreach (var item in subList)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		Console.WriteLine($"Все методы протестированы для класса {list}");
	}
}