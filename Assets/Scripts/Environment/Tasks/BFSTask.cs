using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "BFS Task", menuName = "Tasks/BFS Task")]
    public class BFSTask : Task
    {
        public string rangeStart;
        public string rangeEnd;
        
        private BinaryTree<Employee, string> tree;
        private Employee[] employeesInRange;

        public override void Execute()
        {
            employeesInRange = tree.FindInRangeBFS(rangeStart, rangeEnd).ToArray();

            Benchmark.Run("BFS Search", () => tree.FindInRangeBFS(rangeStart, rangeEnd));
        }

        public void SetTree(BinaryTree<Employee, string> _tree)
        {
            tree = _tree;
        }

        public Employee[] GetEmployeesInRange()
        {
            return employeesInRange;
        }
    }
}
