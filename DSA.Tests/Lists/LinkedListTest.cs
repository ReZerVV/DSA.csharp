namespace DSA.Tests.Lists
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddTest()
        {
            int expectedLength = 1;
            int expectedValue = 10;

            var list = new data_structures.Collections.Lists.LinkedList<int>();
            list.Add(expectedValue);

            Assert.AreEqual(expectedLength, list.Length);
            Assert.AreEqual(expectedValue, list[0]);
        }

        [TestMethod]
        public void ClearTest()
        {
            int expectedLength = 0;
            
            var list = new data_structures.Collections.Lists.LinkedList<int>();
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Clear();

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void ContainsTest()
        {
            var list = new data_structures.Collections.Lists.LinkedList<int>();
            list.Add(0);

            Assert.IsTrue(list.Contains(0));
        }

        [TestMethod]
        public void IndexOfTest()
        {
            int expectedIndex = 2;

            var list = new data_structures.Collections.Lists.LinkedList<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(expectedIndex, list.IndexOf(2));
        }

        [TestMethod]
        public void InsertTest()
        {
            int expectedLength = 3;

            var list = new data_structures.Collections.Lists.LinkedList<int>();
            list.Insert(0, 0);
            list.Insert(0, 1);
            list.Insert(0, 2);

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var list = new data_structures.Collections.Lists.LinkedList<int>();
            list.Add(0);
            list.Remove(0);

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            var list = new data_structures.Collections.Lists.LinkedList<int>();
            list.Add(0);
            list.RemoveAt(0);

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void EmptyTest()
        {
            var list = new data_structures.Collections.Lists.LinkedList<int>();

            Assert.IsTrue(list.Empty());
        }
    }
}
