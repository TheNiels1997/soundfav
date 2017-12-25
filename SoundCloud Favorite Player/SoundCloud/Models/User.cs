namespace SoundCloud_Favorite_Player.SoundCloud.Models
{
    using Newtonsoft.Json;

    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
