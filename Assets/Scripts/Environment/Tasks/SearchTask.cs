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





