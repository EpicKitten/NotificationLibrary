using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace NotificationLibrary.Notification_Services.DiscordWebhooks
{
    public class DiscordWebhooks
    {
        private string discordwebhookurl;
        
        public DiscordWebhooks(string DiscordWebhookURL)
        {
            discordwebhookurl = DiscordWebhookURL;
        }
        public void MessageChannel(string message)
        {
            var postmsg = new Dictionary<string, string>
            {
               { "content", message},
            };
            HTTPMaster master = new HTTPMaster();
            master.SendPost(postmsg, discordwebhookurl);
        }
        public void MessageChannel(string title, string description, DiscordembedAuthor embedAuthor = null, List<DiscordEmbedField> embedFields = null, string titleurl = "", int R = 255, int G = 255, int B = 255, DiscordEmbedFooter embedFooter = null)
        {
            int deccolor = ((R * 256 * 256) + (G * 256) + B);
            JObject postmsg = new JObject(
                new JProperty("embeds",
                    new JArray(
                        new JObject(
                            new JProperty("author"),
                            new JProperty("title", title),
                            new JProperty("url", titleurl),
                            new JProperty("description", description),
                            new JProperty("color", deccolor),
                            new JProperty("fields", new JArray()),
                            new JProperty("footer")
                            ))));

            if (embedAuthor != null)
            {
                JObject authorjson = new JObject
                {
                    new JProperty("name", embedAuthor.Name),
                    new JProperty("url", embedAuthor.URL),
                    new JProperty("icon_url", embedAuthor.Icon_URL)
                };
                postmsg["embeds"][0]["author"] = authorjson;
            }

            if (embedFooter != null)
            {
                JObject footerjson = new JObject
                {
                    new JProperty("text", embedFooter.Text),
                    new JProperty("icon_url", embedFooter.Icon_URL)
                };
                postmsg["embeds"][0]["footer"] = footerjson;
            }

            JArray array = postmsg["embeds"][0]["fields"].ToObject<JArray>();
            foreach (DiscordEmbedField def in embedFields)
            {
                JObject jObject = new JObject
                {
                    new JProperty("name", def.Name),
                    new JProperty("value", def.Value),
                    new JProperty("inline", def.Inline)
                };
                array.Add(jObject);
            }
            postmsg["embeds"][0]["fields"] = array;
            System.Console.WriteLine(postmsg.ToString());
            HTTPMaster master = new HTTPMaster();
            master.SendPost(postmsg, discordwebhookurl);
        }
    }
    public class DiscordEmbedField
    {
        public string Name;
        public string Value;
        public bool Inline;
    }
    public class DiscordembedAuthor
    {
        public string Name;
        public string URL;
        public string Icon_URL;
    }
    public class DiscordEmbedFooter
    {
        public string Text;
        public string Icon_URL;
    }
}
