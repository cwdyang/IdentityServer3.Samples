using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.Core;

namespace WebHost
{
    internal class ExternalScopeStore : IScopeStore
    {
        public Task<IEnumerable<Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
        {
            return Task.FromResult( GetScopes().Where(x => scopeNames.Contains(x.Name)));
        }

        public Task<IEnumerable<Scope>> GetScopesAsync(bool publicOnly = true)
        {
            return Task.FromResult<IEnumerable<Scope>>(GetScopes());
        }

        private List<Scope> GetScopes()
        {
            return
                new List<Scope>
                {
                    ////////////////////////
                    // identity scopes
                    ////////////////////////

                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    StandardScopes.Address,
                    StandardScopes.OfflineAccess,
                    StandardScopes.RolesAlwaysInclude,
                    StandardScopes.AllClaims,

                    ////////////////////////
                    // resource scopes
                    ////////////////////////

                    new Scope
                    {
                        Name = "read",
                        DisplayName = "Read data",
                        Type = ScopeType.Resource,
                        Emphasize = false,

                        ScopeSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        }
                    },
                    new Scope
                    {
                        Name = "write",
                        DisplayName = "Write data",
                        Type = ScopeType.Resource,
                        Emphasize = true,

                        ScopeSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        }
                    },
                    new Scope
                    {
                        Name = "idmgr",
                        DisplayName = "IdentityManager",
                        Type = ScopeType.Resource,
                        Emphasize = true,
                        ShowInDiscoveryDocument = false,

                        Claims = new List<ScopeClaim>
                        {
                            new ScopeClaim(Constants.ClaimTypes.Name),
                            new ScopeClaim(Constants.ClaimTypes.Role)
                        }
                    }
                };
        }
    }
}