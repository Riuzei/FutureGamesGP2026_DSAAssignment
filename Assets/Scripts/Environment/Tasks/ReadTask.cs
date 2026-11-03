using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Read Task", menuName = "Tasks/Read Task")]
    public class ReadTask : Task 
    {
        [SerializeField] private TextAsset jsonFileAsset;
        Employee[] employees;
        public override void Execute() 
        {
            employees = JsonUtility.FromJson<EmployeesArray>(jsonFileAsset.text).Employees;
        }

        public Employee[] GetEmployees() 
        {
            return employees;
        }
    }

}

