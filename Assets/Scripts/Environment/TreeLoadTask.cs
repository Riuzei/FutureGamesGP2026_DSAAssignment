using System;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Tree Load Task", menuName = "Tasks/Tree Load Task")]
    public class TreeLoadTask : Task
    {
        private Employee[] employees;
        private BinaryTree<Employee, string> tree;

        public override void Execute()
        {
            tree = new BinaryTree<Employee, string>
            (
                employee => employee.LastEntranceInEngineRoom,
                StringComparer.Ordinal
            );

            foreach (Employee employee in employees)
                tree.Insert(employee);
        }

        public void SetEmployees(Employee[] _employees)
        {
            employees = _employees;
        }

        public BinaryTree<Employee, string> GetTree()
        {
            return tree;
        }
    }
}