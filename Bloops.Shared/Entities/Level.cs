using System;
using System.Collections.Generic;

namespace Bloops.Shared.Entities
{
    /// <summary>
    /// Niveau.
    /// </summary>
    [Serializable]
    public class Level
    {
        /// <summary>
        /// Identifiant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Position de départ.
        /// </summary>
        public int StartPosition { get; set; }

        /// <summary>
        /// Position de fin.
        /// </summary>
        public int EndPosition { get; set; }

        /// <summary>
        /// Gravité.
        /// </summary>
        public int Gravity { get; set; }

        /// <summary>
        /// Liste d'obstacles.
        /// </summary>
        public List<Obstacle> Obstacles { get; set; }
    }
}
