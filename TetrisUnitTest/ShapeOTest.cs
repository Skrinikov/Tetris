using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisProject;
using Microsoft.Xna.Framework;

namespace TetrisUnitTest
{
    [TestClass]
    public class ShapeOTest
    {
        [TestMethod]
        public void ShapeOLengthTest()
        {

            IBoard b = new Board();
            IShape shape = new ShapeO(b);

            int i = shape.Length;

            Assert.AreEqual(i, 4);

        }

        [TestMethod]
        public void ShapeOIndexerTest_working()
        {
            IBoard b = new Board();
            IShape shape = new ShapeO(b);

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
        public void ShapeOIndexerTest_exception()
        {
            IBoard b = new Board();
            IShape shape = new ShapeO(b);

            Block block = shape[999];
        }

        [TestMethod]
        public void ShapeOMoveLeftTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeO(b);

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
        public void ShapeOMoveRightTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeO(b);

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
        public void ShapeOMoveDownTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeO(b);

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
        public void ShapeODropTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeO(b);

            shape.Drop();

            Point p = shape[0].Position;
            bool isOnGround = false;
            if (p.Y == 1 || p.Y == 0)
                isOnGround = true;

            Assert.IsTrue(isOnGround);

        }

        [TestMethod]
        public void ShapeORotateTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeO(b);

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

            Assert.AreEqual(p0, a0);
            Assert.AreEqual(p1, a1);
            Assert.AreEqual(p2, a2);
            Assert.AreEqual(p3, a3);
        }

        [TestMethod]
        public void ShapeOResetTest()
        {
            IBoard b = new Board();
            IShape shape = new ShapeO(b);

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
