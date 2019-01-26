using Data_Structures;
using Xunit;

namespace Testing
{
    /// <summary>
    /// Contains tests for Doubly linked lists
    /// </summary>
    public class DoublyLinkedListTest
    {
        public DoublyLinkedListTest()
        {
            linkedList = new DoublyLinkedList<string>("Alpha");
        }

        private DoublyLinkedList<string> linkedList;

        [Fact]
        public void TestEmptyInit()
        {
            linkedList = new DoublyLinkedList<string>();
            Assert.Null(linkedList.Head);
            Assert.Null(linkedList.Tail);
        }

        [Fact]
        public void InsertBegin()
        {
            Assert.Equal("Alpha", linkedList.Head.Value);
            Assert.Equal("Alpha", linkedList.Tail.Value);
        }

        [Fact]
        public void InsertBeginEmpty()
        {
            linkedList = new DoublyLinkedList<string>();
            linkedList.InsertBegin("Alpha");
            Assert.Equal("Alpha", linkedList.Head.Value);
            Assert.Equal("Alpha", linkedList.Tail.Value);
        }

        [Fact]
        public void InsertEnd()
        {
            linkedList.InsertEnd("Beta");
            Assert.Equal("Alpha", linkedList.Head.Value);
            Assert.Equal("Beta", linkedList.Tail.Value);
        }

        [Fact]
        public void InsertEndEmpty()
        {
            linkedList.InsertEnd("Alpha");
            Assert.Equal("Alpha", linkedList.Head.Value);
            Assert.Equal("Alpha", linkedList.Tail.Value);
        }

        [Fact]
        public void InsertBefore()
        {
            linkedList.InsertBefore(linkedList.Head, "Before");
            Assert.Equal("Before", linkedList.Head.Value);
            Assert.Equal("Alpha", linkedList.Tail.Value);

            linkedList.InsertBefore(linkedList.Head.Next, "Second");
            Assert.Equal("Second", linkedList.Head.Next.Value);
        }

        [Fact]
        public void InsertAfter()
        {
            linkedList.InsertAfter(linkedList.Head, "Beta");
            Assert.Equal("Beta", linkedList.Head.Next.Value);

            linkedList.InsertAfter(linkedList.Head, "Charlie");
            Assert.Equal("Charlie", linkedList.Head.Next.Value);
            Assert.Equal("Beta", linkedList.Head.Next.Next.Value);
        }
        
        //TODO add tests for insert after and insert before when linked list is empty
    }
}