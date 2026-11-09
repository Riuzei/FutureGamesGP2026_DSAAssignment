using Environment.Tasks;
using UnityEngine;

namespace Environment 
{
    public class Computer : MonoBehaviour, IInteractable 
    {
        [SerializeField] private Task readTask;
        [SerializeField] private Task sortTask;
        
        Employee[] employees;
        Employee[] sortedEmployees;
        private GenericQueue<Task> tasks = new();

        void Start()
        {
            tasks.Enqueue(readTask);
            tasks.Enqueue(sortTask);
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
                foreach(Employee employee in sortedEmployees) 
                {
                    Debug.Log($"Name: {employee.Name}, ID: {employee.EmployeeId}, Last Entry : {employee.LastEntranceInEngineRoom}");
                }
            }
            tasks.Dequeue();
        }
    }
    
}
