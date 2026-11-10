using Environment.Tasks;
using System;
using UnityEngine;

namespace Environment 
{
    public class Computer : MonoBehaviour, IInteractable 
    {
        [SerializeField] private Task readTask;
        [SerializeField] private Task sortTask;
        [SerializeField] private Task searchTask;
        
        Employee[] employees;
        Employee[] sortedEmployees;
        private GenericQueue<Task> tasks = new();

        void Start()
        {
            tasks.Enqueue(readTask);
            tasks.Enqueue(sortTask);
            tasks.Enqueue(searchTask);
        }
    
        public void OnInteract() 
        {
            RunTaskInQueue();
        }
        
        private void RunTaskInQueue() 
        {
            Task _task = tasks.Peek();
            if (_task is SortTask _sortTask)
            {
                _sortTask.SetEmployees(employees);
            }
            if(_task is SearchTask _searchTask)
            {
                _searchTask.SetEmployees(sortedEmployees);
            }
            _task.Execute();
            if(_task is ReadTask readFileTask) 
            {   
                employees = readFileTask.GetEmployees();
                foreach(Employee employee in employees) 
                {
                    Debug.Log($"Name: {employee.Name}, ID: {employee.EmployeeId}, Last Entry : {employee.LastEntranceInEngineRoom}");
                }
            }
            else if(_task is SortTask executedSortTask)
            {
                sortedEmployees = executedSortTask.GetEmployees();
                Console.Clear();
                foreach(Employee employee in sortedEmployees) 
                {
                    Debug.Log($"Name: {employee.Name}, ID: {employee.EmployeeId}, Last Entry : {employee.LastEntranceInEngineRoom}");
                }
            }
            else if(_task is SearchTask executedSearchTask) 
            {
                Employee[] employeesInRange = executedSearchTask.GetEmployeesInRange();
                foreach(Employee employee in employeesInRange) 
                {
                    Debug.Log($"Name: {employee.Name}, ID: {employee.EmployeeId}, Last Entry : {employee.LastEntranceInEngineRoom}");
                }
            }
            tasks.Dequeue();
        }
    }
    
}
