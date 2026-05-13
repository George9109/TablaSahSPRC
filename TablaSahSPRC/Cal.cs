namespace TablaSahSPRC
{
    public class Cal : PiesaSah
    {
        public Cal(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // TODO: Logica pentru forma de L
            return true;
        }
    }
}