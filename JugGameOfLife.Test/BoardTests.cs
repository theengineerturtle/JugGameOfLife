using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using JugGameOfLife;

namespace JugGameOfLife.Test
{
    [TestFixture]
    public class BoardTests
    {
        private Board board;

        [SetUp]
        public void Setup()
        {
            board = new Board(5, 5);
        }

        [Test]
        public void GetCellValue()
        {
            bool status = board.GetCellValue(2, 2);
            Assert.IsFalse(status);
        }

        [Test]
        public void SetCellValue()
        {
            board.SetCellValue(true, 2, 2);
            bool status = board.GetCellValue(2, 2);
            Assert.IsTrue(status);
        }

        [Test]
        public void GetAliveNeighborsCounts_CellIntheMiddle()
        {
            board.SetCellValue(true, 1, 1);
            board.SetCellValue(true, 1, 2);
            board.SetCellValue(true, 3, 3);

            int count = board.getNeighborCounts(2,2);
            Assert.AreEqual(3,count);
        }


        [Test]
        public void GetAliveNeighborsCounts_CellInTheMiddleExceptItself()
        {
            board.SetCellValue(true, 1, 1);
            board.SetCellValue(true, 1, 2);
            board.SetCellValue(true, 2, 2);
            board.SetCellValue(true, 3, 3);

            int count = board.getNeighborCounts(2, 2);
            Assert.AreEqual(3,count);
        }


        [Test]
        public void GetAliveNeighborsCounts_CellOntheLeftTopCorner()
        {
            board.SetCellValue(true, 0, 1);

            int count = board.getNeighborCounts(0, 0);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void GetAliveNeighborsCounts_CellOntheRightTopCorner()
        {
            board.SetCellValue(true, 0, 3);
            int count = board.getNeighborCounts(0, 4);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void GetAliveNeighborsCount_CellOnTheLeftDownCorner()
        {
            board.SetCellValue(true, 4, 1);
            int count = board.getNeighborCounts(4, 0);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void GetAliveNeighborsCount_CellOnTheRightDownCorner()
        {
            board.SetCellValue(true, 3, 4);
            int count = board.getNeighborCounts(4, 4);
            Assert.AreEqual(1, count);
        }

    }
}
