using System;
using Bloops.Api.Business.Entities;
using Bloops.Shared.Entities;

namespace Bloops.Business.Entities
{
    public class DbUser : User, IDbEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }
}
