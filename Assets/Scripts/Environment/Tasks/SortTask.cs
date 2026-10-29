using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Sort Task", menuName = "Tasks/Sort Task")]
    public class SortTask : Task 
    {
        private Worker[] workers;
        public override void Execute() 
        {
            if(workers == null) return;
            int n = workers.Length;
            
            for(int i = 0; i < n; i++) //iterate through the full array length
            {
                int minValIndex = i; //
                for(int j = i+1; j < n; j++) // start from value next to minimum value index 
                {
                //check if the value (j) is less than the value behind it which is considered least value at the moment
                    if(workers[j].employeeId < workers[minValIndex].employeeId) 
                    {
                        minValIndex = j; // if true remember j has the least value so far
                    }
                }
                
                Worker minVal = workers[minValIndex]; //remember minimum value in this loop index (i)
                
                for(int k = minValIndex; k > i; k--)
                {
                    workers[k] = workers[k-1]; //shift forward one by one replacing the values
                }
                
                workers[i] = minVal; //set minimum value to beginning index of iteration (i)
            }
        }
        
        public void SetWorkers(Worker[] _workers)
        {
            workers = _workers;
        }
        
        public Worker[] GetWorkers()
        {
            return workers;
        }
    }
}