public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data) // If the value is less than the current node's data
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value); // Create a new node if left is null
            else
                Left.Insert(value); // Recursively insert into the left subtree
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value); // Create a new node if right is null
            else
                Right.Insert(value); // Recursively insert into the right subtree
        }
    }

    public bool Contains(int value) // Check if the tree contains a value
    {
        // TODO Start Problem 2
        if (value == Data) // If the value matches the current node's data
        {
            return true; // Value found
        }
        if (value < Data) // If the value is less than the current node's data
        {
            return Left?.Contains(value) ?? false; // Check the left subtree
        }
        // If the value is greater than the current node's data
        return false; // Check the right subtree
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = Left?.GetHeight() ?? 0; // Get height of left subtree, default to 0 if null
        int rightHeight = Right?.GetHeight() ?? 0; // Get height of right subtree, default to 0 if null
        return 0; // Replace this line with the correct return statement(s)
    }
}