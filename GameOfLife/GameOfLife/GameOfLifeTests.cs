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
        private GameOfLife ecosystem;

        [TestInitialize]
        public void testSetup()
        {
            ecosystem = new GameOfLife(4, 4);
        }
        [TestMethod]
        public void TestCellIsAlive()
        {
            Assert.AreEqual("Alive", ecosystem.GetCellValue(2, 2));
        }
        [TestMethod]
        public void TestCellIsDead()
        {
            Assert.AreEqual("Dead", ecosystem.GetCellValue(1, 1));
        }
        [TestMethod]
        public void TestFewerThanTwoLiveNeighbors()
        {
            
            Assert.IsTrue(false);
        } 
    }
}
