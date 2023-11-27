using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel_Console
{
    internal class Program
    { 

        static List <Nobel> nobels = new List<Nobel>();

        static void Main(string[] args)
        {
            /*    var ell = File.ReadAllLines("nobel.csv");
                foreach(var line in ell)
                {
                    Console.WriteLine(line);
                }  */


            string[] olvasottNobels = File.ReadAllLines("nobel.csv");
            for (int i = 1; i < olvasottNobels.Length; i++)
            {
                string[] tagok = olvasottNobels[i].Split(';');
                Nobel dijazott = new Nobel(Convert.ToInt32(tagok[0]), tagok[1], tagok[2], tagok[3]);
                nobels.Add(dijazott);
            }



            /*      List<Nobel> nobels = new List<Nobel>();
                  string[] sorok = File.ReadAllLines("nobel.csv");
                  for (int i = 0; i < sorok.Length; i++)
                  {
                      string[] adat = sorok[i].Split(';');
                      int evszam = Convert.ToInt32(sorok[0]);
                      string tipus = adat[1];
                      string keresztnev = adat[2];
                      string vezeteknev = adat[3];

                      Nobel nobel = new Nobel(evszam, tipus, keresztnev, vezeteknev);
                      nobels.Add(nobel);
                  }  */



            // 3. feladat: Arthur B. McDonalds milyen típusú díjat kapott?

            string keresettTipus = "";

            foreach (var item in nobels)
            {
                if (item.Keresztnev == "Arthur B." && item.Vezeteknev == "McDonald")
                {
                    keresettTipus = item.Tipus;
                    break;
                }

            } Console.WriteLine($"3. feladat: {keresettTipus}");

            //4.feladat:Ki kapott 2017-ben irodalmi Nobel-díjat?

            string keresettKNev = "";
            string keresettVNev = "";

            foreach (var item in nobels)
            {
                if (item.Ev == 2017 && item.Tipus == "irodalmi")
                {
                    keresettKNev = item.Keresztnev;
                    keresettVNev = item.Vezeteknev;
                    break;
                }
            } Console.WriteLine($"4. feladat:{keresettKNev} {keresettVNev}");

            //5.feladat: Mely szervezetek kaptak béke Nobel-díjat 1990-től napjainkig?

            Console.Write("5. feladat:\n");
           
            foreach (var item in nobels)
            {
                if (item.Tipus == "béke" && item.Ev >= 1990 && item.Vezeteknev=="")
                {
                    
                  Console.WriteLine($"\t{item.Ev}: {item.Keresztnev}");
                    
                } 
            }

            // 6.feladat: A Curie család több tagja is kapott díjat.
            //            A család tagjai melyik évben, milyen díjat kapott?

            Console.WriteLine("6. feladat:");
            foreach (var item in nobels)
            {
                if(item.Vezeteknev.Contains ("Curie"))
                {
                    Console.WriteLine($"\t{item.Ev}: {item.Keresztnev} {item.Vezeteknev} ({item.Tipus})");
                }               
            }

            // 7. feladat: Melyik típusú díjból hányat osztottak ki ? 

            Console.WriteLine("7.feladat:");
            var dijak = nobels.GroupBy(x => x.Tipus).ToList();
            foreach (var dij in dijak)
            {
                Console.WriteLine($" \t{dij.Key, -20} {dij.Count(),-5} db");
            }

            // 8 feladat: Menteni orvosi.txt néven UTF-8 kódolású szöveges állományt,
            //            ami tartalmazza az összes orvosi Nóbel-díj adatait.

            StreamWriter sw = new StreamWriter("orvosi.txt");
            foreach(var nobel in nobels)
            {
                if(nobel.Tipus == "orvosi")
                {
                    sw.WriteLine($" {nobel.Ev}: {nobel.Keresztnev} {nobel.Vezeteknev}");
                }
            }
            Console.WriteLine("8.feladat:orvosi.txt");
            sw.Close();
             
        }
    }
}

/*        3.feladat: fizikai
          4.feladat:Kazuo Ishiguro
          5. feladat:
                  2017: International Campaign to Abolish Nuclear Weapons (ICAN)
                  2015: National Dialogue Quartet
                  2013: Organisation for the Prohibition of Chemical Weapons(OPCW)
                  2012: European Union(EU)
                  2007: Intergovernmental Panel on Climate Change(IPCC)
                  2006: Grameen Bank
                  2005: International Atomic Energy Agency(IAEA)
                  2001: United Nations(U.N.)
                  1999: Médecins Sans Fronticres
                  1997: International Campaign to Ban Landmines(ICBL)
                  1995: Pugwash Conferences on Science and World Affairs
          6.feladat:
                  1935: Ircne Joliot - Curie(kémiai)
                  1911: Marie Curie, née Sklodowska(kémiai)
                  1903: Pierre Curie(fizikai)
                  1903: Marie Curie, née Sklodowska(fizikai)
          7.feladat:
                  fizikai              207   db
                  kémiai               178   db
                  orvosi               214   db
                  irodalmi             114   db
                  béke                 131   db
                  közgazdaságtani      79    db
          8.feladat:orvosi.txt
Press any key to continue . . .

*/