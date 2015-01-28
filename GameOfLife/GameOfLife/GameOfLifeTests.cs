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
            Assert.AreEqual("Alive", Ecosystem.GetCellStringValue(50, 50));
        }
        [TestMethod]
        public void TestCellIsDead()
        {
            Assert.AreEqual("Dead", Ecosystem.GetCellStringValue(1, 1));
        }
        [TestMethod]
        public void TestFewerThanTwoLiveNeighbors()
        {
            Ecosystem.runEcosystem();
            Assert.AreEqual("Dead", Ecosystem.GetCellStringValue(52, 51));
        }

        [TestMethod]
        public void TestExactlyThreeNeighbors()
        {
            Ecosystem.runEcosystem();
            Assert.AreEqual("Alive", Ecosystem.GetCellStringValue(51, 51));
        }
        [TestMethod]
        public void TestMoreThreeNeighbors()
        {
            Ecosystem.runEcosystem();
            Assert.AreEqual("Dead", Ecosystem.GetCellStringValue(55, 55));
        }

        [TestMethod]
        public void TestTwoOrThreeNeighbors()
        {
            Ecosystem.runEcosystem();
            Assert.AreEqual("Dead", Ecosystem.GetCellStringValue(52, 50));
        }
    }
}
