using System.Drawing; // Avem nevoie de asta pentru a folosi clasa Image

namespace TablaSahSPRC
{
    public abstract class PiesaSah
    {
        public CuloarePiesa Culoare { get; set; }
        public Image Imagine { get; set; }

        // Constructorul: cand cream o piesa, trebuie sa ii spunem ce culoare are
        public PiesaSah(CuloarePiesa culoare)
        {
            Culoare = culoare;
        }

        // Aceasta este metoda pe care fiecare piesa o va calcula in felul ei
        // Primeste coordonatele de unde pleaca (sursa), unde vrea sa ajunga (destinatia) si tabla actuala
        public abstract bool EsteMiscareValida(int linieSursa, int colSursa, int linieDest, int colDest, PiesaSah[,] tabla);
    }
}