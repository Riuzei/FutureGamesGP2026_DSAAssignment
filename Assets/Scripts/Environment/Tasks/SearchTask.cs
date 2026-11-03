using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Search Task", menuName = "Tasks/Search Task")]
    public class SearchTask : Task 
    {
        Employee[] employees;
        public string searchDateTime;
        public override void Execute()
        {
            BinarySearch<Employee> binarySearch = new();
            EmployeeEntranceComparer comparer = new();
            binarySearch.Search(employees, employees[0], comparer); //search by entrance time string later
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

        public Employee[] GetEmployees() 
        {
            return employees;
        }
    }

}

public class BinarySearch<T>
{
    public int Search(T[] array, T target, IComparer<T> comparerType)
    {
        int low = 0;
        int high = array.Length -1;
        while (low <= high)
        {
            int median = low + (high - low) / 2;
            if(comparerType.Compare(array[median], target) == 0)
            {
                return median;
            }
            else if(comparerType.Compare(array[median], target) < 0)
            {
                low = median + 1;
            }
            else
            {
                high = median - 1;
            }
        }
        return -1;
    }
    
}