using Data_Structures;
using Xunit;

namespace Testing
{
    public class BinarySearchTreeTests
    {
        private BinarySearchTree<int> integerTree;
        private BinarySearchTree<string> stringTree;

        public BinarySearchTreeTests()
        {
            integerTree = new BinarySearchTree<int>();
            stringTree = new BinarySearchTree<string>();
        }
        
        #region Initialization Test
        
        [Fact]
        public void InitialSizeZero()
        {
            Assert.Equal(integerTree.Size, 0);
            Assert.Equal(stringTree.Size, 0);
        }
        
        [Fact]
        public void InitWithValue()
        {
            integerTree = new BinarySearchTree<int>(10);
            Assert.Equal(integerTree.Root.Value,10);
            Assert.Equal(integerTree.Size, 1);
        }
        
        [Fact]
        public void InitWithCollection()
        {
            integerTree = new BinarySearchTree<int>(new[]{10,5,15});
            Assert.Equal(integerTree.Root.Value,10);
            Assert.Equal(integerTree.Root.Left.Value,5);
            Assert.Equal(integerTree.Root.Right.Value,15);
            Assert.Equal(integerTree.Size, 3);
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
            Assert.Equal(integerTree.Root.Value, 10);
        }
        
        [Fact]
        public void InsertIncreasesSize()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);
            integerTree.Insert(21);
            Assert.Equal(integerTree.Size, 3);
        }

        [Fact]
        public void InsertGreaterThanRoot_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);
            Assert.Equal(integerTree.Root.Right.Value,15);
        }

        [Fact]
        public void InsertSmallerThanRoot_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(5);
            Assert.Equal(integerTree.Root.Left.Value,5);
        }
        
        [Fact]
        public void InsertLeftNestedLeft_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(5);
            
            integerTree.Insert(3);
            Assert.Equal(integerTree.Root.Left.Left.Value, 3);
        }
        
        [Fact]
        public void InsertLeftNestedRight_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(5);
            
            integerTree.Insert(7);
            Assert.Equal(integerTree.Root.Left.Right.Value, 7);
        }
        
        [Fact]
        public void InsertRightNestedLeft_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);
            
            integerTree.Insert(13);
            Assert.Equal(integerTree.Root.Right.Left.Value, 13);
        }
        
        [Fact]
        public void InsertRightNestedRight_Int()
        {
            integerTree.Insert(10);
            integerTree.Insert(15);
            
            integerTree.Insert(20);
            Assert.Equal(integerTree.Root.Right.Right.Value, 20);
        }

        #endregion
        
        
        #region Test Inserts Strings

        [Fact]
        public void InsertInEmptyBecomesRoot_String()
        {
            Assert.Null(stringTree.Root);
            stringTree.Insert("Echo");
            Assert.Equal(stringTree.Root.Value,"Echo");
        }
        
  
        [Fact]
        public void InsertGreaterThanRoot_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Golf");
            Assert.Equal(stringTree.Root.Right.Value,"Golf");
        }

        [Fact]
        public void InsertSmallerThanRoot_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Charlie");
            Assert.Equal(stringTree.Root.Left.Value,"Charlie");
        }
        
        [Fact]
        public void InsertLeftNestedLeft_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Charlie");
            
            stringTree.Insert("Beta");
            Assert.Equal(stringTree.Root.Left.Left.Value,"Beta");
        }
        
        [Fact]
        public void InsertLeftNestedRight_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Charlie");
            
            stringTree.Insert("Delta");
            Assert.Equal(stringTree.Root.Left.Right.Value,"Delta");
        }
        
        [Fact]
        public void InsertRightNestedLeft_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Golf");
            
            stringTree.Insert("Foxtrot");
            Assert.Equal(stringTree.Root.Right.Left.Value,"Foxtrot");
        }
        
        [Fact]
        public void InsertRightNestedRight_String()
        {
            stringTree.Insert("Echo");
            stringTree.Insert("Golf");
            
            stringTree.Insert("Hotel");
            Assert.Equal(stringTree.Root.Right.Right.Value,"Hotel");
        }

        #endregion
    }
}