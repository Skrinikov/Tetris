using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisProject;
using Microsoft.Xna.Framework;

namespace TetrisUnitTest
{
    [TestClass]
    public class ShapeSTest
    {
        [TestMethod]
        public void ShapeSLengthTest()
        {

            IBoard b = new Board();
            IShape shape = new ShapeS(b);

            int i = shape.Length;

            Assert.AreEqual(i, 4);

        }

        [TestMethod]
        public void ShapeSIndexerTest_working()
        {
            IBoard b = new Board();
            IShape shape = new ShapeS(b);

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
        public void ShapeSIndexerTest_exception()
        {
            IBoard b = new Board();
            IShape shape = new ShapeS(b);

            Block block = shape[999];
        }

        [TestMethod]
        public void ShapeSMoveLeftTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeS(b);

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
        public void ShapeSMoveRightTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeS(b);

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
        public void ShapeSMoveDownTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeS(b);

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
        public void ShapeSDropTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeS(b);

            shape.Drop();

            Point p = shape[0].Position;
            bool isOnGround = false;
            if (p.Y == 1 || p.Y == 0)
                isOnGround = true;

            Assert.IsTrue(isOnGround);

        }

        [TestMethod]
        public void ShapeSRotateTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeS(b);

            shape.MoveDown();
            shape.MoveDown();
            shape.MoveDown();

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;

            shape.Rotate();

            Point a0 = shape[0].Position;
            Point a1 = shape[1].Position;
            Point a2 = shape[2].Position;
            Point a3 = shape[3].Position;

            //Second rotation
            shape.Rotate();

            Point b0 = shape[0].Position;
            Point b1 = shape[1].Position;
            Point b2 = shape[2].Position;
            Point b3 = shape[3].Position;           

            //First rotation
            Assert.AreEqual(p0, a0);
            Assert.AreEqual(p1, new Point(a1.X + 1, a1.Y - 1));
            Assert.AreEqual(p2, new Point(a2.X - 1, a2.Y - 1));
            Assert.AreEqual(p3, new Point(a3.X - 2, a3.Y - 0));
            //Second Rotation
            Assert.AreEqual(a0, b0);
            Assert.AreEqual(a1, new Point(b1.X - 1, b1.Y + 1));
            Assert.AreEqual(a2, new Point(b2.X + 1, b2.Y + 1));
            Assert.AreEqual(a3, new Point(b3.X + 2, b3.Y));

        }

        [TestMethod]
        public void ShapeSResetTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeS(b);

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;

            shape.MoveDown();
            shape.MoveDown();
            shape.MoveLeft();
            shape.MoveLeft();
            shape.MoveDown();
            shape.Reset();

            Point a0 = shape[0].Position;
            Point a1 = shape[1].Position;
            Point a2 = shape[2].Position;
            Point a3 = shape[3].Position;

            Assert.AreEqual(p0, a0);
            Assert.AreEqual(p1, a1);
            Assert.AreEqual(p2, a2);
            Assert.AreEqual(p3, a3);

        }

    }
}
