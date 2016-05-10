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
    public class ShapeZ :Shape
    {

        public ShapeZ(IBoard board)
            : base(board)
        {

            //Initial block positions.
            blocks[0].Position = new Point(5, 21);
            blocks[1].Position = new Point(4, 21);
            blocks[2].Position = new Point(5, 20);
            blocks[3].Position = new Point(6, 20);


            //Offset initialization.
            rotationOffset = new Point[2][];

            rotationOffset[0] = new Point[4];

            //1
            rotationOffset[0][0] = new Point(0, 0);
            rotationOffset[0][1] = new Point(1, -1);
            rotationOffset[0][2] = new Point(1, 1);
            rotationOffset[0][3] = new Point(0, 2);

            rotationOffset[1] = new Point[4];
            //2
            rotationOffset[1][0] = new Point(0, 0);
            rotationOffset[1][1] = new Point(-1, 1);
            rotationOffset[1][2] = new Point(-1, -1);
            rotationOffset[1][3] = new Point(0, -2);

        }

        /// <summary>
        /// Checks if all blocks can rotate using their assigned offset. If all blocks can rotate the methods makes them rotate and then increments the currentRotation variable.
        /// </summary>
        public override void Rotate()
        {
            bool canRotate = true;
            for (int i = 0; i < blocks.Length; i++)
            {
                if(!(blocks[i].TryRotate(rotationOffset[currentRotation][i])))
                    canRotate = false;
            }
            if(canRotate)
            {
                for(int i = 0 ; i < blocks.Length ; i++)
                    blocks[i].Rotate(rotationOffset[currentRotation][i]);

                currentRotation = (currentRotation + 1) % 2;
            }
        }

        /// <summary>
        /// Reset's the points' positions back to their initial values.
        /// </summary>
        public override void Reset()
        {
            blocks[0].Position = new Point(5, 21);
            blocks[1].Position = new Point(4, 21);
            blocks[2].Position = new Point(5, 20);
            blocks[3].Position = new Point(6, 20);
            currentRotation = 0;
        }

    }
}
