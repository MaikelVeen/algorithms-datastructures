using System;
using System.Text;
using Data_Structures;
using Xunit;

namespace Testing
{
    public class BinarySearchTreeTests
    {
        private BinarySearchTree<int> integerTree;
        private BinarySearchTree<string> stringTree;

        private readonly string[] traversalValues;
        private const string PreOrderExpected = "FBADCEGIH";
        private const string PostOrderExpected = "ACEDBHIGF";
        private const string InOrderExpected = "ABCDEFGHI";

        public BinarySearchTreeTests()
        {
            integerTree = new BinarySearchTree<int>();
            stringTree = new BinarySearchTree<string>();


            traversalValues = new[] {"F", "B", "G", "A", "D", "I", "C", "E", "H"};
        }

        #region Initialization Test

        [Fact]
        public void InitialSizeZero()
        {
            Assert.Equal(0, integerTree.Size);
            Assert.Equal(0, stringTree.Size);
        }

        [Fact]
        public void InitWithValue()
        {
            integerTree = new BinarySearchTree<int>(10);
            Assert.Equal(10, integerTree.Root.Value);
            Assert.Equal(1, integerTree.Size);
        }

        [Fact]
        public void InitWithCollection()
        {
            integerTree = new BinarySearchTree<int>(new[] {10, 5, 15});
            Assert.Equal(10, integerTree.Root.Value);
            Assert.Equal(5, integerTree.Root.Left.Value);
            Assert.Equal(15, integerTree.Root.Right.Value);
            Assert.Equal(3, integerTree.Size);
        }

        [Fact]
        public void RootParentIsNull()
        {
            integerTree = new BinarySearchTree<int>(10);
            Assert.Null(integerTree.Root.Parent);
        }

        #endregion

        #region Test Inserts Integers

        [Fact]
        public void InsertInEmptyBecomesRoot_Int()
        {
            Assert.Null(integerTree.Root);
            integerTree.Insert(10);
            Assert.Equal(10, integerTree.Root.Value);
        }

        [Fact]
        public void InsertIncreasesSize()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);
            integerTree.Insert(21);
            Assert.Equal(3, integerTree.Size);
        }

        [Fact]
        public void InsertGreaterThanRoot_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);
            Assert.Equal(15, integerTree.Root.Right.Value);
        }

        [Fact]
        public void InsertSmallerThanRoot_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(5);
            Assert.Equal(5, integerTree.Root.Left.Value);
        }

        [Fact]
        public void InsertLeftNestedLeft_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(5);

            integerTree.Insert(3);
            Assert.Equal(3, integerTree.Root.Left.Left.Value);
        }

        [Fact]
        public void InsertLeftNestedRight_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(5);

            integerTree.Insert(7);
            Assert.Equal(7, integerTree.Root.Left.Right.Value);
        }

        [Fact]
        public void InsertRightNestedLeft_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);

            integerTree.Insert(13);
            Assert.Equal(13, integerTree.Root.Right.Left.Value);
        }

        [Fact]
        public void InsertRightNestedRight_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);

            integerTree.Insert(20);
            Assert.Equal(20, integerTree.Root.Right.Right.Value);
        }

        #endregion

        #region Test Inserts Strings

        [Fact]
        public void InsertInEmptyBecomesRoot_String()
        {
            Assert.Null(stringTree.Root);
            stringTree.Insert("Echo");
            Assert.Equal("Echo", stringTree.Root.Value);
        }


        [Fact]
        public void InsertGreaterThanRoot_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Golf");
            Assert.Equal("Golf", stringTree.Root.Right.Value);
        }

        [Fact]
        public void InsertSmallerThanRoot_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Charlie");
            Assert.Equal("Charlie", stringTree.Root.Left.Value);
        }

        [Fact]
        public void InsertLeftNestedLeft_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Charlie");

            stringTree.Insert("Beta");
            Assert.Equal("Beta", stringTree.Root.Left.Left.Value);
        }

        [Fact]
        public void InsertLeftNestedRight_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Charlie");

            stringTree.Insert("Delta");
            Assert.Equal("Delta", stringTree.Root.Left.Right.Value);
        }

        [Fact]
        public void InsertRightNestedLeft_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Golf");

            stringTree.Insert("Foxtrot");
            Assert.Equal("Foxtrot", stringTree.Root.Right.Left.Value);
        }

        [Fact]
        public void InsertRightNestedRight_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Golf");

            stringTree.Insert("Hotel");
            Assert.Equal("Hotel", stringTree.Root.Right.Right.Value);
        }

        #endregion

        #region Traversal Tests

        [Fact]
        public void TestPreOrderTraversal()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringTree = new BinarySearchTree<string>(traversalValues);

            Assert.Equal(PreOrderExpected, stringTree.PreOrderTraversal(stringTree.Root, stringBuilder));
        }

        [Fact]
        public void TestPostOrderTraversal()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringTree = new BinarySearchTree<string>(traversalValues);

            Assert.Equal(PostOrderExpected, stringTree.PostOrderTraversal(stringTree.Root, stringBuilder));
        }

        [Fact]
        public void TestInOrderTraversal()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringTree = new BinarySearchTree<string>(traversalValues);

            Assert.Equal(InOrderExpected, stringTree.InOrderTraversal(stringTree.Root, stringBuilder));
        }

        [Fact]
        public void TestTraversalExceptions()
        {
            Assert.Throws<ArgumentException>(() => stringTree.InOrderTraversal(stringTree.Root, null));
            Assert.Throws<ArgumentException>(() => stringTree.PreOrderTraversal(stringTree.Root, null));
            Assert.Throws<ArgumentException>(() => stringTree.PostOrderTraversal(stringTree.Root, null));
        }

        #endregion

        #region Search and Contains tests

        [Fact]
        public void SearchEmpty()
        {
            Assert.Null(integerTree.Search(10));
        }

        [Fact]
        public void SearchLeft()
        {
            integerTree.Insert(10);
            integerTree.Insert(5);

            Node<int> foundNode = integerTree.Search(5);
            Assert.NotNull(foundNode);
            Assert.Equal(5, foundNode.Value);
        }

        [Fact]
        public void SearchRight()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);

            Node<int> foundNode = integerTree.Search(15);
            Assert.NotNull(foundNode);
            Assert.Equal(15, foundNode.Value);
        }

        [Fact]
        public void ContainsEmpty()
        {
            Assert.False(integerTree.Contains(10));
        }

        [Fact]
        public void ContainsLeft()
        {
            integerTree.Insert(10);
            integerTree.Insert(5);

            Assert.True(integerTree.Contains(5));
        }

        [Fact]
        public void ContainsRight()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);

            Assert.True(integerTree.Contains(15));
        }

        #endregion

        #region Deletion Tests

        [Fact]
        public void DeleteLeafTest()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.True(stringTree.DeleteValue("A",stringTree.Root));
            Assert.False(stringTree.Contains("A"));
        }

        [Fact]
        public void DeleteLeafTest2()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.True(stringTree.DeleteValue("H",stringTree.Root));
            Assert.False(stringTree.Contains("H"));
        }

        [Fact]
        public void DeleteLeafTest3()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.True(stringTree.DeleteValue("C",stringTree.Root));
            Assert.False(stringTree.Contains("C"));
        }

        [Fact]
        public void DeleteLeafTest4()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.True(stringTree.DeleteValue("E",stringTree.Root));
            Assert.False(stringTree.Contains("E"));
        }
        
        [Fact]
        public void DeleteNodeWithOneChild()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.True(stringTree.DeleteValue("I",stringTree.Root));
            Assert.False(stringTree.Contains("I"));
            Assert.Equal("H", stringTree.Root.Right.Right.Value);
        }

        [Fact]
        public void TestFindInOrderSuccesor()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.Equal("C", stringTree.FindInOrderSuccesor(stringTree.Root.Left).Value);
        }
        
        [Fact]
        public void TestFindInOrderSuccesor2()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.Equal("G", stringTree.FindInOrderSuccesor(stringTree.Root).Value);
        }
        
        [Fact]
        public void TestFindInOrderSuccesor3()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.Equal("E", stringTree.FindInOrderSuccesor(stringTree.Root.Left.Right).Value);
        }

        [Fact]
        public void TestDeleteWithTwoChildren1()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.True(stringTree.DeleteValue("B", stringTree.Root));
            Assert.Equal("C", stringTree.Root.Left.Value);
            Assert.Null(stringTree.Root.Left.Right.Left);
            Assert.False(stringTree.Contains("B"));
        }
        
        [Fact]
        public void TestDeleteWithTwoChildren2()
        {
            stringTree = new BinarySearchTree<string>(traversalValues);
            Assert.True(stringTree.DeleteValue("F", stringTree.Root));
            Assert.Equal("G", stringTree.Root.Value);
            Assert.False(stringTree.Contains("F"));
        }

        #endregion
    }
}