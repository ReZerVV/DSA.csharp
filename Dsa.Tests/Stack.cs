
namespace Dsa.Tests
{
    [TestClass]
    public class Stack
    {
        [TestMethod]
        public void Push()
        {
            var stack = new Custom.Collections.Stack<int>();
            stack.Push(1);

            Assert.AreEqual(stack.Peek(), 1);
        }

        [TestMethod]
        public void Pop()
        {
            var stack = new Custom.Collections.Stack<int>();
            stack.Push(1);
            stack.Pop();

            Assert.IsTrue(stack.Empty());
        }
    }
}
