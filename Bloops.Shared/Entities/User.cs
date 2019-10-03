using System;
using System.Collections.Generic;
using System.Text;

namespace Bloops.Shared.Entities
{
    public class User
    {
        /// <summary>
        /// Identifiant Social API.
        /// </summary>
        public int SocialID { get; }

        /// <summary>
        /// Nom.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Date de dernière connection.
        /// </summary>
        public DateTime LastConnectionDate { get; }

        /// <summary>
        /// Numéro du dernier niveau joué.
        /// </summary>
        public int LastLevelPlayed { get; }
    }
}
