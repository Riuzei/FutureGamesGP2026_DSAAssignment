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
            employeesInRange = tree.FindInRangeDFS(rangeStart, rangeEnd).ToArray();

            Benchmark.Run("DFS Search", () => tree.FindInRangeDFS(rangeStart, rangeEnd));
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
