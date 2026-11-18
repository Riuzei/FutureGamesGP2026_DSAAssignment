using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "DFS Task", menuName = "Tasks/DFS Task")]
    public class DFSTask : Task
    {
        public string rangeStart;
        public string rangeEnd;

        private BinaryTree<Employee, string> tree;
        private Employee[] employeesInRange;

        public override void Execute()
        {
            employeesInRange = tree.FindInRange(rangeStart, rangeEnd).ToArray();

            Benchmark.Run("DFS Search", () => tree.FindInRange(rangeStart, rangeEnd));
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
