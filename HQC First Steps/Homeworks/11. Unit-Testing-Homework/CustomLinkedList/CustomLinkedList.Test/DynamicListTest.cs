namespace CustomLinkedList.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class DynamicListTest
    {
        private DynamicList<int> linkedList;

        [TestInitialize]
        public void TestInitializeIndexGether()
        {
            this.linkedList = new DynamicList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexGether_EmptyList_ShouldThrow()
        {
            int num = this.linkedList[1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexSetter_EmptyList_ShouldThrow()
        {
            this.linkedList[1] = 69;
        }

        [TestMethod]
        public void Add_EmptyList_CoundShouldIncrement()
        {
            for (int i = 0; i < 100; i++)
            {
                this.linkedList.Add(i);
            }

            Assert.AreEqual(100, linkedList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_NonEmptyList_ShouldThrow()
        {
            for (int i = 0; i < 10; i++)
            {
                this.linkedList.Add(i);
            }

            linkedList.RemoveAt(11);
        }

        [TestMethod]
        public void RemoveAt_NonEmptyList_ShouldRemoveAndReturnCurrnetEllemnt()
        {
            const int ListCountAfterRemoveEllemnt = 1;

            this.linkedList.Add(14);
            this.linkedList.Add(41);

            int listCount = this.linkedList.Count;
            int removedElement = this.linkedList.RemoveAt(1);

            Assert.AreEqual(41, removedElement);
            Assert.AreEqual(ListCountAfterRemoveEllemnt, listCount - 1);
        }

        [TestMethod]
        public void Remove_NodeIsFound_ShouldReturnIndexAndRemoveItem()
        {
            const int ListCountAfterRemoveEllemnt = 1;

            this.linkedList.Add(14);
            this.linkedList.Add(41);

            int listCount = this.linkedList.Count;

            int index = linkedList.Remove(41);

            Assert.AreEqual(1, index);
            Assert.AreEqual(ListCountAfterRemoveEllemnt, listCount - 1);
        }

        [TestMethod]
        public void Remove_NodeIsNotFound_ShouldReturnMinus1()
        {
            this.linkedList.Add(14);
            this.linkedList.Add(41);

            int index = linkedList.Remove(50);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void IndexOf_NodeIsFound_ShouldReturnIndex()
        {
            this.linkedList.Add(14);
            this.linkedList.Add(41);

            int index = linkedList.IndexOf(41);

            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void IndexOf_NodeIsNotFound_ShouldReturnMinus1()
        {
            this.linkedList.Add(14);
            this.linkedList.Add(41);

            int index = linkedList.IndexOf(50);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void Contains_NonEmptyList_ShouldReturnTrue()
        {
            this.linkedList.Add(14);
            this.linkedList.Add(41);

            bool result = linkedList.Contains(14);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_EmptyList_ShouldReturnFalse()
        {
            bool result = linkedList.Contains(14);

            Assert.IsFalse(result);
        }
    }
}
