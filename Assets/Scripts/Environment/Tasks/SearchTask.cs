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
        
        public string rangeStart;
        public string rangeEnd;
        public SearchType searchType;
        public enum SearchType 
        {
            Binary,
            Linear
        }

        public override void Execute()
        {
            IComparer<string> comparer = Comparer<string>.Default;
            if(searchType == SearchType.Binary)
            {
                BinarySearch binarySearch = new();
                employeesInRange = binarySearch.Search(employees, rangeStart, rangeEnd, employee => employee.LastEntranceInEngineRoom, comparer);
                
                RunBenchmark("Binary Search", () => binarySearch.Search(employees, rangeStart, rangeEnd, employee => employee.LastEntranceInEngineRoom, comparer), 1000);
            }
            else if(searchType == SearchType.Linear)
            {
                employeesInRange = LinearSearch(employees, rangeStart, rangeEnd, comparer);
                
                RunBenchmark("Linear Search", () => LinearSearch(employees, rangeStart, rangeEnd, comparer), 1000);
            }

        }
        private static void RunBenchmark(string label, Action action, int runs = 1000)
        {
            System.Diagnostics.Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < runs; i++)
                action();
            stopwatch.Stop();

            Debug.Log($"{label} Average Time: {stopwatch.Elapsed.TotalMilliseconds / runs:F6} ms per search");
        }
        Employee[] LinearSearch(Employee[] array, string start, string end, IComparer<string> comparer) 
        {
            List<Employee> result = new List<Employee>();
            foreach (Employee employee in array) 
            {
                if (comparer.Compare(employee.LastEntranceInEngineRoom, start) >= 0 && comparer.Compare(employee.LastEntranceInEngineRoom, end) <= 0) 
                {
                    result.Add(employee);
                }
            }
            return result.ToArray();
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



