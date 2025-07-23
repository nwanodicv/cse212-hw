/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name)); // Ensure name is not null or empty
        }
        if (turns < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(turns), "Turns must be 0 or greater."); // Ensure turns is not negative
        }
        // Create a new person with the provided name and turns, then add them to the queue
        // Note: The Person class should be defined elsewhere in your codebase.
        Person person = new(name, turns); // Assuming Person has a constructor that takes name and turns
        _people.Enqueue(person); // Add the person to the queue
        
        
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        else
        {
            // Get the next person in the queue
            // If they have no turns left, then do not add them back to the queue.
            // If they have turns left, then decrement their turns and add them back to the queue.
            // Problem:
            // In the original code we did not include the logic to handle infinite turns.
            // Base on the requirement, if turns is 0 or less, then they have infinite turns.
            Person person = _people.Dequeue();
            if (person.Turns > 1)
            {
                person.Turns--; // Decrement and re-enqueue
                _people.Enqueue(person);
                //person.Turns -= 1;
                //_people.Enqueue(person);
            }
            // To fix the problem: We have to implement the logic to handle infinite turns, we can check if the turns is 0 or less
            // If turns is 0 or less, then they have infinite turns and will stay in the queuw forever
            else if (person.Turns <= 0)
            {
                // Infinite turns — re-enqueue without modifying turns
                // This means they will stay in the queue forever
                /*person.Turns = int.MaxValue; // Set to a large value to represent infinite turns
                // Note: This is a workaround to represent infinite turns, you can also choose to not modify the turns at all
                // but this way it is clear that they have infinite turns.*/
                _people.Enqueue(person); // Re-enqueue the person with infinite turns
            }

            return person;
        }
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}