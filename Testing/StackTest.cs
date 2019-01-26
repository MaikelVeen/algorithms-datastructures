using System;
using Xunit;
using Data_Structures;

namespace Testing
{
    public class StackTest
    {
        public StackTest()
        {
            stringStack = new Stack<string>();
        }

        private readonly Stack<string> stringStack;

        [Fact]
        public void StackPush()
        {
            stringStack.Push("Alpha");
            Assert.Equal("Alpha", stringStack.Peek());
        }

        [Fact]
        public void StackPushSize()
        {
            stringStack.Push("Alpha");
            Assert.Equal(1, stringStack.Count);
        }

        [Fact]
        public void StackPushSizeMultiple()
        {
            stringStack.Push("Alpha");
            stringStack.Push("Beta");
            stringStack.Push("Charlie");
            Assert.Equal(3, stringStack.Count);
        }

        [Fact]
        public void StackPop()
        {
            stringStack.Push("Alpha");
            stringStack.Push("Beta");
            stringStack.Push("Charlie");
            Assert.Equal("Charlie", stringStack.Pop());
            Assert.Equal("Beta", stringStack.Peek());
        }

        [Fact]
        public void StackPopSize()
        {
            stringStack.Push("Alpha");
            stringStack.Push("Beta");
            stringStack.Push("Charlie");
            stringStack.Pop();
            Assert.Equal(2, stringStack.Count);
        }

        [Fact]
        public void StackPopEmpty()
        {
            Assert.Throws<Exception>(() => stringStack.Pop());
        }
    }
}