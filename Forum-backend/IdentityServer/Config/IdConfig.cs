using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer.Config
{
    public class IdConfig
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>()
            {
                new TestUser
                {
                    Username = "FirstUser",
                    Password = "FirstUserPass",
                    SubjectId = "11",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id, "13")
                    }

                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };


        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("ForumAPI")
                {
                    Scopes = new List<string> {"ForumAPI.write", "ForumAPI.read"},
                    ApiSecrets = new List<Secret> { new Secret ("523joihJu5312kNfg213551".Sha256()) }
                    
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("ForumAPI.write"),
                new ApiScope("ForumAPI.read")
            };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientName ="ForumFront",
                    ClientId = "1997",
                    ClientSecrets = new List<Secret> {new Secret("ggWPii512I2I2lo".Sha256())},
                    AllowedScopes = new List<String> {"ForumAPI.write", "ForumAPI.read" },
                    AllowedGrantTypes = GrantTypes.ClientCredentials
                }
            };
    }
}
