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
            // TODO: Vom scrie matematica specifica pionului (mers in fata, batut pe diagonala) la pasul urmator.
            // Deocamdata returnam "true" ca sa nu ne dea eroare Visual Studio.
            return true;
        }
    }
}