namespace DSA.Tests.Algorithms
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void InsertionSortTest()
        {
            int[] expectedCollection = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] actualCollection = algorithms.Sorting.Sort<int>.Insertion(new int[]{ 4, 6, 8, 2, 1, 3, 5, 7, 9 });
 
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
