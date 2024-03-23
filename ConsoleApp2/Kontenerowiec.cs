namespace ConsoleApp2;

public class Kontenerowiec
{
 public List<Kontener> kontenerywkontenerowcu = new List<Kontener>();
 public static List<Kontenerowiec> kontenerowiece = new List<Kontenerowiec>();
 public int predkosc;
 public int maxkonteneow;
 public int ilosckontenerów=0;
 public double waga=0;
 public double maxwaga;

 public Kontenerowiec(int predkosc, int maxkonteneow, int maxwaga)
 {
  this.predkosc = predkosc;
  this.maxkonteneow = maxkonteneow;
  this.maxwaga = maxwaga;
  kontenerowiece.Add(this);
 }

 public void załadujkontener(Kontener kontener)
 {

 
  if (waga + kontener.WagaWlasna > maxwaga)
  {
   throw new OverfillException("Masa ładunku przekracza pojemność kontenerowca.");
  }
  if (ilosckontenerów+1 > maxkonteneow)
  {
   throw new OverfillException("za dóżo kontenerów.");
  }
  
  kontenerywkontenerowcu.Add(kontener);
  Kontener.wszystkiekontenery.Remove(kontener);
  ilosckontenerów++;
  waga = waga + kontener.WagaWlasna;
 }
 
 public void załadujkontener(List<Kontener> konteners)
 {
  foreach (Kontener kontener in konteners)
  {
  this.załadujkontener(kontener);
  }
 }
 
 
 
 public void odłaczkontener(Kontener kontener)
 {
  kontenerywkontenerowcu.Remove(kontener);
  Kontener.wszystkiekontenery.Add(kontener);
  ilosckontenerów--;
  waga = waga - kontener.WagaWlasna;
 }

 public override string ToString()
 {
  return $"Predkosc: {predkosc}, Max kontenerow: {maxkonteneow}, Aktualna liczba kontenerow: {ilosckontenerów}, Waga: {waga}/{maxwaga}, {KonteneryToString()}";
 }
 
 public string KonteneryToString()
 {
  string result = "";
  foreach (Kontener kontener in kontenerywkontenerowcu)
  {
   result += kontener.show() + ", ";
  }
  // Usunięcie ostatniego przecinka
  if (!string.IsNullOrEmpty(result))
  {
   result = result.Remove(result.Length - 2);
  }
  return result;
 }

 public void zamienKontener(string k1, string k2)
 {
  odłaczkontener(this.ZnajdzKontenernakontenerowcu(k1));
  załadujkontener((Kontener.ZnajdzKontener(k2)));

 }
 
 public Kontener ZnajdzKontenernakontenerowcu(string numerSeryjny)
 {
  return kontenerywkontenerowcu.Find(kontener => kontener.NumerSeryjny.Equals(numerSeryjny));
 }

 public static void zamienKontener(Kontenerowiec k1, Kontenerowiec k2, Kontener kontener)
 {
  k1.odłaczkontener(kontener);
  k2.załadujkontener(kontener);
 }
}
 
