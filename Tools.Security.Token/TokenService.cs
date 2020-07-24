using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Tools.Security.Token
{
    public sealed class TokenService : ITokenService
    {
        private readonly string _passPhrase;

        public TokenService(string passPhrase)
        {
            _passPhrase = passPhrase ?? throw new ArgumentNullException(nameof(passPhrase));
        }

        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;
        private JwtHeader Header
        {
            get
            {
                return _header ?? (_header = new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_passPhrase)),
                        SecurityAlgorithms.HmacSha512)));
            }
        }

        private JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new JwtSecurityTokenHandler());
            }
        }

        public string EncodeToken<T>(T entity, Func<T, IEnumerable<Claim>> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                Header,
                new JwtPayload(
                    issuer: null,
                    audience: null,
                    claims: selector(entity),
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(1))
                );

            return Handler.WriteToken(jwtSecurityToken);
        }

        public IDictionary<string, string> DecodeToken(string token, IEnumerable<string> properties)
        {
            token = token.Replace("Bearer ", "");
            JwtSecurityToken jwtSecurityToken = Handler.ReadJwtToken(token);
            if (jwtSecurityToken.ValidFrom <= DateTime.Now && jwtSecurityToken.ValidTo >= DateTime.Now)
            {
                JwtPayload payload = jwtSecurityToken.Payload;
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payload));

                if (token == test)
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    foreach (Claim claim in payload.Claims.Where((claim) => properties.Contains(claim.Type)))
                    {
                        payload.TryGetValue(claim.Type, out object value);
                        keyValuePairs.Add(claim.Type, value.ToString());
                    }

                    return keyValuePairs;
                }
            }

            return null;
        }
    }
}
