using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace WebAPI.IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            //Client1
            clients.Add(new Client()
            {
                ClientId = "Client1",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "api1" }
            });

            //Client for MVC
            clients.Add(new Client()
            {
                ClientId = "mvc",
                ClientName = "MVC",
                AllowedGrantTypes = GrantTypes.Implicit,

                // where to redirect to after login
                RedirectUris = { "http://localhost:62024/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "http://localhost:62024/signout-callback-oidc" },

                AllowedScopes = new List<string>
                 {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile
                 }

            });

            return clients;
        }

        //Defining the InMemory API's
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> apiResources = new List<ApiResource>();

            apiResources.Add(new ApiResource("api1", "First API"));

            return apiResources;
        }

        //Support for OpenId connectivity scopes
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            List<IdentityResource> resources = new List<IdentityResource>();

            resources.Add(new IdentityResources.OpenId()); // Support for the OpenId
            resources.Add(new IdentityResources.Profile()); // To get the profile information

            return resources;
        }
    }
}
