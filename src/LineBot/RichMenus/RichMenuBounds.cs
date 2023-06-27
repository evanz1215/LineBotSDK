using Newtonsoft.Json;

namespace Line.RichMenus
{
    public class RichMenuBounds
    {
        public RichMenuBounds()
        {
        }

        public RichMenuBounds(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}