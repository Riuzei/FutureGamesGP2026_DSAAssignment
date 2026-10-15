using System.Collections;
using TMPro;
using UnityEngine;

namespace Environment.Tasks {
    public abstract class Task : ScriptableObject 
    {
       public abstract IEnumerator Execute(TextMeshProUGUI text);
    }
}
