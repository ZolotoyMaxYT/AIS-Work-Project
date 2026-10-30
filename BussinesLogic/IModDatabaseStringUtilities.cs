using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic
{
    /// <summary>
    /// Interface for all basic string logic of ModDatabase
    /// </summary>
    public interface IModDatabaseStringUtilities : IBasicModDatabase
    {
        /// <summary>
        /// Get mod as string
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="result">result mod info as string</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult GetStringMod(string id, out string result);
    }
}
