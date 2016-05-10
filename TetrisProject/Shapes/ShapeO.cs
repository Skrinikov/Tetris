using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TetrisProject
{
    /// <summary>
    /// <author>Danieil Skrinikov</author>
    /// </summary>
    public class ShapeO :Shape
    {
        public ShapeO(IBoard board)
            : base(board)
        {
            blocks[0].Position = new Point(5, 21);
            blocks[1].Position = new Point(4, 21);
            blocks[2].Position = new Point(4, 20);
            blocks[3].Position = new Point(5, 20);
        }

        /// <summary>
        /// The Shape O is not rotatable therefore this method has no implementation.
        /// </summary>
        public override void Rotate()
        {
            
        }

        /// <summary>
        /// Resets the default location of the block.
        /// </summary>
        public override void Reset()
        {
            blocks[0].Position = new Point(5, 19);
            blocks[1].Position = new Point(4, 19);
            blocks[2].Position = new Point(4, 18);
            blocks[3].Position = new Point(5, 18);
            currentRotation = 0;
        }

    }
}
