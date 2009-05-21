﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
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
        
        
        
        // Constructor
        public EasySSHdWindow()
        {
            InitializeComponent();
        }

        // Called on Window Load, Initialize all Values
        private void EasySSHdWindow_Load(object sender, EventArgs e)
        {
            string installDir = installDirRegKey.GetValue("native").ToString();
            ConfigParser.readFile(installDir + @"\etc\sshd_config");
            string motdFile = installDir + @"\etc\motd";

            try
            {
                this.readPlainFile(motdFile);
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
                ServerAddressTextBox.Text = ListenAddress;
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
            if (Compression != "")
            {
                CompressionComboBox.Text = Compression;
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
                MessageBeforeLoginTextBox.Text = Banner;
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
            string installDir = installDirRegKey.GetValue("native").ToString();
            string motdFile = installDir + @"\etc\motd";

            try
            {
                this.readPlainFile(motdFile);
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
                else
                {
                    plainFileContent.Add("");
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

            if (!(ListenAddress == ServerAddressTextBox.Text || (ListenAddress == "" && ServerAddressTextBox.Text == "0.0.0.0")))
            {
                ConfigParser.setValue("ListenAddress", ServerAddressTextBox.Text);
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
            if (!(PubkeyAuthentication == LoginPossibleWithCertificateCheckBox.Checked.ToString() || (LoginPossibleWithCertificateCheckBox.Checked == true && PubkeyAuthentication == "yes")))
            {
                ConfigParser.setValue("PubkeyAuthentication", LoginPossibleWithCertificateCheckBox.Checked.ToString());
            }
            if (!(AuthorizedKeysFile == PathToCertificateTextBox.Text || (PathToCertificateTextBox.Text == "" && AuthorizedKeysFile == "")))
            {
                ConfigParser.setValue("AuthorizedKeysFile", PathToCertificateTextBox.Text);
            }
            if (!(PrintMotd == PrintMessageOfTheDayCheckBox.Checked.ToString() || (PrintMessageOfTheDayCheckBox.Checked == true && PrintMotd == "yes")))
            {
                ConfigParser.setValue("PrintMotd", PrintMessageOfTheDayCheckBox.Checked.ToString());
            }
            if (!(plainFileContent.ToString() == PrintMessageOfTheDayTextBox.Text || (plainFileContent.ToString() == "" && PrintMessageOfTheDayTextBox.Text == "")))
            {
                this.writePlainFile(motdFile, PrintMessageOfTheDayTextBox.Text);
            }
            if (!(PrintLastLog == PrintLastLoginCheckBox.Checked.ToString() || (PrintLastLoginCheckBox.Checked == true && PrintLastLog == "yes")))
            {
                ConfigParser.setValue("PrintLastLog", PrintLastLoginCheckBox.Checked.ToString());
            }
            if (!(TCPKeepAlive == TestIfClientIsStillReachableCheckBox.Checked.ToString() || (TestIfClientIsStillReachableCheckBox.Checked == true && TCPKeepAlive == "yes")))
            {
                ConfigParser.setValue("TCPKeepAlive", TestIfClientIsStillReachableCheckBox.Checked.ToString());
            }
            if (!(Compression == CompressionComboBox.Text || (CompressionComboBox.Text == "delayed" && Compression == "")))
            {
                ConfigParser.setValue("Compression", CompressionComboBox.Text);
            }
            if (!(ClientAliveInterval == TestConnectionOfClientEveryNumericUpDown.Value.ToString() || (TestConnectionOfClientEveryNumericUpDown.Value == 0 && ClientAliveInterval == "")))
            {
                ConfigParser.setValue("ClientAliveInterval", TestConnectionOfClientEveryNumericUpDown.Value.ToString());
            }
            if (!(ClientAliveCountMax == PassesNumericUpDown.Value.ToString() || (PassesNumericUpDown.Value == 3 && ClientAliveCountMax == "")))
            {
                ConfigParser.setValue("PrintLastLog", PrintLastLoginCheckBox.Checked.ToString());
            }
            if (!(MaxStartups == ConcurrentLoginsNumericUpDown.Value.ToString() || (ConcurrentLoginsNumericUpDown.Value == 10 && MaxStartups == "")))
            {
                ConfigParser.setValue("MaxStartups", ConcurrentLoginsNumericUpDown.Value.ToString());
            }

            ConfigParser.writeFile(installDir + @"\etc\sshd_config");
            this.changed = false;
            return true;
        }

        // Close Program and ask for saving unsaved changes
        private void CancelButton_Click(object sender, EventArgs e)
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
                if (this.SaveChanges())
                {
                    MessageBox.Show("Changes saved successfully", "EasySSHd", MessageBoxButtons.OK);
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

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            // folderBrowserDialog1_HelpRequest(sender,e);
        }

        private void EasySSHdWindow_TextChanged(object sender, EventArgs e)
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

        private void PrintMessageOfTheDayTextBox_TextChanged(object sender, EventArgs e)
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

        

        

        
    }
}
