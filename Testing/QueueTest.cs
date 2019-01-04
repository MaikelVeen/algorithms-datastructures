using System;
using Xunit;
using Data_Structures;

namespace Testing
{
    public class QueueTest
    {
        [Fact]
        public void Test()
        {
            var queue = new Queue<string>();
            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            
            Assert.Equal(queue.Peek(), "1");
            
            queue.Dequeue();
            Assert.Equal(queue.Peek(), "2");
            
            queue.Dequeue();
            Assert.Equal(queue.Peek(), "3");
            
            queue.Dequeue();
            Assert.Throws<System.NullReferenceException>(() => queue.Peek());
        }
    }
}