using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 1 - Run test cases and record any defects the test code finds in the comment above the test method.
// DO NOT MODIFY THE CODE IN THE TESTS in this file, just the comments above the tests. 
// Fix the code being tested to match requirements and make all tests pass. 

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
    // run until the queue is empty
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
    
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0; // Initialize index for expected results
        for (; i < expectedResult.Length; i++) // Loop through expected results
        {
            var person = players.GetNextPerson(); // Get the next person from the queue
            Assert.IsNotNull(person, "Person should not be null."); // Ensure person is not null
            Assert.AreEqual(expectedResult[i].Turns, person.Turns, "Turns should match expected value."); // Check turns match expected
            Assert.IsNotNull(person.Name, "Name should not be null."); // Ensure name is not null
            Assert.IsFalse(string.IsNullOrWhiteSpace(person.Name), "Name should not be empty or whitespace."); // Ensure name is not empty or whitespace
            Assert.AreEqual(expectedResult[i].Name, person.Name); // Check name matches expected
        }
        while (players.Length > 0) // Continue until the queue is empty
        {
            if (i >= expectedResult.Length) // Check if we have exhausted the expected results
            {
                Assert.Fail("Queue should have ran out of items by now."); // Fail if we have more items in the queue than expected
            }

            var person = players.GetNextPerson(); // Get the next person from the queue
            Assert.IsNotNull(person, "Person should not be null."); // Ensure person is not null
            Assert.AreEqual(expectedResult[i].Turns, person.Turns, "Turns should match expected value."); // Check turns match expected
            Assert.IsNotNull(person.Name, "Name should not be null."); // Ensure name is not null
            Assert.IsFalse(string.IsNullOrWhiteSpace(person.Name), "Name should not be empty or whitespace."); // Ensure name is not empty or whitespace
            Assert.AreEqual(expectedResult[i].Name, person.Name); // Check name matches expected
            i++; // Increment index for expected results
        }

    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // After running 5 times, add George with 3 turns.  Run until the queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, george, sue, tim, george, tim, george];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0; // Initialize index for expected results
        for (; i < 5; i++) // Loop through the first 5 expected results
        {
            var person = players.GetNextPerson(); // Get the next person from the queue
            Assert.IsNotNull(person, "Person should not be null."); // Ensure person is not null
            Assert.AreEqual(expectedResult[i].Turns, person.Turns, "Turns should match expected value."); // Check turns match expected
            Assert.IsNotNull(person.Name, "Name should not be null."); // Ensure name is not null
            Assert.IsFalse(string.IsNullOrWhiteSpace(person.Name), "Name should not be empty or whitespace."); // Ensure name is not empty or whitespace
            Assert.AreEqual(expectedResult[i].Name, person.Name); // Check name matches expected
        }

        players.AddPerson("George", 3); // Add George with 3 turns

        while (players.Length > 0) // Continue until the queue is empty
        {
            if (i >= expectedResult.Length) // Check if we have exhausted the expected results
            {
                Assert.Fail("Queue should have ran out of items by now."); // Fail if we have more items in the queue than expected
            }
            var person = players.GetNextPerson(); // Get the next person from the queue
            Assert.IsNotNull(person, "Person should not be null."); // Ensure person is not null
            Assert.AreEqual(expectedResult[i].Turns, person.Turns, "Turns should match expected value."); // Check turns match expected
            Assert.IsNotNull(person.Name, "Name should not be null."); // Ensure name is not null
            Assert.IsFalse(string.IsNullOrWhiteSpace(person.Name), "Name should not be empty or whitespace."); // Ensure name is not empty or whitespace
            Assert.AreEqual(expectedResult[i].Name, person.Name); // Check name matches expected
            i++; // Increment index for expected results
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_ForeverZero() // Test for zero infinite turns
    {
        var timTurns = 0; // Zero turns should be treated as infinite
        // Create a person with zero turns, which should be treated as infinite.

        var bob = new Person("Bob", 2); // Create a person with 2 turns
        
        var tim = new Person("Tim", timTurns); // Create a person with zero turns, which should be treated as infinite.
        // Zero turns should be treated as infinite, so we expect Tim to have infinite turns.
        var sue = new Person("Sue", 3); // Create a person with 3 turns

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim]; // Expected result array

        var players = new TakingTurnsQueue();  // Create a new TakingTurnsQueue instance
        players.AddPerson(bob.Name, bob.Turns); // Add Bob to the queue with 2 turns
        players.AddPerson(tim.Name, tim.Turns); // Add Tim to the queue with zero turns (infinite)
        players.AddPerson(sue.Name, sue.Turns); // Add Sue to the queue with 3 turns

        int i = 0;
        Person person = null;
        for (; i < 10; i++) // Loop to run the queue 10 times
        {
            person = players.GetNextPerson(); // Get the next person from the queue
            Assert.IsNotNull(person, "Person should not be null."); // Ensure person is not null
            Assert.AreEqual(expectedResult[i].Turns, person.Turns, "Turns should match expected value."); // Check turns match expected
            Assert.IsNotNull(person.Name, "Name should not be null."); // Ensure name is not null
            Assert.IsFalse(string.IsNullOrWhiteSpace(person.Name), "Name should not be empty or whitespace."); // Ensure name is not empty or whitespace
            Assert.AreEqual(expectedResult[i].Name, person.Name); // Check name matches expected
        }
        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson(); // Get the next person from the queue 
        Assert.IsNotNull(infinitePerson, "Infinite person should not be null."); // Ensure infinite person is not null
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite."); // Check that the turns of the infinite person match the expected zero turns
        Assert.IsNotNull(infinitePerson.Name, "Name should not be null."); // Ensure name is not null
        Assert.IsFalse(string.IsNullOrWhiteSpace(infinitePerson.Name), "Name should not be empty or whitespace."); // Ensure name is not empty or whitespace
        Assert.AreEqual(tim.Name, infinitePerson.Name); // Check name matches expected

        // Verify that the people with infinite turns really do have infinite turns.
        infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_ForeverNegative() // Test for negative infinite turns
    {
        var timTurns = -3; // Negative turns should be treated as infinite
        var tim = new Person("Tim", timTurns); // Create a person with negative turns
        // Negative turns should be treated as infinite, so we expect Tim to have infinite turns.
        var sue = new Person("Sue", 3); // Create a person with 3 turns

        Person[] expectedResult = [tim, sue, tim, sue, tim, sue, tim, tim, tim, tim]; // Expected result array

        var players = new TakingTurnsQueue(); // Create a new TakingTurnsQueue instance
        players.AddPerson(tim.Name, tim.Turns); // Add Tim to the queue with negative turns
        players.AddPerson(sue.Name, sue.Turns); // Add Sue to the queue with 3 turns

        for (int i = 0; i < 10; i++) //
        {
            var person = players.GetNextPerson(); // Get the next person from the queue
            Assert.IsNotNull(person, "Person should not be null."); // Ensure person is not null
            Assert.AreEqual(expectedResult[i].Turns, person.Turns, "Turns should match expected value."); // Check turns match expected
            Assert.IsNotNull(person.Name, "Name should not be null."); // Ensure name is not null
            Assert.IsFalse(string.IsNullOrWhiteSpace(person.Name), "Name should not be empty or whitespace."); // Ensure name is not empty or whitespace
            Assert.AreEqual(expectedResult[i].Name, person.Name); // Check name matches expected
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson(); // Get the next person from the queue
        Assert.IsNotNull(infinitePerson, "Infinite person should not be null."); // Ensure infinite person is not null
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite."); // Check that the turns of the infinite person match the expected negative turns
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_Empty() // Test for getting next person from an empty queue
    {
        var players = new TakingTurnsQueue(); // Create an empty queue

        try
        {
            players.GetNextPerson(); // Attempt to get the next person from an empty queue
            Assert.Fail("Exception should have been thrown.");// Fail if no exception is thrown
        }
        catch (InvalidOperationException e) // Catch the expected exception
        {
            Assert.AreEqual("No one in the queue.", e.Message); // Check if the exception message matches the expected message
        }
        catch (AssertFailedException) // Catch any assertion failures
        {
            throw; // Rethrow assertion failures to ensure they are not silently ignored
        }
        catch (Exception e) // Catch any other unexpected exceptions
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}", // Format the error message with the exception type and message
                e.GetType(), e.Message) // Ensure that only the expected InvalidOperationException is caught
            );
        }
    }
}