using System;

namespace DrzewoBinarne
{
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        private Node root;

        public BinaryTree()
        {
            root = null;
        }
        public void Add(int value)
        {
            root = AddRecursive(root, value);
        }

        private Node AddRecursive(Node current, int value)
        {
            if (current == null)
            {
                return new Node(value);
            }

            if (value < current.Value)
            {
                current.Left = AddRecursive(current.Left, value);
            }
            else if (value >= current.Value)
            {
                current.Right = AddRecursive(current.Right, value);
            }

            return current;
        }
        public void DisplayTree()
        {
            DisplayTreeRecursive(root, 0);
        }

        private void DisplayTreeRecursive(Node current, int level)
        {
            if (current != null)
            {
                DisplayTreeRecursive(current.Right, level + 1);

                Console.WriteLine(new string(' ', level * 4) + current.Value);

                DisplayTreeRecursive(current.Left, level + 1);
            }
        }

        public void RemoveNode(int value)
        {
            root = RemoveNodeRec(root, value);
        }

        private Node RemoveNodeRec(Node Curent, int data)
        {
            if (Curent == null)
            {
                return null;
            }

            if (data < Curent.Value)
            {
                Curent.Left = RemoveNodeRec(Curent.Left, data);
            }
            else if (data > Curent.Value)
            {
                Curent.Right = RemoveNodeRec(Curent.Right, data);
            }
            else
            {
                if (Curent.Left == null && Curent.Right == null)
                {
                    return null;
                }

                if (Curent.Left == null)
                {
                    return Curent.Right;
                }

                if (Curent.Right == null)
                {
                    return Curent.Left;
                }

                Node nastepnik = FindMin(Curent.Right);
                Curent.Value = nastepnik.Value;
                Curent.Right = RemoveNodeRec(Curent.Right, nastepnik.Value);
            }

            return Curent;
        }

        private Node FindMin(Node listTrzymany)
        {
            while (listTrzymany.Left != null)
            {
                listTrzymany = listTrzymany.Left;
            }
            return listTrzymany;
        }



    }


    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree drzewo = new BinaryTree();

            drzewo.Add(50);
            drzewo.Add(30);
            drzewo.Add(70);
            drzewo.Add(20);
            drzewo.Add(40);
            drzewo.Add(60);
            drzewo.Add(80);

            drzewo.DisplayTree();
            drzewo.RemoveNode(50);

            drzewo.DisplayTree();

        }
    }
}
