using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ServiceProcess;
using System.Windows.Forms;

using Microsoft.Win32;
using parser;

namespace EasySSHd
{
    public partial class EasySSHdWindow : Form
    {
        private bool changed = false; // global change indicator
        private parser.parser ConfigParser = new parser.parser(); // global config-parser instance
        private RegistryKey installDirRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Cygnus Solutions\Cygwin\mounts v2\/", false);
        private ArrayList plainFileContent = new ArrayList();
        ServiceController sshd = new ServiceController("sshd");
                
        
        // Constructor
        public EasySSHdWindow()
        {
            InitializeComponent();
        }

        // Called on Window Load, Initialize all Values
        private void EasySSHdWindow_Load(object sender, EventArgs e)
        {
            string motdFile = "";
            string installDir = "";
            try
            {
                installDir = installDirRegKey.GetValue("native").ToString();
            }
            catch (NullReferenceException)
            {
                if (MessageBox.Show("The installation path couldn't be detected. Please (re)install EasySSHd.", "EasySSHd", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    EasySSHdWindow_Load(sender, e);
                }
                else
                {
                    Close();
                }
            }

            if (installDir != "")
            {
                switch (ConfigParser.readFile(installDir + @"\etc\sshd_config"))
                {
                    case 1:
                        this.writePlainFile(installDir + @"\etc\sshd_config", "");
                        EasySSHdWindow_Load(sender, e);
                        break;
                    case 2:
                        if (MessageBox.Show("The config file is not readable. Please check the permissions.", "EasySSHd", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            EasySSHdWindow_Load(sender, e);
                        }
                        else
                        {
                            Close();
                        }
                        break;
                }
            }

            motdFile = installDir + @"\etc\motd";

            try
            {
                if (motdFile != @"\etc\motd")
                {
                    this.readPlainFile(motdFile);
                }
            }
            catch (FileNotFoundException)
            {
                if (MessageBox.Show("The file for 'Message of the day' does not exist. Do you want to create an empty one?", "EasySSHd", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    try
                    {
                        this.writePlainFile(motdFile, "");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("The file for 'Message of the day' is not writeable. Please check the permissions.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The file for 'Message of the day' is not readable. Please check the permissions.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string ListenAddress = ConfigParser.getValue("ListenAddress");
            string Port = ConfigParser.getValue("Port");
            string LoginGraceTime = ConfigParser.getValue("LoginGraceTime");
            string MaxAuthTries = ConfigParser.getValue("MaxAuthTries");
            string MaxSessions = ConfigParser.getValue("MaxSessions");
            string PubkeyAuthentication = ConfigParser.getValue("PubkeyAuthentication");
            string AuthorizedKeysFile = ConfigParser.getValue("AuthorizedKeysFile");
            string PrintMotd = ConfigParser.getValue("PrintMotd");            
            string PrintLastLog = ConfigParser.getValue("PrintLastLog");
            string TCPKeepAlive = ConfigParser.getValue("TCPKeepAlive");
            string Compression = ConfigParser.getValue("Compression");
            string ClientAliveInterval = ConfigParser.getValue("ClientAliveInterval");
            string ClientAliveCountMax = ConfigParser.getValue("ClientAliveCountMax");
            string MaxStartups = ConfigParser.getValue("MaxStartups");
            string Banner = ConfigParser.getValue("Banner");

            if (ListenAddress != "") 
            {
                if(this.IsValidIP(ListenAddress))
                {
                    ServerAddressTextBox.Text = ListenAddress;
                }
                else
                {
                    ServerAddressTextBox.Text = "0.0.0.0";
                }
            }
            else
            {
                ServerAddressTextBox.Text = "0.0.0.0";
            }
            if (Port != "")
            {
                ServerPortNumericUpDown.Value = decimal.Parse(Port);
            }
            else
            {
                ServerPortNumericUpDown.Value = 22;
            }
            if (LoginGraceTime != "")
            {
                LoginTimeNumericUpDown.Value = decimal.Parse(LoginGraceTime);
            }
            else
            {
                LoginTimeNumericUpDown.Value = 120;
            }
            if (MaxAuthTries != "")
            {
                MaxAuthTriesNumericUpDown.Value = decimal.Parse(MaxAuthTries);
            }
            else
            {
                MaxAuthTriesNumericUpDown.Value = 6;
            }
            if (MaxStartups != "")
            {
                ConcurrentLoginsNumericUpDown.Value = decimal.Parse(MaxStartups);
            }
            else
            {
                ConcurrentLoginsNumericUpDown.Value = 10;
            }
            if (MaxSessions != "")
            {
                MaxSessionsNumericUpDown.Value = decimal.Parse(MaxSessions);
            }
            else
            {
                MaxSessionsNumericUpDown.Value = 10;
            }
            if (PubkeyAuthentication != "")
            {
                if (PubkeyAuthentication == "yes")
                {
                    LoginPossibleWithCertificateCheckBox.Checked = true;
                }
                else
                {
                    LoginPossibleWithCertificateCheckBox.Checked = false;
                }
            }
            else
            {
                LoginPossibleWithCertificateCheckBox.Checked = true;
            }
            if (AuthorizedKeysFile != "")
            {
                PathToCertificateTextBox.Text = getShownPath(AuthorizedKeysFile);
            }
            else
            {
                PathToCertificateTextBox.Text = "";
            }
            if (Compression != "")
            {
                switch (Compression)
                {
                    case "yes":
                        CompressionComboBox.Text = "On";
                        break;
                    case "no":
                        CompressionComboBox.Text = "Off";
                        break;
                    case "delayed":
                        CompressionComboBox.Text = "delayed";
                        break;
                    default:
                        CompressionComboBox.Text = "delayed";
                        break;
                }
                
            }
            else
            {
                CompressionComboBox.Text = "delayed";
            }
            if (TCPKeepAlive != "")
            {
                if (TCPKeepAlive == "yes")
                {
                    TestIfClientIsStillReachableCheckBox.Checked = true;
                }
                else
                {
                    TestIfClientIsStillReachableCheckBox.Checked = false;
                }
            }
            else
            {
                TestIfClientIsStillReachableCheckBox.Checked = true;
            }
            if (ClientAliveInterval != "")
            {
                TestConnectionOfClientEveryNumericUpDown.Value = decimal.Parse(ClientAliveInterval);
            }
            else
            {
                TestConnectionOfClientEveryNumericUpDown.Value = 0;
            }
            if (ClientAliveCountMax != "")
            {
                PassesNumericUpDown.Value = decimal.Parse(ClientAliveCountMax);
            }
            else
            {
                PassesNumericUpDown.Value = 3;
            }
            if (Banner != "")
            {
                MessageBeforeLoginTextBox.Text = this.getShownPath(Banner);
            }
            else
            {
                MessageBeforeLoginTextBox.Text = "";
            }
            if (PrintMotd != "")
            {
                if (PrintMotd == "yes")
                {
                    PrintMessageOfTheDayCheckBox.Checked = true;
                }
                else
                {
                    PrintMessageOfTheDayCheckBox.Checked = false;
                }
            }
            else
            {
                PrintMessageOfTheDayCheckBox.Checked = true;
            }
            if (!plainFileContent.Contains(null))
            {
                foreach (string line in plainFileContent)
                {
                    PrintMessageOfTheDayTextBox.Text += line + "\r\n";
                }
            }
            else
            {
                PrintMessageOfTheDayTextBox.Text = "";
            }
            if (PrintLastLog != "")
            {
                if (PrintLastLog == "yes")
                {
                    PrintLastLoginCheckBox.Checked = true;
                }
                else
                {
                    PrintLastLoginCheckBox.Checked = false;
                }
            }
            else
            {
                PrintLastLoginCheckBox.Checked = true;
            }
            this.changed = false;
        }

        // Save all changes into sshd_config file
        private bool SaveChanges()
        {
            bool error = false;
            string installDir = installDirRegKey.GetValue("native").ToString();
            string motdFile = installDir + @"\etc\motd";

            try
            {
                this.readPlainFile(motdFile);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The file for 'Message of the day' is not accessable. Please check the permissions.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

            string ListenAddress = ConfigParser.getValue("ListenAddress");
            string Port = ConfigParser.getValue("Port");
            string LoginGraceTime = ConfigParser.getValue("LoginGraceTime");
            string MaxAuthTries = ConfigParser.getValue("MaxAuthTries");
            string MaxSessions = ConfigParser.getValue("MaxSessions");
            string PubkeyAuthentication = ConfigParser.getValue("PubkeyAuthentication");
            string AuthorizedKeysFile = ConfigParser.getValue("AuthorizedKeysFile");
            string PrintMotd = ConfigParser.getValue("PrintMotd");
            string PrintLastLog = ConfigParser.getValue("PrintLastLog");
            string TCPKeepAlive = ConfigParser.getValue("TCPKeepAlive");
            string Compression = ConfigParser.getValue("Compression");
            string ClientAliveInterval = ConfigParser.getValue("ClientAliveInterval");
            string ClientAliveCountMax = ConfigParser.getValue("ClientAliveCountMax");
            string MaxStartups = ConfigParser.getValue("MaxStartups");
            string Banner = ConfigParser.getValue("Banner");

            if (!(ListenAddress == ServerAddressTextBox.Text || (ListenAddress == "" && ServerAddressTextBox.Text == "0.0.0.0")))
            {
                if (this.IsValidIP(ServerAddressTextBox.Text))
                {
                    ConfigParser.setValue("ListenAddress", ServerAddressTextBox.Text);
                }
                else
                {
                    MessageBox.Show("ERROR: The IP address is not valid.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
            }
            if (!(Port == ServerPortNumericUpDown.Value.ToString() || (Port == "" && ServerPortNumericUpDown.Value == 22)))
            {
                ConfigParser.setValue("Port", ServerPortNumericUpDown.Value.ToString());
            }
            if (!(LoginGraceTime == LoginTimeNumericUpDown.Value.ToString() || (LoginTimeNumericUpDown.Value == 120 && LoginGraceTime == "")))
            {
                ConfigParser.setValue("LoginGraceTime", LoginTimeNumericUpDown.Value.ToString());
            }
            if (!(MaxAuthTries == MaxAuthTriesNumericUpDown.Value.ToString() || (MaxAuthTriesNumericUpDown.Value == 6 && MaxAuthTries == "")))
            {
                ConfigParser.setValue("MaxAuthTries", MaxAuthTriesNumericUpDown.Value.ToString());
            }
            if (!(MaxStartups == ConcurrentLoginsNumericUpDown.Value.ToString() || (ConcurrentLoginsNumericUpDown.Value == 10 && MaxStartups == "")))
            {
                ConfigParser.setValue("MaxStartups", ConcurrentLoginsNumericUpDown.Value.ToString());
            }
            if (!(MaxSessions == MaxSessionsNumericUpDown.Value.ToString() || (MaxSessionsNumericUpDown.Value == 10 && MaxSessions == "")))
            {
                ConfigParser.setValue("MaxSessions", MaxSessionsNumericUpDown.Value.ToString());
            }
            if (!((LoginPossibleWithCertificateCheckBox.Checked == false && PubkeyAuthentication == "no") ||
                (LoginPossibleWithCertificateCheckBox.Checked == true && PubkeyAuthentication == "yes")))
            {
                if (LoginPossibleWithCertificateCheckBox.Checked == true)
                {
                    ConfigParser.setValue("PubkeyAuthentication", "yes");
                }
                else
                {
                    ConfigParser.setValue("PubkeyAuthentication", "no");
                }
            }
            if (!(getShownPath(AuthorizedKeysFile) == PathToCertificateTextBox.Text || (PathToCertificateTextBox.Text == "" && AuthorizedKeysFile == "")))
            {
                if (PathToCertificateTextBox.Text != "")
                {
                    if (File.Exists(PathToCertificateTextBox.Text))
                    {
                        ConfigParser.setValue("AuthorizedKeysFile", "/cygdrive/" + PathToCertificateTextBox.Text.Replace(@"\", "/").Replace(":", ""));
                    }
                    else
                    {
                        MessageBox.Show("ERROR: This file does not exist.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                    }
                }
            }
            if (!((PrintMessageOfTheDayCheckBox.Checked == false && PrintMotd == "no") || 
                (PrintMessageOfTheDayCheckBox.Checked == true && PrintMotd == "yes")))
            {
                if (PrintMessageOfTheDayCheckBox.Checked == true)
                {
                    ConfigParser.setValue("PrintMotd", "yes");
                }
                else
                {
                    ConfigParser.setValue("PrintMotd", "no");
                }
            }
            if (!(plainFileContent.ToString() == PrintMessageOfTheDayTextBox.Text || (plainFileContent.ToString() == "" && PrintMessageOfTheDayTextBox.Text == "")))
            {
                this.writePlainFile(motdFile, PrintMessageOfTheDayTextBox.Text);
            }
            if (!((PrintLastLoginCheckBox.Checked == false && PrintLastLog == "no") || 
                (PrintLastLoginCheckBox.Checked == true && PrintLastLog == "yes")))
            {
                if (PrintLastLoginCheckBox.Checked == true)
                {
                    ConfigParser.setValue("PrintLastLog", "yes");
                }
                else
                {
                    ConfigParser.setValue("PrintLastLog", "no");
                }
            }
            if (!((TestIfClientIsStillReachableCheckBox.Checked == false && TCPKeepAlive == "no") || 
                (TestIfClientIsStillReachableCheckBox.Checked == true && TCPKeepAlive == "yes")))
            {
                if (TestIfClientIsStillReachableCheckBox.Checked == true)
                {
                    ConfigParser.setValue("TCPKeepAlive", "yes");
                }
                else
                {
                    ConfigParser.setValue("TCPKeepAlive", "no");
                }
            }
            if (!(Compression == CompressionComboBox.Text || (CompressionComboBox.Text == "delayed" && Compression == "")))
            {
                switch(CompressionComboBox.Text)
                {
                    case "On":
                        ConfigParser.setValue("Compression", "yes");
                        break;
                    case "Off":
                        ConfigParser.setValue("Compression", "no");
                        break;
                    case "delayed":
                        ConfigParser.setValue("Compression", "delayed");
                        break;
                    default:
                        ConfigParser.setValue("Compression", "delayed");
                        break;
                }
            }
            if (!(ClientAliveInterval == TestConnectionOfClientEveryNumericUpDown.Value.ToString() || (TestConnectionOfClientEveryNumericUpDown.Value == 0 && ClientAliveInterval == "")))
            {
                ConfigParser.setValue("ClientAliveInterval", TestConnectionOfClientEveryNumericUpDown.Value.ToString());
            }
            if (!(ClientAliveCountMax == PassesNumericUpDown.Value.ToString() || (PassesNumericUpDown.Value == 3 && ClientAliveCountMax == "")))
            {
                ConfigParser.setValue("ClientAliveCountMax", PassesNumericUpDown.Value.ToString());
            }
            if (!(getShownPath(Banner) == MessageBeforeLoginTextBox.Text || (MessageBeforeLoginTextBox.Text == "" && Banner == "")))
            {
                if (MessageBeforeLoginTextBox.Text != "")
                {
                    if (File.Exists(MessageBeforeLoginTextBox.Text))
                    {
                        ConfigParser.setValue("Banner", "/cygdrive/" + MessageBeforeLoginTextBox.Text.Replace(@"\", "/").Replace(":", ""));
                    }
                    else
                    {
                        MessageBox.Show("ERROR: This file does not exist.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                    }
                }
            }

            if (!error)
            {
                ConfigParser.writeFile(installDir + @"\etc\sshd_config");
                if (MessageBox.Show("Do you want to restart the service to load the changes?", "EasySSd", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StopButton.PerformClick();
                    StartButton.PerformClick();
                }
                this.changed = false;
                return true;
            }
            return false;
        }

        // Close Program and ask for saving unsaved changes
        private void quitButton_Click(object sender, EventArgs e)
        {
            if (!this.changed)
            {
                Application.Exit();
            }
            else
            {
                if (MessageBox.Show("There are unsaved changes\nDo you want to apply them?", "EasySSHd",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!this.SaveChanges())
                    {
                        MessageBox.Show("ERROR: Saving not possible!", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // Save changes
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (this.changed)
            {
                if (!this.SaveChanges())
                {
                    MessageBox.Show("ERROR: Saving not possible!", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Load default values
        private void DefaultsButton_Click(object sender, EventArgs e)
        {
            ServerAddressTextBox.Text = "0.0.0.0";
            ServerPortNumericUpDown.Value = 22;
            LoginTimeNumericUpDown.Value = 120;
            MaxAuthTriesNumericUpDown.Value = 6;
            ConcurrentLoginsNumericUpDown.Value = 10;
            MaxSessionsNumericUpDown.Value = 10;
            LoginPossibleWithCertificateCheckBox.Checked = true;
            PathToCertificateTextBox.Text = "";
            CompressionComboBox.Text = "delayed";
            TestIfClientIsStillReachableCheckBox.Checked = true;
            TestConnectionOfClientEveryNumericUpDown.Value = 0;
            PassesNumericUpDown.Value = 3;
            MessageBeforeLoginTextBox.Text = "";
            PrintMessageOfTheDayCheckBox.Checked = true;
            PrintMessageOfTheDayTextBox.Text = "";
            PrintLastLoginCheckBox.Checked = true;
            this.changed = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            bool started = false;
            try
            {
                sshd.Start();
                sshd.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.Parse("2") );
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("ERROR: Service couldn't be started. Maybe it is already started.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                started = true;
            }
            if (sshd.Status == ServiceControllerStatus.Running && started == false)
            {
                
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            bool stopped = false;
            try
            {
                sshd.Stop();
                sshd.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.Parse("2"));
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("ERROR: Service couldn't be stopped. Maybe it is already stopped.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stopped = true;
            }
            if (sshd.Status == ServiceControllerStatus.Stopped && stopped == false)
            {
                
            }
        }
        
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (openCertificate.ShowDialog().ToString() == "OK")
            {
                PathToCertificateTextBox.Text = openCertificate.FileName;
            }
        }

        private void ServerAddressTextBox_Leave(object sender, EventArgs e)
        {
            string ListenAddress = ConfigParser.getValue("ListenAddress");
            if (!(ListenAddress == ServerAddressTextBox.Text || (ListenAddress == "" && ServerAddressTextBox.Text == "0.0.0.0")))
            {
                if (IsValidIP(ServerAddressTextBox.Text))
                {
                    this.changed = true;
                }
                else
                {
                    MessageBox.Show("ERROR: The ip-address you have set is not valid.", "EasySSHd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ServerPortNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void LoginTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void MaxAuthTriesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void ConcurrentLoginsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void MaxSessionsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void LoginPossibleWithCertificateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void PathToCertificateTextBox_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void CompressionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void TestIfClientIsStillReachableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void TestConnectionOfClientEveryNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void PassesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void MessageBeforeLoginTextBox_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void MessageBeforeLoginBrowseButton_Click(object sender, EventArgs e)
        {
            if (openMessageBeforeLogin.ShowDialog().ToString() == "OK")
            {
                MessageBeforeLoginTextBox.Text = openMessageBeforeLogin.FileName;
            }
        }

        private void PrintMessageOfTheDayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void PrintMessageOfTheDayTextBox_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void PrintLastLoginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }
        
        // Get content of a file which doesn't need to be parsed e.g. motd. Content is saved in "plainFileContent"
        private void readPlainFile(string file)
        {
            string fileLine = "";
            StreamReader fileStr = new StreamReader(file);
            
            while (fileLine != null)
            {
                fileLine = fileStr.ReadLine();
                if (fileLine != null)
                    plainFileContent.Add(fileLine);
            }
            fileStr.Close();
        }
        // Write given text into given file without changing anything e.g. motd.
        private void writePlainFile(string file, string text)
        {
            StreamWriter fileStr = new StreamWriter(file);
            fileStr.WriteLine(text);
            fileStr.Close();
        }

        private bool IsValidIP(string addr)
        {
            string pattern = @"^([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            Regex check = new Regex(pattern);
            bool valid = false;

            //check to make sure an ip address was provided and test if it is valid
            if (addr == "")
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(addr, 0);
            }

            return valid;
        }

        private string getShownPath(string path)
        {
            if (path.Length > 11)
            {
                string shownPath = path.Substring(11);
                string drive = path.Substring(10).Remove(1);
                return drive + ":" + shownPath.Replace(@"/", @"\");
            }
            return "";
        }
                
    }
}
