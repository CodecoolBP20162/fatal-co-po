using ClientWebFramework.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Web.Tests
{
    [TestFixture]
    public class WebTest
    {
        [Test]
        public void LoadComputersIsEmpty()
        {
            //ComputerController computer = new ComputerController();
            string result = null;
            Assert.AreEqual(result, Is.Empty);
        }
    }
}
