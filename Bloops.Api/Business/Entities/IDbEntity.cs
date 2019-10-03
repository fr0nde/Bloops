using System;

namespace Bloops.Api.Business.Entities
{
    internal interface IDbEntity
    {
        int ID { get; }

        DateTime CreationDate { get; }

        DateTime ModificationDate { get; }
    }
}
