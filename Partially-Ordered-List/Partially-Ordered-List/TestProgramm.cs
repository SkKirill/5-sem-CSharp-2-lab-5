using Partially_Ordered_List.Utilites;
using System.Text;

internal class TestProgramm
{
	private static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;

		Console.WriteLine("-----------------TEST LINKEDLIST------------------");
		Partially_Ordered_List.Lists.IList<int> list = new Partially_Ordered_List.Lists.LinkedList<int>();
		TestList(ref list);

		Console.WriteLine("\n---------------TEST UNMUTBLELIST----------------");
		list = new Partially_Ordered_List.Lists.UnmutableList<int>(list);
		TestList(ref list);

		Console.WriteLine("\n----------------TEST ARRAYLIST------------------");
		list = new Partially_Ordered_List.Lists.ArrayList<int>();
		TestList(ref list);

		Console.WriteLine("\n---------------TEST LISTUTILS----------------");
		TestUtils(list);

		Console.WriteLine("\n---------------TEST TESTCLASS----------------");
		Partially_Ordered_List.Lists.IList<TestClass> newlist = new Partially_Ordered_List.Lists.LinkedList<TestClass>();

		newlist.Add(1, new TestClass() { TestField = 1} );
		newlist.Add(1, new TestClass() { TestField = 15} );
		newlist.Add(1, new TestClass() { TestField = 13} );
		newlist.Add(2, new TestClass() { TestField = 1} );
		newlist.Add(2, new TestClass() { TestField = 122} );
		newlist.Add(2, new TestClass() { TestField = 2} );

		ListUtils.ForEach(newlist, item => Console.Write(item + " "));
		Console.WriteLine();

		var current = newlist.First();
		Console.WriteLine($"Conteins {current.TestField}: " + newlist.Contains(current).ToString());
		
		newlist.Remove(current);
		Console.WriteLine($"Удаление {current.TestField}: ");
		ListUtils.ForEach(newlist, item => Console.Write(item + " "));
		Console.WriteLine();
	}

	private static void TestUtils(Partially_Ordered_List.Lists.IList<int> list)
	{
		// Проверка ForEach
		Console.Write("ForEach: ");
		ListUtils.ForEach(list, item => Console.Write(item + " "));
		Console.WriteLine();

		// Проверка Exists
		bool exists = ListUtils.Exists(list, item => item == 3);
		Console.WriteLine($"Exists (3): {exists}");

		// Проверка Find
		int foundItem = ListUtils.Find(list, item => item == 4);
		Console.WriteLine($"Find (4): {foundItem}");

		// Проверка FindLast
		int lastItem = ListUtils.FindLast(list, item => item % 2 == 0);
		Console.WriteLine($"FindLast (четные): {lastItem}");

		// Проверка FindIndex
		int index = ListUtils.FindIndex(list, item => item == 2);
		Console.WriteLine($"FindIndex (2): {index}");

		// Проверка FindAll
		var allEvens = ListUtils.FindAll(list, item => item % 2 == 0, () => new Partially_Ordered_List.Lists.ArrayList<int>());
		Console.WriteLine("FindAll (четные): " + string.Join(", ", allEvens));

		// Проверка ConvertAll
		var stringList = ListUtils.ConvertAll(list, item => item.ToString(), () => new Partially_Ordered_List.Lists.ArrayList<string>());
		Console.WriteLine("ConvertAll to strings: " + string.Join(", ", stringList));

		Console.Write("ForEach: ");
		ListUtils.ForEach(list, item => Console.Write(item + " "));
		Console.WriteLine();

		// Проверка CheckForAll
		bool allPositive = ListUtils.CheckForAll(list, item => item > 0);
		Console.WriteLine($"CheckForAll (положительные): {allPositive}");

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