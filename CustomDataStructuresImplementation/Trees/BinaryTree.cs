using System;

public class BinaryTree<T>
{
    public T Value { get; set; }
    public BinaryTree<T> Left { get; set; }
    public BinaryTree<T> Right { get; set; }
    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.Left = leftChild;
        this.Right = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        this.PrintIndentedPreOrder(this, indent);
    }

    private void PrintIndentedPreOrder(BinaryTree<T> node, int indent)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine($"{new string(' ',indent)}{node.Value}");
        this.PrintIndentedPreOrder(node.Left, indent + 2);
        this.PrintIndentedPreOrder(node.Right, indent + 2);
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.Left != null)
        {
            this.Left.EachInOrder(action);
        }

        action(this.Value);

        if (this.Right != null)
        {
            this.Right.EachInOrder(action);
        }
    }

    public void EachPostOrder(Action<T> action)
    {
        if (this.Left != null)
        {
            this.Left.EachInOrder(action);
        }

        if (this.Right != null)
        {
            this.Right.EachInOrder(action);
        }

        action(this.Value);
    }
}
