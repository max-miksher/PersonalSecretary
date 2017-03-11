using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using VarDumpDll;
using Newtonsoft.Json;
using System.Xml;

namespace PersonalSecretary
{
    public partial class Auth : Form
    {
        public static string client_id; // для адреса аккаунта, с которым мы работаем

        public static string[] access_token; // для ключа доступа к аккаунту

        public static string GetUrl(string client_id)
        {
            string url = "https://oauth.vk.com/authorize?" +
            "client_id=5787265" +
            "&display=page" +
            "&redirect_uri=https://oauth.vk.com/blank.html" +
            "&scope=9999999" +
            "&response_type=token" +
            "&v=5.60" +
            "&state=123456"; // для отправки GET-запроса серверу и получения ответа сервера

            return url;
        }
        

        public static Uri response; // для записи ответа сервера

        WebClient client; // объект, который отправляет и принимает запросы из url
        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            AuthBrowser.Navigate("https://m.vk.com/feed");
        }

        private void AuthBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //response = new Uri(AuthBrowser.Url);

            //access_token = response.Fragment.Split('=', '&');

            //if(access_token.Length>2)
            //this.textBox1.Text += "   " + access_token[1];

            //this.textBox1.Text += "   " + JsonConvert.SerializeObject(AuthBrowser.Url.AbsolutePath);
            try
            {
                //this.textBox1.Text += "---" + doc.GetElementsByTagName("FORM");

                HtmlElementCollection elems = AuthBrowser.Document.GetElementsByTagName("form");
                foreach (HtmlElement elem in elems)
                {
                    String nameStr = elem.GetAttribute("form");
                    if (nameStr != null && nameStr.Length != 0)
                    {
                        String contentStr = elem.GetAttribute("content");
                        this.textBox1.Text += "---" + "Document: " + AuthBrowser.Url.ToString() + "\nDescription: " + contentStr;
                    }
                }
            }
            catch
            {
                this.textBox1.Text += "  1  ";
            }


            //this.textBox1.Text += "   " + JsonConvert.SerializeObject(MathService.ParseCookie(AuthBrowser.Document.Cookie));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthBrowser.Navigate("https://m.vk.com/");
        }
        /*
private void buttonAccessToken_Click(object sender, EventArgs e)
{
webBrowser1.Navigate(GetUrl(this.textBox1.Text).Trim());
}

private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
{
response = new Uri (webBrowser1.Url.AbsoluteUri);
access_token = response.Fragment.Split('=','&')[1];
this.textBox2.Text = access_token;

string aa = "https://api.vk.com/method/status.set?text=qwer&access_token=" + access_token;

webBrowser1.Navigate(aa);
}*/
    }
}
