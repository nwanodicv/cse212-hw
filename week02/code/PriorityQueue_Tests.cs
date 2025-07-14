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
        public void TestPriorityQueue_SingleItem()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("Apple", 5);
            var result = priorityQueue.Dequeue();
            Assert.AreEqual("Apple", result);
        }

        [TestMethod]
        // Scenario: Enqueue multiple items with different priorities and Dequeue.
        // Expected Result: The highest priority item is dequeued.
        // Defect(s) Found: None
        public void TestPriorityQueue_HighestPriorityItem()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("Apple", 1);
            priorityQueue.Enqueue("Banana", 3);
            priorityQueue.Enqueue("Cherry", 2);

            var result = priorityQueue.Dequeue();
            Assert.AreEqual("Banana", result);
        }

        [TestMethod]
        // Scenario: Enqueue multiple items with the same highest priority.
        // Expected Result: The first one enqueued among them is dequeued (FIFO)
        // Defect(s) Found: None
        public void TestPriorityQueue_SamePriorityFIFO()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("Apple", 5);
            priorityQueue.Enqueue("Banana", 5);
            priorityQueue.Enqueue("Cherry", 5);

            var result = priorityQueue.Dequeue();
            Assert.AreEqual("Apple", result);

            result = priorityQueue.Dequeue();
            Assert.AreEqual("Banana", result);

            result = priorityQueue.Dequeue();
            Assert.AreEqual("Cherry", result);
        }

        [TestMethod]
        // Scenario: Dequeue from empty queue.
        // Expected Result: InvalidOperationException thrown.
        // Defect(s) Found: None
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPriorityQueue_EmptyQueueException()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Dequeue();
        }
    }
}
