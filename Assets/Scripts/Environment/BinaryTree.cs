using System;
using System.Collections.Generic;

public class BinaryTree<T, TKey>
{
    public class TreeNode
    {
        public T Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(T value)
        {
            Value = value;
        }
    }
    
    private TreeNode root;
    private Func<T, TKey> getKey;
    private readonly IComparer<TKey> comparer;

    public BinaryTree(Func<T, TKey> getKey, IComparer<TKey> comparer)
    {
        this.getKey = getKey;
        this.comparer = comparer;
    }

    public void Insert(T value)
    {
        root = Insert(root, value);
    }

    private TreeNode Insert(TreeNode node, T value)
    {
        if (node == null)
            return new TreeNode(value);

        if (comparer.Compare(getKey(value), getKey(node.Value)) < 0)
            node.Left = Insert(node.Left, value);
        else
            node.Right = Insert(node.Right, value);

        return node;
    }

    public List<T> FindInRange(TKey min, TKey max)
    {
        List<T> result = new();
        Search(root, min, max, result);
        return result;
    }

    private void Search(TreeNode node, TKey min, TKey max, List<T> result)
    {
        if (node == null) return;

        TKey key = getKey(node.Value);
        bool isBigEnough = comparer.Compare(key, min) >= 0;  
        bool isSmallEnough = comparer.Compare(key, max) <= 0;

        if (isBigEnough)
            Search(node.Left, min, max, result);

        if (isBigEnough && isSmallEnough)
            result.Add(node.Value);

        if (isSmallEnough)
            Search(node.Right, min, max, result);
    }
}