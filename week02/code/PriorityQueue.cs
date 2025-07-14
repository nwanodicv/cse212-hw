public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove.
        // The  _queue.Count - 1, means that the iteration misses the last item in the queue.
        // Based on the requirement, higher priority number are better.
        // And if there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned (FIFO).
        // So we start from index 1 and compare with the first item at index 0
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count - 1; index++)
        {
            // For the program to be able to iterate all the items in the queue, we need to change the >= operator to > operator
            // This way, the program will be able to iterate all the items in the queue and find the item with the highest priority.
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}