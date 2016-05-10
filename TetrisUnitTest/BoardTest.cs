using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisProject;
using Microsoft.Xna.Framework;

namespace TetrisUnitTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void BoardShapeTest()
        {
            IBoard board = new Board();

            IShape shape = board.Shape;

            Assert.IsNotNull(shape);
        }

        [TestMethod]
        public void BoardIndexerTest_Working()
        {
            IBoard board = new Board();

            Color c = board[9, 9];

            Assert.AreEqual(c, Color.Transparent);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void BoardIndexerTest_Exception()
        {
            IBoard board = new Board();

            Color c = board[998439, 43243299];
        }

        [TestMethod]
        public void BoardGetLengthTest()
        {
            IBoard board = new Board();

            int rank0 = board.GetLength(0);
            int rank1 = board.GetLength(1);
            int random = board.GetLength(-21321);

            Assert.AreEqual(rank0, 10);
            Assert.AreEqual(rank1, 20);
            Assert.AreEqual(random, 0);
        }

    }
}
