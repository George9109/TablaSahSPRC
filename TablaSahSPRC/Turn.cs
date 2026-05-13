using System;

namespace TablaSahSPRC
{
    public class Turn : PiesaSah
    {
        public Turn(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // Dacă se modifică și linia și coloana, nu e o mișcare în cruce (de turn)
            if (linieSursa != linieDest && colSursa != colDest)
                return false;

            // Aflăm direcția pasului (ex: dacă merge în jos, pasLinie e 1. Dacă stă pe loc pe linie, e 0)
            int pasLinie = Math.Sign(linieDest - linieSursa);
            int pasColoana = Math.Sign(colDest - colSursa);

            int l = linieSursa + pasLinie;
            int c = colSursa + pasColoana;

            // Verificăm fiecare pătrățel de pe traseu până la destinație
            while (l != linieDest || c != colDest)
            {
                if (tabla[l, c] != null)
                    return false; // Am lovit o piesă pe drum! Nu avem voie să sărim.

                l += pasLinie;
                c += pasColoana;
            }

            return true;
        }
    }
}