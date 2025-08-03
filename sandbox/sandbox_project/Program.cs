using System;


// Stack Implementation using LinkedList
public class StackUsingLinkedList
{
    private class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public StackUsingLinkedList()
    {
        head = null;
    }

    // Push: Add to top
    public void Push(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = head;
        head = newNode;
    }

    // Pop: Remove from top
    public int Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        int value = head.Data;
        head = head.Next;
        return value;
    }

    // GetTop: Peek top value
    public int GetTop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return head.Data;
    }

    // IsEmpty: Check if stack is empty
    public bool IsEmpty()
    {
        return head == null;
    }
}



// Queue Implementation using linkedList
public class QueueUsingLinkedList
{
    private class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private Node tail;

    public QueueUsingLinkedList()
    {
        head = null;
        tail = null;
    }

    // Enqueue: Add to rear
    public void Enqueue(int value)
    {
        Node newNode = new Node(value);
        if (tail != null)
        {
            tail.Next = newNode;
        }
        else
        {
            head = newNode;
        }
        tail = newNode;
    }

    // Dequeue: Remove from front
    public int Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        int value = head.Data;
        head = head.Next;
        if (head == null)
        {
            tail = null;
        }
        return value;
    }

    // Size: Count elements
    public int Size()
    {
        int count = 0;
        Node current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    // IsEmpty: Check if queue is empty
    public bool IsEmpty()
    {
        return head == null;
    }
}


public class Program
{
    public static void Main()
    {
        // Stack Test
        var stack = new StackUsingLinkedList();
        stack.Push(10);
        stack.Push(20);
        Console.WriteLine(stack.GetTop()); // 20
        Console.WriteLine(stack.Pop());    // 20
        Console.WriteLine(stack.GetTop()); // 10

        // Queue Test
        var queue = new QueueUsingLinkedList();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine(queue.Dequeue()); // 1
        Console.WriteLine(queue.Size());    // 2
    }
}
