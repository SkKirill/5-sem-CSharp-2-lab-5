### Скоморохов Кирилл | 8 (900) 988-75-37 | Т-Банк | tg = @sk_kiriII | vk = sk_kirill | VisualStudio2022 | C#

> **1500₽**

# Задача 5  

**Частично упорядоченный список**  
> Разработать библиотеку обобщенных классов для работы с частично
> упорядоченными списками данных. В структуру классов входят как минимум:
``` CSharp
IList<T>: IEnumerable<T>
```
> – базовый интерфейс для всех частично упорядоченных списков;

**Методы:**
- int Add(T value);
- void Clear();
- bool Contains(T value);
- int IndexOf(T value);
- void Insert(int index, T value);
- void Remove(T value);
- void RemoveAt(int index);
- IList<T> subList(int fromIndex, int toIndex);

**Свойства:**
- int Count;
- T this[int index];

`ListException` – класс, описывающий исключения, которые могут происходить в ходе работы с частично упорядоченным списком (также можно
написать ряд наследников);  

`ArrayList<T>: IList<T>` – класс частично упорядоченного списка на основе массива;
`LinkedList<T>: IList<T>` – класс частично упорядоченного списка на основе связного списка;
`UnmutableList<T>: IList<T>` – класс частично упорядоченного неизменяющегося списка, является оберткой над любым существующим списком (должен кидаться исключениями на вызов любого метода, изменяющего список);  

`ListUtils` – класс различных операций над частично упорядоченным списком;   
**Методы:**
- static bool Exists<T>(IList<T>, CheckDelegate<T>);
- static T Find<T>(IList<T>, CheckDelegate<T>);
- static T FindLast<T>(IList<T>, CheckDelegate<T>);
- static int FindIndex<T>(IList<T>, CheckDelegate<T>);
- static int FindLastIndex<T>(IList<T>, CheckDelegate<T>);
- static IList<T> FindAll<T>(IList<T>, CheckDelegate<T>, ListConstructorDelegate<T>);
- static IList<TO> ConvertAll<TI, TO>(IList<TI>, ConvertDelegate<TI, TO>, ListConstructorDelegate<TO>);
- static void ForEach(IList<T>, ActionDelegate<T>);
- static void Sort(IList<T>, CompareDelegate<T>);
- static bool CheckForAll<T>(IList<T>, CheckDelegate<T>);

**Cвойства:**
- static readonly ListConstructorDelegate<T> ArrayListConstructor;
- static readonly ListConstructorDelegate<T> LinkedListConstructor;

> Также необходимо разработать серию примеров, демонстрирующих основные аспекты работы с данной библиотекой частично упорядоченных списков.

# Структура проекта

```
Partially-Ordered-List/
├── Lists/
│   ├── ArrayList.cs
│   ├── LinkedList.cs
│   ├── UnmuntadleList.cs
│   └── IList.cs
├── Exception/
│   ├── IsNullException.cs
│   ├── ListException.cs
│   ├── NotFoundException.cs
│   ├── UnmutableListException.cs
│   └── OutOfRangeException.cs
├── Utilites/
│   ├── TestClass.cs
│   └── ListUtils.cs
└──  TestProgram.cs
```

# Примечания 

В коде можно встретить:
```csharp
    [Obsolete("Obsolete")] 
```
Это обозначение, что данный элемент кода (класс, метод, свойство и т.д.) устарел и больше не рекомендуется к использованию.
в нашем случае это класс `BinaryFormatter` информация с [сайта Microsoft](https://learn.microsoft.com/ru-ru/dotnet/core/compatibility/serialization/8.0/binaryformatter-disabled)  
> В .NET 7 BinaryFormatter.Serialize(Stream, Object)BinaryFormatter.Deserialize(Stream) методы помечены как устаревшие и вызвали ошибку во время компиляции. Тем не менее, если приложение подавляло обнажение, оно по-прежнему может вызывать методы, и они работают правильно в большинстве типов проектов (за исключением ASP.NET, WASM и MAUI).
> Начиная с .NET 8 затронутые методы создаются NotSupportedException во время выполнения во всех типах проектов, 
> > **кроме Windows Forms и WPF.**  

Поэтому в приложениях с WinForm мы просто ставим аннотацию.





Частично упорядоченный список (или частичный порядок) в программировании — это структура данных, 
в которой элементы упорядочены не полностью, как в обычных списках, а частично. Это означает, что между 
элементами списка могут существовать отношения порядка 
(например, "меньше" или "больше"), но не все элементы можно однозначно сравнить друг с другом.  

Частичный порядок чаще всего определяется при помощи реляций. Если элементы можно сравнить между собой, 
то они находятся в отношении порядка. Если нет — они независимы друг от друга.


Отличие от полного порядка:
- Полный порядок — все элементы можно сравнить и упорядочить. Пример: сортировка чисел (1 < 2 < 3).
- Частичный порядок — не все элементы можно сравнить. Пример: дерево зависимостей.