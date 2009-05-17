using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using parser;

namespace EasySSHd
{
    public partial class EasySSHdWindow : Form
    {
        private bool changed = false; // global change indicator
        private parser.parser ConfigParser = new parser.parser(); // global config-parser instance

        // Constructor
        public EasySSHdWindow()
        {
            InitializeComponent();
        }

        // Called on Window Load, Initialize all Values
        private void EasySSHdWindow_Load(object sender, EventArgs e)
        {
            // TODO: Read config file and initialize the GUIs values
        }

        // Save all changes into sshd_config file
        private bool SaveChanges()
        {
            // TODO: get and save changes
            return false;
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
    }
}
