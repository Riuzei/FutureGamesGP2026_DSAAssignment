using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Read File Task", menuName = "Tasks/Read File Task")]
    public class ReadFileTask : Task 
    {
        [SerializeField] private string fileName = "workers.json";
        [SerializeField] private TextAsset jsonFileAsset;
        Worker[] workers;
        // "C:/Users/samrudh.nair/Documents/Github/FutureGamesGP2026_DSAAssignment/Assets/StreamingAssets/workers.json"
        public override void Execute() 
        {
            //read json file & store in worker list
            //string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
            //TextAsset jsonFile = Resources.Load<TextAsset>(fileName);
            //Debug.Log(AssetDatabase.GetAssetPath(jsonFileAsset));
            //if(jsonFile == null)
                //Debug.Log("Json File not found @ " + filePath);
            workers = JsonUtility.FromJson<WorkersArray>("{\"workers\":" + jsonFileAsset.text + "}").workers;
            Debug.Log(workers);
        }

        public Worker[] GetWorkers() 
        {
            return workers;
        }
   
    }
    [Serializable]
    public class Worker 
    {
        public string name;
        public int id;
        public string lastEntranceInEngineRoom;
 
    }
    [Serializable]
    public class WorkersArray 
    {
        public Worker[] workers;

    }


}

