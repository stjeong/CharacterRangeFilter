using Microsoft.VisualStudio.TestTools.UnitTesting;
using CharacterRangeFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRangeFilter.Tests
{
    [TestClass()]
    public class ThisAddInTests
    {
        [TestMethod()]
        public void HasChineseCharacters2MoreTest()
        {
            Assert.AreEqual(false, ThisAddIn.HasChineseCharacters2More(null));
            Assert.AreEqual(false, ThisAddIn.HasChineseCharacters2More(""));
            Assert.AreEqual(false, ThisAddIn.HasChineseCharacters2More("我"));
            Assert.AreEqual(true, ThisAddIn.HasChineseCharacters2More("我爱"));
            Assert.AreEqual(true, ThisAddIn.HasChineseCharacters2More("我爱你"));
        }
    }
}