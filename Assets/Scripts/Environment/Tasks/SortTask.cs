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
            QuickSort(workers, 0, n - 1);
            
            // for(int i = 0; i < n; i++) //iterate through the full array length
            // {
            //     int minValIndex = i; //
            //     for(int j = i+1; j < n; j++) // start from value next to minimum value index 
            //     {
            //     //check if the value (j) is less than the value behind it which is considered least value at the moment
            //         if(workers[j].employeeId < workers[minValIndex].employeeId) 
            //         {
            //             minValIndex = j; // if true remember j has the least value so far
            //         }
            //     }
                
            //     Worker minVal = workers[minValIndex]; //remember minimum value in this loop index (i)
                
            //     for(int k = minValIndex; k > i; k--)
            //     {
            //         workers[k] = workers[k-1]; //shift forward one by one replacing the values
            //     }
                
            //     workers[i] = minVal; //set minimum value to beginning index of iteration (i)
            // }
        }
        
        void QuickSort(Worker[] _workers, int left, int right)
        {
            if(left < right)
            {
                int pivotIndex = Partition(_workers, left, right);
                QuickSort(_workers, left, pivotIndex - 1);
                QuickSort(_workers, pivotIndex + 1, right);
            }
        }
        
        int Partition(Worker[] _workers, int left, int right)
        {
            Worker pivot = _workers[right];
            int i = left - 1;
            
            for(int j = left; j < right; j++)
            {
                if(_workers[j].employeeId < pivot.employeeId)
                {
                    i++;
                    Worker tempWorker = _workers[i];
                    _workers[i] = _workers[j];
                    _workers[j] = tempWorker;
                }
            }
            
            Worker temp = _workers[i+1];
            _workers[i + 1] = _workers[right];
            _workers[right] = temp;
            return i+1;
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