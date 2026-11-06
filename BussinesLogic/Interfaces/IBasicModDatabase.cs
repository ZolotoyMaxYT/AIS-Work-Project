using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BussinesLogic.Interfaces
{
    /// <summary>
    /// Basic interface for ModDatabase
    /// </summary>
    public interface IBasicModDatabase
    {
        /// <summary>
        /// Is mod exist?
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <returns>true if mod is exist, false if not</returns>
        public bool IsExist(string id);

        /// <summary>
        /// ID is correct for this DataBase?
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>true if ID is correct</returns>
        public bool IsCorrectID(string id);

        /// <summary>
        /// Get mod as string
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="result">result mod info as string</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult GetStringMod(string id, out string result);
    }
}
