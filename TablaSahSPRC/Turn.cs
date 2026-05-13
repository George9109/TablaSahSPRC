namespace TablaSahSPRC
{
    public class Turn : PiesaSah
    {
        public Turn(CuloarePiesa culoare) : base(culoare)
        {
        }

        public override bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla)
        {
            // TODO: Logica pentru mersul in linie dreapta (orizontal/vertical)
            return true;
        }
    }
}