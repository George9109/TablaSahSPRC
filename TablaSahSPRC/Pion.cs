using System;

namespace TablaSahSPRC
{
    public class Pion : PiesaSah
    {
        // Constructorul care trimite culoarea mai departe la clasa de baza (PiesaSah)
        public Pion(CuloarePiesa culoare) : base(culoare)
        {
        }

        // Aici suprascriem metoda abstracta. 
        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // Stabilim direcția: Alb merge în sus (-1), Negru merge în jos (+1)
            int directie = (this.Culoare == CuloarePiesa.Alb) ? -1 : 1;

            // Rândul de unde pornesc pionii (6 pentru alb, 1 pentru negru)
            int linieStart = (this.Culoare == CuloarePiesa.Alb) ? 6 : 1;

            // CAZUL 1: Mers în față 1 pătrățel (nu mănâncă)
            if (colSursa == colDest && linieDest == linieSursa + directie)
            {
                if (tabla[linieDest, colDest] == null) // Trebuie să fie gol
                    return true;
            }

            // CAZUL 2: Mers în față 2 pătrățele (doar la prima mutare)
            else if (colSursa == colDest && linieSursa == linieStart && linieDest == linieSursa + (2 * directie))
            {
                // Trebuie să fie gol și pătrățelul din față, și cel de destinație
                if (tabla[linieSursa + directie, colSursa] == null && tabla[linieDest, colDest] == null)
                    return true;
            }

            // CAZUL 3: Capturare pe diagonală (1 pătrățel la stânga sau la dreapta)
            else if (Math.Abs(colDest - colSursa) == 1 && linieDest == linieSursa + directie)
            {
                if (tabla[linieDest, colDest] != null) // Trebuie să existe o piesă de mâncat
                    return true;
            }

            return false;
        }
    }
}