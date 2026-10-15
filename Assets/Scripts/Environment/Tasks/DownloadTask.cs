using System.Collections;
using TMPro;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Download Task", menuName = "Tasks/Download Task")]
    public class DownloadTask : Task 
    {
        [SerializeField] private string textToPrint;

        public override IEnumerator Execute(TextMeshProUGUI prompt) 
        {
            prompt.text = $"CURRENTLY DOWNLOADING:\n{textToPrint}";
            yield return new WaitForSeconds(3);
            prompt.text = $"DOWNLOAD COMPLETED for\n{textToPrint}";
        }
        
    }
}
