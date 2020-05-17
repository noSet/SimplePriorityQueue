using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimplePriorityQueue.Tests
{
    [TestClass()]
    public class PriorityQueueTests
    {
        [TestMethod()]
        public void EnqueueTest()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(0);
            Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Enqueue(0));
        }

        [TestMethod()]
        public void EnqueueTest1()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(3);

            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(4);
        }

        [TestMethod()]
        public void DequeueTest()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(0);
            Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        }

        [TestMethod()]
        public void DequeueTest1()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(7);

            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(4);
            priorityQueue.Enqueue(8);
            priorityQueue.Enqueue(4);
            priorityQueue.Enqueue(2);

            Assert.AreEqual(1, priorityQueue.Dequeue());
            Assert.AreEqual(5, priorityQueue.Count);
        }

        [TestMethod()]
        public void PeekTest()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(0);
            Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Peek());
        }

        [TestMethod()]
        public void PeekTest1()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(3);

            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(4);

            Assert.AreEqual(1, priorityQueue.Peek());
            Assert.AreEqual(3, priorityQueue.Count);
        }

        [TestMethod()]
        public void ClearTest()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(3);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(1);

            priorityQueue.Clear();

            Assert.AreEqual(0, priorityQueue.Count);
        }
    }
}