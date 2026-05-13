namespace TablaSahSPRC
{
    public class Nebun : PiesaSah
    {
        public Nebun(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // TODO: Logica pentru mersul pe diagonala
            return true;
        }
    }
}