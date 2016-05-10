using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisProject;
using Microsoft.Xna.Framework;

namespace TetrisUnitTest
{
    [TestClass]
    public class ShapeProxyTest
    {
        [TestMethod]
        public void ShapeProxyIndexerTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b = shape[0];

            Assert.AreEqual(b.Position,new Point(5, 19));

        }
        [TestMethod]
        public void ShapeProxyDeployNewShapeTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;
            ShapeProxy proxy = (ShapeProxy)shape;

            Block b = shape[0];
            proxy.DeployNewShape();

            Block b1 = shape[0];

            //Compares memory address.
            Assert.IsFalse(b == b1);
            
        }

        [TestMethod]
        public void ShapeProxyLengthTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            int i = shape.Length;

            Assert.IsNotNull(i);
            Assert.IsTrue(i > 0);
        }

        [TestMethod]
        public void ShapeProxyMoveLeftTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;
            shape.MoveLeft();
            Point l0 = shape[0].Position;
            Point l1 = shape[1].Position;
            Point l2 = shape[2].Position;
            Point l3 = shape[3].Position;

            Assert.AreEqual(p0.X ,l0.X +1);
            Assert.AreEqual(p1.X, l1.X +1);
            Assert.AreEqual(p2.X, l2.X +1);
            Assert.AreEqual(p3.X, l3.X +1);


        }
        [TestMethod]
        public void ShapeProxyMoveRightTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;
            shape.MoveRight();
            Point l0 = shape[0].Position;
            Point l1 = shape[1].Position;
            Point l2 = shape[2].Position;
            Point l3 = shape[3].Position;

            Assert.AreEqual(p0.X, l0.X - 1);
            Assert.AreEqual(p1.X, l1.X - 1);
            Assert.AreEqual(p2.X, l2.X - 1);
            Assert.AreEqual(p3.X, l3.X - 1);
        }

        [TestMethod]
        public void ShapeProxyMoveDownTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;
            shape.MoveDown();
            Point l0 = shape[0].Position;
            Point l1 = shape[1].Position;
            Point l2 = shape[2].Position;
            Point l3 = shape[3].Position;

            Assert.AreEqual(p0.Y, l0.Y + 1);
            Assert.AreEqual(p1.Y, l1.Y + 1);
            Assert.AreEqual(p2.Y, l2.Y + 1);
            Assert.AreEqual(p3.Y, l3.Y + 1);
        }

        [TestMethod]
        public void ShapeProxyDropTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Block b0 = shape[0];
            Block b1 = shape[1];
            Block b2 = shape[2];
            Block b3 = shape[3];
           
            shape.Drop();
            Block p0 = shape[0];
            Block p1 = shape[1];
            Block p2 = shape[2];
            Block p3 = shape[3];

            Assert.AreNotSame(b0, p0);
            Assert.AreNotSame(b1, p1);
            Assert.AreNotSame(b2, p2);
            Assert.AreNotSame(b3, p3);
            
        }

        [TestMethod]
        public void ShapeProxyRotateTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            shape.MoveDown();
            shape.MoveDown();
            shape.MoveDown();

            Point p = shape[1].Position;
            shape.Rotate();
            Point p1 = shape[1].Position;

            Assert.AreNotEqual(p1,p);
            

        }

        [TestMethod]
        public void ShapeProxyResetTest()
        {
            IBoard board = new Board();
            IShape shape = board.Shape;

            Point p0 = shape[0].Position;
            Point p1 = shape[1].Position;
            Point p2 = shape[2].Position;
            Point p3 = shape[3].Position;

            shape.MoveDown();
            shape.MoveDown();
            shape.MoveDown();
            shape.MoveRight();
            shape.Reset();

            Point r0 = shape[0].Position;
            Point r1 = shape[1].Position;
            Point r2 = shape[2].Position;
            Point r3 = shape[3].Position;

            Assert.AreEqual(r0, p0);
            Assert.AreEqual(r1, p1);
            Assert.AreEqual(r2, p2);
            Assert.AreEqual(r3, p3);

        }


    }
}
