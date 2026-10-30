using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BussinesLogic
{
    /// <summary>
    /// Interface for all basic MinecraftVersion logic of ModDatabase
    /// </summary>
    public interface IModDatabaseMinecraftVersionManager : IBasicModDatabase
    {
        /// <summary>
        /// Checks whether this mod is compatible with the current version of Minecraft. 
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="version">version of minecraft</param>
        /// <param name="result">result. Mod is compatible?</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult IsCorrectForMinecraftVersion(string id, EntityVersion version, out bool result);

        /// <summary>
        /// Change the mod's Minecraft version to a more up‑to‑date one. And update id style for new versions
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="version">Range of new minecraft's versions </param>
        /// <param name="newId">The new mod ID (or the old one, if it hasn’t changed)</param>
        /// <returns>Status of work <see cref="IsNotCorrectVersionResult"/></returns>
        public IsNotCorrectVersionResult ChangeMinecraftVersionForMod(string id, ModMinecraftVersion version, out string newId);
    }
}
