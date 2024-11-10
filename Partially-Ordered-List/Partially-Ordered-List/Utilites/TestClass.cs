namespace Partially_Ordered_List.Utilites
{
	/// <summary>
	/// Специально созданный под тестирование класс, для проверки работы списков с более сложными структурами данных
	/// </summary>
	public class TestClass : IComparable<TestClass>
	{
		public int TestField {  get; set; }
		public TestClass()
		{
			TestField = default(int);
		}

		public TestClass(int value)
		{
			TestField = value;
		}
		public override string ToString()
		{
			return TestField.ToString();
		}
		public int CompareTo(TestClass other)
		{
			return other.TestField - TestField < 0 ? 1 : (other.TestField == TestField ? 0 : -1);
		}

		public override bool Equals(object obj)
		{
			return obj is TestClass testClass &&
				   TestField == testClass.TestField;
		}
	}
}
