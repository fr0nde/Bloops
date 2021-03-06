﻿using System;
using System.Collections.Generic;

namespace Bloops.Shared.Entities
{
    [Serializable]
    public class User 
    {
        /// <summary>
        /// Identifiant Social.
        /// </summary>
        public string SocialId { get; set; }

        /// <summary>
        /// Nom.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Niveaux.
        /// </summary>
        public List<UserLevel> Levels { get; set; }

        /// <summary>
        /// Boulas.
        /// </summary>
        public int Boulas { get; set; }

        /// <summary>
        /// Equipement.
        /// </summary>
        public List<Item> Items { get; set; }
    }
}
