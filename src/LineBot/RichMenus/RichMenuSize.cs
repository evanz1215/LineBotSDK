using Newtonsoft.Json;

namespace Line.RichMenus
{
    public class RichMenuSize
    {
        public RichMenuSize()
        {
        }

        public RichMenuSize(int height)
        {
            Height = height;
        }

        [JsonProperty("width")]
        public int Width { get; set; } = 2500;

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}