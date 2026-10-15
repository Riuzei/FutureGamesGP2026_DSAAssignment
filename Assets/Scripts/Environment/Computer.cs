using Environment.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable 
    {
        [SerializeField] private TextMeshProUGUI downloadPrompt;
        [SerializeField] private TextMeshProUGUI statusPrompt;
        [SerializeField] private TextMeshProUGUI sortPrompt;
        
        [SerializeField] private Task[] downloadTaskPool;
        [SerializeField] private Task sortTask;

        private GenericQueue<Task> downloadTaskQ = new();
        private GenericQueue<Task> sortTaskQ = new();
        private bool isRunning;

        void Start()
        {
            downloadPrompt.text = "NOTHING\nTO\nDOWNLOAD";
            statusPrompt.text = "DOING NOTHING";
            sortPrompt.text = "NOTHING TO SORT";
        }
    
        public void OnInteract() 
        {
            downloadPrompt.text = $"DOWNLOADING...\n[{downloadTaskQ.Count}]";
            downloadTaskQ.Enqueue(downloadTaskPool[Random.Range(0, downloadTaskPool.Length - 1)]);
            if (!isRunning) 
                StartCoroutine(RunTasks());
        }
        
        private IEnumerator RunTasks() 
        {
            isRunning = true;
            while(downloadTaskQ.Count > 0)
            {
                downloadPrompt.text = $"DOWNLOADING...\n[{downloadTaskQ.Count}]";
                Task task = downloadTaskQ.Peek();
                yield return task.Execute(statusPrompt);
                downloadPrompt.text = $"DOWNLOADING...\n[{downloadTaskQ.Count}]";
                downloadTaskQ.Dequeue();
                sortTaskQ.Enqueue(sortTask);
                sortPrompt.text = $"READY TO SORT\n[{sortTaskQ.Count}]";
            }    
            downloadPrompt.text = "NOTHING\nTO\nDOWNLOAD";
            statusPrompt.text = "DOING NOTHING";
            if(sortTaskQ.Count < 1)
                sortPrompt.text = "NOTHING TO SORT";
            isRunning = false;
        }
    }
    
}
