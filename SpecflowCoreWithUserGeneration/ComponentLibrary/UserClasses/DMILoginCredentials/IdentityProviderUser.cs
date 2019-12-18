using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ComponentLibrary.HelperFunctions;

namespace ComponentLibrary.UserClasses
{
    public class IdentityProviderUser
    {
        public IdentityProviderUserModel user { get; set; }

        public readonly HttpClient Client = new HttpClient();


        public async Task<IdentityProviderUserModel> Create(NewUser newuser)
        {
            var authenticateUser = new AuthenticateIdentityProviderUser();
            var token = authenticateUser.AuthAsync().GetAwaiter().GetResult();

            string aUser = JsonConvert.SerializeObject(newuser);
            var buffer = System.Text.Encoding.UTF8.GetBytes(aUser);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            Client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            var response = await Client.PostAsync(Config.Environment.IdentityProviderUsersEndpoint, byteContent);

            //read the body
            string responseBody = await response.Content.ReadAsStringAsync();
            string body = response.Content.ToString();
            return user = parseUser(responseBody);
        }

        public async Task<IdentityProviderUserModel> CreateFromDmiUser(DMIUser dmiuser)
        {
            var authenticateUser = new AuthenticateIdentityProviderUser();
            var token = authenticateUser.AuthAsync().GetAwaiter().GetResult();

            string aUser = JsonConvert.SerializeObject(dmiuser);
            var buffer = System.Text.Encoding.UTF8.GetBytes(aUser);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            Client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            var response = await Client.PostAsync(Config.Environment.IdentityProviderUsersEndpoint, byteContent);

            //read the body
            string responseBody = await response.Content.ReadAsStringAsync();
            string body = response.Content.ToString();
            return user = parseUser(responseBody);
        }

        private IdentityProviderUserModel parseUser(string response)
        {
            var serializerSettings = new JsonSerializerSettings();
            var user = JsonConvert.DeserializeObject<IdentityProviderUserModel>(response, serializerSettings);
            return user;
        }

    }
}