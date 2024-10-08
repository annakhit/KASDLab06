using System;

internal class MyVector<T>
{
    private T[] elementData;
    private int elementCount;
    private readonly int capacityIncrement;

    public MyVector(int initialCapacity, int capacityIncrement)
    {
        elementData = new T[initialCapacity];
        elementCount = initialCapacity;
        this.capacityIncrement = capacityIncrement;
    }
    public MyVector(int initialCapacity)
    {
        elementData = new T[initialCapacity];
        elementCount = 0;
        capacityIncrement = 0;
    }
    public MyVector()
    {
        elementData = new T[10];
        elementCount = 0;
        capacityIncrement = 0;
    }
    public MyVector(T[] array)
    {
        elementData = (T[])array.Clone();
        elementCount = array.Length;
        capacityIncrement = 0;
    }

    public void AddElement(T element)
    {
        if (elementCount == elementData.Length)
        {
            int increment = capacityIncrement == 0 ? elementData.Length : capacityIncrement;
            T[] newArray = new T[elementCount + increment];
            for (int i = 0; i < elementCount; i++) newArray[i] = elementData[i];
            elementData = newArray;
        }
        elementData[elementCount] = element;
        elementCount++;
    }
    public void AddAll(params T[] array)
    {
        foreach (T element in array) AddElement(element);
    }

    public void Clear()
    {
        elementData = new T[0];
        elementCount = 0;
    }

    public bool Contains(object obj)
    {
        foreach (T element in elementData)
        {
            if (obj.Equals(element)) return true;
        }
        return false;
    }

    public bool ContainsAll(params T[] array)
    {
        foreach (T element in array)
        {
            if (!Contains(element)) return false;
        }
        return true;
    }
    public bool IsEmpty() => elementCount == 0;

    public void Remove(object obj)
    {
        for (int index = 0; index < elementCount; index++)
        {
            if (Contains(obj))
            {
                for (int specIndex = index; specIndex < elementCount - 1; specIndex++)
                {
                    elementData[specIndex] = elementData[specIndex + 1];
                }
                elementCount--;
            }
        }
    }

    public void RemoveAll(params T[] array)
    {
        foreach (T element in array) Remove(element);
    }

    public void RetainAll(params T[] array)
    {
        foreach (T element in array)
        {
            if (!Contains(element))
                Remove(element);
        }
    }

    public int Size() => elementCount;
    public T[] ToArray()
    {
        T[] result = new T[elementCount];
        for (int index = 0; index < elementCount; index++)
        {
            result[index] = elementData[index];
        }
        return result;
    }

    public T[] ToArray(ref T[] array)
    {
        if (array == null)
            ToArray();
        if (array.Length < elementCount)
            throw new ArgumentOutOfRangeException();

        for (int index = 0; index < elementCount; index++)
        {
            array[index] = elementData[index];
        }
        return array;
    }
    public void Add(uint index, T element)
    {
        if (index >= elementCount)
            throw new ArgumentOutOfRangeException();

        if (elementCount == elementData.Length)
        {
            int increment = capacityIncrement == 0 ? elementData.Length : capacityIncrement;
            T[] newArray = new T[elementCount + increment];
            for (int i = 0; i < elementCount; i++) newArray[i] = elementData[i];
            elementData = newArray;
        }

        for (int i = elementCount; i > index; i--)
        {
            elementData[i] = elementData[i - 1];
        }
        elementData[index] = element;
        elementCount++;
    }

    public void AddAll(uint index, T[] array)
    {
        if (index >= elementCount)
            throw new ArgumentOutOfRangeException();

        if (elementCount + array.Length > elementData.Length)
        {
            int increment = capacityIncrement == 0 ? elementData.Length : capacityIncrement;
            T[] tempArray = new T[elementCount + increment];
            for (int i = 0; i < elementCount; i++) tempArray[i] = elementData[i];
            elementData = tempArray;
        }

        for (int i = 0; i < array.Length; i++)
        {
            elementData[index + i + array.Length] = elementData[index + i];
            elementData[index + i] = array[i];
            elementCount++;
        }
    }

    public object Get(uint index)
    {
        if (index >= elementCount)
            throw new ArgumentOutOfRangeException("index");

        return elementData[index];
    }

    public int IndexOf(object obj)
    {
        for (int i = 0; i < elementCount; i++)
            if (elementData[i].Equals(obj)) return i;
        return -1;
    }

    public int LastIndexOf(object obj)
    {
        for (int i = elementData.GetUpperBound(0); i >= 0; i--)
            if (elementData[i].Equals(obj)) return i;
        return -1;
    }

    public T Remove(uint index)
    {
        if (index >= elementCount) throw new ArgumentOutOfRangeException();
        T element = elementData[index];
        for (uint ind = index; ind < elementCount - 1; ind++) elementData[ind] = elementData[ind + 1];
        elementData[index] = default;
        elementCount--;
        return element;
    }

    public void Set(uint index, T element)
    {
        if (index >= elementCount) throw new ArgumentOutOfRangeException();
        if (element == null) throw new ArgumentNullException();
        elementData[index] = element;
    }
    public MyVector<T> SubList(uint fromIndex, uint toIndex)
    {
        if (fromIndex >= elementCount) throw new ArgumentOutOfRangeException();
        if (toIndex > elementCount) throw new ArgumentOutOfRangeException();
        if (toIndex < fromIndex) throw new ArgumentOutOfRangeException();
        MyVector<T> array = new MyVector<T>((int)(toIndex - fromIndex));
        for (int i = 0; i < array.elementCount; i++)
            array.AddElement(elementData[fromIndex + i]);
        return array;
    }

    public T FirstElement() => elementData[0];
    public T LastElement() => elementData[elementCount - 1];
    public void RemoveElementAt(uint index)
    {
        if (index >= elementCount) throw new ArgumentOutOfRangeException();
        T element = elementData[index];
        for (uint ind = index; ind < elementCount - 1; ind++) elementData[ind] = elementData[ind + 1];
        elementData[index] = default;
        elementCount--;
    }

    public void RemoveRange(uint begin, uint end)
    {
        if (begin >= elementCount) throw new ArgumentOutOfRangeException();
        if (end >= elementCount) throw new ArgumentOutOfRangeException();
        if (end < begin) throw new ArgumentOutOfRangeException();
        T[] newArray = new T[elementData.Length];
        uint difference = end - begin;
        for (uint i = 0; i < elementCount - difference; i++) newArray[i] = i < begin ? elementData[i] : elementData[i + difference];
        elementData = newArray;
        elementCount = (int)(elementCount - difference);
    }
    public void Print()
    {
        foreach (T element in elementData)
            Console.WriteLine(element.ToString());
        Console.WriteLine();
    }

}
