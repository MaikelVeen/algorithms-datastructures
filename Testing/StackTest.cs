using System;
using Xunit;
using Data_Structures;

namespace Testing
{
    public class StackTest
    {
        [Fact]
        public void StackPush()
        {
            var stringStack = new Stack<string>();
            stringStack.Push("Test");
            
            Assert.Equal(stringStack.Peek(),"Test");
        }

        [Fact]
        public void StackPushSize()
        {
            var stringStack = new Stack<string>();
            stringStack.Push("Test");
            
            Assert.Equal(stringStack.Size(),1);
        }

        [Fact]
        public void StackPop()
        {
            var stringStack = new Stack<string>();
            stringStack.Push("Test");
            stringStack.Push("ExpectedValue");
            stringStack.Push("AnotherOne");
            stringStack.Pop();
            
            Assert.Equal(stringStack.Peek(),"ExpectedValue");
        }
        
        [Fact]
        public void StackPopSize()
        {
            var stringStack = new Stack<string>();
            stringStack.Push("Test");
            stringStack.Push("ExpectedValue");
            stringStack.Push("AnotherOne");
            stringStack.Pop();
            
            Assert.Equal(stringStack.Size(),2);
        }
        
        [Fact]
        public void StackPopEmpty()
        {
            var stringStack = new Stack<string>();
            Assert.Throws<Exception>(() => stringStack.Pop());
        }
    }
}