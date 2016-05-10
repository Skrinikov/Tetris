using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace TetrisProject
{
    /// <summary>
    /// Contains all information related to a signle block entity. Also contains implementation to change the block's position.
    /// <author>Danieil Skrinikov</author>
    /// </summary>
    public class Block : IComparable
    {
        private IBoard board;
        private Color color;
        private Point pos;

        /// <summary>
        /// Property which returns the color of the block Using Xna Framework.
        /// </summary>
        public Color Color { get { return color; } }

        /// <summary>
        /// Returns the current position of the of the block. Also gives the possibility to set the block's position.
        /// </summary>
        public Point Position
        {
            get
            {
                return new Point(pos.X, pos.Y);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Block.cs - Null position is not valid.");
                if (value.X < 0 || value.X > 9 || value.Y < 0 || value.Y > 21)
                    throw new ArgumentOutOfRangeException("Block.cs - One of the supplied positions is not valid.");

                pos = value;

            }
        }

        public Block(IBoard board, Color color)
        {
            this.board = board;
            this.color = color;
        }

        /// <summary>
        /// Tries to move the block horizontally to the left. If the block can move to the left returns true, if it cannot returns false.
        /// DOES NOT MOVE THE BLOCK
        /// </summary>
        /// <returns>Boolean representing the ability to move the block to the left.</returns>
        public bool TryMoveLeft()
        {
            bool canMove = true;

            if (pos.X <= 0)
                canMove = false;

            if (canMove)
                if (!(board[pos.X - 1, pos.Y].Equals(Color.Transparent)))
                    canMove = false;

            return canMove;
            

        }
        /// <summary>
        /// Tries to move the block horizontally to the right. If the block can move to the right returns true, if it cannot returns false.
        /// DOES NOT MOVE THE BLOCK
        /// </summary>
        /// <returns>Boolean representing the ability to move the block to the right.</returns>
        public bool TryMoveRight()
        {
            bool canMove = true;

            if (pos.X >= 9)
                canMove = false;

            if (canMove)
                if (!(board[pos.X + 1, pos.Y].Equals(Color.Transparent)))
                    canMove = false;

            return canMove;
        }
        /// <summary>
        /// Tries to move the block horizontally to the down. If the block can down to the left returns true, if it cannot returns false.
        /// DOES NOT MOVE THE BLOCK
        /// </summary>
        /// <returns>Boolean representing the ability to move the block to the down.</returns>
        public bool TryMoveDown()
        {

            bool canMove = true;

            if (pos.Y <= 0)
                canMove = false;

            if (canMove)
                if (!(board[pos.X , pos.Y -1].Equals(Color.Transparent)))
                    canMove = false;

            return canMove;

        }
        /// <summary>
        /// Looks if the shape rotation will land the block in a valid position. Returns true if the block can be turned, false if it cannot.
        /// DOES NOT MOVE THE BLOCK
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public bool TryRotate(Point offset)
        {
            int tempX = (int)(pos.X + offset.X);
            int tempY = (int)(pos.Y + offset.Y);

            if (tempX < 0 || tempX > 9 || tempY < 0 || tempY > 19)
                return false;
            else if (!(board[tempX, tempY].Equals(Color.Transparent)))
                return false;

            return true;

        }

        /// <summary>
        /// Makes the block move left by one digit.
        /// </summary>
        public void MoveLeft()
        {
            pos.X -= 1;
        }
        /// <summary>
        /// Makes the block move right by one digit.
        /// </summary>
        public void MoveRight()
        {
            pos.X += 1;
        }
        /// <summary>
        /// Drops the block down by one block.
        /// </summary>
        public void MoveDown()
        {
            pos.Y -= 1;
        }
        /// <summary>
        /// Using a shapes offset rotates the block to it's new position.
        /// </summary>
        public void Rotate(Point offset)
        {
            pos.X += offset.X;
            pos.Y += offset.Y;
        }

        /// <summary>
        /// Compares two blocks based on their position. The smaller both coordinates are the smaller is the object.
        /// </summary>
        /// <param name="o">Any object to be compared with this.</param>
        /// <returns>Int representing the position of the Object o relative to this. -1 - this comes first --- 0 - this is equal --- 1 - this is after.</returns>
        public int CompareTo(Object o)
        {
            if (o == null)
                return 1;

            Block b = o as Block;

            if(this == b)
                return 0;

            if (this.pos.Y < b.Position.Y)
                return -1;
            else if (this.pos.Y == b.Position.Y && this.pos.X < b.Position.X)
                return -1;
            else if (this.pos.Y < b.Position.Y && this.pos.X > b.Position.X)
                return 1;
            else if (this.pos.Y > b.Position.Y)
                return 1;
            else
                return 0;            

        }

    }
}
