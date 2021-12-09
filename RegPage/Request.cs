using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RegPage
{
    public class Request
    {
        public string GetHtml(string url)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            HttpClient client = new HttpClient(handler);
            Header(ref client);
            var res = client.GetStringAsync(url).Result;
            return res;
        }

        public ResHttp Get(string url, List<Cookie> cookies)
        {
            CookieContainer container = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler()
            {
                CookieContainer = container,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            if (cookies != null)
                cookies.ForEach(ck => { container.Add(ck); });

            HttpClient client = new HttpClient(handler);
            Header(ref client);
            var res = client.GetAsync(url).Result;
            if (!res.IsSuccessStatusCode)
                return null;
            byte[] buffer = res.Content.ReadAsByteArrayAsync().Result;
            string html = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            return new ResHttp
            {
                Html = html,
                Cookies = container.GetCookies(new Uri(url)).Cast<Cookie>().ToList()
            };
        }

        public ResHttp Post(string url, Dictionary<string, string> dic, List<Cookie> cookies)
        {
            CookieContainer container = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler()
            {
                CookieContainer = container,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            if (cookies != null)
                cookies.ForEach(ck => { container.Add(ck); });

            HttpClient client = new HttpClient(handler);
            Header(ref client);
            var res = client.PostAsync(url, new FormUrlEncodedContent(dic)).Result;
            if (!res.IsSuccessStatusCode)
                return null;
            byte[] buffer = res.Content.ReadAsByteArrayAsync().Result;
            string html = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            return new ResHttp
            {
                Html = html,
                Cookies = container.GetCookies(new Uri(url)).Cast<Cookie>().ToList()
            };
        }

        public List<Cookie> StrToList(string CookieStr)
        {
            if (string.IsNullOrEmpty(CookieStr) || string.IsNullOrWhiteSpace(CookieStr))
                return null;

            List<string> Cookies = CookieStr.Split(';').ToList();
            if (Cookies.Count == 0)
                return null;

            List<Cookie> cookies = new List<Cookie>();

            Cookies.ForEach(cookie =>
            {
                string name = cookie.Split('=').First();
                string value = cookie.Replace($"{name}=", "");
                if (!(string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(name)) &&
                !(string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value)))
                {
                    try
                    {
                        Cookie ck = new Cookie(name, value, "/", ".facebook.com");
                        cookies.Add(ck);
                    }
                    catch (Exception) { }
                }
            });

            return cookies;
        }

        private void Header(ref HttpClient client)
        {
            client.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"");
            client.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
            client.DefaultRequestHeaders.TryAddWithoutValidation("upgrade-insecure-requests", "1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.93 Safari/537.36");
            client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            client.DefaultRequestHeaders.TryAddWithoutValidation("sec-fetch-site", "none");
            client.DefaultRequestHeaders.TryAddWithoutValidation("sec-fetch-mode", "navigate");
            client.DefaultRequestHeaders.TryAddWithoutValidation("sec-fetch-user", "?1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("sec-fetch-dest", "document");
            client.DefaultRequestHeaders.TryAddWithoutValidation("accept-encoding", "gzip, deflate");
            client.DefaultRequestHeaders.TryAddWithoutValidation("accept-language", "en-US,en;q=0.9,vi;q=0.8");
        }

        public class ResHttp
        {
            public List<Cookie> Cookies { get; set; }
            public string Html { get; set; }
        }
    }
}
