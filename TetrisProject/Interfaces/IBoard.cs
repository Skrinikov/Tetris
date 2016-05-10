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
    /// Gives a common gameboard behaviour to a Tetris game boards.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Returns the shape in memory.
        /// </summary>
        IShape Shape { get; }

        /// <summary>
        /// Using the supplied position returns the color of the block in the board.
        /// </summary>
        /// <param name="i">Horizontal coordinate of the position in the board.</param>
        /// <param name="j">Vertical coordinate of the position in the board.</param>
        /// <returns>Color which is in the given position.</returns>
        Color this[int i, int j] { get; }

        //To Code events.

        /// <summary>
        /// Returns the length of the board array rank.
        /// </summary>
        /// <param name="rank">Integer which represents the rank of the array. Expected input between 1 and 2 inclusive for a 2d board.</param>
        /// <returns>Length of the array in the given position.</returns>
        int GetLength(int rank);

        /// <summary>
        /// Event which is raised once the game is over.
        /// </summary>
        event GameOverHandler GameOver;
        
        /// <summary>
        /// Event Which is raised once at least one line was cleared.
        /// </summary>
        event LinesClearedHandler LinesCleared;

        
    }
}
