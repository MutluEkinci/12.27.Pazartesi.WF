using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._27.Pazartesi.WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Exception Handling(İstisnaların Yakalanması):Programı çok yavaşlatır her yerde kullanma.
            //1-Try
            //2-Catch
            //3-Finally
            //4-Throw => Exception oluşturmak için kullanılır.


            int a = 10, b = 0, c = 0;
            int[] sayilar = { 1, 2, 43 };
            try
            {
                sayilar[10] = 12;
                c = a / b;
                StreamReader sr = new StreamReader("aaa.data");
                sr.Close();
            }
            catch (DivideByZeroException ex)
            {
                this.Text = "Hata:" + ex.Message;
            }
            catch (IndexOutOfRangeException ex)
            {
                button1.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Var" + ex.Message);
            }

            MessageBox.Show(c.ToString());
        }

        private void btntryfinally_Click(object sender, EventArgs e)
        {
            //finally her durumda çalışır.istisna olsada olmasada .
            int a = 10, b = 5, c = 0;

            try
            {
                a = b / 2;
            }
            finally
            {
                MessageBox.Show("her durumda çalışır....");
            }

            MessageBox.Show(a.ToString());
        }

        private void btnThrow_Click(object sender, EventArgs e)
        {
            //throw new Exception();
            //throw new NotImplementedException();

            throw new BesOlamaz();

        }
    }
}
