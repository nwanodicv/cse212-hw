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
        var person = new Person(name, turns);
        _people.Enqueue(person);
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
                person.Turns -= 1;
                _people.Enqueue(person);
            }
            // To fix the problem: We have to implement the logic to handle infinite turns, we can check if the turns is 0 or less
            // If turns is 0 or less, then they have infinite turns and will stay in the queuw forever
            else if (person.Turns <= 0)
            {
                person.Turns = -1; // Set to -1 to indicate infinite turns
                _people.Enqueue(person);
            }

            return person;
        }
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}