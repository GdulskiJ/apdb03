


using ConsoleApp2;
//Stworzenie kontenera danego typu
//Załadowanie ładunku do danego kontenera
//Rozładowanie kontenera

Kontener a = new Kontenerynagaz(10, 10, 10,6,1000, 100);
Console.WriteLine(a.ToString());//Wypisanie informacji o danym kontenerze
try
{
a.załaduj(100);//Załadowanie ładunku do danego kontenera
Console.WriteLine(a.ToString());
}

catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}
a.OpróznijLadunek();//Rozładowanie kontenera
Console.WriteLine(a.ToString());




//załadowanie z wyjatkami
try
{
    a.załaduj(10000);
    Console.WriteLine(a.ToString());
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}


Kontener l = new Kontenerynapłyny(0, 10, 10,6,1000, true);
Kontener f = new Kontenerynapłyny(0, 10, 10,6,1000, false);
try
{
    l.załaduj(501);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}
try
{
    f.załaduj(901);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}
Console.WriteLine(l);

Kontenerchłodniczy g = new Kontenerchłodniczy(0, 10, 10,6,1000, "Bananas");
try
{
    g.załaduj(101, "Bananas");
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}


foreach (Kontener kontener in Kontener.wszystkiekontenery)
{
    Console.WriteLine(kontener.show());
}


//Załadowanie kontenera na statek
 Kontenerowiec k1 = new Kontenerowiec(10, 5, 10000);
 Console.WriteLine("wszystkie wolne kontenery");
 foreach (Kontener kontener in Kontener.wszystkiekontenery)
 {
     Console.WriteLine(kontener.show());
 }
 Console.WriteLine(k1.ToString());
 k1.załadujkontener(g);
 k1.załadujkontener(l);
 Console.WriteLine(k1.ToString());
 Console.WriteLine("wszystkie wolne kontenery");
 foreach (Kontener kontener in Kontener.wszystkiekontenery)
 {
     Console.WriteLine(kontener.show());
 }
//Załadowanie listy kontenerów na statek
 List<Kontener> listakontenerów = new List<Kontener>
 {
     new Kontenerchłodniczy(10, 10, 10, 10, 100, "Bananas"),
     new Kontenerynapłyny(0, 10, 10,6,1000, false)
 };
 Console.WriteLine(k1);
 k1.załadujkontener(listakontenerów);
 Console.WriteLine(k1);
//Usunięcie kontenera ze statku
 k1.odłaczkontener(g);
 Console.WriteLine(k1);
 //Zastąpienie kontenera na statku o danym numerze innymkontenerem
 Console.WriteLine("aaaaaaaaaaaaaaaaa");
 Console.WriteLine(k1.ToString());
 k1.zamienKontener("KON-L-3", "KON-L-2");
 Console.WriteLine("wszystkiek kontenery");
 foreach (Kontener kontener in Kontener.wszystkiekontenery)
 {
     Console.WriteLine(kontener.show());
 }
 Console.WriteLine(k1.ToString());

 //-----
 Kontener d = new Kontenerynapłyny(0, 10, 10,6,1000, true);
 Kontenerowiec k2 = new Kontenerowiec(10, 5, 10000);
 //Możliwość przeniesienie kontenera między dwoma statkami
 Console.WriteLine(k1.ToString());
 k1.załadujkontener(d);
 Console.WriteLine(k1.ToString());

 Kontenerowiec.zamienKontener(k1,k2,d);
 Console.WriteLine(k2.ToString());
 Console.WriteLine(d.ToString());

 //Wypisanie informacji o danym kontenerze
 Console.WriteLine(Kontener.ZnajdzKontener("KON-C-1").ToString());
 //Wypisanie informacji o danym statku i jego ładunku
 Console.WriteLine(k1.ToString());
