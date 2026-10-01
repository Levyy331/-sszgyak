using System;
using System.Collections.Generic;
using System.Text;

namespace Összgyak
{
    internal class Eszkoz
    {
        private int beszerzesiAr;
        private int raktarKeszlet;
        private static int osszesLetezoEszkoz = 0;

        public string Cikkszam { get; set; }
        public string Nev { get; set; }

        public int BeszerzesiAr
        {
            get { return beszerzesiAr; }
            set { beszerzesiAr = value < 0 ? 0 : value; }
        }

        public int RaktarKeszlet
        {
            get { return raktarKeszlet; }
            set { raktarKeszlet = value < 0 ? 0 : value; }
        }

        public static int OsszesLetezoEszkoz
        {
            get { return osszesLetezoEszkoz; }
        }

        public Eszkoz(string cikkszam, string nev, int beszerzesiAr)
            : this(cikkszam, nev, beszerzesiAr, 0)
        {
        }

        public Eszkoz(string cikkszam, string nev, int beszerzesiAr, int raktarKeszlet)
        {
            Cikkszam = cikkszam;
            Nev = nev;
            BeszerzesiAr = beszerzesiAr;
            RaktarKeszlet = raktarKeszlet;

            osszesLetezoEszkoz++;
        }

        public override string ToString()
        {
            return $"[{Cikkszam}] {Nev}, Beszerzési ár: {BeszerzesiAr} Ft, Készlet: {RaktarKeszlet} db";
        }

        public bool Eladas(int db)
        {
            if (db <= RaktarKeszlet)
            {
                RaktarKeszlet -= db;
                return true;
            }
            else
            {
                Console.WriteLine($" Nincs elegendő készleten! (Kért: {db} db, Raktáron: {RaktarKeszlet} db)");
                return false;
            }
        }
    }
}
