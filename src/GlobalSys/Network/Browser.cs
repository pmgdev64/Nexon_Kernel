using System;
using Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using NexonKernel.Network;
using NexonKernel.Network.Ui;

namespace NexonKernel.Network
{
    public class Browser
    {
        private Canvas canvas;

        public Browser(Canvas canvas)
        {
            this.canvas = canvas;
            TextRenderer.Init(canvas);
        }

        public void Start()
        {
            TextRenderer.Clear();
            TextRenderer.Print("NexonBrowser - Enter URL:", Color.White);
            string url = ReadInput();

            if (!url.StartsWith("http://")) {
                url = "http://" + url;
            }

            string host = ExtractHost(url);
            string path = ExtractPath(url);

            string response = HttpClient.SendGetRequest(host, path);
            DisplayResponse(response);
        }

        private string ReadInput()
        {
            string input = "";
            while (true)
            {
                var key = KeyboardManager.ReadKey();
                if (key.Key == ConsoleKeyEx.Enter)
                    break;
                if (key.Key == ConsoleKeyEx.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                }
                else
                {
                    input += key.KeyChar;
                }
                TextRenderer.Print(input, Color.Cyan);
            }
            return input;
        }

        private void DisplayResponse(string html)
        {
            TextRenderer.Clear();
            TextRenderer.Print("Response:\n", Color.Yellow);

            // Strip tags for demo (basic viewer)
            string stripped = System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", "");
            TextRenderer.Print(stripped, Color.LightGray);
        }

        private string ExtractHost(string url)
        {
            string trimmed = url.Replace("http://", "");
            int slash = trimmed.IndexOf('/');
            return slash > 0 ? trimmed.Substring(0, slash) : trimmed;
        }

        private string ExtractPath(string url)
        {
            string trimmed = url.Replace("http://", "");
            int slash = trimmed.IndexOf('/');
            return slash > 0 ? trimmed.Substring(slash) : "/";
        }
    }
}
