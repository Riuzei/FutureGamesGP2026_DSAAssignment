using System;
using System.Collections.Generic;

public class BinarySearch
{
    // T = Employee; TKey = string;
    public T[] Search<T, TKey>(T[] array, TKey rangeStart, TKey rangeEnd, Func<T, TKey> GetTKey, IComparer<TKey> comparer)
    {
        int low = 0;
        int high = array.Length - 1;
        int foundIndex = -1;
        while (low <= high)
        {
            int medianIndex = low + (high - low) / 2;
            TKey medianItem = GetTKey(array[medianIndex]);
            if (comparer.Compare(medianItem, rangeStart) < 0)
            {
                low = medianIndex + 1;
            }
            else if (comparer.Compare(medianItem, rangeEnd) > 0)
            {
                high = medianIndex - 1;
            }
            else
            {
                foundIndex = medianIndex;
                break;
            }
        }

        int firstIndex = foundIndex;
        while (firstIndex > 0 && comparer.Compare(GetTKey(array[firstIndex - 1]), rangeStart) >= 0)
        {
            firstIndex--;
        }
        
        int lastIndex = foundIndex;
        while (lastIndex < array.Length - 1 && comparer.Compare(GetTKey(array[lastIndex + 1]), rangeEnd) <= 0)
        {
            lastIndex++;
        }
        
        T[] result = new T[lastIndex - firstIndex + 1];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i + firstIndex];
        }
        return result;
    }
}