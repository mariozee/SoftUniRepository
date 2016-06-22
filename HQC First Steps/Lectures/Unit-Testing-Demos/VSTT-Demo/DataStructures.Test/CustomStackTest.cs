namespace DataStructures.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class CustomStackTest
    {
        [TestMethod]
        public void Push_EmptyStack_ShoudIncrement()
        {
            var stack = new CustomStack<int>();

            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(100, stack.Count);
        }

        [TestMethod]
        public void Resize_NonEmptyStack_ShouldDoubleItSize()
        {
            var stack = new CustomStack<int>(1);
            stack.Push(6);
            stack.Push(9);

            Assert.AreEqual((uint)2, stack.Capacity);
        }

        [TestMethod]
        public void Pop_NonEmptyStack_ReturnLastItem()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(11);
            stack.Push(111);

            var item = stack.Pop();

            Assert.AreEqual(111, item);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ShouldThrowException()
        {
            var stack = new CustomStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void Clear_NonEmptyStack_ShouldClearAll()
        {
            var stack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void Peek_NonemptyStack_ShouldReturnLastItem()
        {

        }
    }   
}
