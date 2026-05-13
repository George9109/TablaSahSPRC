using System;

namespace TablaSahSPRC
{
    public class Regina : PiesaSah
    {
        public Regina(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            bool miscareDeTurn = (linieSursa == linieDest || colSursa == colDest);
            bool miscareDeNebun = (Math.Abs(linieDest - linieSursa) == Math.Abs(colDest - colSursa));

            if (!miscareDeTurn && !miscareDeNebun)
                return false; // Nu respectă nici regula de Turn, nici pe cea de Nebun

            int pasLinie = Math.Sign(linieDest - linieSursa);
            int pasColoana = Math.Sign(colDest - colSursa);

            int l = linieSursa + pasLinie;
            int c = colSursa + pasColoana;

            while (l != linieDest || c != colDest)
            {
                if (tabla[l, c] != null)
                    return false; // Drum blocat

                l += pasLinie;
                c += pasColoana;
            }

            return true;
        }
    }
}