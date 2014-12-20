using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychicPoker.Infrastructure;
using System.IO;

namespace PsychicPoker.Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ParseDefaultCardSet()
        {
            var parser = new Parser();
            var cards = parser.Parse(new StreamReader(File.OpenRead("testfile.csv")));

            Assert.AreEqual(9, cards.Count);

            Assert.AreEqual(11, cards[0].Count);
        }
    }
}
