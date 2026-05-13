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

        private int dimensiunePatrat = 80; // Mărimea unui pătrățel pe ecran

        public Joc()
        {
            InitializeComponent();

            // 1. Desenăm tabla de șah (pătrățelele goale)
            DeseneazaTabla();

            // 2. Populăm tabla cu piesele de start
            AseazaPieseleInitiale();
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
                    patratSelectat = patratClickat;
                    coordonateSursa = coordonate;

                    // Colorăm fundalul cu galben ca să știm că e selectată
                    patratSelectat.BackColor = Color.Yellow;
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

                // REGULA 2: Întrebăm piesa dacă mișcarea respectă matematica ei (ex: Calul merge în L)
                if (piesaCareSeMuta.EsteMiscareValida(coordonateSursa.X, coordonateSursa.Y, x, y, tablaLogica))
                {
                    // 1. Mutăm logic
                    tablaLogica[x, y] = piesaCareSeMuta;
                    tablaLogica[coordonateSursa.X, coordonateSursa.Y] = null;

                    // 2. Mutăm vizual
                    patratClickat.Image = patratSelectat.Image;
                    patratSelectat.Image = null;

                    // Deselectăm piesa după ce s-a mutat cu succes
                    ResetareCuloareSelectie();
                }
                else
                {
                    // Mutarea este ilegală (ex: ai vrut să muți un Turn pe diagonală). 
                    // Doar deselectăm piesa.
                    ResetareCuloareSelectie();
                }
            }
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

        private void Joc_Load(object sender, EventArgs e)
        {
            // Păstrat pentru eventuale inițializări la încărcarea form-ului
        }
    }
}