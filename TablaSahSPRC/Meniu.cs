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

        // Adăugăm o variabilă pentru conexiune la nivelul meniului
        private ConexiuneServer conexiune;

        private async void btnJoaca_Click(object sender, EventArgs e)
        {

            string cod = textBoxCod.Text.Trim();
            // --- 1. Preluăm și validăm numele ---
            // Presupun că textbox-ul tău se numește textBoxNume. Dacă are alt nume, schimbă-l aici!
            string numeUtilizator = textBoxUser.Text.Trim();

            if (string.IsNullOrEmpty(numeUtilizator))
            {
                // Generăm nume random dacă nu a scris nimic
                Random rnd = new Random();
                numeUtilizator = "Player_" + rnd.Next(1000, 9999);
            }

            // Verificăm dacă utilizatorul a introdus/generat un cod
            if (string.IsNullOrEmpty(cod))
            {
                MessageBox.Show("Te rog să introduci sau să generezi un cod pentru lobby!", "Atenție");
                return;
            }

            // 1. Inițializăm și pornim conexiunea
            conexiune = new ConexiuneServer();

            // Aici pui IP-ul și Portul serverului colegului tău. 
            // Dacă rulați amândoi pe același laptop acum, IP-ul este mereu "127.0.0.1" (Localhost).
            bool conectat = await conexiune.Conecteaza("10.66.2.179", 5000);
            if (!conectat)
            {
                MessageBox.Show("Nu m-am putut conecta la server. Asigură-te că serverul colegului este PORNIT!", "Eroare Conexiune");
                return;
            }

            // 2. Trimitem comanda în funcție de "Modul Curent" din interfața ta
            if (modCurent == 0)
                conexiune.TrimiteJoin(cod);
            else if (modCurent == 1)
                conexiune.TrimiteCreate(cod);
            else if (modCurent == 2)
                conexiune.TrimiteSpectate(cod);

            // 3. Predăm ștafeta: Deschidem jocul și îi oferim conexiunea gata făcută!
            Joc jocForm = new Joc(conexiune, modCurent, cod, numeUtilizator);

            this.Hide();
            jocForm.ShowDialog(); // Aici programul "pauzează" meniul cât timp te joci

            // Când închizi fereastra de joc (X sau "Ieși din joc"), te întorci aici
            this.Show();

            // Închidem frumos conexiunea cu serverul ca să nu lăsăm fantome
            conexiune.TrimiteClose();
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

        //  FUNCTIA PRINCIPALA
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

            for (int i = 0; i < 5; i++)
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