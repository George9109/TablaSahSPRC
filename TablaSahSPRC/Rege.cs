namespace TablaSahSPRC
{
    public class Rege : PiesaSah
    {
        public Rege(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // TODO: Logica pentru mutat o singura patratica in orice directie
            return true;
        }
    }
}