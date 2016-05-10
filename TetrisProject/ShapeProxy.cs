using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisProject
{
    //public delegate void JoinPileHandlerProxy(IShape shape);

    /// <summary>
    /// <author>Danieil Skrinikov</author>
    /// Keeps track of the active shape of the game and contains implementation to generate a new shape.
    /// </summary>
    public class ShapeProxy : IShapeFactory,IShape
    {
        private static Random r = new Random();
        private IShape current;
        private IBoard board;


        
        public event JoinPileHandler JoinPile;
            
        /// <summary>
        /// Constructor for the proxy class. Takes the board as paramter in order to use it int he process of instantiation of Shapes.
        /// </summary>
        /// <param name="board">The board in which the shapes will be added.</param>
        public ShapeProxy(IBoard board)
        {
            this.board = board;
            DeployNewShape();
            
        }

        /// <summary>
        /// Generates a new randomly selected shape and set it as active shape.
        /// </summary>
        public void DeployNewShape()
        {
           int random = r.Next(0, 6);
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

           ((Shape)current).JoinPile += OnJoinPile;

        }

        /// <summary>
        /// Retruns the amount of blocks in the current shape block array.
        /// </summary>
        public int Length
        {
            get { return current.Length; }
        }

        /// <summary>
        /// Indexer for the shape Block array.
        /// </summary>
        /// <param name="i">Index of the block inside of the array to get.</param>
        /// <returns></returns>
        public Block this[int i]
        {
            get { return current[i]; }
        }

        /// <summary>
        /// Calls the move left method of the current shape.
        /// </summary>
        public void MoveLeft()
        {
            current.MoveLeft();
        }
        /// <summary>
        /// Calls the MoveRight method of the current shape.
        /// </summary>
        public void MoveRight()
        {
            current.MoveRight();
        }

        /// <summary>
        /// Calls the MoveDown method in the current shape.
        /// If the current shape has hit the ground calls the DeployNewShapeMethod.
        /// </summary>
        /// <returns>Bool representing if the shape hit the ground or not.</returns>
        public bool MoveDown()
        {
            return current.MoveDown();
        }
        /// <summary>
        /// Calls the Drop method from the current Shape.
        /// </summary>
        public void Drop()
        {
            current.Drop();
        }

        /// <summary>
        /// Calls the Rotate method from the current shape.
        /// </summary>
        public void Rotate()
        {
            current.Rotate();
        }
        /// <summary>
        /// Calls the Reset method int the current shape.
        /// </summary>
        public void Reset()
        {
            current.Reset();
        }

        /// <summary>
        /// Deploys A New Shape and raises a simillar event 
        /// </summary>
        protected void OnJoinPile()
        {    

            if (this.JoinPile != null)
                JoinPile();              

            DeployNewShape();
        }
    }
}
