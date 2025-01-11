using System;

namespace ListaJednokierunkowa
{
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
    public class Lista
    {
        private Node head;

        public Lista()
        {
            head = null;
        }

        public void DodajNaPoczatku(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
        }

        
        public void DodajNaKoncu(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null) 
                {
                    current = current.Next;
                }
                current.Next = newNode; 
            }
        }

        
        public void UsunNaPoczatku()
        {
            if (head == null)
            {
                Console.WriteLine("Lista jest pusta. Nie można usunąć elementu.");
                return;
            }

            head = head.Next;
        }

        
        public void UsunNaKoncu()
        {
            if (head == null)
            {
                Console.WriteLine("Lista jest pusta. Nie można usunąć elementu.");
                return;
            }

            if (head.Next == null) 
            {
                head = null; 
                return;
            }

            Node current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("Lista jest pusta.");
                return;
            }

            Node current = head;
            Console.Write("Lista: ");

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lista mojaLista = new Lista();
            mojaLista.DodajNaPoczatku(30);

            mojaLista.Display();
            mojaLista.DodajNaPoczatku(10);
            mojaLista.Display();
            mojaLista.DodajNaKoncu(20);
            mojaLista.Display();
            mojaLista.UsunNaPoczatku();
            mojaLista.Display();
        }
    }
}