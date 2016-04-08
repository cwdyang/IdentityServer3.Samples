using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer3.Core;
using IdentityServer3.Core.Extensions;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.Services;

namespace WebHost
{
    public class ExternalClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult<Client>( new Client
                {
                    ClientName = "Silicon-only Client",
                    ClientId = "silicon",
                    Enabled = true,
                   
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },
                    AllowedScopes = new List<string>
                        {
                            "read",
                            "write"
                        },

                AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:13048",
                        "http://localhost"

                    },

                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 36000,

                // refresh token settings
                AbsoluteRefreshTokenLifetime = 86400,
                SlidingRefreshTokenLifetime = 43200,
                RefreshTokenUsage = TokenUsage.OneTimeOnly,
                RefreshTokenExpiration = TokenExpiration.Sliding
            });
           
        }
    }
}