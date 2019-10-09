using Bloops.Shared.Responses;
using System;

namespace Bloops.Game.Assets.Scripts.Api
{
    public class ApiException : Exception
    {
        public int StatusCode { get; private set; }

        public ErrorType Type { get; private set; }

        public ApiException(ErrorResponse error) 
            : base(error.Message)
        {
            StatusCode = error.StatusCode;
            Type = error.Type;
        }
    }
}
