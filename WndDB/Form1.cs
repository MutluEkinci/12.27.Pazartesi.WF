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
            SqlCommand cmd = new SqlCommand("select*from musteri", conn);

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
    }
}
