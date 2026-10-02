using Összgyak;

List<Eszkoz> adatok = new List<Eszkoz>();
string fajlEleres = "eszkozok.txt";

foreach (string sor in File.ReadAllLines("eszkozok.txt"))
{
    string[] mezok = sor.Split(';');
    if (!int.TryParse(mezok[3], out int raktardb))
    {
        raktardb = 0;
    }
    if (!int.TryParse(mezok[2], out int ar))
    {
        Console.WriteLine($"Hiba! A(z) {mezok[0]} cikkszámú sor adata hibás.");
        continue;
    }
    Eszkoz ujeszkoz = new Eszkoz(mezok[0], mezok[1], ar, raktardb);
    adatok.Add(ujeszkoz);
}
Console.WriteLine("\n=== SIKERESEN BEOLVASOTT ADATOK ===");
foreach(Eszkoz eszkoz in adatok)
{
    Console.WriteLine(eszkoz);
}
Console.WriteLine($"\nRendszerben regisztrált eszközök száma: {Eszkoz.OsszesLetezoEszkoz} db");
double osszesBruttoAr = 0;
foreach(Eszkoz eszkoz in adatok)
{
    osszesBruttoAr += Penzugy.BruttoArSzamitas((double)eszkoz.BeszerzesiAr * eszkoz.RaktarKeszlet);
}
Console.WriteLine($"Raktárkészlet teljes bruttó értéke: {osszesBruttoAr:0,0} ft");
Eszkoz legdragabb = adatok.MaxBy(e => e.BeszerzesiAr);
Console.WriteLine($"Legdrágább eszköz: {legdragabb.Nev}({legdragabb.BeszerzesiAr}) ft");







