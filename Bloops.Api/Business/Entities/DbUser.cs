using Bloops.Shared.Entities;
using System;

namespace Bloops.Api.Business.Entities
{
    /// <summary>
    /// Utilisateur.
    /// </summary>
    public class DbUser : User, IDbEntity
    {
        /// <summary>
        /// Identifiant.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Date de création.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Date de modification.
        /// </summary>
        public DateTime ModificationDate { get; }
    }
}