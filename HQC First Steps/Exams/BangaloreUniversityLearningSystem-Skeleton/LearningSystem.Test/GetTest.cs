using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningSystem.Data;

namespace LearningSystem.Test
{
    [TestClass]
    public class GetTest
    {
        [TestMethod]
        public void Get_ValidId()
        {
            Repository<string> repo = new Repository<string>();
            repo.Add("elementAtPos0");
            repo.Add("elementAtPos1");
            repo.Add("elementAtPos3");

            int id = 2;
            var element = repo.Get(id);

            Assert.AreEqual("elementAtPos1", element);
        }

        [TestMethod]
        public void Get_InvalidId_ItemShouldBeNull()
        {
            Repository<string> repo = new Repository<string>();
            repo.Add("elementAtPos0");
            int id = 2;
            var element = repo.Get(id);

            Assert.AreEqual(element, null);
        }
    }
}
