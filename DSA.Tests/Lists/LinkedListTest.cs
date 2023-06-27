namespace DSA.Tests.Lists
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void PushBack_LinkedList()
        {
            int expectedValue = 10;

            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushBack(expectedValue);

            Assert.AreEqual(expectedValue, list[0]);
        }

        [TestMethod]
        public void PushFront_LinkedList()
        {
            int expectedValue = 10;

            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushFront(expectedValue);

            Assert.AreEqual(expectedValue, list[0]);
        }

        [TestMethod]
        public void PopFront_LinkedList()
        {
            int expectedLength = 0;

            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushFront(10);
            list.PopFront();

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void Remove_Index_LinkedList()
        {
            int expectedLength = 0;
            int value = 10;
 
            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushFront(value);
            list.Remove(0);

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void Remove_Value_LinkedList()
        {
            int expectedLength = 0;
            int value = 10;

            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushFront(value);
            list.Remove(value:value);

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void Insert_LinkedList()
        {
            int expectedValue = 10;
            int index = 0;

            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushFront(0);
            list.Insert(index, expectedValue);
            list.PushBack(0);

            Assert.AreEqual(expectedValue, list[index + 1]);
        }

        [TestMethod]
        public void Length_LinkedList()
        {
            int expectedLength = 1;

            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushBack(10);

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void Empty_LinkedList()
        {
            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void Enumerable_LinkedList()
        {
            int[] expectedValues = { 0, 1, 2, 3, 4 };


            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushBack(expectedValues[0]);
            list.PushBack(expectedValues[1]);
            list.PushBack(expectedValues[2]);
            list.PushBack(expectedValues[3]);
            list.PushBack(expectedValues[4]);

            int index = 0;
            foreach (var item in list)
            {
                Assert.AreEqual(expectedValues[index], item);
                index += 1;
            }
        }
    }
}
