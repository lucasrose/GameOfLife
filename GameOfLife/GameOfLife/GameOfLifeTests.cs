using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife
{
    [TestClass]
    public class GameOfLifeTests
    {
        public static Int32 AliveCell = 1;
        public static Int32 DeadCell = 0;
        private GameOfLife Ecosystem;

        [TestInitialize]
        public void testSetup()
        {
            Ecosystem = new GameOfLife(100, 100);
        }
        [TestMethod]
        public void TestCellIsAlive()
        {
            Assert.AreEqual("Alive", Ecosystem.GetCellValue(50, 50));
        }
        [TestMethod]
        public void TestCellIsDead()
        {
            Assert.AreEqual("Dead", Ecosystem.GetCellValue(1, 1));
        }
        [TestMethod]
        public void TestFewerThanTwoLiveNeighbors()
        {
            Assert.IsTrue(false);
        } 
    }
}
