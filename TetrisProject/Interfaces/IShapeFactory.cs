using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisProject
{
    /// <summary>
    /// <author>Danieil Skrinikov</author>
    /// Interface which forces an object to be able to generate shapes.
    /// </summary>
    public interface IShapeFactory
    {
        /// <summary>
        /// Generates a random new shape.
        /// </summary>
        void DeployNewShape();

    }
}
