namespace TablaSahSPRC
{
    public class Regina : PiesaSah
    {
        public Regina(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // TODO: Logica pentru mersul combinat (Turn + Nebun)
            return true;
        }
    }
}