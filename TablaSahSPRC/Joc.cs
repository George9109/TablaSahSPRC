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
        public Joc()
        {
            InitializeComponent();
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
                // mergi la meniul principal
                Meniu meniu = new Meniu();
                meniu.Show();
                this.Close(); // închide fereastra jocului
            }
            else
            {
                // nu face nimic (Cancel)
            }
        }
    }
}
