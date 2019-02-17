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
using System.IO;
namespace ArtRock
{
    public partial class FormUpdate : MetroForm
    {
        public MySqlConnection MyConn1;
        MySqlDataReader myReader;
        public FormUpdate()
        {
            InitializeComponent();
            string MyConnection2 = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";          
            MyConn1 = new MySqlConnection(MyConnection2); 
            try
            {                
                string query = "select*from gitar";
                MyConn1.Open();
                MySqlCommand myCommand = new MySqlCommand(query, MyConn1);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    textBox1.Text = myReader[0].ToString();
                    textBox2.Text = myReader[1].ToString();
                    textBox3.Text = myReader[2].ToString();
                    textBox4.Text = myReader[3].ToString();
                    textBox5.Text = myReader[4].ToString();
                    textBox6.Text = myReader[5].ToString();
                    textBox7.Text = myReader[6].ToString();
                    textBox8.Text = myReader[7].ToString();
                    textBox9.Text = myReader[8].ToString();
                    textBox10.Text = myReader[9].ToString();
                    textBox11.Text = myReader[10].ToString();
                    textBox12.Text = myReader[11].ToString();
                    textBox13.Text = myReader[12].ToString();
                    textBox14.Text = myReader[13].ToString();
                    textBox15.Text = myReader[14].ToString();
                    textBox16.Text = myReader[15].ToString();
                }
                myReader.Close();
                MyConn1.Close();              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btUpdate_Click(object sender, EventArgs e)
        {          
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                string MyConnection2 = "datasource=localhost; port=3306; username=root; password=new_password; database=artrockdb;SslMode=none";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                MyConn1.Open();



                string Query = "update gitar set Nama_Gitar='" + this.textBox1.Text + "',"
                + "Serial='" + this.textBox2.Text + "',"
                + "Body='" + this.textBox3.Text + "',"

                + "Finger_Board='" + this.textBox4.Text + "',"
                + "Binding_Head='" + this.textBox5.Text + "',"
                + "Binding_Finger_Board='" + this.textBox6.Text + "',"
                + "Binding_Body='" + this.textBox7.Text + "',"
                + "Scale='" + this.textBox8.Text + "',"
                + "Frets='" + this.textBox9.Text + "',"
                 + "Hardware='" + this.textBox10.Text + "',"
                + "Truss_Rod='" + this.textBox11.Text + "',"
                + "Tunners='" + this.textBox12.Text + "',"
                + "Bridge='" + this.textBox13.Text + "',"
                + "Pickups='" + this.textBox14.Text + "',"
                + "Finish='" + this.textBox15.Text + "',"
                + "
                + " where Serial='" + this.textBox2.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.  

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn1);                
                myReader = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                myReader.Close();
                MyConn1.Close();

                MyConn2.Open();
                string queri = "update artrockdb.gitar set Photo=@Photo where(Serial=@Serial)";
                MyCommand2 = new MySqlCommand(queri, MyConn2);
                //MyCommand2.Parameters.Add("@Nama_Gitar", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Serial", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Body", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Finger_Board", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Binding_Head", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Binding_Finger_Board", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Binding_Body", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Scale", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Frets", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Hardware", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Truss_Rod", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Tunners", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Bridge", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Pickups", MySqlDbType.VarChar, 255);
                //MyCommand2.Parameters.Add("@Finish", MySqlDbType.VarChar, 255);
                MyCommand2.Parameters.Add("@Photo", MySqlDbType.Blob);
                //MyCommand2.Parameters["@Nama_Gitar"].Value = this.textBox1.Text;
                //MyCommand2.Parameters["@Serial"].Value = this.textBox2.Text;
                //MyCommand2.Parameters["@Body"].Value = this.textBox3.Text;
                //MyCommand2.Parameters["@Finger_Board"].Value = this.textBox4.Text;
                //MyCommand2.Parameters["@Binding_Head"].Value = this.textBox5.Text;
                //MyCommand2.Parameters["@Binding_Finger_Board"].Value = this.textBox6.Text;
                //MyCommand2.Parameters["@Binding_Body"].Value = this.textBox7.Text;
                //MyCommand2.Parameters["@Scale"].Value = this.textBox8.Text;
                //MyCommand2.Parameters["@Frets"].Value = this.textBox9.Text;
                //MyCommand2.Parameters["@Hardware"].Value = this.textBox10.Text;
                //MyCommand2.Parameters["@Truss_Rod"].Value = this.textBox11.Text;
                //MyCommand2.Parameters["@Tunners"].Value = this.textBox12.Text;
                //MyCommand2.Parameters["@Bridge"].Value = this.textBox13.Text;
                //MyCommand2.Parameters["@Pickups"].Value = this.textBox14.Text;
                //MyCommand2.Parameters["@Finish"].Value = this.textBox15.Text;
                MyCommand2.Parameters["@Photo"].Value = img;
                if (MyCommand2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Gitar Berhasil Diupdate");
                }


                myReader.Close();
                MyConn1.Close();
                this.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}