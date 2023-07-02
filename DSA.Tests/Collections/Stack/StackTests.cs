using Stacks = data_structures.Collections.Stacks;

namespace DSA.Tests.Collections.Stack
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void EmptyTest()
        {
            var stack = new Stacks.Stack<int>();

            Assert.IsTrue(stack.Empty());
        }

        [TestMethod]
        public void ClearTest()
        {
            var stack = new Stacks.Stack<int>(new[] { 0, 1, 2, 3, 4, 5, 6 });
            stack.Clear();

            Assert.IsTrue(stack.Empty());
        }

        [TestMethod]
        public void PeekTest()
        {
            var stack = new Stacks.Stack<int>(new[] { 0 });

            Assert.AreEqual(0, stack.Peek());
        }

        [TestMethod]
        public void PopTest()
        {
            var stack = new Stacks.Stack<int>(new[] { 0 });
            stack.Pop();

            Assert.IsTrue(stack.Empty());
        }

        [TestMethod]
        public void PushTest()
        {
            var stack = new Stacks.Stack<int>();
            stack.Push(0);

            Assert.AreEqual(0, stack.Peek());
        }
    }
}
