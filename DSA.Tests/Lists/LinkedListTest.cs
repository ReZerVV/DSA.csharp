namespace DSA.Tests.Lists
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void PushBack_LinkedList()
        {
            int expectedValue = 10;
            int expectedLength = 1;
            
            data_structures.Lists.LinkedList<int> list = new data_structures.Lists.LinkedList<int>();
            list.PushBack(expectedValue);

            Assert.AreEqual(expectedLength, list.Length);
            Assert.AreEqual(expectedValue, list[0]);
        }
    }
}
