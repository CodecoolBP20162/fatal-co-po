using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientWebFramework;
using NUnit.Framework;

namespace ClientWebFramework.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void asd()
        {
            int a = 1;
            int b = 1;
            Assert.AreEqual(a, b);
        }
    }
}
