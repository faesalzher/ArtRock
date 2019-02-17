using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MetroFramework.Forms;
using ModernUIProject.Properties;

namespace ModernUIProject.Class
{

    public partial class pnlLogin : pnlSlider
    {
        public event EventHandler SettingClosed;
        public event EventHandler LogInSuccess;
        Form _owner = null;

        public pnlLogin(Form owner)
            : base(owner)
        {
            InitializeComponent();
            _owner = owner;

            for (int i = 3; i < 13; i++)
            {
                MetroTile _tile = new MetroTile();
                _tile.Size = new Size(30, 30);
                _tile.Tag = i;
                _tile.Style = (MetroColorStyle)i;
                _tile.Click += _tile_Click;
                flpSettings.Controls.Add(_tile);
            }

            txtServer.Text = Settings.Default.Server;
            txtDB.Text = Settings.Default.Database;
            txtPortNo.Text = Settings.Default.Port;
            txtUser.Text = Settings.Default.Username;
            txtPass.Text = Settings.Default.Password;

            if (Settings.Default.Theme == MetroThemeStyle.Dark)
            {
                mrbDark.Checked = true;
            }
            else
            {
                mrbLight.Checked = true;
            }

            this.Shown += pnlLogin_Shown;

            metroToggle1.ForeColor = MetroColors.Green;
            metroToggle1.Text = "Open";
        }

        void pnlLogin_Shown(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        void _tile_Click(object sender, EventArgs e)
        {
            ((MetroForm)this.Parent).StyleManager.Style = (MetroColorStyle)((MetroTile)sender).Tag;
            SaveSettings();
        }

        public void ShowSettings()
        {
            pnlSettings.Visible = true;
            pnlCenter.Enabled = false;
        }

        private void lnkBack_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
            pnlCenter.Enabled = true;

            EventHandler handler = SettingClosed;
            if (handler != null) handler(this, e);
        }

        private void mrbDark_CheckedChanged(object sender, EventArgs e)
        {
            if (mrbDark.Checked )
            {
                ((MetroForm)this.Parent).StyleManager.Theme = MetroThemeStyle.Dark;
            }

            SaveSettings();
        }

        private void mrbLight_CheckedChanged(object sender, EventArgs e)
        {
            if (mrbLight.Checked)
            {
                ((MetroForm)this.Parent).StyleManager.Theme = MetroThemeStyle.Light;
            }

            SaveSettings();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (!TestCon(true)) return;

            string _sql = "select * from tbl_User where username = '" + txtUsername.Text + "' limit 1";
            DataTable _table = Functions.DataTable(_sql);
            if (_table.Rows.Count > 0)
            {
                if (_table.Rows[0].Field<string>("Password") != txtPassword.Text)
                {
                    txtPassword.Clear();
                    txtPassword.Focus();
                    MetroFramework.MetroMessageBox.Show(_owner, "Invalid password!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            } else
            {
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
                MetroFramework.MetroMessageBox.Show(_owner, "Username not found!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EventHandler handler = LogInSuccess;
            if (handler != null) handler(this, e);
        }

        void SaveSettings()
        {
            Settings.Default.Server = txtServer.Text;
            Settings.Default.Database = txtDB.Text;
            Settings.Default.Port = txtPortNo.Text;
            Settings.Default.Username = txtUser.Text;
            Settings.Default.Password = txtPass.Text;
            Settings.Default.Theme = ((MetroForm)this.Parent).StyleManager.Theme;
            Settings.Default.Style = ((MetroForm)this.Parent).StyleManager.Style;
            Settings.Default.Save();
        }

        private void pnlLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SaveSettings();
            TestCon();
        }

        private bool TestCon(bool nomessage = false)
        {
            bool _return = true;
            string _message = "Successfully established a connection!";
            MessageBoxIcon _icon = MessageBoxIcon.Information;
            SaveSettings();

            if (!Functions.TestConnection())
            {
                _message = "Failed to establish a connection using the specified connection values!";
                _icon = MessageBoxIcon.Error;
                _return = false;
            }

            if (!nomessage) MetroFramework.MetroMessageBox.Show(_owner, _message, Application.ProductName, MessageBoxButtons.OK, _icon);

            return _return;
        }
    }
}
