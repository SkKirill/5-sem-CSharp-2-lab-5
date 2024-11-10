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
├── Exceptions/
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

> Частично упорядоченный список (или частичный порядок) в программировании — это структура данных, 
> в которой элементы упорядочены не полностью, как в обычных списках, а частично. Это означает, что между 
> элементами списка могут существовать отношения порядка (например, "меньше" или "больше"), но не все 
> элементы можно однозначно сравнить друг с другом.  

> Частичный порядок чаще всего определяется при помощи реляций. Если элементы можно сравнить между собой, 
> то они находятся в отношении порядка. Если нет — они независимы друг от друга.

> Неформально можно сказать, что это отношение вводит некую иерархию элементов множества, выстраивает 
> зависимости между ними, показывает, какой элемент множества «больше», а какой «меньше». При этом 
> такое отношение вовсе не обязано быть отношением линейного порядка, т.е. не все элементы «сравнимы».

**Отличие от полного порядка:**
- Полный порядок — все элементы можно сравнить и упорядочить. Пример: сортировка чисел (1 < 2 < 3).
- Частичный порядок — не все элементы можно сравнить.  
**Пример:**  
{ 1, 2, 'a', 'b'} 
('a' < 'b'; 1 < 2) , а уже числа и буквы между собой стравнить нельзя.

> (Также про частично упорядоченные множества можно прочитать тут)[https://math.mosolymp.ru/upload/files/2024/khamovniki/10/2024-02-12-POSets-10-1.pdf]

