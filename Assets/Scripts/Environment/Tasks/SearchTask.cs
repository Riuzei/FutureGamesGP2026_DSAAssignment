using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks 
{
    [CreateAssetMenu(fileName = "Search Task", menuName = "Tasks/Search Task")]
    public class SearchTask : Task 
    {
        Employee[] employees;
        Employee[] employeesInRange;
        public string searchRangeStart;
        public string searchRangeEnd;

        public override void Execute()
        {
            DateTime[] times = new DateTime[employees.Length];
            for (int i = 0; i < employees.Length; i++)
            {
                times[i] = DateTime.Parse(employees[i].LastEntranceInEngineRoom);
            }
            
            DateTime dateStart = DateTime.Parse(searchRangeStart);
            DateTime dateEnd = DateTime.Parse(searchRangeEnd);
            BinarySearch<DateTime> binarySearch = new();
            IComparer<DateTime> comparer = Comparer<DateTime>.Default;
            int foundIndex = binarySearch.Search(times, dateStart, dateEnd, comparer);
            if(foundIndex == -1)
            {
                employeesInRange = new Employee[0];
                return;
            }
            int first = foundIndex;
            while (first > 0 && times[first - 1] >= dateStart)
            {
                first--;
            }

            int last = foundIndex;
            while (last < times.Length - 1 && times[last + 1] <= dateEnd)
            {
                last++;
            }
            employeesInRange = new Employee[last - first + 1];
            for (int i = first; i <= last; i++)
            {
                employeesInRange[i - first] = employees[i];
            }

        }

        int LinearSearch(DateTime[] array, DateTime dateTime) 
        {
            for(int i = 0; i < array.Length; i++) 
            {
                if(array[i] == dateTime)
                {
                    return i;
                }
            }
            return -1;
        }

        public void SetEmployees(Employee[] _employees) 
        {
            employees = _employees;
        }

        public Employee[] GetEmployeesInRange() 
        {
            return employeesInRange;
        }
    }

}

public class BinarySearch<T>
{
    public int Search(T[] array, T rangeStart, T rangeEnd, IComparer<T> comparer)
    {
        int low = 0;
        int high = array.Length - 1;

        while (low <= high)
        {
            int medianIndex = low + (high - low) / 2;
            T medianItem = array[medianIndex];

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
                return medianIndex;
            }
        }

        return -1;
    }
}