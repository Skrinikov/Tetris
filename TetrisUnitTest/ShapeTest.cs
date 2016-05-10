using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisProject;
using Microsoft.Xna.Framework;

namespace TetrisUnitTest
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void ShapeLengthTest()
        {
            //Assert
            IShape shape = randomShape();

            int length = shape.Length;

            Assert.AreEqual(length, 4);

        }

        [TestMethod]
        public void ShapeIndexerTest_working()
        {
            IShape shape = randomShape();

            Block b0 = shape[0];
            Block b1 = shape[1];
            Block b2 = shape[2];
            Block b3 = shape[3];

            Assert.IsNotNull(b0);
            Assert.IsNotNull(b1);
            Assert.IsNotNull(b2);
            Assert.IsNotNull(b3);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void ShapeIndexerTest_Exception()
        {
            IShape shape = randomShape();
            Block b  = shape[828];

        }

        [TestMethod]
        public void ShapeMoveLeftTest()
        {
            IShape shape = randomShape();

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;

            shape.MoveLeft();
            Point a0 = shape[0].Position;
            Point a1 = shape[1].Position;
            Point a2 = shape[2].Position;
            Point a3 = shape[3].Position;

            Assert.AreEqual(p0.X, a0.X + 1);
            Assert.AreEqual(p1.X, a1.X + 1);
            Assert.AreEqual(p2.X, a2.X + 1);
            Assert.AreEqual(p3.X, a3.X + 1);
        }

        [TestMethod]
        public void ShapeMoveRightTest()
        {
            IShape shape = randomShape();

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;

            shape.MoveRight();
            Point a0 = shape[0].Position;
            Point a1 = shape[1].Position;
            Point a2 = shape[2].Position;
            Point a3 = shape[3].Position;

            Assert.AreEqual(p0.X, a0.X - 1);
            Assert.AreEqual(p1.X, a1.X - 1);
            Assert.AreEqual(p2.X, a2.X - 1);
            Assert.AreEqual(p3.X, a3.X - 1);

        }
        [TestMethod]
        public void ShapeMoveDownTest()
        {
            IShape shape = randomShape();

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;

            shape.MoveDown();
            Point a0 = shape[0].Position;
            Point a1 = shape[1].Position;
            Point a2 = shape[2].Position;
            Point a3 = shape[3].Position;

            Assert.AreEqual(p0.Y, a0.Y + 1);
            Assert.AreEqual(p1.Y, a1.Y + 1);
            Assert.AreEqual(p2.Y, a2.Y + 1);
            Assert.AreEqual(p3.Y, a3.Y + 1);
        }

        [TestMethod]
        public void ShapeDropTest()
        {
            IShape shape = randomShape();

            shape.Drop();

            Point p = shape[0].Position;
            bool isOnGround = false;
            if (p.Y == 1 || p.Y == 0)
                isOnGround = true;

            Assert.IsTrue(isOnGround);

        }
        private IShape randomShape()
        {
            Random r = new Random();
            int random = r.Next(0, 6);
            IShape current;
            IBoard board = new Board();
            switch (random)
            {
                case 0:
                    current = new ShapeT(board);
                    break;
                case 1:
                    current = new ShapeI(board);
                    break;
                case 2:
                    current = new ShapeJ(board);
                    break;
                case 3:
                    current = new ShapeL(board);
                    break;
                case 4:
                    current = new ShapeO(board);
                    break;
                case 5:
                    current = new ShapeS(board);
                    break;
                case 6:
                    current = new ShapeZ(board);
                    break;
                default:
                    current = new ShapeT(board);
                    break;
            }
            return current;
        }
    }
}
