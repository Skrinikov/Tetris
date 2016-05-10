using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisProject;
using Microsoft.Xna.Framework;

namespace TetrisUnitTest
{
    [TestClass]
    public class ShapeJTest
    {
        [TestMethod]
        public void ShapeJLengthTest()
        {

            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

            int i = shape.Length;

            Assert.AreEqual(i, 4);

        }

        [TestMethod]
        public void ShapeJIndexerTest_working()
        {
            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

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
        public void ShapeJIndexerTest_exception()
        {
            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

            Block block = shape[999];
        }

        [TestMethod]
        public void ShapeJMoveLeftTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

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
        public void ShapeJMoveRightTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

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
        public void ShapeJMoveDownTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

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
        public void ShapeJDropTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

            shape.Drop();

            Point p = shape[0].Position;
            bool isOnGround = false;
            if (p.Y == 1 || p.Y == 0)
                isOnGround = true;

            Assert.IsTrue(isOnGround);

        }

        [TestMethod]
        public void ShapeJRotateTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

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

            //Third rotation
            shape.Rotate();

            Point c0 = shape[0].Position;
            Point c1 = shape[1].Position;
            Point c2 = shape[2].Position;
            Point c3 = shape[3].Position;

            //Forth rotation
            shape.Rotate();

            Point d0 = shape[0].Position;
            Point d1 = shape[1].Position;
            Point d2 = shape[2].Position;
            Point d3 = shape[3].Position;

            //First rotation
            Assert.AreEqual(p0, a0);
            Assert.AreEqual(p1, new Point(a1.X - 1, a1.Y + 1));
            Assert.AreEqual(p2, new Point(a2.X + 1, a2.Y - 1));
            Assert.AreEqual(p3, new Point(a3.X + 0, a3.Y - 2));
            //Second Rotation
            Assert.AreEqual(a0, b0);
            Assert.AreEqual(a1, new Point(b1.X - 1, b1.Y - 1));
            Assert.AreEqual(a2, new Point(b2.X + 1, b2.Y + 1));
            Assert.AreEqual(a3, new Point(b3.X + 2, b3.Y + 0));
            //Third Rotation
            Assert.AreEqual(b0, b0);
            Assert.AreEqual(b1, new Point(c1.X + 1, c1.Y - 1));
            Assert.AreEqual(b2, new Point(c2.X - 1, c2.Y + 1));
            Assert.AreEqual(b3, new Point(c3.X - 0, c3.Y + 2));
            //Forth Rotation
            Assert.AreEqual(c0, d0);
            Assert.AreEqual(c1, new Point(d1.X + 1, d1.Y + 1));
            Assert.AreEqual(c2, new Point(d2.X - 1, d2.Y - 1));
            Assert.AreEqual(c3, new Point(d3.X - 2, d3.Y + 0));
        }

        [TestMethod]
        public void ShapeJResetTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeJ(b);

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
