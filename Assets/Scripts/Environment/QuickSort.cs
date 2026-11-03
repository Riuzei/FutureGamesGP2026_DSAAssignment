using System.Collections.Generic;

public class QuickSort<T>
{
    public void Sort(T[] _arrayToSort, int left, int right, IComparer<T> comparer) //make generic
    {
        if(left < right)
        {
            int pivotIndex = Partition(_arrayToSort, left, right, comparer);
            Sort(_arrayToSort, left, pivotIndex - 1, comparer);
            Sort(_arrayToSort, pivotIndex + 1, right, comparer);
        }
    }

    int Partition(T[] _arrayToSort, int left, int right, IComparer<T> comparer)
    {
        T pivot = _arrayToSort[right];
        int i = left - 1;
        
        for(int j = left; j < right; j++)
        {
            if(comparer.Compare(_arrayToSort[j], pivot) < 0) //if array value is less than pivot then result is -1
            {
                i++;
                T tempValue = _arrayToSort[i];
                _arrayToSort[i] = _arrayToSort[j];
                _arrayToSort[j] = tempValue;
            }
        }
        
        T temp = _arrayToSort[i+1];
        _arrayToSort[i + 1] = _arrayToSort[right];
        _arrayToSort[right] = temp;
        return i+1;
    }

}

