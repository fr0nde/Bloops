using System;

namespace Bloops.Shared.Entities
{
    /// <summary>
    /// Obstacle.
    /// </summary>
    [Serializable]
    public class Obstacle
    {
        /// <summary>
        /// Identifiant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type de l'obstacle.
        /// </summary>
        public ObstacleType Type { get; set; }

        /// <summary>
        /// Position.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Rotation.
        /// </summary>
        public int Rotation { get; set; }
    }
}
