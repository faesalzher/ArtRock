﻿using MetroFramework.Forms;
using ModernUIProject.Class;
using ModernUIProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernUIProject
{
    public partial class MainForm : MetroForm
    {
        pnlLogin _login = null;

        public MainForm()
        {
            InitializeComponent();
            
            this.StyleManager = msmMain;
            this.Shown += MainForm_Shown;

            _login = new pnlLogin(this);
            _login.SettingClosed += _login_SettingClosed;
            _login.LogInSuccess += _login_LogInSuccess;
            _login.swipe();

            this.StyleManager.Theme = Settings.Default.Theme;
            this.StyleManager.Style = Settings.Default.Style;
        }

        void _login_LogInSuccess(object sender, EventArgs e)
        {
            _login.swipe(false);
        }

        void _login_SettingClosed(object sender, EventArgs e)
        {
            lnkSettings.Visible = true;
            lnlClose.Visible = true;
        }

        void MainForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.Focus();
        }

        private void lnkSettings_Click(object sender, EventArgs e)
        {
            lnkSettings.Visible = false;
            lnlClose.Visible = false;

            _login.ShowSettings();
        }

        private void lnlClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
