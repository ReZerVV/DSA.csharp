﻿using data_structures.Collections.Lists;

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

            DoublyLinkedList<int> list = new data_structures.Collections.Lists.DoublyLinkedList<int>();
            list.Add(expectedValue);

            Assert.AreEqual(expectedLength, list.Length);
            Assert.AreEqual(expectedValue, list[0]);
        }

        [TestMethod]
        public void ClearTest()
        {
            int expectedLength = 0;
            
            DoublyLinkedList<int> list = new data_structures.Collections.Lists.DoublyLinkedList<int>();
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Clear();

            Assert.AreEqual(expectedLength, list.Length);
        }

        [TestMethod]
        public void ContainsTest()
        {
            DoublyLinkedList<int> list = new data_structures.Collections.Lists.DoublyLinkedList<int>();
            list.Add(0);

            Assert.IsTrue(list.Contains(0));
        }

        [TestMethod]
        public void IndexOfTest()
        {
            DoublyLinkedList<int> list = new data_structures.Collections.Lists.DoublyLinkedList<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual(2, list.IndexOf(2));
        }

        [TestMethod]
        public void InsertTest()
        {

            DoublyLinkedList<int> list = new data_structures.Collections.Lists.DoublyLinkedList<int>();
            list.Add(0);
            list.Insert(0, 1);
            list.Insert(0, 2);

            Assert.AreEqual(3, list.Length);
            CollectionAssert.AreEqual(new[] { 0,2,1 }, list.ToArray());
        }

        [TestMethod]
        public void RemoveTest()
        {
            DoublyLinkedList<int> list = new data_structures.Collections.Lists.DoublyLinkedList<int>();
            list.Add(0);
            list.Remove(0);

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            DoublyLinkedList<int> list = new data_structures.Collections.Lists.DoublyLinkedList<int>();
            list.Add(0);
            list.RemoveAt(0);

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void EmptyTest()
        {
            DoublyLinkedList<int> list = new data_structures.Collections.Lists.DoublyLinkedList<int>();

            Assert.IsTrue(list.Empty());
        }
    }
}
