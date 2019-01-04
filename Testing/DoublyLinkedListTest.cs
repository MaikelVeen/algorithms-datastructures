using Data_Structures;
using Xunit;

namespace Testing
{
    public class DoublyLinkedListTest
    {
        [Fact]
        public void InsertBegin()
        {
            var doubly = new DoublyLinkedList<string>("first");
            doubly.InsertBegin("inserted");
            
            Assert.Equal(doubly.Head.Value, "inserted");
            Assert.Equal(doubly.Tail.Value,"first");
        }
        
        [Fact]
        public void InsertBeginEmpty()
        {
            var doubly = new DoublyLinkedList<string>();
            doubly.InsertBegin("inserted");
            
            Assert.Equal(doubly.Head.Value, "inserted");
            Assert.Equal(doubly.Tail.Value, "inserted");
        }
        
        [Fact]
        public void InsertEnd()
        {
            var doubly = new DoublyLinkedList<string>("first");
            doubly.InsertEnd("inserted");
            
            Assert.Equal(doubly.Head.Value, "first");
            Assert.Equal(doubly.Tail.Value,"inserted");
        }
        
        [Fact]
        public void InsertEndEmpty()
        {
            var doubly = new DoublyLinkedList<string>();
            doubly.InsertEnd("inserted");
            
            Assert.Equal(doubly.Head.Value, "inserted");
            Assert.Equal(doubly.Tail.Value, "inserted");
        }
        
        [Fact]
        public void InsertBefore()
        {
            var doubly = new DoublyLinkedList<string>("first");
            doubly.InsertBefore(doubly.Head, "inserted");
            
            Assert.Equal(doubly.Head.Value, "inserted");
            Assert.Equal(doubly.Tail.Value, "first");
            
            doubly.InsertBefore(doubly.Head.Next, "second");
            Assert.Equal(doubly.Head.Next.Value, "second");
            
        }
        
        [Fact]
        public void InsertAfter()
        {
            var doubly = new DoublyLinkedList<string>("first");
           
            doubly.InsertAfter(doubly.Head, "inserted");
            
            Assert.Equal(doubly.Head.Value, "first");
            Assert.Equal(doubly.Tail.Value, "inserted");
            
            doubly.InsertAfter(doubly.Head.Next, "second");
            Assert.Equal(doubly.Tail.Value, "second");
        }
        
        
    }
}