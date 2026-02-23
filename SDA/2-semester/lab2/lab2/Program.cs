using System;

public class Node
{
    public double Value;
    public Node Prev;
    public Node Next;

    public Node(double value) { Value = value; }
}

public class DoublyLinkedList
{
    public Node Head;

    public void Add(double value)
    {
        Node newNode = new Node(value);
        if (Head == null) Head = newNode;
        else
        {
            Node current = Head;
            while (current.Next != null) current = current.Next;
            current.Next = newNode;
            newNode.Prev = current;
        }
    }

    public void ProcessList()
    {
        if (Head == null) return;

        Node minNode = Head, maxNode = Head, current = Head;
        while (current != null)
        {
            if (current.Value < minNode.Value) minNode = current;
            if (current.Value > maxNode.Value) maxNode = current;
            current = current.Next;
        }

        Console.WriteLine($"Min: {minNode.Value}, Max: {maxNode.Value}");

        InsertAfter(maxNode, minNode.Value);
        InsertAfter(minNode, maxNode.Value);
    }

    private void InsertAfter(Node target, double value)
    {
        Node newNode = new Node(value);
        newNode.Next = target.Next;
        newNode.Prev = target;
        if (target.Next != null) target.Next.Prev = newNode;
        target.Next = newNode;
    }

    public void Print()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

class Program
{
    static void Main()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        Console.Write("Enter the number of items n: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Element {i + 1}: ");
            list.Add(double.Parse(Console.ReadLine()));
        }

        list.Print();
        list.ProcessList();
        Console.WriteLine("List after changes:");
        list.Print();
    }
}