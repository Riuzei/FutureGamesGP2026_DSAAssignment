using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable 
    {
        [SerializeField] private Task readTask;
        [SerializeField] private Task sortTask;
        
        Worker[] workers;
        Worker[] sortedWorkers;
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
                _sortTask.SetWorkers(workers);
            }
            _task.Execute();
            if(_task is ReadTask readFileTask) 
            {   
                workers = readFileTask.GetWorkers();
                foreach(Worker worker in workers) 
                {
                    Debug.Log($"Name: {worker.name}, ID: {worker.employeeId}, Last Entry : {worker.lastEntranceInEngineRoom}");
                }
            }
            else if(_task is SortTask executedSortTask)
            {
                sortedWorkers = executedSortTask.GetWorkers();
                foreach(Worker worker in sortedWorkers) 
                {
                    Debug.Log($"Name: {worker.name}, ID: {worker.employeeId}, Last Entry : {worker.lastEntranceInEngineRoom}");
                }
            }
            tasks.Dequeue();
        }
    }
    
}
