using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BussinesLogic
{
    /// <summary>
    /// Interface for all basic ban logic of ModDatabase
    /// </summary>
    public interface IModDatabaseBanManager : IBasicModDatabase
    {
        /// <summary>
        /// Check status of mod (Active/Ban/Shadow ban)
        /// </summary>
        /// <param name="id">ID of mod</param>
        /// <param name="status">Status of mod <see cref="ModStatus"/></param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult CheckStatusMod(string id, out ModStatus status);

        /// <summary>
        /// Ban mod. Update description and tags.
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <returns>Status of work <see cref="IsBanResult"/></returns>
        public IsBanResult BanMod(string id);

        /// <summary>
        /// Shadow ban mod.
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <returns>Status of work <see cref="IsBanResult"/></returns>
        public IsBanResult ShadowBan(string id);
    }
}
