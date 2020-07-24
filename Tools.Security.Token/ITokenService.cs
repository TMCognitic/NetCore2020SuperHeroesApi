using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Tools.Security.Token
{
    public interface ITokenService
    {
        IDictionary<string, string> DecodeToken(string token, IEnumerable<string> properties);
        string EncodeToken<T>(T entity, Func<T, IEnumerable<Claim>> selector);
    }
}