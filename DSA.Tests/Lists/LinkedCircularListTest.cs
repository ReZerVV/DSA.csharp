namespace DSA.Tests.Lists
{
    [TestClass]
    public class LinkedCircularListTests
    {
        [TestMethod]
        public void AddTest() 
        {
            data_structures.Lists.LinkedCircularList<int> list = new data_structures.Lists.LinkedCircularList<int>();
            list.Add(0);
            list.Add(0);
            list.Add(0);

            Assert.AreEqual(3, list.Length);
        }

        [TestMethod]
        public void ClearTest()
        {
            data_structures.Lists.LinkedCircularList<int> list = new data_structures.Lists.LinkedCircularList<int>();
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Clear();

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void ContainsTest()
        {
            data_structures.Lists.LinkedCircularList<int> list = new data_structures.Lists.LinkedCircularList<int>();
            list.Add(10);
            list.Add(10);
            list.Add(10);

            Assert.IsTrue(list.Contains(10));
        }

        [TestMethod]
        public void IndexOfTest()
        {
            data_structures.Lists.LinkedCircularList<int> list = new data_structures.Lists.LinkedCircularList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);

            Assert.AreEqual(0, list.IndexOf(1));
        }

        [TestMethod]
        public void InsertTest()
        {
            data_structures.Lists.LinkedCircularList<int> list = new data_structures.Lists.LinkedCircularList<int>();
            list.Insert(0, 1);
            list.Insert(0, 1);
            list.Insert(0, 1);

            Assert.AreEqual(3, list.Length);
        }

        [TestMethod]
        public void RemoveTest()
        {
            data_structures.Lists.LinkedCircularList<int> list = new data_structures.Lists.LinkedCircularList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Remove(1);
            list.Remove(1);
            list.Remove(1);

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            data_structures.Lists.LinkedCircularList<int> list = new data_structures.Lists.LinkedCircularList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.RemoveAt(2);
            list.RemoveAt(1);
            list.RemoveAt(0);

            Assert.IsTrue(list.Empty());
        }

        [TestMethod]
        public void EmptyTest()
        {
            data_structures.Lists.LinkedCircularList<int> list = new data_structures.Lists.LinkedCircularList<int>();
            
            Assert.IsTrue(list.Empty());
        }
    }
}
