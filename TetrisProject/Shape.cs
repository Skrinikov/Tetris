using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TetrisProject
{

    public delegate void JoinPileHandler();
        
    /// <summary>
    /// <author>Danieil Skrinikov</author>
    /// Abstract class for the Shapes classes. Provides basic movement implementations.
    /// In the blocks array the first Block object is always the central(i.e. Dot ) block.
    /// </summary>
    public abstract class Shape:IShape
    {
        private IBoard board;
        protected static Random r = new Random();
        protected Block[] blocks;
        protected Point[][] rotationOffset;
        protected int currentRotation;

        public event JoinPileHandler JoinPile;

        /// <summary>
        /// COnstructor for Shape
        /// </summary>
        /// <param name="board">Active tetris board.</param>
        public Shape(IBoard board)
        {
            this.board = board;

            blocks = new Block[4];

            //Random Color Generation.
            Color color = new Color(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256), 255);

            for (int i = 0; i < 4; i++)
                blocks[i] = new Block(board, color);

            currentRotation = 0;
        }

        public int Length
        {
            get { return blocks.Length; }
        }

        /// <summary>
        /// Indexer for the internal blocks array of the object. Only has a getter which returns the block object of the specified location.
        /// </summary>
        /// <param name="i">Indexer for the blocks array</param>
        /// <returns>Block object from the current Shape object blocks array.</returns>
        public Block this[int i]
        {
            get 
            {
                if (i < 0 || i >= blocks.Length)
                    throw new ArgumentOutOfRangeException("Index out of bounds.");

                Block b = new Block(board, blocks[i].Color);
                b.Position = new Point(blocks[i].Position.X, blocks[i].Position.Y);

                return b;

            }
        }

        /// <summary>
        /// First cheks if all blocks in the board array can move left. If all blocks can then it makes them move to the left. If not it remains unchanged.
        /// </summary>
        public void MoveLeft()
        {
            bool canMove = true;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!(blocks[i].TryMoveLeft()))
                    canMove = false;
            }
            if (canMove)
                for (int i = 0; i < blocks.Length; i++)
                    blocks[i].MoveLeft();
        }

        /// <summary>
        /// Checks if all block objects from the current shape can move right. If all blocks can, calls the move right method in all. If not the block's position remains untouched.
        /// </summary>
        public void MoveRight()
        {
            bool canMove = true;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!(blocks[i].TryMoveRight()))
                    canMove = false;
            }
            if (canMove)
                for (int i = 0; i < blocks.Length; i++)
                    blocks[i].MoveRight();
        }
        /// <summary>
        /// Cheks if all block objects frim the current shape can move down. If All blocks can, calls the move down method in all. If it means the blocks have hit the ground. Therefore an event will be raised.
        /// </summary>
        /// <returns>True if the block was moved down, false if not.</returns>
        public bool MoveDown()
        {
            bool canMove = true;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!(blocks[i].TryMoveDown()))
                    canMove = false;
            }
            if (canMove)
                for (int i = 0; i < blocks.Length; i++)
                    blocks[i].MoveDown();
            else
                OnJoinPile();

            return canMove;
        }
        /// <summary>
        /// Drops the current shape to the floor.
        /// </summary>
        public void Drop()
        {
            bool drop = true;
            do
            {

                for (int i = 0; i < blocks.Length; i++)
                {
                    if (!(blocks[i].TryMoveDown()))
                        drop = false;
                }
                if (drop)
                    for (int i = 0; i < blocks.Length; i++)
                        blocks[i].MoveDown();

            } while (drop);

            OnJoinPile();

        }

        /// <summary>
        /// Cheks if all blocks of the shape can be rotated.
        /// </summary>
        public abstract void Rotate();
        /// <summary>
        /// Resets the shape to it's initial values.
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// Throws an event whenever this method is called.
        /// </summary>
        protected void OnJoinPile()
        {
            if (JoinPile != null)
                JoinPile();
        }
    }
}
