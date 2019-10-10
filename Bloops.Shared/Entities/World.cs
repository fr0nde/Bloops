using System;
using System.Collections.Generic;

namespace Bloops.Shared.Entities
{
    /// <summary>
    /// Niveau.
    /// </summary>
    [Serializable]
    public class World
    {
        /// <summary>
        /// Identifiant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du monde.
        /// </summary>
        public string Title { get; set; }

        public World(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
