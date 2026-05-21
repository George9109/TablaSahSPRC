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
    public partial class Joc : Form
    {
        // Matricea pentru elementele vizuale (PictureBox-uri)
        private PictureBox[,] patrateleVizuale = new PictureBox[8, 8];

        // Matricea pentru logica jocului (obiectele piese)
        private PiesaSah[,] tablaLogica = new PiesaSah[8, 8];

        // Adaugă astea sub declarațiile matricelor
        private PictureBox patratSelectat = null; // Ține minte pătrățelul pe care am dat click prima dată
        private Point coordonateSursa; // Ține minte rândul și coloana piesei selectate

        // Adaugă asta sub private Point coordonateSursa;
        private CuloarePiesa randulCurent = CuloarePiesa.Alb; // Albul începe mereu jocul

        private int dimensiunePatrat = 80; // Mărimea unui pătrățel pe ecran

        // NOU: Salvează conexiunea și modul primite de la meniu
        private ConexiuneServer serverNostru;
        private int modJocCurent;

        private string lobbyCode;
        private CuloarePiesa culoareaMea;

        public Joc(ConexiuneServer conexiune, int modCurent, string cod)
        {
            InitializeComponent();

            this.serverNostru = conexiune;
            this.modJocCurent = modCurent;
            this.lobbyCode = cod; // Salvăm codul

            // Stabilim culoarea în funcție de cine ești
            if (modCurent == 1) // 1 = Creare Joc -> Tu ești Albul
                culoareaMea = CuloarePiesa.Alb;
            else if (modCurent == 0) // 0 = Join -> Tu ești Negrul
                culoareaMea = CuloarePiesa.Negru;
            else
                culoareaMea = (CuloarePiesa)999; // Spectator (nu are voie să mute nimic)

            DeseneazaTabla();
            AseazaPieseleInitiale();

            serverNostru.OnTablaUpdate += PrimesteUpdateDeLaAdversar;
        }

        // Funcția care se activează automat când serverul trimite noul vector de la adversar
        private void PrimesteUpdateDeLaAdversar(string vectorPrimit)
        {
            // Deoarece mesajele de rețea vin pe alt fir de execuție, 
            // folosim Invoke pentru a actualiza interfața grafică în siguranță
            this.Invoke((MethodInvoker)delegate {
                ActualizeazaTablaDinString(vectorPrimit);
                // === NOU: TRIMITEM TABLA CĂTRE ADVERSAR ===
                string stareNoua = ConversieTablaInString();
                serverNostru.TrimiteUpdate(lobbyCode, stareNoua);

                // SCHIMBĂM RÂNDUL
                if (randulCurent == CuloarePiesa.Alb)
                    // Schimbăm rândul după ce adversarul a mutat
                    if (randulCurent == CuloarePiesa.Alb)
                    randulCurent = CuloarePiesa.Negru;
                else
                    randulCurent = CuloarePiesa.Alb;
            });
        }

        private void DeseneazaTabla()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PictureBox patrat = new PictureBox();
                    patrat.Size = new Size(dimensiunePatrat, dimensiunePatrat);

                    // Poziționare conform setărilor tale (400 la stânga, 40 sus)
                    patrat.Location = new Point(j * dimensiunePatrat + 400, i * dimensiunePatrat + 40);

                    // Alternăm culorile
                    if ((i + j) % 2 == 0)
                    {
                        patrat.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        patrat.BackColor = Color.Black;
                    }

                    patrat.SizeMode = PictureBoxSizeMode.CenterImage;
                    patrateleVizuale[i, j] = patrat;
                    // NOU: Salvăm coordonatele în proprietatea Tag ca să le știm când dăm click
                    patrat.Tag = new Point(i, j);

                    // NOU: Îi spunem pătrățelului ce funcție să apeleze când facem click pe el
                    patrat.Click += Patrat_Click;
                    this.Controls.Add(patrat);
                }
            }
        }

        private void AseazaPieseleInitiale()
        {
            // --- PIESE NEGRE (Sus - Liniile 0 și 1) ---

            // Pioni negri
            for (int j = 0; j < 8; j++)
            {
                tablaLogica[1, j] = new Pion(CuloarePiesa.Negru);
                patrateleVizuale[1, j].Image = Properties.Resources.Pion;
            }

            // Restul pieselor negre
            tablaLogica[0, 0] = new Turn(CuloarePiesa.Negru); patrateleVizuale[0, 0].Image = Properties.Resources.Turn;
            tablaLogica[0, 7] = new Turn(CuloarePiesa.Negru); patrateleVizuale[0, 7].Image = Properties.Resources.Turn;

            tablaLogica[0, 1] = new Cal(CuloarePiesa.Negru); patrateleVizuale[0, 1].Image = Properties.Resources.cal;
            tablaLogica[0, 6] = new Cal(CuloarePiesa.Negru); patrateleVizuale[0, 6].Image = Properties.Resources.cal;

            tablaLogica[0, 2] = new Nebun(CuloarePiesa.Negru); patrateleVizuale[0, 2].Image = Properties.Resources.nebun;
            tablaLogica[0, 5] = new Nebun(CuloarePiesa.Negru); patrateleVizuale[0, 5].Image = Properties.Resources.nebun;

            tablaLogica[0, 3] = new Regina(CuloarePiesa.Negru); patrateleVizuale[0, 3].Image = Properties.Resources.Regina;
            tablaLogica[0, 4] = new Rege(CuloarePiesa.Negru); patrateleVizuale[0, 4].Image = Properties.Resources.Rege;

            // --- PIESE ALBE (Jos - Liniile 6 și 7) ---

            // Pioni albi
            for (int j = 0; j < 8; j++)
            {
                tablaLogica[6, j] = new Pion(CuloarePiesa.Alb);
                patrateleVizuale[6, j].Image = Properties.Resources.PionAlb;
            }

            // Restul pieselor albe
            tablaLogica[7, 0] = new Turn(CuloarePiesa.Alb); patrateleVizuale[7, 0].Image = Properties.Resources.TurnAlb;
            tablaLogica[7, 7] = new Turn(CuloarePiesa.Alb); patrateleVizuale[7, 7].Image = Properties.Resources.TurnAlb;

            tablaLogica[7, 1] = new Cal(CuloarePiesa.Alb); patrateleVizuale[7, 1].Image = Properties.Resources.CalAlb;
            tablaLogica[7, 6] = new Cal(CuloarePiesa.Alb); patrateleVizuale[7, 6].Image = Properties.Resources.CalAlb;

            tablaLogica[7, 2] = new Nebun(CuloarePiesa.Alb); patrateleVizuale[7, 2].Image = Properties.Resources.NebunAlb;
            tablaLogica[7, 5] = new Nebun(CuloarePiesa.Alb); patrateleVizuale[7, 5].Image = Properties.Resources.NebunAlb;

            tablaLogica[7, 3] = new Regina(CuloarePiesa.Alb); patrateleVizuale[7, 3].Image = Properties.Resources.ReginaAlba;
            tablaLogica[7, 4] = new Rege(CuloarePiesa.Alb); patrateleVizuale[7, 4].Image = Properties.Resources.RegeAlb;
        }

        private void Patrat_Click(object sender, EventArgs e)
        {
            // Aflăm pe ce pătrățel s-a dat click
            PictureBox patratClickat = sender as PictureBox;
            Point coordonate = (Point)patratClickat.Tag;
            int x = coordonate.X; // Linia
            int y = coordonate.Y; // Coloana

            // CAZUL 1: Nu avem nicio piesă selectată încă -> Vrem să selectăm una
            if (patratSelectat == null)
            {
                // Verificăm dacă există o piesă logică pe pătrățelul pe care am dat click
                if (tablaLogica[x, y] != null)
                {
                    // Verificăm dacă piesa selectată este de culoarea celui care trebuie să mute acum
                    // NOU: Acum verificăm și dacă piesa are culoarea ta, nu doar dacă e rândul acelei culori
                    if (tablaLogica[x, y].Culoare == randulCurent && tablaLogica[x, y].Culoare == culoareaMea)
                    {
                        patratSelectat = patratClickat;
                        coordonateSursa = coordonate;

                        // Colorăm fundalul cu galben ca să știm că e selectată
                        patratSelectat.BackColor = Color.Yellow;
                    }
                }
            }
            // CAZUL 2: Avem deja o piesă selectată -> Vrem să o mutăm unde am dat click acum
            else
            {
                PiesaSah piesaCareSeMuta = tablaLogica[coordonateSursa.X, coordonateSursa.Y];
                PiesaSah piesaDestinatie = tablaLogica[x, y];

                // REGULA UNIVERSALĂ 1: Nu poți să te muți pe un pătrățel unde ai deja o piesă de-a ta!
                if (piesaDestinatie != null && piesaDestinatie.Culoare == piesaCareSeMuta.Culoare)
                {
                    // Deselectăm piesa (refacem culoarea) și oprim mutarea
                    ResetareCuloareSelectie();
                    return;
                }

                // REGULA 2: Întrebăm piesa dacă mișcarea respectă matematica ei
                if (piesaCareSeMuta.EsteMiscareValida(coordonateSursa.X, coordonateSursa.Y, x, y, tablaLogica))
                {
                    // === SIMULARE PENTRU ȘAH ===
                    PiesaSah piesaSalvareDestinatie = tablaLogica[x, y]; // Salvăm ce era pe destinație 

                    // Mutăm logic (temporar)
                    tablaLogica[x, y] = piesaCareSeMuta;
                    tablaLogica[coordonateSursa.X, coordonateSursa.Y] = null;

                    // Verificăm dacă după această mutare, Regele NOSTRU este în șah (ceea ce e ilegal)
                    if (EsteRegeleInSah(randulCurent, tablaLogica))
                    {
                        // MUTARE ILEGALĂ! Dăm UNDO (punem piesele la loc cum erau)
                        tablaLogica[coordonateSursa.X, coordonateSursa.Y] = piesaCareSeMuta;
                        tablaLogica[x, y] = piesaSalvareDestinatie;

                        ResetareCuloareSelectie();
                        MessageBox.Show("Mutare ilegală! Nu îți poți lăsa Regele în Șah.", "Atenție");
                        return; // Oprim funcția aici, mutarea vizuală nu se mai întâmplă
                    }

                    // === DACĂ MUTAREA E VALIDĂ ȘI SIGURĂ, O EXECUTĂM VIZUAL ===

                    // 2. Mutăm vizual
                    patratClickat.Image = patratSelectat.Image;
                    patratSelectat.Image = null;

                    ResetareCuloareSelectie();

                    // Verificăm dacă pionul a ajuns la capăt (Promovare)
                    if (piesaCareSeMuta is Pion)
                    {
                        if ((piesaCareSeMuta.Culoare == CuloarePiesa.Alb && x == 0) ||
                            (piesaCareSeMuta.Culoare == CuloarePiesa.Negru && x == 7))
                        {
                            PromoveazaPion(x, y, piesaCareSeMuta.Culoare);
                        }
                    }

                    // SCHIMBĂM RÂNDUL
                    if (randulCurent == CuloarePiesa.Alb)
                        randulCurent = CuloarePiesa.Negru;
                    else
                        randulCurent = CuloarePiesa.Alb;

                    // === VERIFICĂM STAREA ADVERSARULUI (Șah, Șah Mat sau Pat) ===
                    bool esteInSah = EsteRegeleInSah(randulCurent, tablaLogica);
                    bool areMutari = AreMutariValide(randulCurent, tablaLogica);

                    // Dacă jucătorul care urmează NU mai are nicio mutare la dispoziție
                    if (!areMutari)
                    {
                        if (esteInSah)
                        {
                            // Nu are mutări + E în Șah = ȘAH MAT
                            MessageBox.Show("ȘAH MAT! Meciul s-a terminat.", "Victorie!");

                            // Un truc simplu ca să blocăm tabla (nimeni nu mai poate face click)
                            // Setăm un rând fals.
                            randulCurent = (CuloarePiesa)999;
                        }
                        else
                        {
                            // Nu are mutări + NU e în Șah = REMIZĂ (Pat)
                            MessageBox.Show("REMIZĂ (Situație de PAT)! Adversarul nu este în Șah, dar nu mai are mutări legale.", "Egalitate");
                            randulCurent = (CuloarePiesa)999;
                        }
                    }
                    else if (esteInSah)
                    {
                        // Are mutări + E în Șah = Doar ȘAH
                        MessageBox.Show("ȘAH!", "Atenție");
                    }
                }
            }
        }

        private void PromoveazaPion(int x, int y, CuloarePiesa culoare)
        {
            // Creăm o fereastră mică de dialog "din mers"
            Form formularPromovare = new Form();
            formularPromovare.Text = "Promovare Pion";
            formularPromovare.Size = new Size(350, 120);
            formularPromovare.StartPosition = FormStartPosition.CenterParent;
            formularPromovare.FormBorderStyle = FormBorderStyle.FixedDialog;
            formularPromovare.MaximizeBox = false;
            formularPromovare.MinimizeBox = false;
            formularPromovare.ControlBox = false; // Îi scoatem "X"-ul ca să fie obligat să aleagă

            // Creăm butoanele
            Button btnRegina = new Button() { Text = "Regina", Location = new Point(10, 20), Size = new Size(70, 30) };
            Button btnTurn = new Button() { Text = "Turn", Location = new Point(90, 20), Size = new Size(70, 30) };
            Button btnCal = new Button() { Text = "Cal", Location = new Point(170, 20), Size = new Size(70, 30) };
            Button btnNebun = new Button() { Text = "Nebun", Location = new Point(250, 20), Size = new Size(70, 30) };

            string piesaAleasa = "Regina"; // Default

            // Ce se întâmplă când dă click pe un buton
            btnRegina.Click += (s, e) => { piesaAleasa = "Regina"; formularPromovare.Close(); };
            btnTurn.Click += (s, e) => { piesaAleasa = "Turn"; formularPromovare.Close(); };
            btnCal.Click += (s, e) => { piesaAleasa = "Cal"; formularPromovare.Close(); };
            btnNebun.Click += (s, e) => { piesaAleasa = "Nebun"; formularPromovare.Close(); };

            formularPromovare.Controls.Add(btnRegina);
            formularPromovare.Controls.Add(btnTurn);
            formularPromovare.Controls.Add(btnCal);
            formularPromovare.Controls.Add(btnNebun);

            // Afișăm fereastra și așteptăm ca utilizatorul să aleagă
            formularPromovare.ShowDialog();

            // 1. Înlocuim piesa în memoria logică a jocului
            if (piesaAleasa == "Regina") tablaLogica[x, y] = new Regina(culoare);
            else if (piesaAleasa == "Turn") tablaLogica[x, y] = new Turn(culoare);
            else if (piesaAleasa == "Cal") tablaLogica[x, y] = new Cal(culoare);
            else if (piesaAleasa == "Nebun") tablaLogica[x, y] = new Nebun(culoare);

            // 2. Schimbăm imaginea de pe tablă folosind resursele tale
            if (culoare == CuloarePiesa.Alb)
            {
                if (piesaAleasa == "Regina") patrateleVizuale[x, y].Image = Properties.Resources.ReginaAlba;
                else if (piesaAleasa == "Turn") patrateleVizuale[x, y].Image = Properties.Resources.TurnAlb;
                else if (piesaAleasa == "Cal") patrateleVizuale[x, y].Image = Properties.Resources.CalAlb;
                else if (piesaAleasa == "Nebun") patrateleVizuale[x, y].Image = Properties.Resources.NebunAlb;
            }
            else
            {
                if (piesaAleasa == "Regina") patrateleVizuale[x, y].Image = Properties.Resources.Regina;
                else if (piesaAleasa == "Turn") patrateleVizuale[x, y].Image = Properties.Resources.Turn;
                else if (piesaAleasa == "Cal") patrateleVizuale[x, y].Image = Properties.Resources.cal;
                else if (piesaAleasa == "Nebun") patrateleVizuale[x, y].Image = Properties.Resources.nebun;
            }
        }

        private bool EsteRegeleInSah(CuloarePiesa culoareRege, PiesaSah[,] tablaCurenta)
        {
            int regeX = -1, regeY = -1;

            // 1. Căutăm unde se află Regele nostru pe tablă
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablaCurenta[i, j] is Rege && tablaCurenta[i, j].Culoare == culoareRege)
                    {
                        regeX = i;
                        regeY = j;
                        break;
                    }
                }
            }

            // 2. Verificăm dacă vreo piesă a adversarului poate muta peste Rege
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PiesaSah piesa = tablaCurenta[i, j];
                    
                    // Dacă e o piesă și e a adversarului
                    if (piesa != null && piesa.Culoare != culoareRege)
                    {
                        // Întrebăm piesa adversă dacă poate ataca căsuța Regelui
                        if (piesa.EsteMiscareValida(i, j, regeX, regeY, tablaCurenta))
                        {
                            return true; // Este Șah!
                        }
                    }
                }
            }

            return false; // Regele este în siguranță
        }

        private bool AreMutariValide(CuloarePiesa culoare, PiesaSah[,] tablaCurenta)
        {
            // Parcurgem toată tabla ca să găsim piesele noastre
            for (int iSursa = 0; iSursa < 8; iSursa++)
            {
                for (int jSursa = 0; jSursa < 8; jSursa++)
                {
                    PiesaSah piesa = tablaCurenta[iSursa, jSursa];

                    // Dacă am găsit o piesă a jucătorului curent
                    if (piesa != null && piesa.Culoare == culoare)
                    {
                        // Încercăm să o mutăm pe TOATE cele 64 de pătrățele de pe tablă
                        for (int iDest = 0; iDest < 8; iDest++)
                        {
                            for (int jDest = 0; jDest < 8; jDest++)
                            {
                                // 1. Evităm să mutăm peste propriile piese
                                PiesaSah piesaDestinatie = tablaCurenta[iDest, jDest];
                                if (piesaDestinatie != null && piesaDestinatie.Culoare == culoare)
                                    continue;

                                // 2. Întrebăm piesa dacă mutarea este legală matematic (ex: Calul în L)
                                if (piesa.EsteMiscareValida(iSursa, jSursa, iDest, jDest, tablaCurenta))
                                {
                                    // 3. Simulăm mutarea în memorie
                                    tablaCurenta[iDest, jDest] = piesa;
                                    tablaCurenta[iSursa, jSursa] = null;

                                    // 4. Vedem dacă această mutare ne-a scos Regele din Șah
                                    bool neSalveaza = !EsteRegeleInSah(culoare, tablaCurenta);

                                    // 5. Dăm UNDO la simulare (foarte important ca să nu stricăm tabla reală)
                                    tablaCurenta[iSursa, jSursa] = piesa;
                                    tablaCurenta[iDest, jDest] = piesaDestinatie;

                                    // Dacă am găsit MĂCAR O mutare bună, înseamnă că NU e Șah Mat!
                                    if (neSalveaza)
                                    {
                                        return true; // Jucătorul are cum să se miște
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Dacă am încercat absolut toate piesele și absolut toate destinațiile și nu ne-a salvat nimic:
            return false; // Jucătorul nu mai are nicio mutare validă
        }

        private void ResetareCuloareSelectie()
        {
            if (patratSelectat != null)
            {
                if ((coordonateSursa.X + coordonateSursa.Y) % 2 == 0)
                    patratSelectat.BackColor = Color.WhiteSmoke;
                else
                    patratSelectat.BackColor = Color.Black;

                patratSelectat = null;
            }
        }

        private void btnPararesteJoc_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show(
                "Ești sigur că vrei să ieși?\nDacă ieși vei pierde meciul!",
                "Confirmare",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (rezultat == DialogResult.Yes)
            {
                Meniu meniu = new Meniu();
                meniu.Show();
                this.Close();
            }
        }

        //======Noua=====
        private string ConversieTablaInString()
        {
            List<string> valori = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PiesaSah piesa = tablaLogica[i, j];
                    if (piesa == null)
                    {
                        valori.Add("0");
                    }
                    else
                    {
                        int cod = 0;
                        if (piesa is Pion) cod = 1;
                        else if (piesa is Cal) cod = 2;
                        else if (piesa is Nebun) cod = 3;
                        else if (piesa is Turn) cod = 4;
                        else if (piesa is Regina) cod = 5;
                        else if (piesa is Rege) cod = 6;

                        // Dacă e piesă neagră, codul devine negativ
                        if (piesa.Culoare == CuloarePiesa.Negru)
                        {
                            cod = -cod;
                        }

                        valori.Add(cod.ToString());
                    }
                }
            }

            // Unește toate numerele cu virgulă între ele
            return string.Join(",", valori);
        }

        public void ActualizeazaTablaDinString(string stareTabla)
        {
            string[] valori = stareTabla.Split(',');
            int index = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int codPiesa = int.Parse(valori[index]);
                    index++;

                    // Curățăm pătrățelul curent
                    tablaLogica[i, j] = null;
                    patrateleVizuale[i, j].Image = null;

                    if (codPiesa != 0)
                    {
                        CuloarePiesa culoare = (codPiesa > 0) ? CuloarePiesa.Alb : CuloarePiesa.Negru;
                        int tipPiesa = Math.Abs(codPiesa);

                        // Recreăm piesa logică
                        if (tipPiesa == 1) tablaLogica[i, j] = new Pion(culoare);
                        else if (tipPiesa == 2) tablaLogica[i, j] = new Cal(culoare);
                        else if (tipPiesa == 3) tablaLogica[i, j] = new Nebun(culoare);
                        else if (tipPiesa == 4) tablaLogica[i, j] = new Turn(culoare);
                        else if (tipPiesa == 5) tablaLogica[i, j] = new Regina(culoare);
                        else if (tipPiesa == 6) tablaLogica[i, j] = new Rege(culoare);

                        // Punem imaginea potrivită
                        if (culoare == CuloarePiesa.Alb)
                        {
                            if (tipPiesa == 1) patrateleVizuale[i, j].Image = Properties.Resources.PionAlb;
                            else if (tipPiesa == 2) patrateleVizuale[i, j].Image = Properties.Resources.CalAlb;
                            else if (tipPiesa == 3) patrateleVizuale[i, j].Image = Properties.Resources.NebunAlb;
                            else if (tipPiesa == 4) patrateleVizuale[i, j].Image = Properties.Resources.TurnAlb;
                            else if (tipPiesa == 5) patrateleVizuale[i, j].Image = Properties.Resources.ReginaAlba;
                            else if (tipPiesa == 6) patrateleVizuale[i, j].Image = Properties.Resources.RegeAlb;
                        }
                        else
                        {
                            if (tipPiesa == 1) patrateleVizuale[i, j].Image = Properties.Resources.Pion;
                            else if (tipPiesa == 2) patrateleVizuale[i, j].Image = Properties.Resources.cal;
                            else if (tipPiesa == 3) patrateleVizuale[i, j].Image = Properties.Resources.nebun;
                            else if (tipPiesa == 4) patrateleVizuale[i, j].Image = Properties.Resources.Turn;
                            else if (tipPiesa == 5) patrateleVizuale[i, j].Image = Properties.Resources.Regina;
                            else if (tipPiesa == 6) patrateleVizuale[i, j].Image = Properties.Resources.Rege;
                        }
                    }
                }
            }
        }

        private void Joc_Load(object sender, EventArgs e)
        {
            // Păstrat pentru eventuale inițializări la încărcarea form-ului
        }
    }
}