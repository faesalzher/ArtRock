using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace ArtRock
{
    public partial class login : MetroForm
    {
        public MySqlConnection connect;
        Thread th;
        public login()
        {
            InitializeComponent();
            string connectionInfo = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";
            connect = new MySqlConnection(connectionInfo);
        }
        private bool validate_login(string user, string pass)
        {
            connect.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from login where username=@user and password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            if (user == "" || pass == "")
            {
                MessageBox.Show("Kolom Tidak Boleh Kosong!");
                return;
            }
            bool r = validate_login(user, pass);
            if (r) {
                this.Close();
                th = new Thread(bukaformbaru);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                
            }
                
            else
                MessageBox.Show("Username atau Password Salah!");
        }

        private void bukaformbaru(object obj)
        {
            Application.Run(new FormUtama());
        }
    }
}
