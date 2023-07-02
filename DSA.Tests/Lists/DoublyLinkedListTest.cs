namespace DSA.Tests.Lists
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void AddTest()
        {
            int expectedLength = 1;
            int expectedValue = 10;

            data_structures.Lists.DoublyLinkedList<int> list = new data_structures.Lists.DoublyLinkedList<int>();
            list.Add(expectedValue);

            Assert.AreEqual(expectedLength, list.Length);
            Assert.AreEqual(expectedValue, list[0]);
        }

        [TestMethod]
        public void ClearTest()
        {
            int expectedLength = 0;
            
            data_structures.Lists.DoublyLinkedList<int> list = new data_structures.Lists.DoublyLinkedList<int>();
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Clear();

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void ContainsTest()
        {
            data_structures.Lists.DoublyLinkedList<int> list = new data_structures.Lists.DoublyLinkedList<int>();
            list.Add(0);

            Assert.IsTrue(list.Contains(0));
        }

        [TestMethod]
        public void IndexOfTest()
        {
            int expectedIndex = 2;

            data_structures.Lists.DoublyLinkedList<int> list = new data_structures.Lists.DoublyLinkedList<int>();
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

            data_structures.Lists.DoublyLinkedList<int> list = new data_structures.Lists.DoublyLinkedList<int>();
            list.Insert(0, 0);
            list.Insert(0, 1);
            list.Insert(0, 2);

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void RemoveTest()
        {
            data_structures.Lists.DoublyLinkedList<int> list = new data_structures.Lists.DoublyLinkedList<int>();
            list.Add(0);
            list.Remove(0);

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            data_structures.Lists.DoublyLinkedList<int> list = new data_structures.Lists.DoublyLinkedList<int>();
            list.Add(0);
            list.RemoveAt(0);

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void EmptyTest()
        {
            data_structures.Lists.DoublyLinkedList<int> list = new data_structures.Lists.DoublyLinkedList<int>();

            Assert.IsTrue(list.Empty());
        }
    }
}
