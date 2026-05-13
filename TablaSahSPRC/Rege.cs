using System;

namespace TablaSahSPRC
{
    public class Rege : PiesaSah
    {
        public Rege(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // Calculăm câte pătrățele s-a mutat pe orizontală și pe verticală
            // Math.Abs transformă numerele negative în pozitive (distanța absolută)
            int diferentaLinii = Math.Abs(linieDest - linieSursa);
            int diferentaColoane = Math.Abs(colDest - colSursa);

            // Regele are voie să se mute doar o casuță maxim (1 pe linie, 1 pe coloană sau 1 pe diagonală)
            if (diferentaLinii <= 1 && diferentaColoane <= 1)
            {
                return true; // E voie!
            }

            return false; // Nu e voie!
        }
    }
}