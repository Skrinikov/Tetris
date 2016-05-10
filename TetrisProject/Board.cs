using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TetrisProject
{
    public delegate void LinesClearedHandler(int lines);
    public delegate void GameOverHandler();

    /// <summary>
    /// <author>Danieil Skrinikov</author>
    /// </summary>
    public class Board: IBoard
    {

        private Color[,] board;
        private IShape shape;
        private IShapeFactory shapeFactory;

        /// <summary>
        /// Event which is raised once the game is over.
        /// </summary>
        public event GameOverHandler GameOver;

        /// <summary>
        /// Event Which is raised once at least one line was cleared.
        /// </summary>
        public event LinesClearedHandler LinesCleared;

        /// <summary>
        /// Returns the shape which is in this instance's memory.
        /// </summary>
        public IShape Shape
        {
            get { return shape; }
        }

        /// <summary>
        /// Constructor for the Board class. Generates a new duo-dimensional Color array. ANd instantiates the IShapeFactory class.
        /// </summary>
        public Board()
        {

            board = new Color[10, 20];
            shapeFactory = new ShapeProxy(this);
            shape = (IShape)shapeFactory;

            shape.JoinPile += addToPile;

        }
        /// <summary>
        /// Returns the color of the block in the given position
        /// </summary>
        /// <param name="i">Horizontal Coordinate of the board. Range is 0 to 9</param>
        /// <param name="j">Vertical Coordinate of the board. Range is 0 to 19</param>
        /// <returns>The color in the given cell on the board.</returns>
        public Color this[int i, int j]
        {
            get
            {
                if (i < 0 || i > 9 || j < 0 || j > 19)
                    return Color.Transparent;

                return board[i, j];
            }
        }

        /// <summary>
        /// Returns the length of the board according to the rank. 
        /// </summary>
        /// <param name="rank">Rank to which look for the length. Expected input 1 or 2</param>
        /// <returns>Length of the array at that rank.</returns>
        public int GetLength(int rank)
        {
            if (rank > 1 || rank < 0)
                return 0;
            if (rank == 0)
                return 10;
            else 
                return 20;
        }

        /// <summary>
        /// Raises the event that notifices
        /// </summary>
        /// <param name="lines">Amount of lines which were cleared.</param>
        protected void OnLinesCleared(int lines)
        {
            if (LinesCleared != null)
                LinesCleared(lines);            
        }

        //Raises the game over event.
        private void onGameOver()
        {

            if (GameOver != null)
                GameOver();
        }

        //Adds the shape to the board, looks for all y values where the shape has been set to. Calls if the line is full if it is clears the line. Calls the OnLinesCleared methods which fires an event.
        private void addToPile()
        {
            Block[] blocks = new Block[shape.Length];
            Boolean gameOver = false;
            int x;
            int y;
            int linesCleared = 0;

            for (int i = 0; i < blocks.Length; i++)
                blocks[i] = shape[i];

            Array.Sort(blocks);

            for (int i = 0; i < blocks.Length && !(gameOver); i++)
            {
                x = blocks[i].Position.X;
                y = blocks[i].Position.Y;

                if (y > 19)
                {
                    gameOver = true;
                    break;
                }
                else
                {
                    board[x, y] = blocks[i].Color;
                    if (checkIfLineIsFull(y))
                    {
                        clearLine(y);
                        linesCleared++;
                        for (int j = i; j < blocks.Length; j++)
                        {
                            try{
                            blocks[j].Position = new Point(x, (blocks[j].Position.Y) - 1);
                            }
                            catch(ArgumentOutOfRangeException){}
                        }
                    }
                }
            }
            if (gameOver)
                onGameOver();
            else
                if(linesCleared > 0)
                    OnLinesCleared(linesCleared);
        }

        //Using the provided vertical coordinate looks through all of the x coordinates of the line to look if they're transparent.
        //If they are transparent returns false because it means that the line is not full.
        private bool checkIfLineIsFull(int line)
        {

            for (int i = 0; i < 10; i++)
                if (board[i, line].Equals(Color.Transparent))
                    return false;
            return true;

        }
        //Clears 
        private void clearLine(int line)
        {

            //clears the line.
            for (int i = 0; i < 10; i++)
                board[i, line] = Color.Transparent;

            //shifts everything down by one.
            for (int x = 0; x < 10; x++)
                for (int y = line; y < 19; y++)
                    board[x, y] = board[x, y + 1];
                    
            
            //Clears top line.
            for (int i = 0; i < 10; i++)
                board[i, 19] = Color.Transparent;


        }

    }
}
