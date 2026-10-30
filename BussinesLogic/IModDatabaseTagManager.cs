using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BussinesLogic
{
    /// <summary>
    /// Interface for all basic tag logic of ModDatabase
    /// </summary>
    public interface IModDatabaseTagManager : IBasicModDatabase
    {
        /// <summary>
        /// Mod has this tag?
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="tag">tag</param>
        /// <param name="result">has tag?</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult HasTag(string id, string tag, out bool result);

        /// <summary>
        /// Add new tag to mod
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="tag">new tag</param>
        /// <returns>Status of work <see cref="HasTagResult"/></returns>
        public HasTagResult AddTag(string id, string tag);

        /// <summary>
        /// Remove tag from mod
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="tag">old tag</param>
        /// <returns>Status of work <see cref=" HasNotTagResult"/></returns>
        public HasNotTagResult RemoveTag(string id, string tag);

        /// <summary>
        /// Get list of mods with this tag
        /// </summary>
        /// <param name="tag">tag</param>
        /// <param name="mods">result list of mods</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult GetAllModsWithTag(string tag, out string[] mods);

        /// <summary>
        /// Get all tags of mod
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="result">result list of tags</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult GetAllTags(string id, out string[] result);
    }
}
