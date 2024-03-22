namespace ConsoleApp2;

public class Kontenerchłodniczy : Kontener
{
    private string rodzajProduktu;
    private double temp=20.5;
    private static int counter=1;

    private string[] produkty = { "Bananas", "Chocolate", "Fish", "Meat", "Ice cream", "Frozen pizza", "Cheese", "Sausages", "Butter", "Eggs" };

    public Kontenerchłodniczy(int masaLadunku, int wysokosc, int wagaWlasna, int glebokosc, int maksymalnaLadownosc, string rodzajProduktu) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        this.rodzajProduktu = rodzajProduktu;
        this.numerSeryjny = "KON-C-"+counter;
        counter++;
    }
    public void załaduj(int masa, string produkt)
    {
        if (masa + masaLadunku > maksymalnaLadownosc)
        {
            throw new OverfillException("Masa ładunku przekracza pojemność kontenera.");
        }
        if (!produkty.Contains(produkt))
        {
            throw new OverfillException("Zły ładunek.");
        }

        masaLadunku = masaLadunku + masa;
        wagaWlasna = wagaWlasna + masa;
        Console.WriteLine($"Kontener został załadowany masą ładunku: {masa} kg.");
    }
}
