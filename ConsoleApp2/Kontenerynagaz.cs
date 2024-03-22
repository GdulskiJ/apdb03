namespace ConsoleApp2;

public class Kontenerynagaz : Kontener
{
    private int cisnienie;
    private static int counter=1;

    public Kontenerynagaz(int masaLadunku, int wysokosc, int wagaWlasna, int glebokosc, int maksymalnaLadownosc, int cisnienie) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        this.cisnienie = cisnienie;
        this.numerSeryjny = "KON-G-"+counter;
        counter++;
    }
    
    public override void OpróznijLadunek()
    {
        wagaWlasna = wagaWlasna - masaLadunku*0.95;
        masaLadunku = masaLadunku*0.05;
        Console.WriteLine("Kontener został opróżniony.");
            
    }
    
}