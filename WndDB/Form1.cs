using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WndDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Hangi veritabanında çalışıcaksan onun providerını indirip kullanman gerek.
            //ADO.NET Providers
            //OleDB...
            //Sql...(Tercihen)
            //Oracle...

            //MS kodu amaç için kullanmayı tavsiye ediyor ama biri diğerinin yerine kullanılabilir bazı durumlarda.
            //cmd.ExecuteScalar();//Eğer sorgu sonucunda geriye bir tane değer dönecekse kullanılır.(Select'te kullanılır)
            //cmd.ExecuteNonQuery();//Eğer cümle insert,update ya da delete ise kullanılır.
            //cmd.ExecuteReader();//select cümlelerinde kullanılır.

            string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from musteri order by musıd", conn);

            SqlDataReader dr = cmd.ExecuteReader();

            string strSatir = "";
            while (dr.Read())//satır satır okur.
            {
                //listBox1.Items.Add(dr[0] + " " + dr[1] + " " + dr[2]);
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    strSatir += dr.GetValue(i) + " ";//sütun sütun okur.
                }
                listBox1.Items.Add(strSatir);
                strSatir = "";
            }
            //listBox1.Items.Add(dr["musID"]);

            conn.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //Kullanmayınız!!!!
            //string strSQL = "insert into musteri values(" + int.Parse(txtID.Text) + ",'" + txtAd.Text + "','" + txtSoyad.Text + "')";

            string strSQL = "insert into musteri values(@id,@ad,@soyad)";
            SqlCommand cmd = new SqlCommand(strSQL, conn);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            string strSQLID = "select*from musteri where Musıd=@musid";

            SqlCommand cmd = new SqlCommand(strSQLID, conn);

            cmd.Parameters.AddWithValue("@musid", int.Parse(txtID.Text));
            SqlDataReader dr = cmd.ExecuteReader();


            dr.Read();

            if (dr.HasRows)
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();

                panel1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Aradığınız kayıt bulunamadı.");
                txtAd.Clear();
                txtSoyad.Clear();
            }

            //string strSatir = "";
            //while (dr.Read())
            //{
            //    for (int i = 0; i < dr.FieldCount; i++)
            //    {
            //        strSatir += dr.GetValue(i) + " ";
            //    }
            //    listBox1.Items.Add(strSatir);
            //    strSatir = "";
            //}
            //conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            string strSQLUpdate = "";

            strSQLUpdate = "update musteri set musad=@ad,mussoyad=@soyad where musıd=@musid";
            SqlCommand cmd = new SqlCommand(strSQLUpdate, conn);

            cmd.Parameters.AddWithValue("@musid", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);


            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);

            DialogResult dr = MessageBox.Show("Kaydı silmek istiyor musunuz?", "UYARI", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                conn.Open();

                string strSQLDelete = "Delete from musteri where musıd=@id";

                SqlCommand cmd = new SqlCommand(strSQLDelete, conn);

                cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnBaglantısızSelect_Click(object sender, EventArgs e)
        {
            

            string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";

            //da.SelectCommand = new SqlCommand("Select*from musteri");
            //da.SelectCommand.Connection.ConnectionString=strConn;

            SqlDataAdapter da = new SqlDataAdapter("select*from musteri order by musıd",strConn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            DataRow satir = dt.NewRow();

            satir[0] = 155;
            satir[1] = "cevdettt";
            satir[2] = "korkmazzz";
            
            //dt.Rows.Add(satir);

            dt.Rows[1][1] = "....";

            SqlCommandBuilder scb = new SqlCommandBuilder(da);

            textBox1.Text = scb.GetUpdateCommand().CommandText;

            dataGridView1.DataSource = dt;
            // MessageBox.Show(dt.Rows.Count.ToString());

            string strSatir = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    strSatir += dt.Rows[i][j].ToString() + " ";
                }
                listBox1.Items.Add(strSatir + dt.Rows[i].RowState);

                strSatir = "";
            }
            da.Update(dt);
        }

        private void btnBğlGridDoldur_Click(object sender, EventArgs e)
        {
            string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from musteri order by musıd", conn);

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dataGridView1.ColumnCount = dr.FieldCount;
            object[] veriler = new object[dr.FieldCount];
           
            //COLUMN
            for (int i = 0; i < dr.FieldCount; i++)
            {
                dataGridView1.Columns[i].Name = dr.GetName(i);
            }
            
            //DATA
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    veriler[i] = dr[i];
                }
                
                dataGridView1.Rows.Add(veriler);
            
            }
            
            conn.Close();
        }
    }
}
