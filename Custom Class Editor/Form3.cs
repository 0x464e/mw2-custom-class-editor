using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using DevComponents.DotNetBar;


namespace Custom_Class_Editor
{
    public partial class Form3 : DevComponents.DotNetBar.Metro.MetroForm
    {
        string UpdatedFileName;
        JObject jsonFile;
        Stopwatch sw = new Stopwatch();

        public Form3()
        {
            InitializeComponent();

            try
            {
                jsonFile = JObject.Parse(new WebClient().DownloadString("https://www.dropbox.com/s/n8m5chuebo1x26q/MW2%20Custom%20Class%20Editor%20Dload%20Link.json?dl=1"));
            }

            catch(Exception E)
            {
                MessageBoxEx.Show("Error while trying to read updater file:\n\n" + E);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                WebClient downloader = new WebClient();
                downloader.DownloadFileCompleted += Completed;
                downloader.DownloadProgressChanged += ProgressChanged;
                UpdatedFileName = (string)jsonFile["updateName"]; 
                Uri url = new Uri((string)jsonFile["updateLink"]);
                sw.Start();
                try
                {
                    downloader.DownloadFileAsync(url, Application.StartupPath + "\\" + UpdatedFileName);
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("Error while trying to download the update: \n" + ex);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Error while trying to download the update: \n" + ex);
            }
        }

        void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarX1.Value = e.ProgressPercentage;
            labelX2.Text = e.ProgressPercentage + "%";
            labelX1.Text = $"Currently downloading the update. {e.BytesReceived / 1024d / 1024d:0.00} MB's / {e.TotalBytesToReceive / 1024d / 1024d:0.00} MB's @ {e.BytesReceived / 1924d / sw.Elapsed.TotalSeconds:0.00} kb/s";
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();

            if (MessageBoxEx.Show("Download complete!\nThe updated tool was saved to:\n" + Application.StartupPath + "\n\nWould you like to open the updated tool now?", "Update downloaded", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Process.Start(Application.StartupPath + "\\" + UpdatedFileName);
                Process.Start("http://www.se7ensins.com/forums/threads/Meow.1170984/");
                Application.Exit(); 
            }
            else
            {
                Close();
                Process.Start("http://www.se7ensins.com/forums/threads/Meow.1170984/");
            }
        } 
    }
}
