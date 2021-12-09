using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegPage
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            Rlogs.ReadOnly = true;
            Rcookies.ReadOnly = true;
            btnStop.Enabled = false;
        }

        public static List<Thread> threads = new List<Thread>();
        public static Queue<string> qCookies = new Queue<string>();
        private Request request = new Request();
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

        private void Main(string cookie)
        {
            if (string.IsNullOrEmpty(cookie) || string.IsNullOrWhiteSpace(cookie))
                return;

            List<Cookie> cookies = request.StrToList(cookie);

            InfoFacebook info = GetInfo(cookies);

            //var res = request.Get(ManagerUrl.CreatePage, cookies);

            // TÊN PAGE NÈ MẤY ÔNG NỘI
            string namePage = "VÕ MINH THÀNH";

            Dictionary<string, string> EditName = DataEditName(info, namePage);
            var postEditName = request.Post(ManagerUrl.EditName, EditName, cookies);

            JFacebook.EditName.EditName_Root JEditName = JsonConvert.DeserializeObject<JFacebook.EditName.EditName_Root>(postEditName.Html.Replace("for (;;);", ""));

            var res = request.Get(ManagerUrl.Creation_flow_Name
                .Replace("NAMEPAGE", namePage)
                .Replace("DRAFT_ID", Convert.ToString(JEditName.payload.payload.draftID)), cookies);

            var Dother = DataOther(info);
            var other = request.Post(ManagerUrl.Select_Other, Dother, cookies);
            JFacebook.EditCategory.EditCategory_Root JEditCategory_Root = JsonConvert.DeserializeObject<JFacebook.EditCategory.EditCategory_Root>(other.Html.Replace("for (;;);", ""));

            doc.LoadHtml(JEditCategory_Root.payload.actions.First().html);
            var option = doc.DocumentNode.SelectNodes("//select/option").ToList();
            string page_category = option.Last().Attributes["value"].Value;

            Dictionary<string, string> Category =
                EditCategory(info, page_category, Convert.ToString(JEditName.payload.payload.draftID));
            var edit_category = request.Post(ManagerUrl.EditCategory, Category, cookies);
            //tự check json
        }

        InfoFacebook GetInfo(List<Cookie> cookies)
        {
            var res = request.Get(ManagerUrl.Profile, cookies);
            if (!res.Html.Contains("fb_dtsg") && !res.Html.Contains("jazoest"))
                return null;

            doc.LoadHtml(res.Html);

            return new InfoFacebook
            {
                fb_dtsg = doc.DocumentNode.SelectSingleNode("//input[@name ='fb_dtsg']").Attributes["value"].Value,
                jazoest = doc.DocumentNode.SelectSingleNode("//input[@name ='jazoest']").Attributes["value"].Value,
                Uid = cookies.FirstOrDefault(x => x.Name == "c_user").Value
            };
        }

        #region Data Post
        Dictionary<string, string> DataEditName(InfoFacebook info, string namePage)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("page_name", namePage);
            dic.Add("fb_dtsg", info.fb_dtsg);
            dic.Add("jazoest", info.jazoest);
            dic.Add("lsd", "is1gFmpq-TdJHRPEUn23wX");
            dic.Add("__dyn", "1KQdAGm1gwHwh8-t0BBBgS5UdEO3m2i5U4e0C8dEc8uwaS6Uhx60kO4o3Bw4Ewk9EdEnw9u0XoswvosyU6S0veeKdwbK0JE52229wcq0C8fo2IwKw9O0iC1qw8W1uwa-7U881soGdw46w");
            dic.Add("__csr", "");
            dic.Add("__req", "4");
            dic.Add("__a", "AYlNi9EzkSRedMrZwhqaL3iUCoQX8-xwxEvj1YqexPXGmBqCOUx-APl_1lbRcZ4ncwUsUyw8tz2wvcWZdgonDeOlyE-gGN8giAwvDLdTx-G--Q");
            dic.Add("__user", info.Uid);
            return dic;
        }
        Dictionary<string, string> DataOther(InfoFacebook info)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("fb_dtsg", info.fb_dtsg);
            dic.Add("jazoest", info.jazoest);
            dic.Add("lsd", "LwJRAIsJ7fR-_dnQ4Qpfw9");
            dic.Add("__dyn", "1KQdAGm1gwHwh8-t0BBBgS5UdEO3m2i5U4e0C8dEc8uwaS6Uhx60kO4o3Bw4Ewk9EdEnw9u0XoswvosyU6S0veeKdwbK0JE52229wcq0C8fo2IwKw9O0iC1qw8W1uwa-7U881soGdw46w");
            dic.Add("__csr", "");
            dic.Add("__req", "3");
            dic.Add("__a", "AYnRmpcxeLKlalW3p1WzpsPhkwH8EWbA464Xnq4aGZSaZXnRIGSb7UQUmq5EMIMyGT1Z1AmUMwPBPt-0SAbycBiACvbjm8STjW-nfFvaNd1nAQ");
            dic.Add("__user", info.Uid);
            return dic;
        }
        Dictionary<string, string> EditCategory(InfoFacebook info, string page_category, string draft_id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("page_category", page_category);
            dic.Add("ref_type", "unknown");
            dic.Add("draft_id", draft_id);
            dic.Add("fb_dtsg", info.fb_dtsg);
            dic.Add("jazoest", info.jazoest);
            dic.Add("lsd", "LwJRAIsJ7fR-_dnQ4Qpfw9");
            dic.Add("__dyn", "1KQdAGm1gwHwh8-t0BBBgS5UdEO3m2i5U4e0C8dEc8uwaS6Uhx60kO4o3Bw4Ewk9EdEnw9u0XoswvosyU6S0veeKdwbK0JE52229wcq0C8fo2IwKw9O0iC1qw8W1uwa-7U881soGdw46w");
            dic.Add("__csr", "");
            dic.Add("__req", "d");
            dic.Add("__a", "AYnRmpcxeLKlalW3p1WzpsPhkwH8EWbA464Xnq4aGZSaZXnRIGSb7UQUmq5EMIMyGT1Z1AmUMwPBPt-0SAbycBiACvbjm8STjW-nfFvaNd1nAQ");
            dic.Add("__user", info.Uid);
            return dic;
        }
        #endregion

        private void btnGetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
                txtTinsoft.Text = open.FileName;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (string.IsNullOrEmpty(Rcookies.Text) && string.IsNullOrWhiteSpace(Rcookies.Text))
                {
                    XtraMessageBox.Show("Không có cookie", "Error");
                    return;
                }

                Rcookies.Text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList()
                .ForEach(ck => { qCookies.Enqueue(ck); });

                btnStop.Enabled = true;

                while (qCookies.Count != 0)
                {
                    int numThread = qCookies.Count > Convert.ToInt32(nThread.Value) ? Convert.ToInt32(nThread.Value) : qCookies.Count;
                    for (int i = 0; i < numThread; i++)
                    {
                        string cookie = qCookies.Dequeue();
                        Thread thread = new Thread(() =>
                        {
                            Main(cookie);
                        });
                        thread.Start();
                        thread.IsBackground = true;
                        threads.Add(thread);
                        Thread.Sleep(300);
                    }

                    foreach (Thread thread in threads)
                    {
                        try
                        {
                            thread.Join();
                        }
                        catch (Exception) { }
                    }
                }
            });
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (threads.Count != 0)
            {
                foreach (Thread thread in threads)
                {
                    try
                    {
                        thread.Abort();
                    }
                    catch (Exception) { }
                }
            }
            qCookies.Clear();
        }

    }

    public class InfoFacebook
    {
        public string fb_dtsg { get; set; }
        public string jazoest { get; set; }
        public string Uid { get; set; }
    }
}
