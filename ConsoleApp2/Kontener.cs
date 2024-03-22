using ConsoleApp2;

public class Kontener : IHazardNotifier
{
    public static List<Kontener> wszystkiekontenery = new List<Kontener>();
    protected double masaLadunku;
    private int wysokosc;
    protected double wagaWlasna;
    private int glebokosc;
    protected string numerSeryjny;
    protected int maksymalnaLadownosc;

    public Kontener(int masaLadunku, int wysokosc, int wagaWlasna, int glebokosc, int maksymalnaLadownosc)
    {
        this.masaLadunku = masaLadunku;
        this.wysokosc = wysokosc;
        this.wagaWlasna = wagaWlasna+masaLadunku;
        this.glebokosc = glebokosc;
        this.maksymalnaLadownosc = maksymalnaLadownosc;
        wszystkiekontenery.Add(this);
    }

    public override string ToString()
    {
        return $"Kontener {numerSeryjny}: \n" +
               $"Masa ładunku: {masaLadunku} kg\n" +
               $"Wysokość: {wysokosc} cm\n" +
               $"Waga własna: {wagaWlasna} kg\n" +
               $"Głębokość: {glebokosc} cm\n" +
               $"Numer seryjny: {numerSeryjny}\n" +
               $"Maksymalna ładowność: {maksymalnaLadownosc} kg";
    }

    public virtual void załaduj(int masa)
    {
        if (masa + masaLadunku > maksymalnaLadownosc)
        {
            throw new OverfillException("Masa ładunku przekracza pojemność kontenera.");
        }

        masaLadunku = masaLadunku + masa;
        wagaWlasna = wagaWlasna + masa;
        Console.WriteLine($"Kontener został załadowany masą ładunku: {masa} kg.");
    }

    public virtual void OpróznijLadunek()
    {
        wagaWlasna = (int)(wagaWlasna - masaLadunku);
        masaLadunku = 0;
        Console.WriteLine("Kontener został opróżniony.");
            
    }

    public string show()
    {
        return this.numerSeryjny;
    }


    public double MasaLadunku
    {
        get => masaLadunku;
        set => masaLadunku = value;
    }

    public int Wysokosc
    {
        get => wysokosc;
        set => wysokosc = value;
    }

    public double WagaWlasna
    {
        get => wagaWlasna;
        set => wagaWlasna = value;
    }

    public int Glebokosc
    {
        get => glebokosc;
        set => glebokosc = value;
    }

    public string NumerSeryjny
    {
        get => numerSeryjny;
        set => numerSeryjny = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int MaksymalnaLadownosc
    {
        get => maksymalnaLadownosc;
        set => maksymalnaLadownosc = value;
    }
    public static Kontener ZnajdzKontener(string numerSeryjny)
    {
        return wszystkiekontenery.Find(kontener => kontener.NumerSeryjny.Equals(numerSeryjny));
    }
}