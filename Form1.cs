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
    }
}
