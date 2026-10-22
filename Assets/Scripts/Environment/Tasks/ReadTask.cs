using System.IO;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Read Task", menuName = "Tasks/Read Task")]
    public class ReadTask : Task 
    {
        [SerializeField] private TextAsset jsonFileAsset;
        Worker[] workers;
        public override void Execute() 
        {
            workers = JsonUtility.FromJson<WorkersArray>("{\"workers\":" + jsonFileAsset.text + "}").workers;
        }

        public Worker[] GetWorkers() 
        {
            return workers;
        }
    }

}

