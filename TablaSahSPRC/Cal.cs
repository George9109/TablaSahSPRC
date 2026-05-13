using System;

namespace TablaSahSPRC
{
    public class Cal : PiesaSah
    {
        public Cal(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            int diferentaLinii = Math.Abs(linieDest - linieSursa);
            int diferentaColoane = Math.Abs(colDest - colSursa);

            // Forma de L înseamnă fie (2 linii și 1 coloană), fie (1 linie și 2 coloane)
            if ((diferentaLinii == 2 && diferentaColoane == 1) || (diferentaLinii == 1 && diferentaColoane == 2))
            {
                return true;
            }

            return false;
        }
    }
}