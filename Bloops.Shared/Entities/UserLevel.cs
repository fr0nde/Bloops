using System;
using System.Collections.Generic;

namespace Bloops.Shared.Entities
{
    /// <summary>
    /// Niveau.
    /// </summary>
    [Serializable]
    public class UserLevel
    {
        /// <summary>
        /// Utilisateur.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Niveau.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Durée.
        /// </summary>
        public TimeSpan Duration { get; set; }
        
        /// <summary>
        /// Score.
        /// </summary>
        public int Score { get; set; }
    }
}
