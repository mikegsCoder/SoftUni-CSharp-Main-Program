using System;
using System.Collections.Generic;
using System.Linq;

public class PlayWithTrees
{
    static void Main()
    {
        var tree =
            new Tree<int>(7,
                new Tree<int>(19,
                    new Tree<int>(1),
                    new Tree<int>(12),
                    new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14,
                    new Tree<int>(23),
                    new Tree<int>(6)));

        Console.WriteLine("Tree (indented):");
        tree.Print();

        Console.WriteLine(new string('-',30));
        List<int> listDFS = tree.OrderDFS().ToList();
        Console.WriteLine("Order DFS Result:");
        Console.WriteLine(string.Join(", ",listDFS));

        Console.WriteLine(new string('-', 30));
        List<int> listBFS = tree.OrderBFS().ToList();
        Console.WriteLine("Order BFS Result:");
        Console.WriteLine(string.Join(", ", listBFS));
        Console.WriteLine(new string('-', 30));

        Console.WriteLine();

        var binaryTree =
            new BinaryTree<string>("*",
                new BinaryTree<string>("+",
                    new BinaryTree<string>("3"),
                    new BinaryTree<string>("2")),
                new BinaryTree<string>("-",
                    new BinaryTree<string>("9"),
                    new BinaryTree<string>("6")));

        Console.WriteLine("Binary tree (indented, pre-order):");
        binaryTree.PrintIndentedPreOrder();

        Console.Write("Binary tree nodes (in-order):");
        binaryTree.EachInOrder(c => Console.Write(" " + c));
        Console.WriteLine();

        Console.Write("Binary tree nodes (post-order):");
        binaryTree.EachPostOrder(c => Console.Write(" " + c));
        Console.WriteLine();
    }
}
