using System;

namespace Bloops.Shared.Entities
{
    [Serializable]
    public class ObstacleType
    {
        /// <summary>
        /// Identifiant.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Rotatif.
        /// </summary>
        public bool Rotatable { get; }

        /// <summary>
        /// Mortel.
        /// </summary>
        public bool Lethal { get; }
    }
}
