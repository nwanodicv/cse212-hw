using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PriorityQueueTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        // Scenario: Enqueue a single item and Dequeue it.
        // Expected Result: The same item is returned.
        // Defect(s) Found: None
        public void TestPriorityQueue_SingleItem() // Scenario: Enqueue a single item and Dequeue it.
        {
            var priorityQueue = new PriorityQueue(); // Create a new instance of the PriorityQueue
            priorityQueue.Enqueue("Apple", 5); // Enqueue a single item with priority 5
            var result = priorityQueue.Dequeue(); // Dequeue the item
            Assert.AreEqual("Apple", result); // Assert that the dequeued item is the same as the enqueued item
        }

        [TestMethod]
        // Scenario: Enqueue multiple items with different priorities and Dequeue.
        // Expected Result: The highest priority item is dequeued.
        // Defect(s) Found: None
        public void TestPriorityQueue_HighestPriorityItem() // Scenario: Enqueue multiple items with different priorities and Dequeue.
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("Apple", 1); // Enqueue item with priority 1
            priorityQueue.Enqueue("Banana", 3); // Enqueue item with priority 3
            priorityQueue.Enqueue("Cherry", 2); // Enqueue item with priority 2

            var result = priorityQueue.Dequeue();
            Assert.AreEqual("Banana", result); // Banana has the highest priority (3)
        }

        [TestMethod]
        // Scenario: Enqueue multiple items with the same highest priority.
        // Expected Result: The first one enqueued among them is dequeued (FIFO)
        // Defect(s) Found: None
        public void TestPriorityQueue_SamePriorityFIFO()
        {
            var priorityQueue = new PriorityQueue(); // Create a new instance of the PriorityQueue
            priorityQueue.Enqueue("Apple", 5); // Enqueue multiple items with the same priority
            priorityQueue.Enqueue("Banana", 5); // Enqueue another item with the same priority
            priorityQueue.Enqueue("Cherry", 5); // Enqueue yet another item with the same priority

            var result = priorityQueue.Dequeue(); // Dequeue the first item
            Assert.AreEqual("Apple", result); // Assert that the first item enqueued is returned

            result = priorityQueue.Dequeue(); // Dequeue the next item
            Assert.AreEqual("Banana", result); // Assert that the second item enqueued is returned

            result = priorityQueue.Dequeue(); // Dequeue the last item
            Assert.AreEqual("Cherry", result); // Assert that the last item enqueued is returned
        }

        [TestMethod]
        // Scenario: Dequeue from empty queue.
        // Expected Result: InvalidOperationException thrown.
        // Defect(s) Found: None
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPriorityQueue_EmptyQueueException()
        {
            var priorityQueue = new PriorityQueue(); // Create a new instance of the PriorityQueue
            priorityQueue.Dequeue(); // Attempt to dequeue from an empty queue, which should throw an exception
        }
    }
}
