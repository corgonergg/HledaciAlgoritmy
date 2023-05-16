using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace HledaciAlgoritmy
{
    public class Algoritmus
    {
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //
        // HLEDACÍ ALGORITMY
        //
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        public static List<List<Policko>> AStar(Mapa mapakulozeni, bool rezim)
        {
            // PROHLEDÁVÁNÍ ALGORITMEM ASTAR

            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Deklarace proměnných a nalezení startu a konce
            List<Policko> DostupnaPolicka = new List<Policko>(); // Pole dostupných políček
            List<Policko> ObsazenaPolicka = new List<Policko>(); // Pole obsazených políček
            Policko startovnipolicko = mapakulozeni.NajdiPolicko(Typpolicko.Start); // Startovní políčko
            Policko koncovepolicko = mapakulozeni.NajdiPolicko(Typpolicko.Konec); // Koncové políčko
            DostupnaPolicka.Add(startovnipolicko);
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Prohledávání mapy
            while (DostupnaPolicka.Count > 0) // Pokud zbývají dostupný políčka
            {
                Policko aktualnipolicko = DostupnaPolicka[0];
                // Projede dostupná a políčka vybere Cenově nejvýhodnější
                for (int i = 1; i < DostupnaPolicka.Count; i++)
                {
                    // Pokud je výhodnější, tak ho přidej
                    if (DostupnaPolicka[i].Celkem < aktualnipolicko.Celkem || DostupnaPolicka[i].Celkem == aktualnipolicko.Celkem && DostupnaPolicka[i].hCena < aktualnipolicko.hCena)
                    {
                        aktualnipolicko = DostupnaPolicka[i];
                    }
                }

                // Pokud není políčko startovní tak označí obsazená políčka
                // Políčko už není dostupné tak se z něj stane obsazené
                DostupnaPolicka.Remove(aktualnipolicko);
                ObsazenaPolicka.Add(aktualnipolicko);

                if (aktualnipolicko == koncovepolicko)
                {
                    return new List<List<Policko>>() { ObsazenaPolicka };
                }  // Pokud jsme našli konec, tak ho přidej
                // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
                #region Prohledej sousedy
                // Projeď sousedy daného políčka
                foreach (Policko soused in mapakulozeni.NajdiSousedy(aktualnipolicko, rezim))
                {
                    // Pokud již soused není dostupný (překážka,nebo byl již označen) tak ho přeskoč
                    if (!soused.dostupny || ObsazenaPolicka.Contains(soused))
                        continue;
                    // Zapiš cenu aktuální políčka
                    int CenaProSouseda = aktualnipolicko.gCena + ZiskejVzdalenost(aktualnipolicko, soused, rezim) + soused.PenalizaceCesty;
                    // Porovnej cenu aktuálního políčka se sousedem
                    if (CenaProSouseda < soused.gCena || !DostupnaPolicka.Contains(soused))
                    {
                        // Pokud je cena nižší tak se posune o souseda
                        soused.gCena = CenaProSouseda; // Vzdálenost od startu
                        soused.hCena = ZiskejVzdalenost(soused, koncovepolicko, rezim); // Vzdálenost od konce
                        soused.otec = aktualnipolicko;

                        if (!DostupnaPolicka.Contains(soused)) // Pokud neobsahuješ souseda, tak ho přidej
                            DostupnaPolicka.Add(soused);
                    }
                }
                #endregion
                // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            }
            return null;
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        }
        public static List<List<Policko>> Dijkstra(Mapa mapakulozeni, bool rezim)
        {
            // PROHLEDÁVÁNÍ ALGORITMEM DIJKSTRA

            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Deklarace proměnných
            int kolikaty = 0;         
            List<Policko> DostupnaPolicka = new List<Policko>(); // Pole dostupných políček
            List<List<Policko>> ObsazenaPolicka = new List<List<Policko>>(); // Pole obsazených políček
            Policko startovnipolicko = null; // Startovní políčko
            List<Policko> koncovapolicka = new List<Policko>(); // Koncová políčka
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Hledání startovního a koncových políček
            // Najdi startovnípolíčko
            foreach (Policko pol in mapakulozeni.mapa)
                if (pol.typ == Typpolicko.Start) // Pokud je políčko start, tak ho přidej
                    startovnipolicko = pol;
            
            // Najdi koncové políčko
            foreach (Policko pol in mapakulozeni.mapa)
            {
                if (pol.typ == Typpolicko.Konec)
                {
                    koncovapolicka.Add(pol);
                    ObsazenaPolicka.Add(new List<Policko>());
                } // Pokud je políčko konec, tak ho přidej
            }
            DostupnaPolicka.Add(startovnipolicko); // Přidej startovní políčko do dostupných
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Prohledávání mapy
            while (DostupnaPolicka.Count > 0) // Dokud nedojdou dostupná políčka
            {
                // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
                #region Otestování výhodnosti políčka
                Policko aktualnipolicko = DostupnaPolicka[0];
                // Projede dostupná a políčka vybere Cenově nejvýhodnější
                for (int i = 1; i < DostupnaPolicka.Count; i++)
                {
                    // Pokud je políčko výhodnější, tak ho použij
                    if (DostupnaPolicka[i].gCena < aktualnipolicko.gCena || DostupnaPolicka[i].gCena == aktualnipolicko.gCena)
                    {
                        aktualnipolicko = DostupnaPolicka[i];
                    }
                }
                // Pokud není políčko startovní tak označí obsazená políčka
                // Políčko už není dostupné tak se z něj stane obsazené
                DostupnaPolicka.Remove(aktualnipolicko);
                ObsazenaPolicka[kolikaty].Add(aktualnipolicko);

                if (koncovapolicka.Contains(aktualnipolicko))
                {
                    koncovapolicka.Remove(aktualnipolicko);
                    kolikaty++;
                    if (koncovapolicka.Count == 0)
                        return ObsazenaPolicka;
                    ObsazenaPolicka[kolikaty] = ObsazenaPolicka[kolikaty - 1].ToList();
                } // Pokud je to koncové políčko, tak ho přidej
                #endregion
                // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
                #region Prohledání sousedů políčka
                foreach (Policko soused in mapakulozeni.NajdiSousedy(aktualnipolicko, rezim))
                {
                    // Pokud již soused není dostupný (překážka,nebo byl již označen) tak ho přeskoč
                    if (!soused.dostupny || ObsazenaPolicka[kolikaty].Contains(soused))
                        continue;

                    // Zapiš cenu aktuální políčka
                    int CenaProSouseda = aktualnipolicko.gCena + ZiskejVzdalenost(aktualnipolicko, soused, rezim) + soused.PenalizaceCesty;
                    // Porovnej cenu aktuálního políčka se sousedem
                    if (CenaProSouseda < soused.gCena || !DostupnaPolicka.Contains(soused))
                    {
                        // Pokud je cena nižší tak se posune o souseda
                        soused.gCena = CenaProSouseda;
                        soused.otec = aktualnipolicko;

                        if (!DostupnaPolicka.Contains(soused))
                        {
                            DostupnaPolicka.Add(soused);
                        } // Pokud neobsahuješ souseda, tak ho přidej
                    }
                }
                #endregion
                // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            }
            return null;
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        }
        public static List<List<Policko>> BFS(Mapa mapakulozeni, bool rezim)
        {
            // PROHLEDÁVÁNÍ ALGORITMEM BFS (PROHLEDÁVÁNÍ DO ŠÍŘKY)

            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Deklarace proměnných
            int kolikaty = 0;
            List<Policko> DostupnaPolicka = new List<Policko>(); // Pole dostupných políček
            List<Policko> koncovapolicka = new List<Policko>(); // Pole koncových políček
            List<List<Policko>> ObsazenaPolicka = new List<List<Policko>>(); // Pole obsazených políček
            Policko startovnipolicko = null; // Startovní políčko
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Hledání startovního políčka a koncových
            // Najdi startovní políčko
            foreach (Policko pol in mapakulozeni.mapa)
                if (pol.typ == Typpolicko.Start) // Pokud je políčko start, tak ho přidej
                    startovnipolicko = pol;

            foreach (Policko pol in mapakulozeni.mapa)             // Najdi koncová políčka
            {
                if (pol.typ == Typpolicko.Konec) // Je políčko konec?
                {
                    koncovapolicka.Add(pol);
                    ObsazenaPolicka.Add(new List<Policko>());
                } // Pokud je políčko konec, tak ho přidej
            }
            DostupnaPolicka.Add(startovnipolicko); // Přidej startovní políčko do dostupných políček
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Prohledávání mapy
            while (DostupnaPolicka.Count > 0) // Dokud nedojdou volná políčka
            {
                foreach (Policko policko in DostupnaPolicka)
                {
                    ObsazenaPolicka[kolikaty].Add(policko); // Označ políčko jako prohledaný 
                    if (koncovapolicka.Contains(policko)) // Pokud je to koncové políčko
                    {
                        koncovapolicka.Remove(policko);
                        kolikaty++; // Kolik konců bylo
                        if (koncovapolicka.Count == 0) // Pokud již nezbývá nalézt žádný konec
                            return ObsazenaPolicka; // Ukonči a vrať výsledek
                        ObsazenaPolicka[kolikaty] = ObsazenaPolicka[kolikaty - 1].ToList();
                    } // Pokud je to koncové políčko, tak ho přidej
                }
                DostupnaPolicka.Clear(); // Vyčisti pole
                // Vzdálenosti mezi políčky - !!BFS nebere v potaz vzdálenosti!!
                for (int i = 0; i < ObsazenaPolicka.Count; i++)
                {
                    foreach (Policko policko in ObsazenaPolicka[i])
                    {
                        foreach (Policko soused in mapakulozeni.NajdiSousedy(policko, rezim)) // Prohledej sousedy
                        {
                            // Určení reálné vzdálenosti
                            int CenaProSouseda = policko.gCena + ZiskejVzdalenost(policko, soused, rezim) + soused.PenalizaceCesty;
                            // Pokud již soused není dostupný (překážka,nebo byl již označen) tak ho přeskoč
                            if (!soused.dostupny || ObsazenaPolicka[kolikaty].Contains(soused))
                                continue;
                            if (!DostupnaPolicka.Contains(soused)) // Pokud ještě neprošel souseda
                            {
                                soused.otec = policko;
                                soused.gCena = CenaProSouseda;
                                DostupnaPolicka.Add(soused);
                            } // Pokud neobsahuješ souseda, tak ho přidej
                        }
                    }
                }
            }
            return null; // Pokud nebylo nic nalezeno vrať nic
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        }
        public static List<List<Policko>> DFS(Mapa mapakulozeni, bool rezim)
        {
            // PROHLEDÁVÁNÍ ALGORITMEM DFS (PROHLEDÁVÁNÍ DO HLOUBKY)

            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Deklarace proměnných
            int kolikaty = 0;
            Stack<Policko> DostupnaPolicka = new Stack<Policko>(); // Dostupné políčka
            List<List<Policko>> ObsazenaPolicka = new List<List<Policko>>(); // Obsazené políčka
            Policko startovnipolicko = null; // startovní políčko
            List<Policko> koncovapolicka = new List<Policko>(); // Koncové políčka
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Hledání startovního políčka a koncových
            foreach (Policko pol in mapakulozeni.mapa) // HLEDÁNÍ STARTU
                if (pol.typ == Typpolicko.Start)  // Pokud je políčko start, tak ho přidej
                    startovnipolicko = pol;

            foreach (Policko pol in mapakulozeni.mapa) // HLEDÁNÍ CÍLŮ
            {
                if (pol.typ == Typpolicko.Konec)
                {
                    koncovapolicka.Add(pol);
                    ObsazenaPolicka.Add(new List<Policko>());
                } // Pokud je políčko konec, tak ho přidej
            }
            DostupnaPolicka.Push(startovnipolicko); // Přidej na vrchol skladu start
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Prohledávání mapy
            while (DostupnaPolicka.Count > 0)
            {
                Policko aktualnipolicko = DostupnaPolicka.Pop(); // Vem a odstraň políčko s nejvyšší prioritou
                ObsazenaPolicka[kolikaty].Add(aktualnipolicko); // Označ políčko jako prohledaný
                if (koncovapolicka.Contains(aktualnipolicko)) // Pokud je to koncové políčko
                {
                    koncovapolicka.Remove(aktualnipolicko);
                    kolikaty++; // Kolik konců bylo
                    if (koncovapolicka.Count == 0) // Pokud již nezbývá nalézt žádný konec
                        return ObsazenaPolicka; // Ukonči a vrať výsledek
                    ObsazenaPolicka[kolikaty] = ObsazenaPolicka[kolikaty - 1].ToList();
                } // Pokud je to koncové políčko, tak ho přidej

                foreach (Policko soused in mapakulozeni.NajdiSousedy(aktualnipolicko, rezim)) // Prohledej sousedy
                {
                    // Určení reálné vzdálenosti
                    int CenaProSouseda = aktualnipolicko.gCena + ZiskejVzdalenost(aktualnipolicko, soused, rezim) + soused.PenalizaceCesty;
                    // Pokud již soused není dostupný (překážka,nebo byl již označen) tak ho přeskoč
                    if (!soused.dostupny || ObsazenaPolicka[kolikaty].Contains(soused))
                        continue;
                    if (!DostupnaPolicka.Contains(soused)) // Pokud ještě neprošel souseda
                    {
                        soused.otec = aktualnipolicko;
                        soused.gCena = CenaProSouseda;
                        DostupnaPolicka.Push(soused);
                    } // Pokud neobsahuješ souseda, tak ho přidej
                }
            }
            return null;
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        }
        //
        // Metoda ke zpětnému vykreslení cesty a ke grafické animaci
        //
        public static void VykresliCestu(Policko startovnipolicko, Policko koncovepolicko, Mapa mapakulozeni)
        {
            List<Policko> Cesta = new List<Policko>(); // Deklarace listu cesty
            Policko aktualnipolicko = koncovepolicko; // Začni u koncového políčka

            while (aktualnipolicko != startovnipolicko) // Dokud jsme nedošli na začátek
            {
                Cesta.Add(aktualnipolicko); // Přidej políčko do listu cesty
                aktualnipolicko = aktualnipolicko.otec; // Po tom co políčko již přidal, tak vezme jeho předchůdce
            }

            Cesta.Reverse(); // Obrať ten list, ať začíná od startu
            mapakulozeni.Cesta.Add(Cesta); // Přidání cesty k mapě
        }
        //
        // Metoda k získání vzdálenosti mezi políčkem A a B
        //
        private static int ZiskejVzdalenost(Policko startovnipolicko, Policko koncovepolicko, bool rezim)
        {
            // Typy (Hledání standardní, nebo i diagonální)
            int nasobek;
            if (rezim)
                nasobek = 14; // Diagonální
            else
                nasobek = 20; // Standardní

            // Absolutní vzdálenost políček mezi sebou
            int VzdalenostX = Math.Abs(startovnipolicko.x - koncovepolicko.x);
            int VzdalenostY = Math.Abs(startovnipolicko.y - koncovepolicko.y);

            // Rovnice na vzdálenost
            if (VzdalenostX > VzdalenostY)
                return nasobek * VzdalenostY + 10 * (VzdalenostX - VzdalenostY);
            else
                return nasobek * VzdalenostX + 10 * (VzdalenostY - VzdalenostX);
        }
    }
}
