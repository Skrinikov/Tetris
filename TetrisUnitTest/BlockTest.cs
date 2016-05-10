using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using TetrisProject;

namespace TetrisUnitTest
{
    [TestClass]
    public class BlockTest
    {
        [TestMethod]
        public void BlockTryMoveLeftTest()
        {

            //Arrange
            IBoard board = new Board();
            IShape shape = board.Shape;
            

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(9,9);

            Block b2 = new Block(board, Color.Orange);
            b2.Position = new Point(0, 9);
            
            //Act
            bool t = b1.TryMoveLeft();
            bool f1 = b2.TryMoveLeft();

            //Assert
            Assert.IsTrue(t);
            Assert.IsFalse(f1);

        }

        [TestMethod]
        public void BlockMoveLefTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(9, 9);

            b1.MoveLeft();

            Assert.AreEqual(b1.Position.X, 8);
        }

        [TestMethod]
        public void BlockTryMoveRightTest()
        {
            //Arrange
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(5, 9);

            Block b2 = new Block(board, Color.Orange);
            b2.Position = new Point(9, 9);

            //Act
            bool t = b1.TryMoveRight();
            bool f1 = b2.TryMoveRight();

            //Assert
            Assert.IsTrue(t);
            Assert.IsFalse(f1);
        }

        [TestMethod]
        public void BlockMoveRightTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(5, 9);

            b1.MoveRight();

            Assert.AreEqual(b1.Position.X, 6);
        }

        [TestMethod]
        public void BlockTryMoveDownTest()
        {

            //Arrange
            IBoard board = new Board();
            IShape shape = board.Shape;
            shape.Drop();

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(5, 9);

            Block b2 = new Block(board, Color.Orange);
            b2.Position = new Point(5, 0);

            //Act
            bool t = b1.TryMoveDown();
            bool f1 = b2.TryMoveDown();

            //Assert
            Assert.IsTrue(t);
            Assert.IsFalse(f1);

        }

        [TestMethod]
        public void BlockMoveDownTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(5, 9);

            b1.MoveDown();

            Assert.AreEqual(b1.Position.Y, 8);
        }

        [TestMethod]
        public void BlockColorTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b1 = new Block(board, Color.Orange);

            Assert.AreEqual(b1.Color, Color.Orange);
        }

        [TestMethod]
        public void BlockPositionTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(5, 5);

            Assert.AreEqual(b1.Position, new Point(5, 5));
        }

        [TestMethod]
        public void BlockTryRotateTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(5, 5);
            Block b2 = new Block(board, Color.Pink);
            b2.Position = new Point(0, 0);

            bool t = b1.TryRotate(new Point(-1, 1));
            bool f = b2.TryRotate(new Point(-1,-1));

            Assert.IsTrue(t);
            Assert.IsFalse(f);
        }
        [TestMethod]
        public void BlockRotateTest()
        {
            IBoard board = new Board();

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(5, 5);

            b1.Rotate(new Point(-1, 1));

            Assert.AreEqual(b1.Position, new Point(4, 6));
        }

        [TestMethod]
        public void BlockCompareToTest()
        {

            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b1 = new Block(board, Color.Orange);
            b1.Position = new Point(5, 5);

            Block b2 = new Block(board, Color.Orange);
            b2.Position = new Point(4, 5);

            Block b3 = new Block(board, Color.Orange);
            b3.Position = new Point(6, 6);

            int less1 = b2.CompareTo(b1);
            int less2 = b1.CompareTo(b3);
            int equal = b1.CompareTo(b1);
            int more = b3.CompareTo(b2);

            Assert.IsTrue(less1 < 0);
            Assert.IsTrue(less2 < 0);
            Assert.IsTrue(equal == 0);
            Assert.IsTrue(more > 0);


        }
    }
}
