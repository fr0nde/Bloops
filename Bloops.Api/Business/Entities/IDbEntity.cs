using System;

namespace Bloops.Api.Business.Entities
{
    internal interface IDbEntity
    {
        int Id { get; set; }

        DateTime CreationDate { get; set; }

        DateTime ModificationDate { get; set; }
    }
}
