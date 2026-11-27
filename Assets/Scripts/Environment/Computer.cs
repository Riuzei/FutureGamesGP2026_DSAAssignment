using Environment.Tasks;
using TMPro;
using UnityEngine;

namespace Environment
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeField] private Task readTask;
        [SerializeField] private Task treeLoadTask;
        [SerializeField] private Task dfsTask;
        [SerializeField] private Task bfsTask;
        // [SerializeField] private Task sortTask;
        // [SerializeField] private Task searchTask;
        public TextMeshProUGUI nextTaskText;
        public TextMeshProUGUI executedTaskText;

        Employee[] employees;
        Employee[] sortedEmployees;
        BinaryTree<Employee, string> tree;
        private GenericQueue<Task> tasks = new();

        void Start()
        {
            tasks.Enqueue(readTask);
            tasks.Enqueue(treeLoadTask);
            tasks.Enqueue(dfsTask);
            tasks.Enqueue(bfsTask);
            Task nextTask = tasks.Peek();
            nextTaskText.text = "Next Task\n" + nextTask.taskName + "\n"+ nextTask.taskDescription;
            //tasks.Enqueue(sortTask);
            //tasks.Enqueue(searchTask);
        }

        public void OnInteract()
        {
            if (tasks.Count == 0) return;
            RunTaskInQueue();
        }

        private void RunTaskInQueue()
        {
            Task _task = tasks.Peek();
            executedTaskText.text = "EXECUTING\n" + _task.taskName;
            if (_task is TreeLoadTask loadTask)
                loadTask.SetEmployees(employees);
            else if (_task is DFSTask dfs)
                dfs.SetTree(tree);
            else if (_task is BFSTask bfs)
                bfs.SetTree(tree);

            if (_task is SortTask _sortTask)
            {
                _sortTask.SetEmployees(employees);
            }
            if(_task is SearchTask _searchTask)
            {
                _searchTask.SetEmployees(sortedEmployees);
            }
            _task.Execute();

            if (_task is ReadTask readFileTask)
            {
                employees = readFileTask.GetEmployees();
                LogEmployees(employees);
            }
            else if (_task is TreeLoadTask executedLoadTask)
            {
                tree = executedLoadTask.GetTree();
                Debug.Log("Binary Tree Loaded!");
            }
            else if (_task is DFSTask executedDFSTask)
            {
                LogEmployees(executedDFSTask.GetEmployeesInRange());
            }
            else if(_task is BFSTask executedBFSTask)
            {
                LogEmployees(executedBFSTask.GetEmployeesInRange());
            }
            // else if(_task is SortTask executedSortTask)
            // {
            //     sortedEmployees = executedSortTask.GetEmployees();
            //     LogEmployees(sortedEmployees);
            // }
            // else if(_task is SearchTask executedSearchTask)
            // {
            //     Employee[] employeesInRange = executedSearchTask.GetEmployeesInRange();
            //     LogEmployees(employeesInRange);
            // }

            tasks.Dequeue();
            executedTaskText.text = "Executed Task\n" + _task.taskName;
            if(tasks.Count == 0) 
            {
                nextTaskText.text = "";
                return;
            }
            Task nextTask = tasks.Peek();
            nextTaskText.text = "Next Task\n" + nextTask.taskName + "\n"+ nextTask.taskDescription;
        }

        private void LogEmployees(Employee[] list)
        {
            foreach (Employee employee in list)
                Debug.Log($"Name: {employee.Name}, ID: {employee.EmployeeId}, Last Entry : {employee.LastEntranceInEngineRoom}");
        }
    }
}