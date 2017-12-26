namespace SoundCloud_Favorite_Player.SoundCloud.Models
{
    using Newtonsoft.Json;

    public class Data
    {
        [JsonProperty("collection")]
        public Favorite[] Collection { get; set; }

        [JsonProperty("next_href")]
        public string NextPage { get; set; }
    }
}
