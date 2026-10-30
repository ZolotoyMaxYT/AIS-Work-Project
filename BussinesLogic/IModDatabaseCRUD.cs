using DataAccessLayer;
using Model;
using System.Data.Entity;

namespace BussinesLogic
{
    /// <summary>
    /// Interface for all basic CRUD logic of ModDatabase
    /// </summary>
    public interface IModDatabaseCRUD : IBasicModDatabase
    {
        /// <summary>
        /// Create new mod in database
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="name">Name of mod</param>
        /// <param name="description">Description of mod</param>
        /// <param name="author">Author of mod</param>
        /// <param name="version">Version of mod</param>
        /// <param name="minecraftVersion">Range of Minecraft's versions</param>
        /// <param name="isJavaMod">is java mod? else bedrock mod</param>
        /// <param name="rank">Rank of mod</param>
        /// <param name="tags">List of mod's tags</param>
        /// <returns>Status of work <see cref="IsExistResult"/></returns>
        public IsExistResult Create(string id, string name, string description, string author, EntityVersion version, ModMinecraftVersion minecraftVersion, bool isJavaMod, int rank, List<string> tags);


        /// <summary>
        /// Delete mod from database
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult Delete(string id);

        /// <summary>
        /// Read mod from database
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="mod">const JSON object of mod</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult Read(string id, out Dictionary<string, object> mod);

        /// <summary>
        /// Update mod from database
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="name">Name of mod</param>
        /// <param name="description">Description of mod</param>
        /// <param name="author">Author of mod</param>
        /// <param name="version">Version of mod</param>
        /// <param name="rank">Rank of mod</param>
        /// <param name="tags">List of mod's tags</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult Update(string id, string? name = null, string? description = null, string? author = null, EntityVersion? version = null, int? rank = null, List<string>? tags = null);

    }
}
