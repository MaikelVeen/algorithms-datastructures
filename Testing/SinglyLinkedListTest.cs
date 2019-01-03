using Xunit;
using Data_Structures;

namespace Testing
{
    public class SinglyLinkedListTest
    {
        [Fact]
        public void TestSinglySearch()
        {
            var fourthNode = new LinkedListNode<int>()
            {
                Value = 50,
                Next = null
            };
            var thirdNode = new LinkedListNode<int>()
            {
                Value = 40,
                Next = fourthNode
            };

            var secondNode = new LinkedListNode<int>()
            {
                Value = 30,
                Next = thirdNode
            };

            var startNode = new LinkedListNode<int>()
            {
                Value = 20,
                Next = secondNode
            };

            var linkedList = new SinglyLinkedList<int>
            {
                Start = startNode
            };

            Assert.Equal(secondNode, linkedList.Find(30));
        }

        [Fact]
        public void TestSinglyInsert()
        {
            var secondNode = new LinkedListNode<int>()
            {
                Value = 30,
                Next = null
            };

            var startNode = new LinkedListNode<int>()
            {
                Value = 20,
                Next = secondNode
            };

            var linkedList = new SinglyLinkedList<int>
            {
                Start = startNode
            };

            linkedList.Insert(25);
            Assert.Equal(startNode.Next.Value, 25);
        }


        [Fact]
        public void TestSinglyInsertEmpty()
        {
            var linkedList = new SinglyLinkedList<int>
            {
                Start = null
            };

            linkedList.Insert(25);
            Assert.Equal(linkedList.Start.Value, 25);
        }

        [Fact]
        public void TestSinglyInsertBeforeStart()
        {
            var linkedList = new SinglyLinkedList<int>
            {
                Start = new LinkedListNode<int>()
                {
                    Value = 30,
                    Next = null
                }
            };

            linkedList.Insert(25);
            Assert.Equal(linkedList.Start.Value, 25);
        }

        [Fact]
        public void TestSinglyDelete()
        {
            var linkedList = new SinglyLinkedList<int>
            {
                Start = new LinkedListNode<int>()
                {
                    Value = 30,
                    Next = new LinkedListNode<int>()
                    {
                        Value = 40, Next = new LinkedListNode<int>()
                        {
                            Value = 50,
                            Next = null
                        }
                    }
                }
            };
            
            linkedList.RemoveValue(40);
            Assert.Equal(linkedList.Start.Next.Value,50);
        }

        [Fact]
        public void TestSinglyDeleteStart()
        {
            var linkedList = new SinglyLinkedList<int>
            {
                Start = new LinkedListNode<int>()
                {
                    Value = 30,
                    Next = null
                }
            };

            linkedList.RemoveValue(30);
            Assert.Null(linkedList.Start);
        }
    }
}