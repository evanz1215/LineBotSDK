using Line.Bots;
using Line.Constant;
using Line.Helpers;
using Line.Messages;
using Line.Messages.Audio;
using Line.Messages.Image;
using Line.Messages.Imagemap;
using Line.Messages.Location;
using Line.Messages.Sticker;
using Line.Messages.Text;
using Line.Messages.Video;
using Line.RichMenus;
using Line.UserProfiles;
using Line.Webhooks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Line
{
    public class LineBot
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClientData;

        public LineBot(string channelSecret, string channelAccessToken)
        {
            ChannelSecret = channelSecret;
            ChannelAccessToken = channelAccessToken;
            _httpClient = _httpClient ?? HttpClientFactory.Create(ChannelAccessToken);
            _httpClientData = _httpClientData ?? HttpClientFactory.CreateData(ChannelAccessToken);
        }

        #region BroadcastMessage

        #region BroadcastTextMessage

        public async Task BroadcastTextMessageAsync(IEnumerable<TextMessage> messages)
        {
            await BroadcastMessageAsync(messages);
        }

        public async Task BroadcastTextMessageAsync(TextMessage message)
        {
            var textMessages = new List<TextMessage> { message };
            await BroadcastMessageAsync(textMessages);
        }

        public async Task BroadcastTextMessageAsync(IEnumerable<string> messages)
        {
            var textMessages = new List<TextMessage>();
            foreach (var message in messages)
            {
                textMessages.Add(new TextMessage(message));
            }
            await BroadcastMessageAsync(textMessages);
        }

        public async Task BroadcastTextMessageAsync(string messaage)
        {
            var textMessage = new TextMessage(messaage);

            await BroadcastMessageAsync(textMessage);
        }

        public void BroadcastTextMessage(IEnumerable<TextMessage> messages)
        {
            BroadcastMessage broadcastMessage = new BroadcastMessage(messages);

            string jsonContent = JsonConvert.SerializeObject(broadcastMessage);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync(LineAPIConstant.BroadcastMessage, content);
            task.Wait(); // 等待非同步操作完成

            var response = task.Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                // 處理錯誤訊息
                Console.WriteLine($"錯誤訊息: {errorMessage}");
            }
        }

        public void BroadcastTextMessage(TextMessage message)
        {
            var textMessages = new List<TextMessage> { message };
            BroadcastTextMessage(textMessages);
        }

        public void BroadcastTextMessage(IEnumerable<string> messages)
        {
            var textMessages = new List<TextMessage>();
            foreach (var message in messages)
            {
                textMessages.Add(new TextMessage(message));
            }
            BroadcastTextMessage(textMessages);
        }

        public void BroadcastTextMessage(string messaage)
        {
            var textMessage = new TextMessage(messaage);

            BroadcastTextMessage(textMessage);
        }

        #endregion BroadcastTextMessage

        #region BroadcastImageMessage

        public async Task BroadcastImageMessageAsync(IEnumerable<ImageMessage> messages)
        {
            await BroadcastMessageAsync(messages);
        }

        public async Task BroadcastImageMessageAsync(ImageMessage message)
        {
            var imageMessages = new List<ImageMessage> { message };
            await BroadcastMessageAsync(imageMessages);
        }

        public async Task BroadcastImageMessageAsync(string originalContentUrl, string previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);

            await BroadcastMessageAsync(imageMessage);
        }

        public async Task BroadcastImageMessageAsync(Uri originalContentUrl, Uri previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);

            await BroadcastMessageAsync(imageMessage);
        }

        public void BroadcastImageMessage(IEnumerable<ImageMessage> messages)
        {
            BroadcastMessage(messages);
        }

        public void BroadcastImageMessage(ImageMessage message)
        {
            BroadcastMessage(message);
        }

        public void BroadcastImageMessage(string originalContentUrl, string previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);

            BroadcastImageMessage(imageMessage);
        }

        public void BroadcastImageMessage(Uri originalContentUrl, Uri previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);

            BroadcastImageMessage(imageMessage);
        }

        #endregion BroadcastImageMessage

        #region BroadcastVideoMessage

        public async Task BroadcastVideoMessageAsync(IEnumerable<VideoMessage> messages)
        {
            await BroadcastMessageAsync(messages);
        }

        public async Task BroadcastVideoMessageAsync(VideoMessage message)
        {
            var videoMessages = new List<VideoMessage> { message };
            await BroadcastMessageAsync(videoMessages);
        }

        public async Task BroadcastVideoMessageAsync(string originalContentUrl, string previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);

            await BroadcastMessageAsync(videoMessage);
        }

        public async Task BroadcastVideoMessageAsync(string originalContentUrl, string previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);

            await BroadcastMessageAsync(videoMessage);
        }

        public async Task BroadcastVideoMessageAsync(Uri originalContentUrl, Uri previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);

            await BroadcastMessageAsync(videoMessage);
        }

        public async Task BroadcastVideoMessageAsync(Uri originalContentUrl, Uri previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);

            await BroadcastMessageAsync(videoMessage);
        }

        public void BroadcastVideoMessage(IEnumerable<VideoMessage> messages)
        {
            BroadcastMessage(messages);
        }

        public void BroadcastVideoMessage(VideoMessage message)
        {
            BroadcastMessage(message);
        }

        public void BroadcastVideoMessage(string originalContentUrl, string previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);

            BroadcastVideoMessage(videoMessage);
        }

        public void BroadcastVideoMessage(string originalContentUrl, string previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);

            BroadcastVideoMessage(videoMessage);
        }

        public void BroadcastVideoMessage(Uri originalContentUrl, Uri previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);

            BroadcastVideoMessage(videoMessage);
        }

        public void BroadcastVideoMessage(Uri originalContentUrl, Uri previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);

            BroadcastVideoMessage(videoMessage);
        }

        #endregion BroadcastVideoMessage

        #region BroadcastAudioMessage

        public async Task BroadcastAudioMessageAsync(IEnumerable<AudioMessage> messages)
        {
            await BroadcastMessageAsync(messages);
        }

        public async Task BroadcastAudioMessageAsync(AudioMessage message)
        {
            var audioMessages = new List<AudioMessage> { message };
            await BroadcastMessageAsync(audioMessages);
        }

        public async Task BroadcastAudioMessageAsync(string originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);

            await BroadcastMessageAsync(audioMessage);
        }

        public async Task BroadcastAudioMessageAsync(Uri originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);

            await BroadcastMessageAsync(audioMessage);
        }

        public void BroadcastAudioMessage(IEnumerable<AudioMessage> messages)
        {
            BroadcastMessage(messages);
        }

        public void BroadcastAudioMessage(AudioMessage message)
        {
            BroadcastMessage(message);
        }

        public void BroadcastAudioMessage(string originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);

            BroadcastAudioMessage(audioMessage);
        }

        public void BroadcastAudioMessage(Uri originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);

            BroadcastAudioMessage(audioMessage);
        }

        #endregion BroadcastAudioMessage

        public async Task BroadcastMessageAsync(IEnumerable<IMessage> messages)
        {
            BroadcastMessage broadcastMessage = new BroadcastMessage(messages);

            string jsonContent = JsonConvert.SerializeObject(broadcastMessage);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(LineAPIConstant.BroadcastMessage, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                // 處理錯誤訊息
                Console.WriteLine($"錯誤訊息: {errorMessage}");
            }
        }

        public async Task BroadcastMessageAsync(IMessage message)
        {
            BroadcastMessage broadcastMessage = new BroadcastMessage(message);

            string jsonContent = JsonConvert.SerializeObject(broadcastMessage);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(LineAPIConstant.BroadcastMessage, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                // 處理錯誤訊息
                Console.WriteLine($"錯誤訊息: {errorMessage}");
            }
        }

        public void BroadcastMessage(IEnumerable<IMessage> messages)
        {
            BroadcastMessage broadcastMessage = new BroadcastMessage(messages);

            string jsonContent = JsonConvert.SerializeObject(broadcastMessage);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync(LineAPIConstant.BroadcastMessage, content);
            task.Wait(); // 等待非同步操作完成

            var response = task.Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                // 處理錯誤訊息
                Console.WriteLine($"錯誤訊息: {errorMessage}");
            }
        }

        public void BroadcastMessage(IMessage messages)
        {
            BroadcastMessage broadcastMessage = new BroadcastMessage(messages);

            string jsonContent = JsonConvert.SerializeObject(broadcastMessage);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync(LineAPIConstant.BroadcastMessage, content);
            task.Wait(); // 等待非同步操作完成

            var response = task.Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                // 處理錯誤訊息
                Console.WriteLine($"錯誤訊息: {errorMessage}");
            }
        }

        #endregion BroadcastMessage

        #region PushMessage

        #region PushTextMessage

        public async Task PushTextMessageAsync(string to, IEnumerable<TextMessage> messages)
        {
            await PushMessageAsync(to, messages);
        }

        public async Task PushTextMessageAsync(string to, TextMessage message)
        {
            await PushMessageAsync(to, message);
        }

        public async Task PushTextMessageAsync(string to, IEnumerable<string> message)
        {
            var textMessages = new List<TextMessage>();

            foreach (var item in message)
            {
                textMessages.Add(new TextMessage(item));
            }

            await PushMessageAsync(to, textMessages);
        }

        public async Task PushTextMessageAsync(string to, string message)
        {
            var textMessage = new TextMessage(message);

            await PushMessageAsync(to, textMessage);
        }

        public void PushTextMessage(string to, IEnumerable<TextMessage> messages)
        {
            PushMessage(to, messages);
        }

        public void PushTextMessage(string to, TextMessage message)
        {
            PushMessage(to, message);
        }

        public void PushTextMessage(string to, IEnumerable<string> message)
        {
            var textMessages = new List<TextMessage>();

            foreach (var item in message)
            {
                textMessages.Add(new TextMessage(item));
            }

            PushMessage(to, textMessages);
        }

        public void PushTextMessage(string to, string message)
        {
            var textMessage = new TextMessage(message);

            PushMessage(to, textMessage);
        }

        #endregion PushTextMessage

        #region PushImageMessage

        public async Task PushImageMessageAsync(string to, IEnumerable<ImageMessage> messages)
        {
            await PushMessageAsync(to, messages);
        }

        public async Task PushImageMessageAsync(string to, ImageMessage message)
        {
            await PushMessageAsync(to, message);
        }

        public async Task PushImageMessageAsync(string to, Uri originalContentUrl, Uri previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            await PushMessageAsync(to, imageMessage);
        }

        public async Task PushImageMessageAsync(string to, string originalContentUrl, string previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            await PushMessageAsync(to, imageMessage);
        }

        public void PushImageMessage(string to, IEnumerable<ImageMessage> messages)
        {
            PushMessage(to, messages);
        }

        public void PushImageMessage(string to, ImageMessage message)
        {
            PushMessage(to, message);
        }

        public void PushImageMessage(string to, Uri originalContentUrl, Uri previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            PushMessage(to, imageMessage);
        }

        public void PushImageMessage(string to, string originalContentUrl, string previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            PushMessage(to, imageMessage);
        }

        #endregion PushImageMessage

        #region PushVideoMessage

        public void PushVideoMessage(string to, IEnumerable<VideoMessage> messages)
        {
            PushMessage(to, messages);
        }

        public void PushVideoMessage(string to, VideoMessage message)
        {
            PushMessage(to, message);
        }

        public void PushVideoMessage(string to, string originalContentUrl, string previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);
            PushMessage(to, videoMessage);
        }

        public void PushVideoMessage(string to, string originalContentUrl, string previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);
            PushMessage(to, videoMessage);
        }

        public void PushVideoMessage(string to, Uri originalContentUrl, Uri previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);
            PushMessage(to, videoMessage);
        }

        public void PushVideoMessage(string to, Uri originalContentUrl, Uri previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);
            PushMessage(to, videoMessage);
        }

        public async Task PushVideoMessageAsync(string to, IEnumerable<VideoMessage> messages)
        {
            await PushMessageAsync(to, messages);
        }

        public async Task PushVideoMessageAsync(string to, VideoMessage message)
        {
            await PushMessageAsync(to, message);
        }

        public async Task PushVideoMessageAsync(string to, string originalContentUrl, string previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);
            await PushMessageAsync(to, videoMessage);
        }

        public async Task PushVideoMessageAsync(string to, string originalContentUrl, string previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);
            await PushMessageAsync(to, videoMessage);
        }

        public async Task PushVideoMessageAsync(string to, Uri originalContentUrl, Uri previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);
            await PushMessageAsync(to, videoMessage);
        }

        public async Task PushVideoMessageAsync(string to, Uri originalContentUrl, Uri previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);
            await PushMessageAsync(to, videoMessage);
        }

        #endregion PushVideoMessage

        #region PushAudioMessage

        public async Task PushAudioMessageAsync(string to, IEnumerable<AudioMessage> messages)
        {
            await PushMessageAsync(to, messages);
        }

        public async Task PushAudioMessageAsync(string to, AudioMessage message)
        {
            await PushMessageAsync(to, message);
        }

        public async Task PushAudioMessageAsync(string to, string originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);
            await PushMessageAsync(to, audioMessage);
        }

        public async Task PushAudioMessageAsync(string to, Uri originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);
            await PushMessageAsync(to, audioMessage);
        }

        public void PushAudioMessage(string to, IEnumerable<AudioMessage> messages)
        {
            PushMessage(to, messages);
        }

        public void PushAudioMessage(string to, AudioMessage message)
        {
            PushMessage(to, message);
        }

        public void PushAudioMessage(string to, string originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);
            PushMessage(to, audioMessage);
        }

        public void PushAudioMessage(string to, Uri originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);
            PushMessage(to, audioMessage);
        }

        #endregion PushAudioMessage

        #region PushStickerMessage

        public void PushStickerMessage(string to, IEnumerable<StickerMessage> messages)
        {
            PushMessage(to, messages);
        }

        public void PushStickerMessage(string to, StickerMessage message)
        {
            PushMessage(to, message);
        }

        public void PushStickerMessage(string to, string packageId, string stickerId)
        {
            var stickerMessage = new StickerMessage(packageId, stickerId);
            PushMessage(to, stickerMessage);
        }

        public async Task PushStickerMessageAsync(string to, IEnumerable<StickerMessage> messages)
        {
            await PushMessageAsync(to, messages);
        }

        public async Task PushStickerMessageAsync(string to, StickerMessage message)
        {
            await PushMessageAsync(to, message);
        }

        public async Task PushStickerMessageAsync(string to, string packageId, string stickerId)
        {
            var stickerMessage = new StickerMessage(packageId, stickerId);
            await PushMessageAsync(to, stickerMessage);
        }

        #endregion PushStickerMessage

        #region PushLocationMessage

        public void PushLocationMessage(string to, IEnumerable<LocationMessage> messages)
        {
            PushMessage(to, messages);
        }

        public void PushLocationMessage(string to, LocationMessage message)
        {
            PushMessage(to, message);
        }

        public void PushLocationMessage(string to, string title, string address, decimal latitude, decimal longitude)
        {
            var locationMessage = new LocationMessage(title, address, latitude, longitude);
            PushMessage(to, locationMessage);
        }

        public async Task PushLocationMessageAsync(string to, IEnumerable<LocationMessage> messages)
        {
            await PushMessageAsync(to, messages);
        }

        public async Task PushLocationMessageAsync(string to, LocationMessage message)
        {
            await PushMessageAsync(to, message);
        }

        public async Task PushLocationMessageAsync(string to, string title, string address, decimal latitude, decimal longitude)
        {
            var locationMessage = new LocationMessage(title, address, latitude, longitude);
            await PushMessageAsync(to, locationMessage);
        }

        #endregion PushLocationMessage

        #region PushImagemapMessage

        private void PushImagemapMessage(string to, IEnumerable<ImagemapMessage> messages)
        {
            PushMessage(to, messages);
        }

        private async Task PushImagemapMessageAsync(string to, IEnumerable<ImagemapMessage> messages)
        {
            await PushMessageAsync(to, messages);
        }

        private async Task PushImagemapMessageAsync(string to, ImagemapMessage message)
        {
            await PushMessageAsync(to, message);
        }

        #endregion PushImagemapMessage

        public async Task PushMessageAsync(string to, IEnumerable<IMessage> messages)
        {
            var pushMessage = new PushMessage(to, messages);
            string jsonContent = JsonConvert.SerializeObject(pushMessage);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(LineAPIConstant.PushMessageUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
        }

        public async Task PushMessageAsync(string to, IMessage message)
        {
            var pushMessage = new PushMessage(to, message);
            string jsonContent = JsonConvert.SerializeObject(pushMessage);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(LineAPIConstant.PushMessageUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
        }

        public void PushMessage(string to, IEnumerable<IMessage> messages)
        {
            var pushMessage = new PushMessage(to, messages);
            string jsonContent = JsonConvert.SerializeObject(pushMessage);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync(LineAPIConstant.PushMessageUrl, content);
            task.Wait(); // 等待非同步操作完成
            var response = task.Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new Exception(errorMessage);
            }
        }

        public void PushMessage(string to, IMessage message)
        {
            var pushMessage = new PushMessage(to, message);
            string jsonContent = JsonConvert.SerializeObject(pushMessage);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync(LineAPIConstant.PushMessageUrl, content);
            task.Wait(); // 等待非同步操作完成
            var response = task.Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new Exception(errorMessage);
            }
        }

        #endregion PushMessage

        #region ReplyMessage

        #region ReplyTextMessage

        public async Task ReplyTextMessageAsync(string replyToken, IEnumerable<TextMessage> messages)
        {
            await ReplyMessageAsync(replyToken, messages);
        }

        public async Task ReplyTextMessageAsync(string replyToken, TextMessage message)
        {
            await ReplyMessageAsync(replyToken, message);
        }

        public async Task ReplyTextMessageAsync(string replyToken, string message)
        {
            var textMessage = new TextMessage(message);
            await ReplyMessageAsync(replyToken, textMessage);
        }

        public async Task ReplyTextMessageAsync(string replyToken, IEnumerable<string> messages)
        {
            List<TextMessage> textMessages = new List<TextMessage>();

            foreach (var message in messages)
            {
                textMessages.Add(new TextMessage(message));
            }

            await ReplyMessageAsync(replyToken, textMessages);
        }

        public void ReplyTextMessage(string replyToken, IEnumerable<TextMessage> messages)
        {
            ReplyMessage(replyToken, messages);
        }

        public void ReplyTextMessage(string replyToken, TextMessage message)
        {
            ReplyMessage(replyToken, message);
        }

        public void ReplyTextMessage(string replyToken, string message)
        {
            var textMessage = new TextMessage(message);
            ReplyMessage(replyToken, textMessage);
        }

        public void ReplyTextMessage(string replyToken, IEnumerable<string> messages)
        {
            List<TextMessage> textMessages = new List<TextMessage>();

            foreach (var message in messages)
            {
                textMessages.Add(new TextMessage(message));
            }

            ReplyMessage(replyToken, textMessages);
        }

        #endregion ReplyTextMessage

        #region ReplyImageMessage

        public async Task ReplyImageMessageAsync(string replyToken, IEnumerable<ImageMessage> messages)
        {
            await ReplyMessageAsync(replyToken, messages);
        }

        public async Task ReplyImageMessageAsync(string replyToken, ImageMessage message)
        {
            await ReplyMessageAsync(replyToken, message);
        }

        public async Task ReplyImageMessageAsync(string replyToken, Uri originalContentUrl, Uri previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            await ReplyMessageAsync(replyToken, imageMessage);
        }

        public async Task ReplyImageMessageAsync(string replyToken, string originalContentUrl, string previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            await ReplyMessageAsync(replyToken, imageMessage);
        }

        public void ReplyImageMessage(string replyToken, IEnumerable<ImageMessage> messages)
        {
            ReplyMessage(replyToken, messages);
        }

        public void ReplyImageMessage(string replyToken, ImageMessage message)
        {
            ReplyMessage(replyToken, message);
        }

        public void ReplyImageMessage(string replyToken, Uri originalContentUrl, Uri previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            ReplyMessage(replyToken, imageMessage);
        }

        public void ReplyImageMessage(string replyToken, string originalContentUrl, string previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            ReplyMessage(replyToken, imageMessage);
        }

        #endregion ReplyImageMessage

        public async Task ReplyMessageAsync(string replyToken, IEnumerable<IMessage> messages)
        {
            var replyMessage = new ReplyMessage(replyToken, messages);
            string jsonContent = JsonConvert.SerializeObject(replyMessage);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"message/reply", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
        }

        public async Task ReplyMessageAsync(string replyToken, IMessage messages)
        {
            var replyMessage = new ReplyMessage(replyToken, messages);

            string jsonContent = JsonConvert.SerializeObject(replyMessage);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"message/reply", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
        }

        public void ReplyMessage(string replyToken, IEnumerable<IMessage> messages)
        {
            var replyMessage = new ReplyMessage(replyToken, messages);

            string jsonContent = JsonConvert.SerializeObject(replyMessage);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync($"message/reply", content);
            task.Wait(); // 等待非同步操作完成
            var response = task.Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new Exception(errorMessage);
            }
        }

        public void ReplyMessage(string replyToken, IMessage message)
        {
            var replyMessage = new ReplyMessage(replyToken, message);

            string jsonContent = JsonConvert.SerializeObject(replyMessage);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync($"message/reply", content);
            task.Wait(); // 等待非同步操作完成
            var response = task.Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new Exception(errorMessage);
            }
        }

        #endregion ReplyMessage

        #region MulticastMessage

        #region MulticatTextMessage

        public async Task MulticastTextMessageAsync(IEnumerable<string> to, IEnumerable<TextMessage> messages)
        {
            await MulticastMessageAsync(to, messages);
        }

        public async Task MulticastTextMessageAsync(IEnumerable<string> to, TextMessage message)
        {
            List<TextMessage> textMessages = new List<TextMessage>() { message };
            await MulticastMessageAsync(to, textMessages);
        }

        public async Task MulticastTextMessageAsync(IEnumerable<string> to, string message)
        {
            var textMessage = new TextMessage(message);

            await MulticastMessageAsync(to, textMessage);
        }

        #endregion MulticatTextMessage

        #region MulticastImageMessage

        public async Task MulticastImageMessageAsync(IEnumerable<string> to, IEnumerable<ImageMessage> messages)
        {
            await MulticastMessageAsync(to, messages);
        }

        public async Task MulticastImageMessageAsync(IEnumerable<string> to, ImageMessage message)
        {
            List<ImageMessage> imageMessages = new List<ImageMessage>() { message };
            await MulticastMessageAsync(to, imageMessages);
        }

        public async Task MulticastImageMessageAsync(IEnumerable<string> to, Uri originalContentUrl, Uri previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            await MulticastMessageAsync(to, imageMessage);
        }

        public async Task MulticastImageMessageAsync(IEnumerable<string> to, string originalContentUrl, string previewImageUrl)
        {
            var imageMessage = new ImageMessage(originalContentUrl, previewImageUrl);
            await MulticastMessageAsync(to, imageMessage);
        }

        #endregion MulticastImageMessage

        #region MulticastVideoMessage

        public async Task MulticastVideoMessageAsync(IEnumerable<string> to, IEnumerable<VideoMessage> messages)
        {
            await MulticastMessageAsync(to, messages);
        }

        public async Task MulticastVideoMessageAsync(IEnumerable<string> to, VideoMessage message)
        {
            List<VideoMessage> videoMessages = new List<VideoMessage>() { message };
            await MulticastMessageAsync(to, videoMessages);
        }

        public async Task MulticastVideoMessageAsync(IEnumerable<string> to, Uri originalContentUrl, Uri previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);
            await MulticastMessageAsync(to, videoMessage);
        }

        public async Task MulticastVideoMessageAsync(IEnumerable<string> to, Uri originalContentUrl, Uri previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);
            await MulticastMessageAsync(to, videoMessage);
        }

        public async Task MulticastVideoMessageAsync(IEnumerable<string> to, string originalContentUrl, string previewImageUrl)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl);
            await MulticastMessageAsync(to, videoMessage);
        }

        public async Task MulticastVideoMessageAsync(IEnumerable<string> to, string originalContentUrl, string previewImageUrl, string trackingId)
        {
            var videoMessage = new VideoMessage(originalContentUrl, previewImageUrl, trackingId);
            await MulticastMessageAsync(to, videoMessage);
        }

        #endregion MulticastVideoMessage

        #region MulticastAudioMessage

        public async Task MulticastAudioMessageAsync(IEnumerable<string> to, IEnumerable<AudioMessage> messages)
        {
            await MulticastMessageAsync(to, messages);
        }

        public async Task MulticastAudioMessageAsync(IEnumerable<string> to, AudioMessage message)
        {
            List<AudioMessage> audioMessages = new List<AudioMessage>() { message };
            await MulticastMessageAsync(to, audioMessages);
        }

        public async Task MulticastAudioMessageAsync(IEnumerable<string> to, Uri originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);
            await MulticastMessageAsync(to, audioMessage);
        }

        public async Task MulticastAudioMessageAsync(IEnumerable<string> to, string originalContentUrl, int duration)
        {
            var audioMessage = new AudioMessage(originalContentUrl, duration);
            await MulticastMessageAsync(to, audioMessage);
        }

        #endregion MulticastAudioMessage

        public async Task MulticastMessageAsync(IEnumerable<string> to, IEnumerable<IMessage> messages)
        {
            var multicastMessage = new MulticastMessage(to, messages);
            string jsonContent = JsonConvert.SerializeObject(multicastMessage);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(LineAPIConstant.MulticastMessageUrl, stringContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task MulticastMessageAsync(IEnumerable<string> to, IMessage message)
        {
            var multicastMessage = new MulticastMessage(to, message);
            string jsonContent = JsonConvert.SerializeObject(multicastMessage);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(LineAPIConstant.MulticastMessageUrl, stringContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        #endregion MulticastMessage

        #region Bot

        public BotInfo GetBotInfo()
        {
            var task = _httpClient.GetAsync($"{LineAPIConstant.BotInfoUrl}");
            task.Wait();
            var response = task.Result;

            //response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new Exception(errorMessage);
            }

            var content = response.Content.ReadAsStringAsync().Result;
            var botInfo = JsonConvert.DeserializeObject<BotInfo>(content);
            return botInfo;
        }

        public async Task<BotInfo> GetBotInfoAsync()
        {
            var response = await _httpClient.GetAsync($"{LineAPIConstant.BotInfoUrl}");
            //response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
            var botInfo = JsonConvert.DeserializeObject<BotInfo>(content);
            return botInfo;
        }

        #endregion Bot

        #region UserProfile

        public UserProfile GetUserProfile(string userId)
        {
            var task = _httpClient.GetAsync($"{LineAPIConstant.ProfileUrl}/{userId}");
            task.Wait();

            var response = task.Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new Exception(errorMessage);
            }

            var content = response.Content.ReadAsStringAsync().Result;
            var userProfile = JsonConvert.DeserializeObject<UserProfile>(content);
            return userProfile;
        }

        public async Task<UserProfile> GetUserProfileAsync(string userId)
        {
            var response = await _httpClient.GetAsync($"{LineAPIConstant.ProfileUrl}/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
            var userProfile = JsonConvert.DeserializeObject<UserProfile>(content);
            return userProfile;
        }

        #endregion UserProfile

        #region RichMenu

        public async Task<RichMenusResponse> GetRichMenusAsync()
        {
            var response = await _httpClient.GetAsync($"richmenu/list");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();

            var richMenu = JsonConvert.DeserializeObject<RichMenusResponse>(content);

            return richMenu;
        }

        public async Task<RichMenu> GetRichMenuAsync(string richMenuId)
        {
            var response = await _httpClient.GetAsync($"richmenu/{richMenuId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();

            var richMenu = JsonConvert.DeserializeObject<RichMenu>(content);

            return richMenu;
        }

        public async Task SetDefaultRichMenuAsync(string richMenuId)
        {
            var response = await _httpClient.PostAsync($"user/all/richmenu/{richMenuId}", null);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteRichMenuAsync(string richMenuId)
        {
            var response = await _httpClient.DeleteAsync($"richmenu/{richMenuId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task<string> CreateRichMenuAsync(RichMenu richMenu)
        {
            var jsonContent = JsonConvert.SerializeObject(richMenu);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"richmenu", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();

            var richMenuIdResponse = JsonConvert.DeserializeObject<RichMenuIdResponse>(content);

            return richMenuIdResponse?.RichMenuId;
        }

        public async Task<bool> ValidateRichMenuAsync(RichMenu richMenu)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(richMenu);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"richmenu/validate", stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }

                var content = await response.Content.ReadAsStringAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task SetRichMenuImageAsync(string richMenuId, byte[] imageData)
        {
            var byteContent = new ByteArrayContent(imageData);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            var response = await _httpClient.PostAsync($"richmenu/{richMenuId}/content", byteContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task SetRichMenuImageAsync(string richMenuId, Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                var imageData = memoryStream.ToArray();

                var byteContent = new ByteArrayContent(imageData);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                //var ccc = @"richmenu/richmenu-70e38a15d7192067155f700e930188bd/content";
                var response = await _httpClientData.PostAsync($"richmenu/{richMenuId}/content", byteContent);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }

                var content = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task GetRichMenuImageAsync(string richMenuId)
        {
            var response = await _httpClientData.GetAsync($"richmenu/{richMenuId}/content");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStreamAsync();
        }

        public async Task GetDefaultRichMenuAsync()
        {
            var response = await _httpClient.GetAsync($"user/all/richmenu");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteDefaultRichMenuAsync()
        {
            var response = await _httpClient.DeleteAsync($"user/all/richmenu");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task GetUserDefaultRichMenuAsync(string userId)
        {
            var response = await _httpClient.GetAsync($"user/{userId}/richmenu");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task SetUserDefaultRichMenuAsync(string userId, string richMenuId)
        {
            var response = await _httpClient.PostAsync($"user/{userId}/richmenu/{richMenuId}", null);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteUserDefaultRichMenuAsync(string userId)
        {
            var response = await _httpClient.DeleteAsync($"user/{userId}/richmenu");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task GetRichMenuAliasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"richmenu/alias/list");

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }

                var content = await response.Content.ReadAsStringAsync();
            }
            catch
            {
                Console.WriteLine("");
            }
        }

        public async Task SetRichMenuAliasAsync(SetRichMenuAliasDto setRichMenuAliasDto)
        {
            var jsonContent = JsonConvert.SerializeObject(setRichMenuAliasDto);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"richmenu/alias", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteRichMenuAliasAsync(string richMenuAliasId)
        {

            var response = await _httpClient.DeleteAsync($"richmenu/alias/{richMenuAliasId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();


        }

        #endregion RichMenu

        #region Group

        public async Task LeaveGroupAsync(string groupId)
        {
            var response = await _httpClient.PostAsync($"group/{groupId}/leave", null);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task GetGroupSummaryAsync(string groupId)
        {
            var response = await _httpClient.GetAsync($"group/{groupId}/summary");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        #endregion Group

        #region Room

        //public async Task LeaveRoomAsync(string roomId)
        //{
        //    var response = await _httpClient.PostAsync($"room/{roomId}/leave", null);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        var errorMessage = await response.Content.ReadAsStringAsync();
        //        throw new Exception(errorMessage);
        //    }

        //    var content = await response.Content.ReadAsStringAsync();
        //}

        #endregion Room

        #region Webhook

        /// <summary>
        /// 取得Webhook資訊
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WebhookInfo> GetWebhookEndpointAsync()
        {
            var response = await _httpClient.GetAsync($"channel/webhook/endpoint");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
            var webhookInfo = JsonConvert.DeserializeObject<WebhookInfo>(content);
            return webhookInfo;
        }

        /// <summary>
        /// 更新Webhook
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task UpdateWebhookEnpointAsync(string endpoint)
        {
            WebhookForUpdateDto webhookForUpdateDto = new WebhookForUpdateDto(endpoint);

            await UpdateWebhookEnpointAsync(webhookForUpdateDto);
        }

        /// <summary>
        /// 更新Webhook
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task UpdateWebhookEnpointAsync(Uri endpoint)
        {
            WebhookForUpdateDto webhookForUpdateDto = new WebhookForUpdateDto(endpoint);

            await UpdateWebhookEnpointAsync(webhookForUpdateDto);
        }

        /// <summary>
        /// 更新Webhook
        /// </summary>
        /// <param name="webhookForUpdateDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateWebhookEnpointAsync(WebhookForUpdateDto webhookForUpdateDto)
        {
            string jsonContent = JsonConvert.SerializeObject(webhookForUpdateDto);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"channel/webhook/endpoint", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 測試Webhook是否正常
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WebhookTestResponse> TestWebhookEndpointAsync(string endpoint)
        {
            WebhookForTestDto webhookForTestDto = new WebhookForTestDto(endpoint);

            var jsonContent = JsonConvert.SerializeObject(webhookForTestDto);

            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("channel/webhook/test", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

            var content = await response.Content.ReadAsStringAsync();

            var webhookTestResponse = JsonConvert.DeserializeObject<WebhookTestResponse>(content);

            return webhookTestResponse;
        }

        #endregion Webhook

        #region property

        private string _channelAccessToken;

        public string ChannelAccessToken
        {
            get { return _channelAccessToken; }
            set { _channelAccessToken = value; }
        }

        private string _channelSecret;

        public string ChannelSecret
        {
            get { return _channelSecret; }
            set { _channelSecret = value; }
        }

        #endregion property
    }
}