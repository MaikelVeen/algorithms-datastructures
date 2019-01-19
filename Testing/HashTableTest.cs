using System;
using Data_Structures;
using Xunit;

namespace Testing
{
    public class HashTableTest
    {
        [Fact]
        public void TestSizeInit()
        {
           HashMap<int, string> hashMap = new HashMap<int, string>(10);
           Assert.Equal(hashMap.Size, 10);
        }

        [Fact]
        public void TestPut()
        {
            HashMap<int, string> hashMap = new HashMap<int, string>(10);
            hashMap.Put(10, "Test");
            Assert.Equal(hashMap.Entries, 1);
        }

        [Fact]
        public void TestPutDuplicate()
        {
            HashMap<int, string> hashMap = new HashMap<int, string>(10);
            hashMap.Put(10, "Test");
            hashMap.Put(10, "Test2");
            Assert.Equal(hashMap.Entries, 2);
        }

        [Fact]
        public void TestGet()
        {
            HashMap<int, string> hashMap = new HashMap<int, string>(10);
            hashMap.Put(10, "Test");
            hashMap.Put(423432, "Test2");
            hashMap.Put(324, "Test3");

            string s = hashMap.GetValue(10);
            Assert.Equal("Test",s);
            
            string s1 = hashMap.GetValue(423432);
            Assert.Equal("Test2",s1);
            
            string s2 = hashMap.GetValue(324);
            Assert.Equal("Test3",s2);
            
        }

        [Fact]
        public void TestResize()
        {
            HashMap<int, string> hashMap = new HashMap<int, string>(10);
            hashMap.Put(1, "Test");
            hashMap.Put(2, "Test1");
            hashMap.Put(3, "Test2");
            hashMap.Put(4, "Test3");
            hashMap.Put(5, "Test4");
            hashMap.Put(6, "Test5");
            hashMap.Put(7, "Test6");
            Assert.Equal(hashMap.Entries, 7);
            Assert.Equal(hashMap.Size, 20);
        }
        
        [Fact]
        public void TestGettingNonExistant()
        {
            HashMap<int, string> hashMap = new HashMap<int, string>(10);
            Assert.Throws<Exception>(() => hashMap.GetValue(10));
        }
    }
}