namespace EasySSHd
{
    partial class EasySSHdWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServerAdressLabel = new System.Windows.Forms.Label();
            this.ServerPortLabel = new System.Windows.Forms.Label();
            this.ServerConnectionGB = new System.Windows.Forms.GroupBox();
            this.ServerPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ServerAddressTextBox = new System.Windows.Forms.TextBox();
            this.LoginSecurityGB = new System.Windows.Forms.GroupBox();
            this.ConcurrentLoginsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ConcurrentLoginsLabel = new System.Windows.Forms.Label();
            this.MaxSessionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxAuthTriesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LoginTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxSessionsLabel = new System.Windows.Forms.Label();
            this.MaxAuthTriesLabel = new System.Windows.Forms.Label();
            this.LoginTimeLabel = new System.Windows.Forms.Label();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.SSLTabPage = new System.Windows.Forms.TabPage();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PathToCertificateTextBox = new System.Windows.Forms.TextBox();
            this.PathToCertificateLabel = new System.Windows.Forms.Label();
            this.LoginPossibleWithCertificateCheckBox = new System.Windows.Forms.CheckBox();
            this.CompressionTabPage = new System.Windows.Forms.TabPage();
            this.CompressionComboBox = new System.Windows.Forms.ComboBox();
            this.CheckingTabPage = new System.Windows.Forms.TabPage();
            this.OptionTwoGroupBox = new System.Windows.Forms.GroupBox();
            this.PassesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PassesLabel = new System.Windows.Forms.Label();
            this.TestConnectionOfClientEveryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TestConnectionOfClientEveryLabel = new System.Windows.Forms.Label();
            this.OptionOneGroupBox = new System.Windows.Forms.GroupBox();
            this.TestIfClientIsStillReachableCheckBox = new System.Windows.Forms.CheckBox();
            this.InfoTabPage = new System.Windows.Forms.TabPage();
            this.PrintMessageOfTheDayTextBox = new System.Windows.Forms.TextBox();
            this.PrintLastLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.PrintMessageOfTheDayCheckBox = new System.Windows.Forms.CheckBox();
            this.MessageBeforeLoginLabel = new System.Windows.Forms.Label();
            this.MessageBeforeLoginTextBox = new System.Windows.Forms.TextBox();
            this.LoggingBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.HelpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.DefaultsButton = new System.Windows.Forms.Button();
            this.openCertificate = new System.Windows.Forms.OpenFileDialog();
            this.ServerConnectionGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPortNumericUpDown)).BeginInit();
            this.LoginSecurityGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConcurrentLoginsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSessionsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxAuthTriesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTimeNumericUpDown)).BeginInit();
            this.TabControl.SuspendLayout();
            this.SSLTabPage.SuspendLayout();
            this.CompressionTabPage.SuspendLayout();
            this.CheckingTabPage.SuspendLayout();
            this.OptionTwoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PassesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestConnectionOfClientEveryNumericUpDown)).BeginInit();
            this.OptionOneGroupBox.SuspendLayout();
            this.InfoTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerAdressLabel
            // 
            this.ServerAdressLabel.AutoSize = true;
            this.ServerAdressLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerAdressLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ServerAdressLabel.Location = new System.Drawing.Point(6, 34);
            this.ServerAdressLabel.Name = "ServerAdressLabel";
            this.ServerAdressLabel.Size = new System.Drawing.Size(96, 16);
            this.ServerAdressLabel.TabIndex = 1;
            this.ServerAdressLabel.Text = "Server Address";
            // 
            // ServerPortLabel
            // 
            this.ServerPortLabel.AutoSize = true;
            this.ServerPortLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerPortLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ServerPortLabel.Location = new System.Drawing.Point(6, 78);
            this.ServerPortLabel.Name = "ServerPortLabel";
            this.ServerPortLabel.Size = new System.Drawing.Size(72, 16);
            this.ServerPortLabel.TabIndex = 2;
            this.ServerPortLabel.Text = "Server Port";
            // 
            // ServerConnectionGB
            // 
            this.ServerConnectionGB.Controls.Add(this.ServerPortNumericUpDown);
            this.ServerConnectionGB.Controls.Add(this.ServerAddressTextBox);
            this.ServerConnectionGB.Controls.Add(this.ServerAdressLabel);
            this.ServerConnectionGB.Controls.Add(this.ServerPortLabel);
            this.ServerConnectionGB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerConnectionGB.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ServerConnectionGB.Location = new System.Drawing.Point(26, 17);
            this.ServerConnectionGB.Name = "ServerConnectionGB";
            this.ServerConnectionGB.Size = new System.Drawing.Size(234, 186);
            this.ServerConnectionGB.TabIndex = 4;
            this.ServerConnectionGB.TabStop = false;
            this.ServerConnectionGB.Text = "Server Connection";
            // 
            // ServerPortNumericUpDown
            // 
            this.ServerPortNumericUpDown.Location = new System.Drawing.Point(108, 73);
            this.ServerPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ServerPortNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ServerPortNumericUpDown.Name = "ServerPortNumericUpDown";
            this.ServerPortNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.ServerPortNumericUpDown.TabIndex = 5;
            this.ServerPortNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.ServerPortNumericUpDown.ValueChanged += new System.EventHandler(this.ServerPortNumericUpDown_ValueChanged);
            // 
            // ServerAddressTextBox
            // 
            this.ServerAddressTextBox.Location = new System.Drawing.Point(108, 31);
            this.ServerAddressTextBox.Name = "ServerAddressTextBox";
            this.ServerAddressTextBox.Size = new System.Drawing.Size(100, 22);
            this.ServerAddressTextBox.TabIndex = 4;
            //this.ServerAddressTextBox.TextChanged += new System.EventHandler(this.EasySSHdWindow_TextChanged);
            this.ServerAddressTextBox.Leave += new System.EventHandler(this.ServerAddressTextBox_Leave);
            // 
            // LoginSecurityGB
            // 
            this.LoginSecurityGB.Controls.Add(this.ConcurrentLoginsNumericUpDown);
            this.LoginSecurityGB.Controls.Add(this.ConcurrentLoginsLabel);
            this.LoginSecurityGB.Controls.Add(this.MaxSessionsNumericUpDown);
            this.LoginSecurityGB.Controls.Add(this.MaxAuthTriesNumericUpDown);
            this.LoginSecurityGB.Controls.Add(this.LoginTimeNumericUpDown);
            this.LoginSecurityGB.Controls.Add(this.MaxSessionsLabel);
            this.LoginSecurityGB.Controls.Add(this.MaxAuthTriesLabel);
            this.LoginSecurityGB.Controls.Add(this.LoginTimeLabel);
            this.LoginSecurityGB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginSecurityGB.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LoginSecurityGB.Location = new System.Drawing.Point(310, 17);
            this.LoginSecurityGB.Name = "LoginSecurityGB";
            this.LoginSecurityGB.Size = new System.Drawing.Size(246, 186);
            this.LoginSecurityGB.TabIndex = 5;
            this.LoginSecurityGB.TabStop = false;
            this.LoginSecurityGB.Text = "Login Security";
            // 
            // ConcurrentLoginsNumericUpDown
            // 
            this.ConcurrentLoginsNumericUpDown.Location = new System.Drawing.Point(126, 111);
            this.ConcurrentLoginsNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ConcurrentLoginsNumericUpDown.Name = "ConcurrentLoginsNumericUpDown";
            this.ConcurrentLoginsNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.ConcurrentLoginsNumericUpDown.TabIndex = 9;
            this.ConcurrentLoginsNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ConcurrentLoginsNumericUpDown.ValueChanged += new System.EventHandler(this.ConcurrentLoginsNumericUpDown_ValueChanged);
            // 
            // ConcurrentLoginsLabel
            // 
            this.ConcurrentLoginsLabel.AutoSize = true;
            this.ConcurrentLoginsLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConcurrentLoginsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ConcurrentLoginsLabel.Location = new System.Drawing.Point(6, 113);
            this.ConcurrentLoginsLabel.Name = "ConcurrentLoginsLabel";
            this.ConcurrentLoginsLabel.Size = new System.Drawing.Size(113, 16);
            this.ConcurrentLoginsLabel.TabIndex = 8;
            this.ConcurrentLoginsLabel.Text = "Concurrent Logins";
            // 
            // MaxSessionsNumericUpDown
            // 
            this.MaxSessionsNumericUpDown.Location = new System.Drawing.Point(126, 148);
            this.MaxSessionsNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MaxSessionsNumericUpDown.Name = "MaxSessionsNumericUpDown";
            this.MaxSessionsNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.MaxSessionsNumericUpDown.TabIndex = 7;
            this.MaxSessionsNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxSessionsNumericUpDown.ValueChanged += new System.EventHandler(this.MaxSessionsNumericUpDown_ValueChanged);
            // 
            // MaxAuthTriesNumericUpDown
            // 
            this.MaxAuthTriesNumericUpDown.Location = new System.Drawing.Point(126, 72);
            this.MaxAuthTriesNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MaxAuthTriesNumericUpDown.Name = "MaxAuthTriesNumericUpDown";
            this.MaxAuthTriesNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.MaxAuthTriesNumericUpDown.TabIndex = 6;
            this.MaxAuthTriesNumericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.MaxAuthTriesNumericUpDown.ValueChanged += new System.EventHandler(this.MaxAuthTriesNumericUpDown_ValueChanged);
            // 
            // LoginTimeNumericUpDown
            // 
            this.LoginTimeNumericUpDown.Location = new System.Drawing.Point(126, 31);
            this.LoginTimeNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LoginTimeNumericUpDown.Name = "LoginTimeNumericUpDown";
            this.LoginTimeNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.LoginTimeNumericUpDown.TabIndex = 5;
            this.LoginTimeNumericUpDown.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.LoginTimeNumericUpDown.ValueChanged += new System.EventHandler(this.LoginTimeNumericUpDown_ValueChanged);
            // 
            // MaxSessionsLabel
            // 
            this.MaxSessionsLabel.AutoSize = true;
            this.MaxSessionsLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxSessionsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaxSessionsLabel.Location = new System.Drawing.Point(6, 150);
            this.MaxSessionsLabel.Name = "MaxSessionsLabel";
            this.MaxSessionsLabel.Size = new System.Drawing.Size(91, 16);
            this.MaxSessionsLabel.TabIndex = 4;
            this.MaxSessionsLabel.Text = "Max Sessions";
            // 
            // MaxAuthTriesLabel
            // 
            this.MaxAuthTriesLabel.AutoSize = true;
            this.MaxAuthTriesLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAuthTriesLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaxAuthTriesLabel.Location = new System.Drawing.Point(6, 75);
            this.MaxAuthTriesLabel.Name = "MaxAuthTriesLabel";
            this.MaxAuthTriesLabel.Size = new System.Drawing.Size(100, 16);
            this.MaxAuthTriesLabel.TabIndex = 2;
            this.MaxAuthTriesLabel.Text = "Max Auth. Tries";
            // 
            // LoginTimeLabel
            // 
            this.LoginTimeLabel.AutoSize = true;
            this.LoginTimeLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoginTimeLabel.Location = new System.Drawing.Point(6, 34);
            this.LoginTimeLabel.Name = "LoginTimeLabel";
            this.LoginTimeLabel.Size = new System.Drawing.Size(108, 16);
            this.LoginTimeLabel.TabIndex = 0;
            this.LoginTimeLabel.Text = "Login Time (sec.)";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.SSLTabPage);
            this.TabControl.Controls.Add(this.CompressionTabPage);
            this.TabControl.Controls.Add(this.CheckingTabPage);
            this.TabControl.Controls.Add(this.InfoTabPage);
            this.TabControl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(26, 209);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(530, 168);
            this.TabControl.TabIndex = 6;
            // 
            // SSLTabPage
            // 
            this.SSLTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.SSLTabPage.Controls.Add(this.BrowseButton);
            this.SSLTabPage.Controls.Add(this.PathToCertificateTextBox);
            this.SSLTabPage.Controls.Add(this.PathToCertificateLabel);
            this.SSLTabPage.Controls.Add(this.LoginPossibleWithCertificateCheckBox);
            this.SSLTabPage.Location = new System.Drawing.Point(4, 25);
            this.SSLTabPage.Name = "SSLTabPage";
            this.SSLTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SSLTabPage.Size = new System.Drawing.Size(522, 139);
            this.SSLTabPage.TabIndex = 0;
            this.SSLTabPage.Text = "SSL";
            this.SSLTabPage.ToolTipText = "options regarding SSL";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(436, 78);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(63, 23);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PathToCertificateTextBox
            // 
            this.PathToCertificateTextBox.Location = new System.Drawing.Point(21, 78);
            this.PathToCertificateTextBox.Name = "PathToCertificateTextBox";
            this.PathToCertificateTextBox.Size = new System.Drawing.Size(409, 22);
            this.PathToCertificateTextBox.TabIndex = 3;
            this.PathToCertificateTextBox.TextChanged += new System.EventHandler(this.PathToCertificateTextBox_TextChanged);
            // 
            // PathToCertificateLabel
            // 
            this.PathToCertificateLabel.AutoSize = true;
            this.PathToCertificateLabel.Location = new System.Drawing.Point(18, 58);
            this.PathToCertificateLabel.Name = "PathToCertificateLabel";
            this.PathToCertificateLabel.Size = new System.Drawing.Size(206, 16);
            this.PathToCertificateLabel.TabIndex = 2;
            this.PathToCertificateLabel.Text = "Path to Certificate (view of cygwin)";
            // 
            // LoginPossibleWithCertificateCheckBox
            // 
            this.LoginPossibleWithCertificateCheckBox.AutoSize = true;
            this.LoginPossibleWithCertificateCheckBox.Checked = true;
            this.LoginPossibleWithCertificateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LoginPossibleWithCertificateCheckBox.Location = new System.Drawing.Point(21, 22);
            this.LoginPossibleWithCertificateCheckBox.Name = "LoginPossibleWithCertificateCheckBox";
            this.LoginPossibleWithCertificateCheckBox.Size = new System.Drawing.Size(199, 20);
            this.LoginPossibleWithCertificateCheckBox.TabIndex = 1;
            this.LoginPossibleWithCertificateCheckBox.Text = "Login possible with Certificate";
            this.LoginPossibleWithCertificateCheckBox.UseVisualStyleBackColor = true;
            this.LoginPossibleWithCertificateCheckBox.CheckedChanged += new System.EventHandler(this.LoginPossibleWithCertificateCheckBox_CheckedChanged);
            // 
            // CompressionTabPage
            // 
            this.CompressionTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.CompressionTabPage.Controls.Add(this.CompressionComboBox);
            this.CompressionTabPage.Location = new System.Drawing.Point(4, 25);
            this.CompressionTabPage.Name = "CompressionTabPage";
            this.CompressionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CompressionTabPage.Size = new System.Drawing.Size(522, 139);
            this.CompressionTabPage.TabIndex = 1;
            this.CompressionTabPage.Text = "Compression";
            this.CompressionTabPage.ToolTipText = "activate or deactivate compression";
            // 
            // CompressionComboBox
            // 
            this.CompressionComboBox.FormattingEnabled = true;
            this.CompressionComboBox.Items.AddRange(new object[] {
            "on",
            "off",
            "delayed"});
            this.CompressionComboBox.Location = new System.Drawing.Point(31, 25);
            this.CompressionComboBox.Name = "CompressionComboBox";
            this.CompressionComboBox.Size = new System.Drawing.Size(76, 24);
            this.CompressionComboBox.TabIndex = 0;
            this.CompressionComboBox.Text = "yes";
            this.CompressionComboBox.SelectedIndexChanged += new System.EventHandler(this.CompressionComboBox_SelectedIndexChanged);
            // 
            // CheckingTabPage
            // 
            this.CheckingTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.CheckingTabPage.Controls.Add(this.OptionTwoGroupBox);
            this.CheckingTabPage.Controls.Add(this.OptionOneGroupBox);
            this.CheckingTabPage.Location = new System.Drawing.Point(4, 25);
            this.CheckingTabPage.Name = "CheckingTabPage";
            this.CheckingTabPage.Size = new System.Drawing.Size(522, 139);
            this.CheckingTabPage.TabIndex = 2;
            this.CheckingTabPage.Text = "Checking";
            this.CheckingTabPage.ToolTipText = "connection testing and controling";
            // 
            // OptionTwoGroupBox
            // 
            this.OptionTwoGroupBox.Controls.Add(this.PassesNumericUpDown);
            this.OptionTwoGroupBox.Controls.Add(this.PassesLabel);
            this.OptionTwoGroupBox.Controls.Add(this.TestConnectionOfClientEveryNumericUpDown);
            this.OptionTwoGroupBox.Controls.Add(this.TestConnectionOfClientEveryLabel);
            this.OptionTwoGroupBox.Location = new System.Drawing.Point(17, 60);
            this.OptionTwoGroupBox.Name = "OptionTwoGroupBox";
            this.OptionTwoGroupBox.Size = new System.Drawing.Size(482, 68);
            this.OptionTwoGroupBox.TabIndex = 6;
            this.OptionTwoGroupBox.TabStop = false;
            this.OptionTwoGroupBox.Text = "Option 2";
            // 
            // PassesNumericUpDown
            // 
            this.PassesNumericUpDown.Location = new System.Drawing.Point(272, 39);
            this.PassesNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PassesNumericUpDown.Name = "PassesNumericUpDown";
            this.PassesNumericUpDown.Size = new System.Drawing.Size(204, 22);
            this.PassesNumericUpDown.TabIndex = 4;
            this.PassesNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PassesNumericUpDown.ValueChanged += new System.EventHandler(this.PassesNumericUpDown_ValueChanged);
            // 
            // PassesLabel
            // 
            this.PassesLabel.AutoSize = true;
            this.PassesLabel.Location = new System.Drawing.Point(269, 18);
            this.PassesLabel.Name = "PassesLabel";
            this.PassesLabel.Size = new System.Drawing.Size(52, 16);
            this.PassesLabel.TabIndex = 3;
            this.PassesLabel.Text = "Passes";
            // 
            // TestConnectionOfClientEveryNumericUpDown
            // 
            this.TestConnectionOfClientEveryNumericUpDown.Location = new System.Drawing.Point(14, 39);
            this.TestConnectionOfClientEveryNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TestConnectionOfClientEveryNumericUpDown.Name = "TestConnectionOfClientEveryNumericUpDown";
            this.TestConnectionOfClientEveryNumericUpDown.Size = new System.Drawing.Size(219, 22);
            this.TestConnectionOfClientEveryNumericUpDown.TabIndex = 1;
            this.TestConnectionOfClientEveryNumericUpDown.ValueChanged += new System.EventHandler(this.TestConnectionOfClientEveryNumericUpDown_ValueChanged);
            // 
            // TestConnectionOfClientEveryLabel
            // 
            this.TestConnectionOfClientEveryLabel.AutoSize = true;
            this.TestConnectionOfClientEveryLabel.Location = new System.Drawing.Point(11, 18);
            this.TestConnectionOfClientEveryLabel.Name = "TestConnectionOfClientEveryLabel";
            this.TestConnectionOfClientEveryLabel.Size = new System.Drawing.Size(222, 16);
            this.TestConnectionOfClientEveryLabel.TabIndex = 2;
            this.TestConnectionOfClientEveryLabel.Text = "Test connection of Client every (sec.)";
            // 
            // OptionOneGroupBox
            // 
            this.OptionOneGroupBox.Controls.Add(this.TestIfClientIsStillReachableCheckBox);
            this.OptionOneGroupBox.Location = new System.Drawing.Point(17, 3);
            this.OptionOneGroupBox.Name = "OptionOneGroupBox";
            this.OptionOneGroupBox.Size = new System.Drawing.Size(482, 51);
            this.OptionOneGroupBox.TabIndex = 5;
            this.OptionOneGroupBox.TabStop = false;
            this.OptionOneGroupBox.Text = "Option 1";
            // 
            // TestIfClientIsStillReachableCheckBox
            // 
            this.TestIfClientIsStillReachableCheckBox.AutoSize = true;
            this.TestIfClientIsStillReachableCheckBox.Checked = true;
            this.TestIfClientIsStillReachableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TestIfClientIsStillReachableCheckBox.Location = new System.Drawing.Point(14, 21);
            this.TestIfClientIsStillReachableCheckBox.Name = "TestIfClientIsStillReachableCheckBox";
            this.TestIfClientIsStillReachableCheckBox.Size = new System.Drawing.Size(195, 20);
            this.TestIfClientIsStillReachableCheckBox.TabIndex = 0;
            this.TestIfClientIsStillReachableCheckBox.Text = "Test if client is still reachable";
            this.TestIfClientIsStillReachableCheckBox.UseVisualStyleBackColor = true;
            this.TestIfClientIsStillReachableCheckBox.CheckedChanged += new System.EventHandler(this.TestIfClientIsStillReachableCheckBox_CheckedChanged);
            // 
            // InfoTabPage
            // 
            this.InfoTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.InfoTabPage.Controls.Add(this.PrintMessageOfTheDayTextBox);
            this.InfoTabPage.Controls.Add(this.PrintLastLoginCheckBox);
            this.InfoTabPage.Controls.Add(this.PrintMessageOfTheDayCheckBox);
            this.InfoTabPage.Controls.Add(this.MessageBeforeLoginLabel);
            this.InfoTabPage.Controls.Add(this.MessageBeforeLoginTextBox);
            this.InfoTabPage.Location = new System.Drawing.Point(4, 25);
            this.InfoTabPage.Name = "InfoTabPage";
            this.InfoTabPage.Size = new System.Drawing.Size(522, 139);
            this.InfoTabPage.TabIndex = 3;
            this.InfoTabPage.Text = "Info";
            this.InfoTabPage.ToolTipText = "information printed before or after login";
            // 
            // PrintMessageOfTheDayTextBox
            // 
            this.PrintMessageOfTheDayTextBox.Location = new System.Drawing.Point(289, 43);
            this.PrintMessageOfTheDayTextBox.Multiline = true;
            this.PrintMessageOfTheDayTextBox.Name = "PrintMessageOfTheDayTextBox";
            this.PrintMessageOfTheDayTextBox.Size = new System.Drawing.Size(210, 50);
            this.PrintMessageOfTheDayTextBox.TabIndex = 4;
            this.PrintMessageOfTheDayTextBox.TextChanged += new System.EventHandler(this.PrintMessageOfTheDayTextBox_TextChanged);
            // 
            // PrintLastLoginCheckBox
            // 
            this.PrintLastLoginCheckBox.AutoSize = true;
            this.PrintLastLoginCheckBox.Checked = true;
            this.PrintLastLoginCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PrintLastLoginCheckBox.Location = new System.Drawing.Point(289, 99);
            this.PrintLastLoginCheckBox.Name = "PrintLastLoginCheckBox";
            this.PrintLastLoginCheckBox.Size = new System.Drawing.Size(110, 20);
            this.PrintLastLoginCheckBox.TabIndex = 3;
            this.PrintLastLoginCheckBox.Text = "Print last login";
            this.PrintLastLoginCheckBox.UseVisualStyleBackColor = true;
            this.PrintLastLoginCheckBox.CheckedChanged += new System.EventHandler(this.PrintLastLoginCheckBox_CheckedChanged);
            // 
            // PrintMessageOfTheDayCheckBox
            // 
            this.PrintMessageOfTheDayCheckBox.AutoSize = true;
            this.PrintMessageOfTheDayCheckBox.Checked = true;
            this.PrintMessageOfTheDayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PrintMessageOfTheDayCheckBox.Location = new System.Drawing.Point(289, 20);
            this.PrintMessageOfTheDayCheckBox.Name = "PrintMessageOfTheDayCheckBox";
            this.PrintMessageOfTheDayCheckBox.Size = new System.Drawing.Size(213, 20);
            this.PrintMessageOfTheDayCheckBox.TabIndex = 2;
            this.PrintMessageOfTheDayCheckBox.Text = "Print Message of the day (Motd)";
            this.PrintMessageOfTheDayCheckBox.UseVisualStyleBackColor = true;
            this.PrintMessageOfTheDayCheckBox.CheckedChanged += new System.EventHandler(this.PrintMessageOfTheDayCheckBox_CheckedChanged);
            // 
            // MessageBeforeLoginLabel
            // 
            this.MessageBeforeLoginLabel.AutoSize = true;
            this.MessageBeforeLoginLabel.Location = new System.Drawing.Point(21, 24);
            this.MessageBeforeLoginLabel.Name = "MessageBeforeLoginLabel";
            this.MessageBeforeLoginLabel.Size = new System.Drawing.Size(131, 16);
            this.MessageBeforeLoginLabel.TabIndex = 1;
            this.MessageBeforeLoginLabel.Text = "Message before login";
            // 
            // MessageBeforeLoginTextBox
            // 
            this.MessageBeforeLoginTextBox.Location = new System.Drawing.Point(24, 43);
            this.MessageBeforeLoginTextBox.Multiline = true;
            this.MessageBeforeLoginTextBox.Name = "MessageBeforeLoginTextBox";
            this.MessageBeforeLoginTextBox.Size = new System.Drawing.Size(206, 50);
            this.MessageBeforeLoginTextBox.TabIndex = 0;
            this.MessageBeforeLoginTextBox.TextChanged += new System.EventHandler(this.MessageBeforeLoginTextBox_TextChanged);
            // 
            // LoggingBox
            // 
            this.LoggingBox.BackColor = System.Drawing.SystemColors.Control;
            this.LoggingBox.Location = new System.Drawing.Point(26, 383);
            this.LoggingBox.Multiline = true;
            this.LoggingBox.Name = "LoggingBox";
            this.LoggingBox.ReadOnly = true;
            this.LoggingBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LoggingBox.Size = new System.Drawing.Size(530, 39);
            this.LoggingBox.TabIndex = 7;
            this.LoggingBox.Text = "EasySSHd Logging:";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(400, 428);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 9;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitButton.Location = new System.Drawing.Point(481, 428);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 10;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(26, 429);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 11;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(107, 429);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 12;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // HelpLinkLabel
            // 
            this.HelpLinkLabel.AutoSize = true;
            this.HelpLinkLabel.Location = new System.Drawing.Point(2, 0);
            this.HelpLinkLabel.Name = "HelpLinkLabel";
            this.HelpLinkLabel.Size = new System.Drawing.Size(29, 13);
            this.HelpLinkLabel.TabIndex = 13;
            this.HelpLinkLabel.TabStop = true;
            this.HelpLinkLabel.Text = "Help";
            // 
            // DefaultsButton
            // 
            this.DefaultsButton.Location = new System.Drawing.Point(319, 428);
            this.DefaultsButton.Name = "DefaultsButton";
            this.DefaultsButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultsButton.TabIndex = 14;
            this.DefaultsButton.Text = "Defaults";
            this.DefaultsButton.UseVisualStyleBackColor = true;
            this.DefaultsButton.Click += new System.EventHandler(this.DefaultsButton_Click);
            // 
            // openCertificate
            // 
            this.openCertificate.AddExtension = false;
            // 
            // EasySSHdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.quitButton;
            this.ClientSize = new System.Drawing.Size(584, 464);
            this.Controls.Add(this.DefaultsButton);
            this.Controls.Add(this.HelpLinkLabel);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.LoggingBox);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.LoginSecurityGB);
            this.Controls.Add(this.ServerConnectionGB);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "EasySSHdWindow";
            this.Text = "EasySSHd";
            this.Load += new System.EventHandler(this.EasySSHdWindow_Load);
            this.ServerConnectionGB.ResumeLayout(false);
            this.ServerConnectionGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPortNumericUpDown)).EndInit();
            this.LoginSecurityGB.ResumeLayout(false);
            this.LoginSecurityGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConcurrentLoginsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSessionsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxAuthTriesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTimeNumericUpDown)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.SSLTabPage.ResumeLayout(false);
            this.SSLTabPage.PerformLayout();
            this.CompressionTabPage.ResumeLayout(false);
            this.CheckingTabPage.ResumeLayout(false);
            this.OptionTwoGroupBox.ResumeLayout(false);
            this.OptionTwoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PassesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestConnectionOfClientEveryNumericUpDown)).EndInit();
            this.OptionOneGroupBox.ResumeLayout(false);
            this.OptionOneGroupBox.PerformLayout();
            this.InfoTabPage.ResumeLayout(false);
            this.InfoTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerAdressLabel;
        private System.Windows.Forms.Label ServerPortLabel;
        private System.Windows.Forms.GroupBox ServerConnectionGB;
        private System.Windows.Forms.GroupBox LoginSecurityGB;
        private System.Windows.Forms.Label LoginTimeLabel;
        private System.Windows.Forms.Label MaxAuthTriesLabel;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage SSLTabPage;
        private System.Windows.Forms.TabPage CompressionTabPage;
        private System.Windows.Forms.TextBox LoggingBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label MaxSessionsLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox ServerAddressTextBox;
        private System.Windows.Forms.CheckBox LoginPossibleWithCertificateCheckBox;
        private System.Windows.Forms.LinkLabel HelpLinkLabel;
        private System.Windows.Forms.NumericUpDown ServerPortNumericUpDown;
        private System.Windows.Forms.NumericUpDown MaxSessionsNumericUpDown;
        private System.Windows.Forms.NumericUpDown MaxAuthTriesNumericUpDown;
        private System.Windows.Forms.NumericUpDown LoginTimeNumericUpDown;
        private System.Windows.Forms.Label PathToCertificateLabel;
        private System.Windows.Forms.NumericUpDown ConcurrentLoginsNumericUpDown;
        private System.Windows.Forms.Label ConcurrentLoginsLabel;
        private System.Windows.Forms.TabPage CheckingTabPage;
        private System.Windows.Forms.CheckBox TestIfClientIsStillReachableCheckBox;
        private System.Windows.Forms.TabPage InfoTabPage;
        private System.Windows.Forms.Label TestConnectionOfClientEveryLabel;
        private System.Windows.Forms.NumericUpDown TestConnectionOfClientEveryNumericUpDown;
        private System.Windows.Forms.Label PassesLabel;
        private System.Windows.Forms.NumericUpDown PassesNumericUpDown;
        private System.Windows.Forms.Label MessageBeforeLoginLabel;
        private System.Windows.Forms.TextBox MessageBeforeLoginTextBox;
        private System.Windows.Forms.CheckBox PrintLastLoginCheckBox;
        private System.Windows.Forms.CheckBox PrintMessageOfTheDayCheckBox;
        private System.Windows.Forms.Button DefaultsButton;
        private System.Windows.Forms.TextBox PrintMessageOfTheDayTextBox;
        private System.Windows.Forms.TextBox PathToCertificateTextBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.ComboBox CompressionComboBox;
        private System.Windows.Forms.GroupBox OptionTwoGroupBox;
        private System.Windows.Forms.GroupBox OptionOneGroupBox;
        private System.Windows.Forms.OpenFileDialog openCertificate;
    }
}

