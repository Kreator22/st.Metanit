//https://metanit.com/sharp/tutorial/3.12.php
//https://metanit.com/sharp/practice/2.1.php

//Напишите обобщенный класс, который может хранить в массиве объекты любого типа.
//Кроме того, данный класс должен иметь методы для добавления данных в массив, удаления из массива,
//получения элемента из массива по индексу и метод, возвращающий длину массива.
//Для упрощения работы можно пересоздавать массив при каждой операции добавления и удаления


Storage<int> storage = new Storage<int>(3);
for(int i = 0; i < 3; i++)
    storage.SetElementByIndex(i, 10 - i);
Console.WriteLine("Создали массив из трёх элементов");
storage.Print();

int index = 2;
Console.WriteLine($"Элемент номер {index + 1} = {storage.GetElementByIndex(index)}");
Console.WriteLine();

storage.AddElement(7);
Console.WriteLine("Добавили элемент");
storage.Print();

storage.AddElements([6,5]);
Console.WriteLine("Добавили ещё два элемента");
storage.Print();

storage.DeleteElementByIndex(index);
Console.WriteLine($"Удалили элемент номер {index + 1}");
storage.Print();


class Storage<T>
{
    private T[] arr;
    public Storage(int length) => arr = new T[length];

    public void AddElement(T element) 
        => arr = arr.Append<T>(element).ToArray();
    public void AddElements(IEnumerable<T> elements)
        => arr = arr.Concat<T>(elements).ToArray();
    
    public void DeleteElementByIndex(int index)
    {
        CheckIndex(index);

        IEnumerable<T> arr1 = arr.Take(index);
        IEnumerable<T> arr2 = arr.Skip(index + 1);
        arr = arr1.Concat<T>(arr2).ToArray();
    }

    public T GetElementByIndex(int index)
    {
        CheckIndex(index);
        return arr[index];
    }
    public void SetElementByIndex(int index, T element)
    {
        CheckIndex(index);
        arr[index] = element;
    }
    private void CheckIndex(int index)
    {
        if (index >= arr.Length || index < 0) throw new Exception($"Индекс должен быть в диапазоне от 0 до {arr.Length - 1}");
    }
    public int Length() => arr.Length;

    public void Print()
    {
        for (int i = 0; i < Length(); i++)
            Console.WriteLine($"{i} - {arr[i]}");
        Console.WriteLine();
    }
}