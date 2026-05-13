using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablaSahSPRC
{
    public partial class Meniu : Form
    {
        // 0 = Introdu cod
        // 1 = Creare joc
        // 2 = Urmareste meci
        int modCurent = 0;
        public Meniu()
        {
            InitializeComponent();
        }

        private void btnJoaca_Click(object sender, EventArgs e)
        {
            Joc jocForm = new Joc();
            this.Hide();
            jocForm.ShowDialog();
            this.Show();
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            modCurent = 0;
            UpdateUI();
        }


        private void btnSchimbaActiune_Click(object sender, EventArgs e)
        {
            modCurent++;

            if (modCurent > 2)
                modCurent = 0;

            UpdateUI();
        }

        // 🔥 FUNCTIA PRINCIPALA
        void UpdateUI()
        {
            // Reset text
            labelIntroduCod.Text = "Introdu cod";
            labelCreareJoc.Text = "Creare joc";
            labelUrmaresteMeci.Text = "Urmareste meci";

            // Reset culori (optional)
            labelIntroduCod.ForeColor = Color.White;
            labelCreareJoc.ForeColor = Color.White;
            labelUrmaresteMeci.ForeColor = Color.White;

            if (modCurent == 0) // 0 = Introdu cod
            {
                labelIntroduCod.Text = "*" + labelIntroduCod.Text;
                labelIntroduCod.ForeColor = Color.Red;
               
                btnGenerareCod.Enabled = false;
                btnInchideLobby.Enabled = false;
                textBoxCod.Enabled = true;
            }
            else if (modCurent == 1) // 1 = Creare joc
            {
                labelCreareJoc.Text = "*" + labelCreareJoc.Text;
                labelCreareJoc.ForeColor = Color.Red;

                btnGenerareCod.Enabled = true;
                btnInchideLobby.Enabled = true;
                textBoxCod.Enabled = false;
            }
            else if (modCurent == 2)  // 2 = Urmareste meci
            {
                labelUrmaresteMeci.Text = "*" + labelUrmaresteMeci.Text;
                labelUrmaresteMeci.ForeColor = Color.Red;

                btnGenerareCod.Enabled = false;
                btnInchideLobby.Enabled = false;
                textBoxCod.Enabled =true;
            }
        }

        // (optional) buton generare cod
        private void btnGenerareCod_Click(object sender, EventArgs e)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();

            string cod = "";

            for (int i = 0; i < 10; i++)
            {
                cod += chars[rnd.Next(chars.Length)];
            }

            textBoxCod.Text = cod;

            // blochezi schimbarea actiunii
            btnSchimbaActiune.Enabled = false;
        }

        // (optional) buton inchidere lobby
        private void btnInchideLobby_Click(object sender, EventArgs e)
        {
            textBoxCod.Text = "";

            // deblochezi schimbarea actiunii
            btnSchimbaActiune.Enabled = true;
        }

        private void btnIesiDinJoc_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreareIntroduUrmareste_Click(object sender, EventArgs e)
        {

        }

        private void labelIntroduCod_Click(object sender, EventArgs e)
        {

        }
    }
}