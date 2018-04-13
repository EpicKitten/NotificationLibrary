using NotificationLibrary.Notification_Services.DiscordWebhooks;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Net47_LibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscordWebhooks webhooks = new DiscordWebhooks("https://discordapp.com/api/webhooks/433824702826283018/8l0sO7fOsl0wETFd2wGMbfshsiPb58da_3mwRYr5uJuL11xE9406cxl5jFy0-TYArLkO");
            webhooks.MessageChannel("mems");
            DiscordEmbedField field = new DiscordEmbedField() { Name = "name1", Value = "val", Inline = true };
            DiscordEmbedField field2 = new DiscordEmbedField() { Name = "name13", Value = "2val", Inline = true };
            DiscordembedAuthor author = new DiscordembedAuthor() { Name = "kitten", URL = "https://gist.github.com/Birdie0/78ee79402a4301b1faf412ab5f1cdcf9", Icon_URL = "http://icons.iconarchive.com/icons/paomedia/small-n-flat/256/sign-check-icon.png" };
            webhooks.MessageChannel("title", "desc", author, new List<DiscordEmbedField>() { field, field2 }, "", 255, 255, 255, new DiscordEmbedFooter() { Text = "Footer", Icon_URL = "" });
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
