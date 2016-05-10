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
    /// Interface for the Shapes in a Tetris game.
    /// </summary>
    public interface IShape
    {

        event JoinPileHandler JoinPile;

        /// <summary>
        /// Returns the amount of blocks in the array of a shape.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Indexer for a shape object. Returns a Block object in the given position.
        /// </summary>
        /// <param name="i">Index of the block to get.</param>
        /// <returns>Block object of the given position.</returns>
        Block this[int i] { get; }
        /// <summary>
        /// Trys to move the shape to the left.
        /// </summary>
        void MoveLeft();
        /// <summary>
        /// Tries to move the shape to the right.
        /// </summary>
        void MoveRight();
        /// <summary>
        /// Moves the shape down by one. Then checks if the shape has hit the ground.
        /// </summary>
        /// <returns>True if the shape has hit the ground. False if it is still in the air.</returns>
        bool MoveDown();
        /// <summary>
        /// Drops the current shape to the ground.
        /// </summary>
        void Drop();
        /// <summary>
        /// Rotates the shape by -90 degrees.
        /// </summary>
        void Rotate();
        /// <summary>
        /// Resets the shape to it's original state.
        /// </summary>
        void Reset();

    }
}
