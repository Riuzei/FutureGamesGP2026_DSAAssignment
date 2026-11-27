using UnityEngine;

namespace Environment.Tasks {
    public abstract class Task : ScriptableObject 
    {
        public string taskName;
        public string taskDescription;   
        public abstract void Execute();
    }

}
