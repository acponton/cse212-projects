using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities.
    // Expected Result: The item with the highest priority is dequeued first.
    // Defect(s) Found: none.
    public void Test_HighestPriorityDequeued()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        var Result = priorityQueue.Dequeue();
        Assert.AreEqual("High", Result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: The first item (FIFO) with the highest priority is dequeued.
    // Defect(s) Found: 
    public void Test_FIFO_WithSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 10);

        var Result = priorityQueue.Dequeue();
        Assert.AreEqual("First", Result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with correct message is thrown.
    // Defect(s) Found: none.
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue(); // Should throw
    }

    [TestMethod]
    // Scenario: Multiple dequeue operations continue to return correct items in order.
    // Expected Result: Items returned in priority order, then FIFO within same priority.
    // Defect(s) Found: 
    public void Test_SequentialDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);

        Assert.AreEqual("C", priorityQueue.Dequeue()); // Highest priority (3)
        Assert.AreEqual("B", priorityQueue.Dequeue()); // Next highest (2), FIFO
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Same priority as B, comes next
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Last one
    }

}