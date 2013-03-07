using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore.Interfaces
{
    /// <summary>
    /// This interface define the signature of specification for the give type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification <T>
    {
        /// <summary>
        /// retun true if object match the specification represented by interface.
        /// </summary>
        /// <param name="genObject"> generic object</param>
        /// <returns> return bool value based on specification. </returns>
        bool IsSpecificationMeet(T genObject);
    }
}
