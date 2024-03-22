namespace ConsoleApp2;

public class Kontenerynapłyny:Kontener
{
    private Boolean czyniebezpieczne;
    private static int counter=1;
    public Kontenerynapłyny(int masaLadunku, int wysokosc, int wagaWlasna, int glebokosc, int maksymalnaLadownosc, bool czyniebezpieczne) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        this.czyniebezpieczne = czyniebezpieczne;
        this.numerSeryjny = "KON-L-"+counter;
        counter++;
    }
    
    
    public override void załaduj(int masa)
    {

        if (czyniebezpieczne.Equals(true))
        {
            if (masa + masaLadunku > maksymalnaLadownosc/2)
            {
                throw new OverfillException("Masa ładunku przekracza pojemność kontenera."+"{"+numerSeryjny+"}");
            }
        }
        else
        {
            if (masa + masaLadunku > maksymalnaLadownosc*0.9)
            {
                throw new OverfillException("Masa ładunku przekracza pojemność kontenera."+"{"+numerSeryjny+"}");
            }
        }
        

        masaLadunku = masaLadunku + masa;
        wagaWlasna = wagaWlasna + masa;
        Console.WriteLine($"Kontener został załadowany masą ładunku: {masa} kg.");
    }


}