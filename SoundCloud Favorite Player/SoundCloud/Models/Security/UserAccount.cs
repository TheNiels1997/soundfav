namespace SoundCloud_Favorite_Player.SoundCloud.Models.Security
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class UserAccount
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public byte[] Password { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        public static async Task<UserAccount> Load(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                return JsonConvert.DeserializeObject<UserAccount>(await reader.ReadToEndAsync());
            }
        }
        public async Task Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(this));
            }
        }
        public async Task Login(string client_id, string client_secret)
        {
            using (HttpClient client = new HttpClient())
            {
                FormUrlEncodedContent content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("client_id",client_id),
                    new KeyValuePair<string, string>("client_secret",client_secret),
                    new KeyValuePair<string, string>("grant_type","password"),
                    new KeyValuePair<string, string>("username",Username),
                    new KeyValuePair<string, string>("password",Encoding.UTF32.GetString(Password)),
                    new KeyValuePair<string, string>("scope","non-expiring")
                });

                using (HttpResponseMessage message = await client.PostAsync("https://api.soundcloud.com/oauth2/token", content))
                {
                    if (message.StatusCode != System.Net.HttpStatusCode.OK)
                        throw new System.Exception("Login failed. " + Environment.NewLine + Environment.NewLine + "Please check your credentials and try again.");

                    dynamic response = JsonConvert.DeserializeObject(await message.Content.ReadAsStringAsync());
                    AccessToken = response.access_token;
                }
            }
        }
    }
}
