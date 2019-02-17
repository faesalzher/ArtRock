using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;
using System.IO;


namespace ArtRock
{
    public partial class FormUtama : MetroForm
    {
        MySqlDataReader myReader;
        public MySqlConnection connect;
        public FormUtama()      
        {
            InitializeComponent();
            string MyConnection2 = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";
               connect = new MySqlConnection(MyConnection2);
            string constring = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand sqlcom = new MySqlCommand("SELECT * FROM artrockdb.gitar", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = sqlcom;
                DataTable dta = new DataTable();
                metroGrid1.AllowUserToAddRows = false;
                sda.Fill(dta);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dta;
                metroGrid1.DataSource = bsource;
                sda.Update(dta);
                metroGrid1.DataSource = dta;
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)metroGrid1.Columns[15];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                sda.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void lihatdata()
        {
            string connectionInfo = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";
            connect = new MySqlConnection(connectionInfo);
            string constring = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand sqlcom = new MySqlCommand("SELECT * FROM artrockdb.gitar", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = sqlcom;
                DataTable dta = new DataTable();
                metroGrid1.AllowUserToAddRows = false;
                sda.Fill(dta);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dta;
                metroGrid1.DataSource = bsource;
                sda.Update(dta);
                metroGrid1.DataSource = dta;
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)metroGrid1.Columns[15];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                sda.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void btCekKoneksi_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                MessageBox.Show("connected");
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DaftarGitar_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&
                textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" &&
                textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" &&
                textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" &&
                textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "" /*&&
                textBox16.Text != ""*/)
            {
                try
                {

                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    string MyConnection2 = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";
                    string queri = "insert into artrockdb.gitar(Nama_Gitar,Serial,Body,Finger_Board,Binding_Head,Binding_Finger_Board,Binding_Body,Scale,Frets,Hardware,Truss_Rod,Tunners,Bridge,Pickups,Finish,Photo)VALUES(@Nama_Gitar,@Serial,@Body,@Finger_Board,@Binding_Head,@Binding_Finger_Board,@Binding_Body,@Scale,@Frets,@Hardware,@Truss_Rod,@Tunners,@Bridge,@Pickups,@Finish,@Photo)";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                                                           MyConn2.Open();
                    MySqlCommand MyCommand2 = new MySqlCommand(queri, MyConn2);
                    MyCommand2.Parameters.Add("@Nama_Gitar", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Serial", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Body", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Finger_Board", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Binding_Head", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Binding_Finger_Board", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Binding_Body", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Scale", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Frets", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Hardware", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Truss_Rod", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Tunners", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Bridge", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Pickups", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Finish", MySqlDbType.VarChar, 255);
                    MyCommand2.Parameters.Add("@Photo", MySqlDbType.Blob);
                    MyCommand2.Parameters["@Nama_Gitar"].Value = this.textBox1.Text;
                    MyCommand2.Parameters["@Serial"].Value = this.textBox2.Text;
                    MyCommand2.Parameters["@Body"].Value = this.textBox3.Text;
                    MyCommand2.Parameters["@Finger_Board"].Value = this.textBox4.Text;
                    MyCommand2.Parameters["@Binding_Head"].Value = this.textBox5.Text;
                    MyCommand2.Parameters["@Binding_Finger_Board"].Value = this.textBox6.Text;
                    MyCommand2.Parameters["@Binding_Body"].Value = this.textBox7.Text;
                    MyCommand2.Parameters["@Scale"].Value = this.textBox8.Text;
                    MyCommand2.Parameters["@Frets"].Value = this.textBox9.Text;
                    MyCommand2.Parameters["@Hardware"].Value = this.textBox10.Text;
                    MyCommand2.Parameters["@Truss_Rod"].Value = this.textBox11.Text;
                    MyCommand2.Parameters["@Tunners"].Value = this.textBox12.Text;
                    MyCommand2.Parameters["@Bridge"].Value = this.textBox13.Text;
                    MyCommand2.Parameters["@Pickups"].Value = this.textBox14.Text;
                    MyCommand2.Parameters["@Finish"].Value = this.textBox15.Text;
                    MyCommand2.Parameters["@Photo"].Value = img;
                    if (MyCommand2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Gitar Berhasil Ditambahkan");
                    }
                    MyConn2.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                    textBox16.Clear();

                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Semua kolom harus terisi");
            }
        }
        private void btCariGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose image(*.jpg;*.png;*.gif|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                textBox16.Text = opf.FileName;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        

        private void metroTabPage3_Click(object sender, EventArgs e)
        {
           
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus Data Gitar Ini?", "Hapus Gitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string MyConnection2 = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";
                    string Query = "delete from gitar where Serial='" + this.textBox18.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Gitar Dihapus");
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Gitara Tidak Dihapus", "Hapus Gitar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
        private void metroLink1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                MessageBox.Show("Berhasil Terkoneksi!");
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            lihatdata();

        }

        private void btCari_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string MyConnection3 = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";
                    string Query = "select* from gitar where Serial='" + this.tbCari.Text + "';";
                    MySqlConnection MyConn3 = new MySqlConnection(MyConnection3);
                    MySqlCommand MyCommand3 = new MySqlCommand(Query, MyConn3);
                    MySqlDataReader MyReader3;
                    MyConn3.Open();
                    MyReader3 = MyCommand3.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    if (MyReader3.Read())
                    {
                        FormUpdate fupdate = new FormUpdate();
                        fupdate.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Gitar tidak ditemukan!");
                    }
                    MyConn3.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void TambahGitar_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void TabArtrock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }

        private void lbTbBarang_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbNamaBarang_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void cariGambarDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}