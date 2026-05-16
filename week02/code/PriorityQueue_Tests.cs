using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities, then dequeue them.
    // Expected Result: They should be dequeued in order of highest priority first.
    // Defect(s) Found: The loop condition was < _queue.Count - 1, meaning it skipped checking the last item in the queue. 
    // Additionally, the Dequeue method didn't actually remove the item from the queue, it just returned its value.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low Priority", 1);
        priorityQueue.Enqueue("High Priority", 10);
        priorityQueue.Enqueue("Medium Priority", 5);

        Assert.AreEqual("High Priority", priorityQueue.Dequeue());
        Assert.AreEqual("Medium Priority", priorityQueue.Dequeue());
        Assert.AreEqual("Low Priority", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same high priority.
    // Expected Result: They should be dequeued following FIFO rules (the one added first is removed first).
    // Defect(s) Found: The logic for finding the highest priority used >= instead of >, which caused it to select 
    // the item closer to the back of the queue (LIFO) instead of the front of the queue (FIFO) in the event of a tie.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First High", 10);
        priorityQueue.Enqueue("Second High", 10);
        priorityQueue.Enqueue("Low Priority", 1);
        priorityQueue.Enqueue("Third High", 10);

        Assert.AreEqual("First High", priorityQueue.Dequeue());
        Assert.AreEqual("Second High", priorityQueue.Dequeue());
        Assert.AreEqual("Third High", priorityQueue.Dequeue());
        Assert.AreEqual("Low Priority", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: Should throw an InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None found here. Exception handling was correctly implemented.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}