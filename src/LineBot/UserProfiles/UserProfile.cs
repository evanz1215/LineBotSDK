using Newtonsoft.Json;

namespace Line.UserProfiles
{
    public class UserProfile
    {
        [JsonProperty("userId")]
        public string UserId;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("pictureUrl")]
        public string PictureUrl;

        [JsonProperty("language")]
        public string Language;
    }
}