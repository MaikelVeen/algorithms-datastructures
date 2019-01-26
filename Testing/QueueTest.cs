using System;
using Xunit;
using Data_Structures;

namespace Testing
{
    public class QueueTest
    {
        public QueueTest()
        {
            queue = new Queue<string>();
        }

        private readonly Queue<string> queue;

        [Fact]
        public void TestInit()
        {
            Assert.Null(queue.Peek());
            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void EnqueueOne()
        {
            queue.Enqueue("Alpha");
            Assert.Equal(1, queue.Count);
            Assert.Equal("Alpha", queue.Peek());
        }

        [Fact]
        public void EnqueueThree()
        {
            queue.Enqueue("Alpha");
            queue.Enqueue("Beta");
            queue.Enqueue("Charlie");
            Assert.Equal(3, queue.Count);
            Assert.Equal("Alpha", queue.Peek());
        }

        [Fact]
        public void DequeueOne()
        {
            queue.Enqueue("Alpha");
            queue.Dequeue();
            Assert.Null(queue.Peek());
            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void DequeueThree()
        {
            queue.Enqueue("Alpha");
            queue.Enqueue("Beta");
            queue.Enqueue("Charlie");

            Assert.Equal("Alpha", queue.Peek());
            queue.Dequeue();
            Assert.Equal("Beta", queue.Peek());
            queue.Dequeue();
            Assert.Equal("Charlie", queue.Peek());
            queue.Dequeue();
            Assert.Null(queue.Peek());
            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void TestContainsEmpty()
        {
            Assert.False(queue.Contains("Alpha"));
        }
        
        [Fact]
        public void TestContains()
        {
            queue.Enqueue("Alpha");
            Assert.True(queue.Contains("Alpha"));
        }
    }
}