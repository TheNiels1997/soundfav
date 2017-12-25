namespace SoundCloud_Favorite_Player.SoundCloud.Models
{
    using Newtonsoft.Json;

    public class Favorite
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("stream_url")]
        public string StreamUrl { get; set; }

        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
