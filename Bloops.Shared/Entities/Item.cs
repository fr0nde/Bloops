using System;
using System.Collections.Generic;

namespace Bloops.Shared.Entities
{
    /// <summary>
    /// Niveau.
    /// </summary>
    [Serializable]
    public class Item
    {
        /// <summary>
        /// Identifiant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public ItemType Type { get; set; }
    }

    public enum ItemType
    {
    }
}
