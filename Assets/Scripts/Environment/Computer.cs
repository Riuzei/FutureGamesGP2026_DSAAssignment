using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable 
    {
        [SerializeField] private Task readTask;
        [SerializeField] private Task sortTask;
        Worker[] workers;
        private GenericQueue<Task> tasks = new();

        void Start()
        {
            tasks.Enqueue(readTask);
        }
    
        public void OnInteract() 
        {
            RunTaskInQueue();
        }
        
        private void RunTaskInQueue() 
        {
            Task _task = tasks.Peek();
            _task.Execute();
            if(_task is ReadFileTask readFileTask) 
            {   
                workers = readFileTask.GetWorkers();
                foreach(Worker worker in workers) 
                {
                    Debug.Log($"Name: {worker.name}, ID: {worker.id}, Last Entry : {worker.lastEntranceInEngineRoom}");
                }
            }
            tasks.Dequeue();
        }
    }
    
}
