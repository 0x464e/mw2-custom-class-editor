using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using XRPCLib;
using System.Net;

namespace Custom_Class_Editor
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        XRPC Ox = new XRPC();
        public uint SV = 0x82254940;
        
        

        #region stringei
        string cb11c, cb12c, cb13c, cb14c, cb15c, cb16c, cb17c, cb18c, cb19c, cb20c;

        string cb21sc, cb22sc, cb23sc, cb24sc, cb25sc, cb26sc, cb27sc, cb28sc, cb29sc, cb30sc;

        string cb31ls, cb32ls, cb33ls, cb34ls, cb35ls, cb36ls, cb37ls, cb38ls, cb39ls, cb40ls;

        string cb1txt, cb2txt, cb3txt, cb4txt, cb5txt, cb6txt, cb7txt, cb8txt, cb9txt, cb10txt, cb11txt, cb12txt, cb13txt, cb14txt, cb15txt, cb16txt, cb17txt, cb18txt, cb19txt, cb20txt, cb21txt, cb22txt, cb23txt, cb24txt, cb25txt, cb26txt, cb27txt, cb28txt, cb29txt, cb30txt, cb31txt, cb32txt, cb33txt, cb34txt, cb35txt, cb36txt, cb37txt, cb38txt, cb39txt, cb40txt;

        string tb2txt, tb3txt, tb4txt, tb5txt, tb6txt, tb7txt, tb8txt, tb9txt, tb10txt, tb11txt;

        string ctb2txt, ctb3txt, ctb4txt, ctb5txt, ctb6txt, ctb7txt, ctb8txt, ctb9txt, ctb10txt, ctb11txt;

        #endregion
        #region es
        public Form1()
        {
            InitializeComponent();
        }

        void CheckForUpdate()
        {
            try
            {     
                var v1 = new WebClient().DownloadString("https://www.dropbox.com/s/npgz9481iiwm8f0/MW2%20Custom%20Class%20Editor%20Version%20Number.txt?dl=1");
                var v2 = ProductVersion;
                var version1 = new Version(v1);
                var version2 = new Version(v2);
                var result = version1.CompareTo(version2);
                if (result > 0)
                    RequestUpdate();
            }
            catch(Exception E)
            {
                MessageBoxEx.Show("Error While Checking For Update: \n\n"+E.Message, "Error");
            }
        }

        public void CheckForUpdate2()
        {
            try
            {
                string str = new WebClient().DownloadString("https://www.dropbox.com/s/npgz9481iiwm8f0/MW2%20Custom%20Class%20Editor%20Version%20Number.txt?dl=1");
                string v1 = str;
                string v2 = ProductVersion;
                var version1 = new Version(v1);
                var version2 = new Version(v2);
                var result = version1.CompareTo(version2);
                if (result > 0)
                {
                    RequestUpdate();
                }
                else
                {
                    MessageBox.Show("You're using the latest version (Version: " + str + ")");
                }
            }
            catch (Exception E)
            {
                MessageBoxEx.Show("Error While Checking For Update: \n\n" + E.Message, "Error");
            }
        }

        void RequestUpdate()
        {
            try
            {
                var VerNum = new WebClient().DownloadString("https://www.dropbox.com/s/npgz9481iiwm8f0/MW2%20Custom%20Class%20Editor%20Version%20Number.txt?dl=1");
                var whatsNew = new WebClient().DownloadString("https://www.dropbox.com/s/q9g8mpiht21v6jb/MW2%20Custom%20Class%20Editor%20What%27s%20new.txt?dl=1");
                if (MessageBoxEx.Show("There is an update available! \nWould you like to download it? \n\nCurrent version: " + ProductVersion + " \nVersion Available: " + VerNum + "\n\nNOTE:\nIf you have skipped updates (you're more than one update behind)\nThis What's new only tells what's new for the newest update\n\nWhat's new?\n" + whatsNew, "Update Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Form Update = new Form3();
                    Update.ShowDialog();
                }
            }
            catch (Exception E)
            {
                MessageBoxEx.Show("Error While Requesting Update: \n\n" + E.Message, "Error");
            }
        }

        public void VisitSe7enSinsThread()
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.se7ensins.com/forums/threads/nika.1170984/");
                base.Close();
                Application.Exit();
            }
            catch (Exception E)
            {
                MessageBoxEx.Show("Error While Trying To Visit Se7enSins Thread: \n\n"+E.Message,"Error");
            }
        }

        public string toHex(string inp) //the string to hex converter
        {
            string outp = string.Empty;
            char[] value = inp.ToCharArray();
            foreach (char L in value)
            {
                int V = Convert.ToInt32(L);
                outp += string.Format("{0:X2}", V);
            }
            return outp;
        }

        public void colors()
        {
            textBoxX1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            if (!Ox.activeConnection)
                labelX4.ForeColor = Color.Red;
            if (Ox.activeConnection)
                labelX4.ForeColor = Color.Green;
            labelX13.ForeColor = Color.FromArgb(0, 64, 64);
        }

        private void buttonX1_Click(object sender, EventArgs e) //connect
        {
            Ox.Connect();
            if (!Ox.activeConnection)
            {
                labelX4.ForeColor = Color.Red;
                labelX4.Text = "Not  connected";
                MessageBox.Show("Connection to default console failed!\nMake sure that you have set RPC.xex and xbdm.xex as a DashLaunch plugin.\nAnd make sure you have set your console as the default DVK in SDK.", "Connection Status");           
            }

            else
            {
                labelX4.ForeColor = Color.Green;
                labelX4.Text = "Connected";
                buttonX6.Text = "Get Gamertags";
                buttonX2.Enabled = true;
                MessageBox.Show("Succesfully connected to default console, Enjoy the tool!", "Connection Status");
            }

        }

        private void buttonX2_Click(object sender, EventArgs e) //test connection
        {
            try
            {
                Ox.Connect();
                labelX4.ForeColor = Color.Green;
                labelX4.Text = "Connected";
                MessageBox.Show("You are connected!", "Connection Status");
            }

            catch
            {
                labelX4.ForeColor = Color.Red;
                labelX4.Text = "Not  connected";
                textBoxX6.Text = "Get Gamertags";
                buttonX2.Enabled = false;
                MessageBox.Show("Not connected anymore.", "Connection Status");
            }
        }

        private void buttonX3_Click(object sender, EventArgs e) //getting information about the console
        {
            if (!Ox.activeConnection)
                MessageBox.Show("Please Connect First..", "Error");

            else
                MessageBox.Show("Consoles name: " + Ox.xbCon.Name + "\n\nConsoles type: " + Ox.xbCon.ConsoleType + "\n\nMounted Drives: " + Ox.xbCon.Drives + "\n\nCurrently running: " + Ox.xbCon.RunningProcessInfo.ProgramName, "Information About Your Console");
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer: Ox\n\nSpecial thanks to Bitwise, he made me start learning to code! :)\nIf you don't know how to code and want to learn, you definitely should!\nAlso thanks to Bitwise for helping me understand a lot of beginner things!\n\nThanks to Coder123 for the scrolling text code!\n\nThanks to CIA for the client list and everything related to the client list!\n\nBased the new autoupdating system off coldfire202's updater", "Credits");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForUpdate();
            this.Size = new Size(512, 325);
            timer1.Enabled = true;
            buttonX2.Enabled = false;
            labelX7.Text = "Pro tip:\nDouble click\nany textbox to\nclear it :)";
            textBoxX1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            labelX4.ForeColor = Color.Red;
            labelX13.ForeColor = Color.FromArgb(0, 64, 64);
            labelX35.ForeColor = Color.Red;
            labelX34.ForeColor = Color.Green;
            labelX33.ForeColor = Color.Yellow;
            labelX32.ForeColor = Color.Blue;
            labelX31.ForeColor = Color.Cyan;
            labelX30.ForeColor = Color.Pink;
            labelX29.ForeColor = Color.Black;
            labelX28.ForeColor = Color.Gray;
            labelX27.ForeColor = Color.Black;
            labelX23.ForeColor = Color.Pink;
            labelX22.ForeColor = Color.Blue;
            labelX21.ForeColor = Color.Green;
            superTabControl2.SelectedTabIndex = 0;
            textBoxX25.Text = "";
            textBoxX24.Text = "";
            textBoxX23.Text = "";
            textBoxX22.Text = "";
            textBoxX18.Text = "";
            textBoxX21.Text = "";
            textBoxX20.Text = "";
            textBoxX19.Text = "";
            textBoxX17.Text = "";
            textBoxX16.Text = "";
            textBoxX12.Text = "";
            textBoxX15.Text = "";
            textBoxX13.Text = "";
            textBoxX14.Text = "";
            textBoxX26.Text = "";
            textBoxX27.Text = "";
            nekkero();
        }

        private void timer1_Tick(object sender, EventArgs e) //scrolling label text thanks to Coder123 for the code
        {
            char[] chars = labelX2.Text.ToCharArray();
            char[] newChar = new char[chars.Length];
            int l = chars.Length;
            int k = 0;
            for (int j = 0; j < chars.Length; j++)
            {

                if (j + 1 < chars.Length)
                    newChar[j] = chars[j + 1];
                else
                {
                    newChar[l - 1] = chars[k];
                }
            }
            labelX2.Text = new string(newChar);
        }

        private void buttonX5_Click(object sender, EventArgs e) //screenshots jtag/rgh
        {
            if (!Ox.activeConnection)
                MessageBox.Show("Please connect first.", "Error");

            else
            {
                try
                {

                        Ox.xbCon.ScreenShot(Application.StartupPath + "\\" + textBoxX1.Text + ".bmp");
                        if (MessageBoxEx.Show("Your screenshot '" + textBoxX1.Text + "' was saved to:\n" + Application.StartupPath + "  \n\nWould you like to view the screenshot now?", "Screenshot saved", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + textBoxX1.Text + ".bmp");
                }

                catch
                {
                    MessageBox.Show("Something went wrong while taking the screenshot", "Screenshot failed");
                }
            }          
        }

        private void textBoxX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX1.Text = string.Empty;
        }

        public uint Gamertag(int clientID) 
        {
            return (getPlayerState(clientID) + 0x3290);
        }

        public string GetGamertag(int ClientNum) 
        {
            byte[] Bytee = new byte[100];
            uint num;
            string Meow;
            Ox.xbCon.DebugTarget.GetMemory(Gamertag(ClientNum), 20, Bytee, out num);
            Ox.xbCon.DebugTarget.InvalidateMemoryCache(true, getPlayerState((int) ClientNum) + 0x3290, 20);
            Meow = new ASCIIEncoding().GetString(Bytee);
            return Meow;
        }

        public uint getPlayerState(int clientIndex)
        {
            if (Ox.activeConnection)
            {
                uint num;
                byte[] data = new byte[4];
                Ox.xbCon.DebugTarget.GetMemory((uint)((-2098186752 + (clientIndex * 640)) + 0x158), 4, data, out num);
                Array.Reverse(data);
                return BitConverter.ToUInt32(data, 0);
            }
            return 0;
        }

        public void clientList()
        {
            richTextBox1.Clear();
            richTextBox1.AppendText(Environment.NewLine + "CLIENT LIST\n");
            richTextBox1.AppendText(Environment.NewLine + "-1 = All Clients");
            for(int Meow = 0; Meow < 17; Meow++)
                richTextBox1.AppendText(Environment.NewLine + Meow.ToString() + " = " + GetGamertag(Meow));
        }

        private void textBoxX2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX2.Text = string.Empty; //when textbox is double clicked it empties the textbox
        }

        private void textBoxX3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX3.Text = string.Empty;
        }

        private void textBoxX4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX4.Text = string.Empty;
        }

        private void textBoxX5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX5.Text = string.Empty;
        }

        private void textBoxX6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX6.Text = string.Empty;
        }

        private void textBoxX7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX7.Text = string.Empty;
        }

        private void textBoxX8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX8.Text = string.Empty;
        }

        private void textBoxX9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX9.Text = string.Empty;
        }

        private void textBoxX10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX10.Text = string.Empty;
        }

        private void textBoxX11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxX11.Text = string.Empty;
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX2.Checked)
            {
                textBoxX2.MaxLength = 1000;
                textBoxX3.MaxLength = 1000;
                textBoxX4.MaxLength = 1000;
                textBoxX5.MaxLength = 1000;
                textBoxX6.MaxLength = 1000;
                textBoxX7.MaxLength = 1000;
                textBoxX8.MaxLength = 1000;
                textBoxX9.MaxLength = 1000;
                textBoxX10.MaxLength = 1000;
                textBoxX11.MaxLength = 1000;

                textBoxX2.Text = string.Empty;
                textBoxX3.Text = string.Empty;
                textBoxX4.Text = string.Empty;
                textBoxX5.Text = string.Empty;
                textBoxX6.Text = string.Empty;
                textBoxX7.Text = string.Empty;
                textBoxX8.Text = string.Empty;
                textBoxX9.Text = string.Empty;
                textBoxX10.Text = string.Empty;
                textBoxX11.Text = string.Empty;

                textBoxX2.CharacterCasing = CharacterCasing.Upper;
                textBoxX3.CharacterCasing = CharacterCasing.Upper;
                textBoxX4.CharacterCasing = CharacterCasing.Upper;
                textBoxX5.CharacterCasing = CharacterCasing.Upper;
                textBoxX6.CharacterCasing = CharacterCasing.Upper;
                textBoxX7.CharacterCasing = CharacterCasing.Upper;
                textBoxX8.CharacterCasing = CharacterCasing.Upper;
                textBoxX9.CharacterCasing = CharacterCasing.Upper;
                textBoxX10.CharacterCasing = CharacterCasing.Upper;
                textBoxX11.CharacterCasing = CharacterCasing.Upper;
            }


            if (!checkBoxX2.Checked)
            {
                textBoxX2.MaxLength = 20;
                textBoxX3.MaxLength = 20;
                textBoxX4.MaxLength = 20;
                textBoxX5.MaxLength = 20;
                textBoxX6.MaxLength = 20;
                textBoxX7.MaxLength = 20;
                textBoxX8.MaxLength = 20;
                textBoxX9.MaxLength = 20;
                textBoxX10.MaxLength = 20;
                textBoxX11.MaxLength = 20;

                textBoxX2.CharacterCasing = CharacterCasing.Normal;
                textBoxX3.CharacterCasing = CharacterCasing.Normal;
                textBoxX4.CharacterCasing = CharacterCasing.Normal;
                textBoxX5.CharacterCasing = CharacterCasing.Normal;
                textBoxX6.CharacterCasing = CharacterCasing.Normal;
                textBoxX7.CharacterCasing = CharacterCasing.Normal;
                textBoxX8.CharacterCasing = CharacterCasing.Normal;
                textBoxX9.CharacterCasing = CharacterCasing.Normal;
                textBoxX10.CharacterCasing = CharacterCasing.Normal;
                textBoxX11.CharacterCasing = CharacterCasing.Normal;

                textBoxX2.Text = "Class 1";
                textBoxX3.Text = "Class 2";
                textBoxX4.Text = "Class 3";
                textBoxX5.Text = "Class 4";
                textBoxX6.Text = "Class 5";
                textBoxX7.Text = "Class 6";
                textBoxX8.Text = "Class 7";
                textBoxX9.Text = "Class 8";
                textBoxX10.Text = "Class 9";
                textBoxX11.Text = "Class 10";
            }
                
        }

        private void buttonX6_Click_2(object sender, EventArgs e)
        {
            if (!Ox.activeConnection)
                MessageBox.Show("Please connect first.", "Error");

            else
                clientList();
        }
        #endregion
        private void buttonX7_Click_1(object sender, EventArgs e)
        {
            if (!Ox.activeConnection)
                MessageBox.Show("Please connect first.", "Error");

            else
            {
                #region asd
                #region classnames
                ctb2txt = textBoxX2.Text;
                ctb3txt = textBoxX3.Text;
                ctb4txt = textBoxX4.Text;
                ctb5txt = textBoxX5.Text;
                ctb6txt = textBoxX6.Text;
                ctb7txt = textBoxX7.Text;
                ctb8txt = textBoxX8.Text;
                ctb9txt = textBoxX9.Text;
                ctb10txt = textBoxX10.Text;
                ctb11txt = textBoxX11.Text;
                #endregion
                #region stun
                int cb1sl = comboBoxEx1.SelectedIndex + 1;
                int cb2sl = comboBoxEx2.SelectedIndex + 1;
                int cb3sl = comboBoxEx3.SelectedIndex + 1;
                int cb4sl = comboBoxEx4.SelectedIndex + 1;
                int cb5sl = comboBoxEx5.SelectedIndex + 1;
                int cb6sl = comboBoxEx6.SelectedIndex + 1;
                int cb7sl = comboBoxEx7.SelectedIndex + 1;
                int cb8sl = comboBoxEx8.SelectedIndex + 1;
                int cb9sl = comboBoxEx9.SelectedIndex + 1;
                int cb10sl = comboBoxEx10.SelectedIndex + 1;
                #endregion
                #region camos
                if (comboBoxEx11.SelectedIndex != 10)
                    cb11c = comboBoxEx11.SelectedIndex.ToString();
                else if (comboBoxEx11.SelectedIndex == 10)
                    cb11c = "A";
                if (comboBoxEx12.SelectedIndex != 10)
                    cb12c = comboBoxEx12.SelectedIndex.ToString();
                else if (comboBoxEx12.SelectedIndex == 10)
                    cb12c = "A";
                if (comboBoxEx13.SelectedIndex != 10)
                    cb13c = comboBoxEx13.SelectedIndex.ToString();
                else if (comboBoxEx13.SelectedIndex == 10)
                    cb13c = "A";
                if (comboBoxEx14.SelectedIndex != 10)
                    cb14c = comboBoxEx14.SelectedIndex.ToString();
                else if (comboBoxEx14.SelectedIndex == 10)
                    cb14c = "A";
                if (comboBoxEx15.SelectedIndex != 10)
                    cb15c = comboBoxEx15.SelectedIndex.ToString();
                else if (comboBoxEx15.SelectedIndex == 10)
                    cb15c = "A";
                if (comboBoxEx16.SelectedIndex != 10)
                    cb16c = comboBoxEx16.SelectedIndex.ToString();
                else if (comboBoxEx16.SelectedIndex == 10)
                    cb16c = "A";
                if (comboBoxEx17.SelectedIndex != 10)
                    cb17c = comboBoxEx17.SelectedIndex.ToString();
                else if (comboBoxEx17.SelectedIndex == 10)
                    cb17c = "A";
                if (comboBoxEx18.SelectedIndex != 10)
                    cb18c = comboBoxEx18.SelectedIndex.ToString();
                else if (comboBoxEx18.SelectedIndex == 10)
                    cb18c = "A";
                if (comboBoxEx19.SelectedIndex != 10)
                    cb19c = comboBoxEx19.SelectedIndex.ToString();
                else if (comboBoxEx19.SelectedIndex == 10)
                    cb19c = "A";
                if (comboBoxEx20.SelectedIndex != 10)
                    cb20c = comboBoxEx20.SelectedIndex.ToString();
                else if (comboBoxEx20.SelectedIndex == 10)
                    cb20c = "A";



                if (comboBoxEx21.SelectedIndex != 10)
                    cb21sc = comboBoxEx21.SelectedIndex.ToString();
                else if (comboBoxEx21.SelectedIndex == 10)
                    cb21sc = "A";
                if (comboBoxEx22.SelectedIndex != 10)
                    cb22sc = comboBoxEx22.SelectedIndex.ToString();
                else if (comboBoxEx22.SelectedIndex == 10)
                    cb22sc = "A";
                if (comboBoxEx23.SelectedIndex != 10)
                    cb23sc = comboBoxEx23.SelectedIndex.ToString();
                else if (comboBoxEx23.SelectedIndex == 10)
                    cb23sc = "A";
                if (comboBoxEx24.SelectedIndex != 10)
                    cb24sc = comboBoxEx24.SelectedIndex.ToString();
                else if (comboBoxEx24.SelectedIndex == 10)
                    cb24sc = "A";
                if (comboBoxEx25.SelectedIndex != 10)
                    cb25sc = comboBoxEx25.SelectedIndex.ToString();
                else if (comboBoxEx25.SelectedIndex == 10)
                    cb25sc = "A";
                if (comboBoxEx26.SelectedIndex != 10)
                    cb26sc = comboBoxEx26.SelectedIndex.ToString();
                else if (comboBoxEx26.SelectedIndex == 10)
                    cb26sc = "A";
                if (comboBoxEx27.SelectedIndex != 10)
                    cb27sc = comboBoxEx27.SelectedIndex.ToString();
                else if (comboBoxEx27.SelectedIndex == 10)
                    cb27sc = "A";
                if (comboBoxEx28.SelectedIndex != 10)
                    cb28sc = comboBoxEx28.SelectedIndex.ToString();
                else if (comboBoxEx28.SelectedIndex == 10)
                    cb28sc = "A";
                if (comboBoxEx29.SelectedIndex != 10)
                    cb29sc = comboBoxEx29.SelectedIndex.ToString();
                else if (comboBoxEx29.SelectedIndex == 10)
                    cb29sc = "A";
                if (comboBoxEx30.SelectedIndex != 10)
                    cb30sc = comboBoxEx30.SelectedIndex.ToString();
                else if (comboBoxEx30.SelectedIndex == 10)
                    cb30sc = "A";
                #endregion
                #region lethal
                if (comboBoxEx31.SelectedIndex == 0)
                    cb31ls = "00";
                if (comboBoxEx32.SelectedIndex == 0)
                    cb32ls = "00";
                if (comboBoxEx33.SelectedIndex == 0)
                    cb33ls = "00";
                if (comboBoxEx34.SelectedIndex == 0)
                    cb34ls = "00";
                if (comboBoxEx35.SelectedIndex == 0)
                    cb35ls = "00";
                if (comboBoxEx36.SelectedIndex == 0)
                    cb36ls = "00";
                if (comboBoxEx37.SelectedIndex == 0)
                    cb37ls = "00";
                if (comboBoxEx38.SelectedIndex == 0)
                    cb38ls = "00";
                if (comboBoxEx39.SelectedIndex == 0)
                    cb39ls = "00";
                if (comboBoxEx40.SelectedIndex == 0)
                    cb40ls = "00";

                if (comboBoxEx31.SelectedIndex == 1)
                    cb31ls = "05";
                if (comboBoxEx32.SelectedIndex == 1)
                    cb32ls = "05";
                if (comboBoxEx33.SelectedIndex == 1)
                    cb33ls = "05";
                if (comboBoxEx34.SelectedIndex == 1)
                    cb34ls = "05";
                if (comboBoxEx35.SelectedIndex == 1)
                    cb35ls = "05";
                if (comboBoxEx36.SelectedIndex == 1)
                    cb36ls = "05";
                if (comboBoxEx37.SelectedIndex == 1)
                    cb37ls = "05";
                if (comboBoxEx38.SelectedIndex == 1)
                    cb38ls = "05";
                if (comboBoxEx39.SelectedIndex == 1)
                    cb39ls = "05";
                if (comboBoxEx40.SelectedIndex == 1)
                    cb40ls = "05";

                if (comboBoxEx31.SelectedIndex == 2)
                    cb31ls = "10";
                if (comboBoxEx32.SelectedIndex == 2)
                    cb32ls = "10";
                if (comboBoxEx33.SelectedIndex == 2)
                    cb33ls = "10";
                if (comboBoxEx34.SelectedIndex == 2)
                    cb34ls = "10";
                if (comboBoxEx35.SelectedIndex == 2)
                    cb35ls = "10";
                if (comboBoxEx36.SelectedIndex == 2)
                    cb36ls = "10";
                if (comboBoxEx37.SelectedIndex == 2)
                    cb37ls = "10";
                if (comboBoxEx38.SelectedIndex == 2)
                    cb38ls = "10";
                if (comboBoxEx39.SelectedIndex == 2)
                    cb39ls = "10";
                if (comboBoxEx40.SelectedIndex == 2)
                    cb40ls = "10";

                if (comboBoxEx31.SelectedIndex == 3)
                    cb31ls = "13";
                if (comboBoxEx32.SelectedIndex == 3)
                    cb32ls = "13";
                if (comboBoxEx33.SelectedIndex == 3)
                    cb33ls = "13";
                if (comboBoxEx34.SelectedIndex == 3)
                    cb34ls = "13";
                if (comboBoxEx35.SelectedIndex == 3)
                    cb35ls = "13";
                if (comboBoxEx36.SelectedIndex == 3)
                    cb36ls = "13";
                if (comboBoxEx37.SelectedIndex == 3)
                    cb37ls = "13";
                if (comboBoxEx38.SelectedIndex == 3)
                    cb38ls = "13";
                if (comboBoxEx39.SelectedIndex == 3)
                    cb39ls = "13";
                if (comboBoxEx40.SelectedIndex == 3)
                    cb40ls = "13";

                if (comboBoxEx31.SelectedIndex == 4)
                    cb31ls = "14";
                if (comboBoxEx32.SelectedIndex == 4)
                    cb32ls = "14";
                if (comboBoxEx33.SelectedIndex == 4)
                    cb33ls = "14";
                if (comboBoxEx34.SelectedIndex == 4)
                    cb34ls = "14";
                if (comboBoxEx35.SelectedIndex == 4)
                    cb35ls = "14";
                if (comboBoxEx36.SelectedIndex == 4)
                    cb36ls = "14";
                if (comboBoxEx37.SelectedIndex == 4)
                    cb37ls = "14";
                if (comboBoxEx38.SelectedIndex == 4)
                    cb38ls = "14";
                if (comboBoxEx39.SelectedIndex == 4)
                    cb39ls = "14";
                if (comboBoxEx40.SelectedIndex == 4)
                    cb40ls = "14";

                if (comboBoxEx31.SelectedIndex == 5)
                    cb31ls = "20";
                if (comboBoxEx32.SelectedIndex == 5)
                    cb32ls = "20";
                if (comboBoxEx33.SelectedIndex == 5)
                    cb33ls = "20";
                if (comboBoxEx34.SelectedIndex == 5)
                    cb34ls = "20";
                if (comboBoxEx35.SelectedIndex == 5)
                    cb35ls = "20";
                if (comboBoxEx36.SelectedIndex == 5)
                    cb36ls = "20";
                if (comboBoxEx37.SelectedIndex == 5)
                    cb37ls = "20";
                if (comboBoxEx38.SelectedIndex == 5)
                    cb38ls = "20";
                if (comboBoxEx39.SelectedIndex == 5)
                    cb39ls = "20";
                if (comboBoxEx40.SelectedIndex == 5)
                    cb40ls = "20";

                if (comboBoxEx31.SelectedIndex == 6)
                    cb31ls = "23";
                if (comboBoxEx32.SelectedIndex == 6)
                    cb32ls = "23";
                if (comboBoxEx33.SelectedIndex == 6)
                    cb33ls = "23";
                if (comboBoxEx34.SelectedIndex == 6)
                    cb34ls = "23";
                if (comboBoxEx35.SelectedIndex == 6)
                    cb35ls = "23";
                if (comboBoxEx36.SelectedIndex == 6)
                    cb36ls = "23";
                if (comboBoxEx37.SelectedIndex == 6)
                    cb37ls = "23";
                if (comboBoxEx38.SelectedIndex == 6)
                    cb38ls = "23";
                if (comboBoxEx39.SelectedIndex == 6)
                    cb39ls = "23";
                if (comboBoxEx40.SelectedIndex == 6)
                    cb40ls = "23";

                if (comboBoxEx31.SelectedIndex == 7)
                    cb31ls = "25";
                if (comboBoxEx32.SelectedIndex == 7)
                    cb32ls = "25";
                if (comboBoxEx33.SelectedIndex == 7)
                    cb33ls = "25";
                if (comboBoxEx34.SelectedIndex == 7)
                    cb34ls = "25";
                if (comboBoxEx35.SelectedIndex == 7)
                    cb35ls = "25";
                if (comboBoxEx36.SelectedIndex == 7)
                    cb36ls = "25";
                if (comboBoxEx37.SelectedIndex == 7)
                    cb37ls = "25";
                if (comboBoxEx38.SelectedIndex == 7)
                    cb38ls = "25";
                if (comboBoxEx39.SelectedIndex == 7)
                    cb39ls = "25";
                if (comboBoxEx40.SelectedIndex == 7)
                    cb40ls = "25";

                if (comboBoxEx31.SelectedIndex == 8)
                    cb31ls = "28";
                if (comboBoxEx32.SelectedIndex == 8)
                    cb32ls = "28";
                if (comboBoxEx33.SelectedIndex == 8)
                    cb33ls = "28";
                if (comboBoxEx34.SelectedIndex == 8)
                    cb34ls = "28";
                if (comboBoxEx35.SelectedIndex == 8)
                    cb35ls = "28";
                if (comboBoxEx36.SelectedIndex == 8)
                    cb36ls = "28";
                if (comboBoxEx37.SelectedIndex == 8)
                    cb37ls = "28";
                if (comboBoxEx38.SelectedIndex == 8)
                    cb38ls = "28";
                if (comboBoxEx39.SelectedIndex == 8)
                    cb39ls = "28";
                if (comboBoxEx40.SelectedIndex == 8)
                    cb40ls = "28";

                if (comboBoxEx31.SelectedIndex == 9)
                    cb31ls = "29";
                if (comboBoxEx32.SelectedIndex == 9)
                    cb32ls = "29";
                if (comboBoxEx33.SelectedIndex == 9)
                    cb33ls = "29";
                if (comboBoxEx34.SelectedIndex == 9)
                    cb34ls = "29";
                if (comboBoxEx35.SelectedIndex == 9)
                    cb35ls = "29";
                if (comboBoxEx36.SelectedIndex == 9)
                    cb36ls = "29";
                if (comboBoxEx37.SelectedIndex == 9)
                    cb37ls = "29";
                if (comboBoxEx38.SelectedIndex == 9)
                    cb38ls = "29";
                if (comboBoxEx39.SelectedIndex == 9)
                    cb39ls = "29";
                if (comboBoxEx40.SelectedIndex == 9)
                    cb40ls = "29";

                if (comboBoxEx31.SelectedIndex == 10)
                    cb31ls = "31";
                if (comboBoxEx32.SelectedIndex == 10)
                    cb32ls = "31";
                if (comboBoxEx33.SelectedIndex == 10)
                    cb33ls = "31";
                if (comboBoxEx34.SelectedIndex == 10)
                    cb34ls = "31";
                if (comboBoxEx35.SelectedIndex == 10)
                    cb35ls = "31";
                if (comboBoxEx36.SelectedIndex == 10)
                    cb36ls = "31";
                if (comboBoxEx37.SelectedIndex == 10)
                    cb37ls = "31";
                if (comboBoxEx38.SelectedIndex == 10)
                    cb38ls = "31";
                if (comboBoxEx39.SelectedIndex == 10)
                    cb39ls = "31";
                if (comboBoxEx40.SelectedIndex == 10)
                    cb40ls = "31";

                if (comboBoxEx31.SelectedIndex == 11)
                    cb31ls = "36";
                if (comboBoxEx32.SelectedIndex == 11)
                    cb32ls = "36";
                if (comboBoxEx33.SelectedIndex == 11)
                    cb33ls = "36";
                if (comboBoxEx34.SelectedIndex == 11)
                    cb34ls = "36";
                if (comboBoxEx35.SelectedIndex == 11)
                    cb35ls = "36";
                if (comboBoxEx36.SelectedIndex == 11)
                    cb36ls = "36";
                if (comboBoxEx37.SelectedIndex == 11)
                    cb37ls = "36";
                if (comboBoxEx38.SelectedIndex == 11)
                    cb38ls = "36";
                if (comboBoxEx39.SelectedIndex == 11)
                    cb39ls = "36";
                if (comboBoxEx40.SelectedIndex == 11)
                    cb40ls = "36";

                if (comboBoxEx31.SelectedIndex == 12)
                    cb31ls = "37";
                if (comboBoxEx32.SelectedIndex == 12)
                    cb32ls = "37";
                if (comboBoxEx33.SelectedIndex == 12)
                    cb33ls = "37";
                if (comboBoxEx34.SelectedIndex == 12)
                    cb34ls = "37";
                if (comboBoxEx35.SelectedIndex == 12)
                    cb35ls = "37";
                if (comboBoxEx36.SelectedIndex == 12)
                    cb36ls = "37";
                if (comboBoxEx37.SelectedIndex == 12)
                    cb37ls = "37";
                if (comboBoxEx38.SelectedIndex == 12)
                    cb38ls = "37";
                if (comboBoxEx39.SelectedIndex == 12)
                    cb39ls = "37";
                if (comboBoxEx40.SelectedIndex == 12)
                    cb40ls = "37";

                if (comboBoxEx31.SelectedIndex == 13)
                    cb31ls = "40";
                if (comboBoxEx32.SelectedIndex == 13)
                    cb32ls = "40";
                if (comboBoxEx33.SelectedIndex == 13)
                    cb33ls = "40";
                if (comboBoxEx34.SelectedIndex == 13)
                    cb34ls = "40";
                if (comboBoxEx35.SelectedIndex == 13)
                    cb35ls = "40";
                if (comboBoxEx36.SelectedIndex == 13)
                    cb36ls = "40";
                if (comboBoxEx37.SelectedIndex == 13)
                    cb37ls = "40";
                if (comboBoxEx38.SelectedIndex == 13)
                    cb38ls = "40";
                if (comboBoxEx39.SelectedIndex == 13)
                    cb39ls = "40";
                if (comboBoxEx40.SelectedIndex == 13)
                    cb40ls = "40";

                if (comboBoxEx31.SelectedIndex == 14)
                    cb31ls = "3D";
                if (comboBoxEx32.SelectedIndex == 14)
                    cb32ls = "3D";
                if (comboBoxEx33.SelectedIndex == 14)
                    cb33ls = "3D";
                if (comboBoxEx34.SelectedIndex == 14)
                    cb34ls = "3D";
                if (comboBoxEx35.SelectedIndex == 14)
                    cb35ls = "3D";
                if (comboBoxEx36.SelectedIndex == 14)
                    cb36ls = "3D";
                if (comboBoxEx37.SelectedIndex == 14)
                    cb37ls = "3D";
                if (comboBoxEx38.SelectedIndex == 14)
                    cb38ls = "3D";
                if (comboBoxEx39.SelectedIndex == 14)
                    cb39ls = "3D";
                if (comboBoxEx40.SelectedIndex == 14)
                    cb40ls = "3D";

                if (comboBoxEx31.SelectedIndex == 15)
                    cb31ls = "0E";
                if (comboBoxEx32.SelectedIndex == 15)
                    cb32ls = "0E";
                if (comboBoxEx33.SelectedIndex == 15)
                    cb33ls = "0E";
                if (comboBoxEx34.SelectedIndex == 15)
                    cb34ls = "0E";
                if (comboBoxEx35.SelectedIndex == 15)
                    cb35ls = "0E";
                if (comboBoxEx36.SelectedIndex == 15)
                    cb36ls = "0E";
                if (comboBoxEx37.SelectedIndex == 15)
                    cb37ls = "0E";
                if (comboBoxEx38.SelectedIndex == 15)
                    cb38ls = "0E";
                if (comboBoxEx39.SelectedIndex == 15)
                    cb39ls = "0E";
                if (comboBoxEx40.SelectedIndex == 15)
                    cb40ls = "0E";

                if (comboBoxEx31.SelectedIndex == 16)
                    cb31ls = "0B";
                if (comboBoxEx32.SelectedIndex == 16)
                    cb32ls = "0B";
                if (comboBoxEx33.SelectedIndex == 16)
                    cb33ls = "0B";
                if (comboBoxEx34.SelectedIndex == 16)
                    cb34ls = "0B";
                if (comboBoxEx35.SelectedIndex == 16)
                    cb35ls = "0B";
                if (comboBoxEx36.SelectedIndex == 16)
                    cb36ls = "0B";
                if (comboBoxEx37.SelectedIndex == 16)
                    cb37ls = "0B";
                if (comboBoxEx38.SelectedIndex == 16)
                    cb38ls = "0B";
                if (comboBoxEx39.SelectedIndex == 16)
                    cb39ls = "0B";
                if (comboBoxEx40.SelectedIndex == 16)
                    cb40ls = "0B";

                if (comboBoxEx31.SelectedIndex == 17)
                    cb31ls = "3F";
                if (comboBoxEx32.SelectedIndex == 17)
                    cb32ls = "3F";
                if (comboBoxEx33.SelectedIndex == 17)
                    cb33ls = "3F";
                if (comboBoxEx34.SelectedIndex == 17)
                    cb34ls = "3F";
                if (comboBoxEx35.SelectedIndex == 17)
                    cb35ls = "3F";
                if (comboBoxEx36.SelectedIndex == 17)
                    cb36ls = "3F";
                if (comboBoxEx37.SelectedIndex == 17)
                    cb37ls = "3F";
                if (comboBoxEx38.SelectedIndex == 17)
                    cb38ls = "3F";
                if (comboBoxEx39.SelectedIndex == 17)
                    cb39ls = "3F";
                if (comboBoxEx40.SelectedIndex == 17)
                    cb40ls = "3F";

                if (comboBoxEx31.SelectedIndex == 18)
                    cb31ls = "0A";
                if (comboBoxEx32.SelectedIndex == 18)
                    cb32ls = "0A";
                if (comboBoxEx33.SelectedIndex == 18)
                    cb33ls = "0A";
                if (comboBoxEx34.SelectedIndex == 18)
                    cb34ls = "0A";
                if (comboBoxEx35.SelectedIndex == 18)
                    cb35ls = "0A";
                if (comboBoxEx36.SelectedIndex == 18)
                    cb36ls = "0A";
                if (comboBoxEx37.SelectedIndex == 18)
                    cb37ls = "0A";
                if (comboBoxEx38.SelectedIndex == 18)
                    cb38ls = "0A";
                if (comboBoxEx39.SelectedIndex == 18)
                    cb39ls = "0A";
                if (comboBoxEx40.SelectedIndex == 18)
                    cb40ls = "0A";

                if (comboBoxEx31.SelectedIndex == 19)
                    cb31ls = "0C";
                if (comboBoxEx32.SelectedIndex == 19)
                    cb32ls = "0C";
                if (comboBoxEx33.SelectedIndex == 19)
                    cb33ls = "0C";
                if (comboBoxEx34.SelectedIndex == 19)
                    cb34ls = "0C";
                if (comboBoxEx35.SelectedIndex == 19)
                    cb35ls = "0C";
                if (comboBoxEx36.SelectedIndex == 19)
                    cb36ls = "0C";
                if (comboBoxEx37.SelectedIndex == 19)
                    cb37ls = "0C";
                if (comboBoxEx38.SelectedIndex == 19)
                    cb38ls = "0C";
                if (comboBoxEx39.SelectedIndex == 19)
                    cb39ls = "0C";
                if (comboBoxEx40.SelectedIndex == 19)
                    cb40ls = "0C";

                if (comboBoxEx31.SelectedIndex == 20)
                    cb31ls = "42";
                if (comboBoxEx32.SelectedIndex == 20)
                    cb32ls = "42";
                if (comboBoxEx33.SelectedIndex == 20)
                    cb33ls = "42";
                if (comboBoxEx34.SelectedIndex == 20)
                    cb34ls = "42";
                if (comboBoxEx35.SelectedIndex == 20)
                    cb35ls = "42";
                if (comboBoxEx36.SelectedIndex == 20)
                    cb36ls = "42";
                if (comboBoxEx37.SelectedIndex == 20)
                    cb37ls = "42";
                if (comboBoxEx38.SelectedIndex == 20)
                    cb38ls = "42";
                if (comboBoxEx39.SelectedIndex == 20)
                    cb39ls = "42";
                if (comboBoxEx40.SelectedIndex == 20)
                    cb40ls = "42";

                if (comboBoxEx31.SelectedIndex == 21)
                    cb31ls = "46";
                if (comboBoxEx32.SelectedIndex == 21)
                    cb32ls = "46";
                if (comboBoxEx33.SelectedIndex == 21)
                    cb33ls = "46";
                if (comboBoxEx34.SelectedIndex == 21)
                    cb34ls = "46";
                if (comboBoxEx35.SelectedIndex == 21)
                    cb35ls = "46";
                if (comboBoxEx36.SelectedIndex == 21)
                    cb36ls = "46";
                if (comboBoxEx37.SelectedIndex == 21)
                    cb37ls = "46";
                if (comboBoxEx38.SelectedIndex == 21)
                    cb38ls = "46";
                if (comboBoxEx39.SelectedIndex == 21)
                    cb39ls = "46";
                if (comboBoxEx40.SelectedIndex == 21)
                    cb40ls = "46";

                if (comboBoxEx31.SelectedIndex == 22)
                    cb31ls = "52";
                if (comboBoxEx32.SelectedIndex == 22)
                    cb32ls = "52";
                if (comboBoxEx33.SelectedIndex == 22)
                    cb33ls = "52";
                if (comboBoxEx34.SelectedIndex == 22)
                    cb34ls = "52";
                if (comboBoxEx35.SelectedIndex == 22)
                    cb35ls = "52";
                if (comboBoxEx36.SelectedIndex == 22)
                    cb36ls = "52";
                if (comboBoxEx37.SelectedIndex == 22)
                    cb37ls = "52";
                if (comboBoxEx38.SelectedIndex == 22)
                    cb38ls = "52";
                if (comboBoxEx39.SelectedIndex == 22)
                    cb39ls = "52";
                if (comboBoxEx40.SelectedIndex == 22)
                    cb40ls = "52";

                if (comboBoxEx31.SelectedIndex == 23)
                    cb31ls = "53";
                if (comboBoxEx32.SelectedIndex == 23)
                    cb32ls = "53";
                if (comboBoxEx33.SelectedIndex == 23)
                    cb33ls = "53";
                if (comboBoxEx34.SelectedIndex == 23)
                    cb34ls = "53";
                if (comboBoxEx35.SelectedIndex == 23)
                    cb35ls = "53";
                if (comboBoxEx36.SelectedIndex == 23)
                    cb36ls = "53";
                if (comboBoxEx37.SelectedIndex == 23)
                    cb37ls = "53";
                if (comboBoxEx38.SelectedIndex == 23)
                    cb38ls = "53";
                if (comboBoxEx39.SelectedIndex == 23)
                    cb39ls = "53";
                if (comboBoxEx40.SelectedIndex == 23)
                    cb40ls = "53";

                if (comboBoxEx31.SelectedIndex == 24)
                    cb31ls = "57";
                if (comboBoxEx32.SelectedIndex == 24)
                    cb32ls = "57";
                if (comboBoxEx33.SelectedIndex == 24)
                    cb33ls = "57";
                if (comboBoxEx34.SelectedIndex == 24)
                    cb34ls = "57";
                if (comboBoxEx35.SelectedIndex == 24)
                    cb35ls = "57";
                if (comboBoxEx36.SelectedIndex == 24)
                    cb36ls = "57";
                if (comboBoxEx37.SelectedIndex == 24)
                    cb37ls = "57";
                if (comboBoxEx38.SelectedIndex == 24)
                    cb38ls = "57";
                if (comboBoxEx39.SelectedIndex == 24)
                    cb39ls = "57";
                if (comboBoxEx40.SelectedIndex == 24)
                    cb40ls = "57";

                if (comboBoxEx31.SelectedIndex == 25)
                    cb31ls = "58";
                if (comboBoxEx32.SelectedIndex == 25)
                    cb32ls = "58";
                if (comboBoxEx33.SelectedIndex == 25)
                    cb33ls = "58";
                if (comboBoxEx34.SelectedIndex == 25)
                    cb34ls = "58";
                if (comboBoxEx35.SelectedIndex == 25)
                    cb35ls = "58";
                if (comboBoxEx36.SelectedIndex == 25)
                    cb36ls = "58";
                if (comboBoxEx37.SelectedIndex == 25)
                    cb37ls = "58";
                if (comboBoxEx38.SelectedIndex == 25)
                    cb38ls = "58";
                if (comboBoxEx39.SelectedIndex == 25)
                    cb39ls = "58";
                if (comboBoxEx40.SelectedIndex == 25)
                    cb40ls = "58";

                if (comboBoxEx31.SelectedIndex == 26)
                    cb31ls = "59";
                if (comboBoxEx32.SelectedIndex == 26)
                    cb32ls = "59";
                if (comboBoxEx33.SelectedIndex == 26)
                    cb33ls = "59";
                if (comboBoxEx34.SelectedIndex == 26)
                    cb34ls = "59";
                if (comboBoxEx35.SelectedIndex == 26)
                    cb35ls = "59";
                if (comboBoxEx36.SelectedIndex == 26)
                    cb36ls = "59";
                if (comboBoxEx37.SelectedIndex == 26)
                    cb37ls = "59";
                if (comboBoxEx38.SelectedIndex == 26)
                    cb38ls = "59";
                if (comboBoxEx39.SelectedIndex == 26)
                    cb39ls = "59";
                if (comboBoxEx40.SelectedIndex == 26)
                    cb40ls = "59";
                
                if (comboBoxEx31.SelectedIndex == 27)
                    cb31ls = "1A";
                if (comboBoxEx32.SelectedIndex == 27)
                    cb32ls = "1A";
                if (comboBoxEx33.SelectedIndex == 27)
                    cb33ls = "1A";
                if (comboBoxEx34.SelectedIndex == 27)
                    cb34ls = "1A";
                if (comboBoxEx35.SelectedIndex == 27)
                    cb35ls = "1A";
                if (comboBoxEx36.SelectedIndex == 27)
                    cb36ls = "1A";
                if (comboBoxEx37.SelectedIndex == 27)
                    cb37ls = "1A";
                if (comboBoxEx38.SelectedIndex == 27)
                    cb38ls = "1A";
                if (comboBoxEx39.SelectedIndex == 27)
                    cb39ls = "1A";
                if (comboBoxEx40.SelectedIndex == 27)
                    cb40ls = "1A";

                if (comboBoxEx31.SelectedIndex == 28)
                    cb31ls = "60";
                if (comboBoxEx32.SelectedIndex == 28)
                    cb32ls = "60";
                if (comboBoxEx33.SelectedIndex == 28)
                    cb33ls = "60";
                if (comboBoxEx34.SelectedIndex == 28)
                    cb34ls = "60";
                if (comboBoxEx35.SelectedIndex == 28)
                    cb35ls = "60";
                if (comboBoxEx36.SelectedIndex == 28)
                    cb36ls = "60";
                if (comboBoxEx37.SelectedIndex == 28)
                    cb37ls = "60";
                if (comboBoxEx38.SelectedIndex == 28)
                    cb38ls = "60";
                if (comboBoxEx39.SelectedIndex == 28)
                    cb39ls = "60";
                if (comboBoxEx40.SelectedIndex == 28)
                    cb40ls = "60";
                #endregion
                #region attachments
                int cb41pa2 = comboBoxEx41.SelectedIndex + 1;
                int cb42pa2 = comboBoxEx42.SelectedIndex + 1;
                int cb43pa2 = comboBoxEx43.SelectedIndex + 1;
                int cb44pa2 = comboBoxEx44.SelectedIndex + 1;
                int cb45pa2 = comboBoxEx45.SelectedIndex + 1;
                int cb46pa2 = comboBoxEx46.SelectedIndex + 1;
                int cb47pa2 = comboBoxEx47.SelectedIndex + 1;
                int cb48pa2 = comboBoxEx48.SelectedIndex + 1;
                int cb49pa2 = comboBoxEx49.SelectedIndex + 1;
                int cb50pa2 = comboBoxEx50.SelectedIndex + 1;

                string cb41pa = cb41pa2.ToString();
                string cb42pa = cb42pa2.ToString();
                string cb43pa = cb43pa2.ToString();
                string cb44pa = cb44pa2.ToString();
                string cb45pa = cb45pa2.ToString();
                string cb46pa = cb46pa2.ToString();
                string cb47pa = cb47pa2.ToString();
                string cb48pa = cb48pa2.ToString();
                string cb49pa = cb49pa2.ToString();
                string cb50pa = cb50pa2.ToString();

                if (comboBoxEx41.SelectedIndex == 9)
                    cb41pa = "A";
                if (comboBoxEx42.SelectedIndex == 9)
                    cb42pa = "A";
                if (comboBoxEx43.SelectedIndex == 9)
                    cb43pa = "A";
                if (comboBoxEx44.SelectedIndex == 9)
                    cb44pa = "A";
                if (comboBoxEx45.SelectedIndex == 9)
                    cb45pa = "A";
                if (comboBoxEx46.SelectedIndex == 9)
                    cb46pa = "A";
                if (comboBoxEx47.SelectedIndex == 9)
                    cb47pa = "A";
                if (comboBoxEx48.SelectedIndex == 9)
                    cb48pa = "A";
                if (comboBoxEx49.SelectedIndex == 9)
                    cb49pa = "A";
                if (comboBoxEx50.SelectedIndex == 9)
                    cb50pa = "A";

                if (comboBoxEx41.SelectedIndex == 10)
                    cb41pa = "B";
                if (comboBoxEx42.SelectedIndex == 10)
                    cb42pa = "B";
                if (comboBoxEx43.SelectedIndex == 10)
                    cb43pa = "B";
                if (comboBoxEx44.SelectedIndex == 10)
                    cb44pa = "B";
                if (comboBoxEx45.SelectedIndex == 10)
                    cb45pa = "B";
                if (comboBoxEx46.SelectedIndex == 10)
                    cb46pa = "B";
                if (comboBoxEx47.SelectedIndex == 10)
                    cb47pa = "B";
                if (comboBoxEx48.SelectedIndex == 10)
                    cb48pa = "B";
                if (comboBoxEx49.SelectedIndex == 10)
                    cb49pa = "B";
                if (comboBoxEx50.SelectedIndex == 10)
                    cb50pa = "B";

                if (comboBoxEx41.SelectedIndex == 11)
                    cb41pa = "C";
                if (comboBoxEx42.SelectedIndex == 11)
                    cb42pa = "C";
                if (comboBoxEx43.SelectedIndex == 11)
                    cb43pa = "C";
                if (comboBoxEx44.SelectedIndex == 11)
                    cb44pa = "C";
                if (comboBoxEx45.SelectedIndex == 11)
                    cb45pa = "C";
                if (comboBoxEx46.SelectedIndex == 11)
                    cb46pa = "C";
                if (comboBoxEx47.SelectedIndex == 11)
                    cb47pa = "C";
                if (comboBoxEx48.SelectedIndex == 11)
                    cb48pa = "C";
                if (comboBoxEx49.SelectedIndex == 11)
                    cb49pa = "C";
                if (comboBoxEx50.SelectedIndex == 11)
                    cb50pa = "C";

                if (comboBoxEx41.SelectedIndex == 12)
                    cb41pa = "D";
                if (comboBoxEx42.SelectedIndex == 12)
                    cb42pa = "D";
                if (comboBoxEx43.SelectedIndex == 12)
                    cb43pa = "D";
                if (comboBoxEx44.SelectedIndex == 12)
                    cb44pa = "D";
                if (comboBoxEx45.SelectedIndex == 12)
                    cb45pa = "D";
                if (comboBoxEx46.SelectedIndex == 12)
                    cb46pa = "D";
                if (comboBoxEx47.SelectedIndex == 12)
                    cb47pa = "D";
                if (comboBoxEx48.SelectedIndex == 12)
                    cb48pa = "D";
                if (comboBoxEx49.SelectedIndex == 12)
                    cb49pa = "D";
                if (comboBoxEx50.SelectedIndex == 12)
                    cb50pa = "D";

                if (comboBoxEx41.SelectedIndex == 13)
                    cb41pa = "E";
                if (comboBoxEx42.SelectedIndex == 13)
                    cb42pa = "E";
                if (comboBoxEx43.SelectedIndex == 13)
                    cb43pa = "E";
                if (comboBoxEx44.SelectedIndex == 13)
                    cb44pa = "E";
                if (comboBoxEx45.SelectedIndex == 13)
                    cb45pa = "E";
                if (comboBoxEx46.SelectedIndex == 13)
                    cb46pa = "E";
                if (comboBoxEx47.SelectedIndex == 13)
                    cb47pa = "E";
                if (comboBoxEx48.SelectedIndex == 13)
                    cb48pa = "E";
                if (comboBoxEx49.SelectedIndex == 13)
                    cb49pa = "E";
                if (comboBoxEx50.SelectedIndex == 13)
                    cb50pa = "E";

                if (comboBoxEx41.SelectedIndex == 14)
                    cb41pa = "F";
                if (comboBoxEx42.SelectedIndex == 14)
                    cb42pa = "F";
                if (comboBoxEx43.SelectedIndex == 14)
                    cb43pa = "F";
                if (comboBoxEx44.SelectedIndex == 14)
                    cb44pa = "F";
                if (comboBoxEx45.SelectedIndex == 14)
                    cb45pa = "F";
                if (comboBoxEx46.SelectedIndex == 14)
                    cb46pa = "F";
                if (comboBoxEx47.SelectedIndex == 14)
                    cb47pa = "F";
                if (comboBoxEx48.SelectedIndex == 14)
                    cb48pa = "F";
                if (comboBoxEx49.SelectedIndex == 14)
                    cb49pa = "F";
                if (comboBoxEx50.SelectedIndex == 14)
                    cb50pa = "F";



                int cb51sa2 = comboBoxEx51.SelectedIndex + 1;
                int cb52sa2 = comboBoxEx52.SelectedIndex + 1;
                int cb53sa2 = comboBoxEx53.SelectedIndex + 1;
                int cb54sa2 = comboBoxEx54.SelectedIndex + 1;
                int cb55sa2 = comboBoxEx55.SelectedIndex + 1;
                int cb56sa2 = comboBoxEx56.SelectedIndex + 1;
                int cb57sa2 = comboBoxEx57.SelectedIndex + 1;
                int cb58sa2 = comboBoxEx58.SelectedIndex + 1;
                int cb59sa2 = comboBoxEx59.SelectedIndex + 1;
                int cb60sa2 = comboBoxEx60.SelectedIndex + 1;

                string cb51sa = cb51sa2.ToString();
                string cb52sa = cb52sa2.ToString();
                string cb53sa = cb53sa2.ToString();
                string cb54sa = cb54sa2.ToString();
                string cb55sa = cb55sa2.ToString();
                string cb56sa = cb56sa2.ToString();
                string cb57sa = cb57sa2.ToString();
                string cb58sa = cb58sa2.ToString();
                string cb59sa = cb59sa2.ToString();
                string cb60sa = cb60sa2.ToString();

                if (comboBoxEx51.SelectedIndex == 9)
                    cb51sa = "A";
                if (comboBoxEx52.SelectedIndex == 9)
                    cb52sa = "A";
                if (comboBoxEx53.SelectedIndex == 9)
                    cb53sa = "A";
                if (comboBoxEx54.SelectedIndex == 9)
                    cb54sa = "A";
                if (comboBoxEx55.SelectedIndex == 9)
                    cb55sa = "A";
                if (comboBoxEx56.SelectedIndex == 9)
                    cb56sa = "A";
                if (comboBoxEx57.SelectedIndex == 9)
                    cb57sa = "A";
                if (comboBoxEx58.SelectedIndex == 9)
                    cb58sa = "A";
                if (comboBoxEx59.SelectedIndex == 9)
                    cb59sa = "A";
                if (comboBoxEx60.SelectedIndex == 9)
                    cb60sa = "A";

                if (comboBoxEx51.SelectedIndex == 10)
                    cb51sa = "B";
                if (comboBoxEx52.SelectedIndex == 10)
                    cb52sa = "B";
                if (comboBoxEx53.SelectedIndex == 10)
                    cb53sa = "B";
                if (comboBoxEx54.SelectedIndex == 10)
                    cb54sa = "B";
                if (comboBoxEx55.SelectedIndex == 10)
                    cb55sa = "B";
                if (comboBoxEx56.SelectedIndex == 10)
                    cb56sa = "B";
                if (comboBoxEx57.SelectedIndex == 10)
                    cb57sa = "B";
                if (comboBoxEx58.SelectedIndex == 10)
                    cb58sa = "B";
                if (comboBoxEx59.SelectedIndex == 10)
                    cb59sa = "B";
                if (comboBoxEx60.SelectedIndex == 10)
                    cb60sa = "B";

                if (comboBoxEx51.SelectedIndex == 11)
                    cb51sa = "C";
                if (comboBoxEx52.SelectedIndex == 11)
                    cb52sa = "C";
                if (comboBoxEx53.SelectedIndex == 11)
                    cb53sa = "C";
                if (comboBoxEx54.SelectedIndex == 11)
                    cb54sa = "C";
                if (comboBoxEx55.SelectedIndex == 11)
                    cb55sa = "C";
                if (comboBoxEx56.SelectedIndex == 11)
                    cb56sa = "C";
                if (comboBoxEx57.SelectedIndex == 11)
                    cb57sa = "C";
                if (comboBoxEx58.SelectedIndex == 11)
                    cb58sa = "C";
                if (comboBoxEx59.SelectedIndex == 11)
                    cb59sa = "C";
                if (comboBoxEx60.SelectedIndex == 11)
                    cb60sa = "C";

                if (comboBoxEx51.SelectedIndex == 12)
                    cb51sa = "D";
                if (comboBoxEx52.SelectedIndex == 12)
                    cb52sa = "D";
                if (comboBoxEx53.SelectedIndex == 12)
                    cb53sa = "D";
                if (comboBoxEx54.SelectedIndex == 12)
                    cb54sa = "D";
                if (comboBoxEx55.SelectedIndex == 12)
                    cb55sa = "D";
                if (comboBoxEx56.SelectedIndex == 12)
                    cb56sa = "D";
                if (comboBoxEx57.SelectedIndex == 12)
                    cb57sa = "D";
                if (comboBoxEx58.SelectedIndex == 12)
                    cb58sa = "D";
                if (comboBoxEx59.SelectedIndex == 12)
                    cb59sa = "D";
                if (comboBoxEx60.SelectedIndex == 12)
                    cb60sa = "D";

                if (comboBoxEx51.SelectedIndex == 13)
                    cb51sa = "E";
                if (comboBoxEx52.SelectedIndex == 13)
                    cb52sa = "E";
                if (comboBoxEx53.SelectedIndex == 13)
                    cb53sa = "E";
                if (comboBoxEx54.SelectedIndex == 13)
                    cb54sa = "E";
                if (comboBoxEx55.SelectedIndex == 13)
                    cb55sa = "E";
                if (comboBoxEx56.SelectedIndex == 13)
                    cb56sa = "E";
                if (comboBoxEx57.SelectedIndex == 13)
                    cb57sa = "E";
                if (comboBoxEx58.SelectedIndex == 13)
                    cb58sa = "E";
                if (comboBoxEx59.SelectedIndex == 13)
                    cb59sa = "E";
                if (comboBoxEx60.SelectedIndex == 13)
                    cb60sa = "E";

                if (comboBoxEx51.SelectedIndex == 14)
                    cb51sa = "F";
                if (comboBoxEx52.SelectedIndex == 14)
                    cb52sa = "F";
                if (comboBoxEx53.SelectedIndex == 14)
                    cb53sa = "F";
                if (comboBoxEx54.SelectedIndex == 14)
                    cb54sa = "F";
                if (comboBoxEx55.SelectedIndex == 14)
                    cb55sa = "F";
                if (comboBoxEx56.SelectedIndex == 14)
                    cb56sa = "F";
                if (comboBoxEx57.SelectedIndex == 14)
                    cb57sa = "F";
                if (comboBoxEx58.SelectedIndex == 14)
                    cb58sa = "F";
                if (comboBoxEx59.SelectedIndex == 14)
                    cb59sa = "F";
                if (comboBoxEx60.SelectedIndex == 14)
                    cb60sa = "F";
                #endregion
                #endregion
                #region asdasd 
                if (!checkBoxX1.Checked && !checkBoxX2.Checked)
                {
                    textBoxX2.Text = toHex(textBoxX2.Text); //turning the textboxes text to hex
                    textBoxX3.Text = toHex(textBoxX3.Text);
                    textBoxX4.Text = toHex(textBoxX4.Text);
                    textBoxX5.Text = toHex(textBoxX5.Text);
                    textBoxX6.Text = toHex(textBoxX6.Text);
                    textBoxX7.Text = toHex(textBoxX7.Text);
                    textBoxX8.Text = toHex(textBoxX8.Text);
                    textBoxX9.Text = toHex(textBoxX9.Text);
                    textBoxX10.Text = toHex(textBoxX10.Text);
                    textBoxX11.Text = toHex(textBoxX11.Text);
                }

                    textBoxX2.CharacterCasing = CharacterCasing.Upper; //changing the character casing to upper (wouldn't work without this)
                    textBoxX3.CharacterCasing = CharacterCasing.Upper;
                    textBoxX4.CharacterCasing = CharacterCasing.Upper;
                    textBoxX5.CharacterCasing = CharacterCasing.Upper;
                    textBoxX6.CharacterCasing = CharacterCasing.Upper;
                    textBoxX7.CharacterCasing = CharacterCasing.Upper;
                    textBoxX8.CharacterCasing = CharacterCasing.Upper;
                    textBoxX9.CharacterCasing = CharacterCasing.Upper;
                    textBoxX10.CharacterCasing = CharacterCasing.Upper;
                    textBoxX11.CharacterCasing = CharacterCasing.Upper;
                #endregion



                    Ox.Call(SV, (int)numericUpDown1.Value, 1, "J " + (!checkBoxX1.Checked ? "3040 " + textBoxX2.Text + "00" + " 3104 " + textBoxX3.Text + "00" + " 3168 " + textBoxX4.Text + "00" + " 3232 " + textBoxX5.Text + "00" + " 3296 " + textBoxX6.Text + "00" + " 3360 " + textBoxX7.Text + "00" + " 3424 " + textBoxX8.Text + "00" + " 3488 " + textBoxX9.Text + "00" + " 3552 " + textBoxX10.Text + "00" + " 3616 " + textBoxX11.Text + "00 " : "") + (!checkBoxX3.Checked ? "3038 " + (comboBoxEx1.SelectedIndex <= 8 ? "0" + cb1sl.ToString() : "") + ((comboBoxEx1.SelectedIndex > 8) && (comboBoxEx1.SelectedIndex <= 32) ? cb1sl.ToString() : "") + (comboBoxEx1.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx1.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx1.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx1.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx1.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx1.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx1.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx1.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx1.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx1.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx1.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx1.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx1.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx1.SelectedIndex == 46 ? "39" : "") + " 3102 " + (comboBoxEx2.SelectedIndex <= 8 ? "0" + cb2sl.ToString() : "") + ((comboBoxEx2.SelectedIndex > 8) && (comboBoxEx2.SelectedIndex <= 32) ? cb2sl.ToString() : "") + (comboBoxEx2.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx2.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx2.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx2.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx2.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx2.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx2.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx2.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx2.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx2.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx2.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx2.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx2.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx2.SelectedIndex == 46 ? "39" : "") + " 3166 " + (comboBoxEx3.SelectedIndex <= 8 ? "0" + cb3sl.ToString() : "") + ((comboBoxEx3.SelectedIndex > 8) && (comboBoxEx3.SelectedIndex <= 32) ? cb3sl.ToString() : "") + (comboBoxEx3.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx3.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx3.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx3.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx3.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx3.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx3.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx3.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx3.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx3.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx3.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx3.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx3.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx3.SelectedIndex == 46 ? "39" : "") + " 3230 " + (comboBoxEx4.SelectedIndex <= 8 ? "0" + cb4sl.ToString() : "") + ((comboBoxEx4.SelectedIndex > 8) && (comboBoxEx4.SelectedIndex <= 32) ? cb4sl.ToString() : "") + (comboBoxEx4.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx4.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx4.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx4.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx4.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx4.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx4.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx4.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx4.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx4.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx4.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx4.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx4.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx4.SelectedIndex == 46 ? "39" : "") + " 3294 " + (comboBoxEx5.SelectedIndex <= 8 ? "0" + cb5sl.ToString() : "") + ((comboBoxEx5.SelectedIndex > 8) && (comboBoxEx5.SelectedIndex <= 32) ? cb5sl.ToString() : "") + (comboBoxEx5.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx5.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx5.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx5.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx5.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx5.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx5.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx5.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx5.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx5.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx5.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx5.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx5.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx5.SelectedIndex == 46 ? "39" : "") + " 3358 " + (comboBoxEx6.SelectedIndex <= 8 ? "0" + cb6sl.ToString() : "") + ((comboBoxEx6.SelectedIndex > 8) && (comboBoxEx6.SelectedIndex <= 32) ? cb6sl.ToString() : "") + (comboBoxEx6.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx6.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx6.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx6.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx6.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx6.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx6.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx6.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx6.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx6.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx6.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx6.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx6.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx6.SelectedIndex == 46 ? "39" : "") + " 3422 " + (comboBoxEx7.SelectedIndex <= 8 ? "0" + cb7sl.ToString() : "") + ((comboBoxEx7.SelectedIndex > 8) && (comboBoxEx7.SelectedIndex <= 32) ? cb7sl.ToString() : "") + (comboBoxEx7.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx7.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx7.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx7.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx7.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx7.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx7.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx7.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx7.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx7.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx7.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx7.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx7.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx7.SelectedIndex == 46 ? "39" : "") + " 3486 " + (comboBoxEx8.SelectedIndex <= 8 ? "0" + cb8sl.ToString() : "") + ((comboBoxEx8.SelectedIndex > 8) && (comboBoxEx8.SelectedIndex <= 32) ? cb8sl.ToString() : "") + (comboBoxEx8.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx8.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx8.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx8.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx8.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx8.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx8.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx8.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx8.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx8.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx8.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx8.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx8.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx8.SelectedIndex == 46 ? "39" : "") + " 3550 " + (comboBoxEx9.SelectedIndex <= 8 ? "0" + cb9sl.ToString() : "") + ((comboBoxEx9.SelectedIndex > 8) && (comboBoxEx9.SelectedIndex <= 32) ? cb9sl.ToString() : "") + (comboBoxEx9.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx9.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx9.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx9.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx9.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx9.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx9.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx9.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx9.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx9.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx9.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx9.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx9.SelectedIndex == 45 ? "3B" : "") + (comboBoxEx9.SelectedIndex == 46 ? "39" : "") + " 3614 " + (comboBoxEx10.SelectedIndex <= 8 ? "0" + cb10sl.ToString() : "") + ((comboBoxEx10.SelectedIndex > 8) && (comboBoxEx10.SelectedIndex <= 32) ? cb10sl.ToString() : "") + (comboBoxEx10.SelectedIndex == 33 ? "0C" : "") + (comboBoxEx10.SelectedIndex == 34 ? "0D" : "") + (comboBoxEx10.SelectedIndex == 35 ? "0E" : "") + (comboBoxEx10.SelectedIndex == 36 ? "0F" : "") + (comboBoxEx10.SelectedIndex == 37 ? "1A" : "") + (comboBoxEx10.SelectedIndex == 38 ? "1B" : "") + (comboBoxEx10.SelectedIndex == 39 ? "1C" : "") + (comboBoxEx10.SelectedIndex == 40 ? "1D" : "") + (comboBoxEx10.SelectedIndex == 41 ? "1E" : "") + (comboBoxEx10.SelectedIndex == 42 ? "1F" : "") + (comboBoxEx10.SelectedIndex == 43 ? "2B" : "") + (comboBoxEx10.SelectedIndex == 44 ? "2F" : "") + (comboBoxEx10.SelectedIndex == 45 ? "3B" : "") : "") + (comboBoxEx10.SelectedIndex == 46 ? "39" : "") + (!checkBoxX4.Checked ? " 3010" + " 0" + cb11c + " 3074" + " 0" + cb12c + " 3138" + " 0" + cb13c + " 3202" + " 0" + cb14c + " 3266" + " 0" + cb15c + " 3330" + " 0" + cb16c + " 3394" + " 0" + cb17c + " 3458" + " 0" + cb18c + " 3522" + " 0" + cb19c + " 3586" + " 0" + cb20c : "") + (!checkBoxX5.Checked ? " 3022" + " 0" + cb21sc + " 3086" + " 0" + cb22sc + " 3150" + " 0" + cb23sc + " 3214" + " 0" + cb24sc + " 3278" + " 0" + cb25sc + " 3342" + " 0" + cb26sc + " 3406" + " 0" + cb27sc + " 3470" + " 0" + cb28sc + " 3534" + " 0" + cb29sc + " 3598" + " 0" + cb30sc : "") + (!checkBoxX6.Checked ? " 3028 " + cb31ls + " 3092 " + cb32ls + " 3156 " + cb33ls + " 3220 " + cb34ls + " 3284 " + cb35ls + " 3348 " + cb36ls + " 3412 " + cb37ls + " 3476 " + cb38ls + " 3540 " + cb39ls + " 3604 " + cb40ls : "") + (!checkBoxX8.Checked ? " 3006 0" + cb41pa + " 3070 0" + cb42pa + " 3134 0" + cb43pa + " 3198 0" + cb44pa + " 3262 0" + cb45pa + " 3326 0" + cb46pa + " 3390 0" + cb47pa + " 3454 0" + cb48pa + " 3518 0" + cb49pa + " 3582 0" + cb50pa : "") + (!checkBoxX9.Checked ? " 3018 0" + cb51sa + " 3082 0" + cb52sa + " 3146 0" + cb53sa + " 3210 0" + cb54sa + " 3274 0" + cb55sa + " 3338 0" + cb56sa + " 3402 0" + cb57sa + " 3466 0" + cb58sa + " 3530 0" + cb59sa + " 3594 0" + cb60sa : "") + " 2064 ^6Meow!^5:D^2_Ox's_MW2_Custom_Class_Tool^3:)");

                #region asdaqwwdq
                    textBoxX2.CharacterCasing = CharacterCasing.Normal; //changing the character casing back to normal.
                    textBoxX3.CharacterCasing = CharacterCasing.Normal;
                    textBoxX4.CharacterCasing = CharacterCasing.Normal;
                    textBoxX5.CharacterCasing = CharacterCasing.Normal;
                    textBoxX6.CharacterCasing = CharacterCasing.Normal;
                    textBoxX7.CharacterCasing = CharacterCasing.Normal;
                    textBoxX8.CharacterCasing = CharacterCasing.Normal;
                    textBoxX9.CharacterCasing = CharacterCasing.Normal;
                    textBoxX10.CharacterCasing = CharacterCasing.Normal;
                    textBoxX11.CharacterCasing = CharacterCasing.Normal;

                    textBoxX2.Text = ctb2txt;
                    textBoxX3.Text = ctb3txt;
                    textBoxX4.Text = ctb4txt;
                    textBoxX5.Text = ctb5txt;
                    textBoxX6.Text = ctb6txt;
                    textBoxX7.Text = ctb7txt;
                    textBoxX8.Text = ctb8txt;
                    textBoxX9.Text = ctb9txt;
                    textBoxX10.Text = ctb10txt;
                    textBoxX11.Text = ctb11txt;

                    if(checkBoxX7.Checked)
                    {
                        comboBoxEx1.SelectedIndex = -1;
                        comboBoxEx2.SelectedIndex = -1;
                        comboBoxEx3.SelectedIndex = -1;
                        comboBoxEx4.SelectedIndex = -1;
                        comboBoxEx5.SelectedIndex = -1;
                        comboBoxEx6.SelectedIndex = -1;
                        comboBoxEx7.SelectedIndex = -1;
                        comboBoxEx8.SelectedIndex = -1;
                        comboBoxEx8.SelectedIndex = -1;
                        comboBoxEx9.SelectedIndex = -1;
                        comboBoxEx10.SelectedIndex = -1;
                        comboBoxEx11.SelectedIndex = -1;
                        comboBoxEx12.SelectedIndex = -1;
                        comboBoxEx13.SelectedIndex = -1;
                        comboBoxEx14.SelectedIndex = -1;
                        comboBoxEx15.SelectedIndex = -1;
                        comboBoxEx16.SelectedIndex = -1;
                        comboBoxEx17.SelectedIndex = -1;
                        comboBoxEx18.SelectedIndex = -1;
                        comboBoxEx19.SelectedIndex = -1;
                        comboBoxEx20.SelectedIndex = -1;
                        comboBoxEx21.SelectedIndex = -1;
                        comboBoxEx22.SelectedIndex = -1;
                        comboBoxEx23.SelectedIndex = -1;
                        comboBoxEx24.SelectedIndex = -1;
                        comboBoxEx25.SelectedIndex = -1;
                        comboBoxEx26.SelectedIndex = -1;
                        comboBoxEx27.SelectedIndex = -1;
                        comboBoxEx28.SelectedIndex = -1;
                        comboBoxEx29.SelectedIndex = -1;
                        comboBoxEx30.SelectedIndex = -1;
                        comboBoxEx32.SelectedIndex = -1;
                        comboBoxEx32.SelectedIndex = -1;
                        comboBoxEx33.SelectedIndex = -1;
                        comboBoxEx34.SelectedIndex = -1;
                        comboBoxEx35.SelectedIndex = -1;
                        comboBoxEx36.SelectedIndex = -1;
                        comboBoxEx37.SelectedIndex = -1;
                        comboBoxEx38.SelectedIndex = -1;
                        comboBoxEx39.SelectedIndex = -1;
                        comboBoxEx40.SelectedIndex = -1;

                        comboBoxEx1.Text = cb1txt;
                        comboBoxEx2.Text = cb2txt;
                        comboBoxEx3.Text = cb3txt;
                        comboBoxEx4.Text = cb4txt;
                        comboBoxEx5.Text = cb5txt;
                        comboBoxEx6.Text = cb6txt;
                        comboBoxEx7.Text = cb7txt;
                        comboBoxEx8.Text = cb8txt;
                        comboBoxEx9.Text = cb9txt;
                        comboBoxEx10.Text = cb10txt;
                        comboBoxEx11.Text = cb11txt;
                        comboBoxEx12.Text = cb12txt;
                        comboBoxEx13.Text = cb13txt;
                        comboBoxEx14.Text = cb14txt;
                        comboBoxEx15.Text = cb15txt;
                        comboBoxEx16.Text = cb16txt;
                        comboBoxEx17.Text = cb17txt;
                        comboBoxEx18.Text = cb18txt;
                        comboBoxEx19.Text = cb19txt;
                        comboBoxEx20.Text = cb20txt;
                        comboBoxEx21.Text = cb21txt;
                        comboBoxEx22.Text = cb22txt;
                        comboBoxEx23.Text = cb23txt;
                        comboBoxEx24.Text = cb24txt;
                        comboBoxEx25.Text = cb25txt;
                        comboBoxEx26.Text = cb26txt;
                        comboBoxEx27.Text = cb27txt;
                        comboBoxEx28.Text = cb28txt;
                        comboBoxEx29.Text = cb29txt;
                        comboBoxEx30.Text = cb30txt;
                        comboBoxEx31.Text = cb31txt;
                        comboBoxEx32.Text = cb32txt;
                        comboBoxEx33.Text = cb33txt;
                        comboBoxEx34.Text = cb34txt;
                        comboBoxEx35.Text = cb35txt;
                        comboBoxEx36.Text = cb36txt;
                        comboBoxEx37.Text = cb37txt;
                        comboBoxEx38.Text = cb38txt;
                        comboBoxEx39.Text = cb39txt;
                        comboBoxEx40.Text = cb40txt;

                        textBoxX2.Text = tb2txt;
                        textBoxX3.Text = tb3txt;
                        textBoxX4.Text = tb4txt;
                        textBoxX5.Text = tb5txt;
                        textBoxX6.Text = tb6txt;
                        textBoxX7.Text = tb7txt;
                        textBoxX8.Text = tb8txt;
                        textBoxX9.Text = tb9txt;
                        textBoxX10.Text = tb10txt;
                        textBoxX11.Text = tb11txt;
                    }
                #endregion
            }
        }
        #region es2
        private void buttonX10_Click(object sender, EventArgs e)
        {
            CheckForUpdate2();
        }

        void nekkero()
        {
            cb1txt = comboBoxEx1.Text;
            cb2txt = comboBoxEx2.Text;
            cb3txt = comboBoxEx3.Text;
            cb4txt = comboBoxEx4.Text;
            cb5txt = comboBoxEx5.Text;
            cb6txt = comboBoxEx6.Text;
            cb7txt = comboBoxEx7.Text;
            cb8txt = comboBoxEx8.Text;
            cb9txt = comboBoxEx9.Text;
            cb10txt = comboBoxEx10.Text;
            cb11txt = comboBoxEx11.Text;
            cb12txt = comboBoxEx12.Text;
            cb13txt = comboBoxEx13.Text;
            cb14txt = comboBoxEx14.Text;
            cb15txt = comboBoxEx15.Text;
            cb16txt = comboBoxEx16.Text;
            cb17txt = comboBoxEx17.Text;
            cb18txt = comboBoxEx18.Text;
            cb19txt = comboBoxEx19.Text;
            cb20txt = comboBoxEx20.Text;
            cb21txt = comboBoxEx21.Text;
            cb22txt = comboBoxEx22.Text;
            cb23txt = comboBoxEx23.Text;
            cb24txt = comboBoxEx24.Text;
            cb25txt = comboBoxEx25.Text;
            cb26txt = comboBoxEx26.Text;
            cb27txt = comboBoxEx27.Text;
            cb28txt = comboBoxEx28.Text;
            cb29txt = comboBoxEx29.Text;
            cb30txt = comboBoxEx30.Text;
            cb31txt = comboBoxEx31.Text;
            cb32txt = comboBoxEx32.Text;
            cb33txt = comboBoxEx33.Text;
            cb34txt = comboBoxEx34.Text;
            cb35txt = comboBoxEx35.Text;
            cb36txt = comboBoxEx36.Text;
            cb37txt = comboBoxEx37.Text;
            cb38txt = comboBoxEx38.Text;
            cb39txt = comboBoxEx39.Text;
            cb40txt = comboBoxEx40.Text;

            tb2txt = textBoxX2.Text;
            tb3txt = textBoxX3.Text;
            tb4txt = textBoxX4.Text;
            tb5txt = textBoxX5.Text;
            tb6txt = textBoxX6.Text;
            tb7txt = textBoxX7.Text;
            tb8txt = textBoxX8.Text;
            tb9txt = textBoxX9.Text;
            tb10txt = textBoxX10.Text;
            tb11txt = textBoxX11.Text;
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonX5_Click((object)sender, (EventArgs)e);
            }
        }

        private void superTabItem2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(871, 341);
        }

        private void superTabItem1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(512, 325);
        }

        private void superTabItem7_Click(object sender, EventArgs e)
        {
            this.Size = new Size(512, 325);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.se7ensins.com/forums/threads/Meow.1170984/");
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void superTabControlPanel3_Click(object sender, EventArgs e)
        {

        }

    }
}
        #endregion