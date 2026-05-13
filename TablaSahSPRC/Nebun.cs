using System;

namespace TablaSahSPRC
{
    public class Nebun : PiesaSah
    {
        public Nebun(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // Dacă distanța pe X nu e egală cu cea pe Y, nu este o diagonală perfectă
            if (Math.Abs(linieDest - linieSursa) != Math.Abs(colDest - colSursa))
                return false;

            int pasLinie = Math.Sign(linieDest - linieSursa);
            int pasColoana = Math.Sign(colDest - colSursa);

            int l = linieSursa + pasLinie;
            int c = colSursa + pasColoana;

            while (l != linieDest || c != colDest)
            {
                if (tabla[l, c] != null)
                    return false; // Ceva blochează diagonala

                l += pasLinie;
                c += pasColoana;
            }

            return true;
        }
    }
}