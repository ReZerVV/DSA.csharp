using Custom.Collections.List;

namespace Dsa.Tests
{
    [TestClass]
    public class SinglyLinkedList
    {
        [TestMethod]
        public void Add()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(1);

            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod]
        public void Clear()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(1);
            list.Clear();

            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void Contains()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(1);

            Assert.IsTrue(list.Contains(1));
        }

        [TestMethod]
        public void IndexOf()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(1);

            Assert.AreEqual(list.IndexOf(1), 0);
        }

        [TestMethod]
        public void Insert()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(1);

            Assert.AreEqual(list.IndexOf(1), 0);
        }

        [TestMethod]
        public void Remove()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(1);
            list.Remove(1);
            list.Add(2);
            list.Add(1);
            list.Add(2);
            list.Remove(1);

            Assert.IsFalse(list.Contains(1));
        }

        [TestMethod]
        public void RemoveAt()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(1);
            list.RemoveAt(0);
            list.Add(2);
            list.Add(1);
            list.Add(2);
            list.RemoveAt(1);

            Assert.IsFalse(list.Contains(1));
        }
    }
}
