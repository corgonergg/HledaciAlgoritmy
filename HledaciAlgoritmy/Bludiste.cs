using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HledaciAlgoritmy
{
    class Bludiste
    {

        public static void Recursive(Mapa mapakulozeni)
        {
            Random nahoda = new Random();
            // Najdu náhodné políčko v poli
            Policko aktualnipolicko = mapakulozeni.NajdiRealnePolicko(0, 0);

            aktualnipolicko.dostupnostprogeneraci = false;

            List<Policko> NavstivenePolicka = new List<Policko>();
            NavstivenePolicka.Add(aktualnipolicko);

            while (NavstivenePolicka.Count > 0)
            {
                if (nahoda.Next(10) == 0)
                {
                    aktualnipolicko = NavstivenePolicka[nahoda.Next(NavstivenePolicka.Count)];
                    NavstivenePolicka.RemoveAt(nahoda.Next(NavstivenePolicka.Count));
                }
                else
                {
                    aktualnipolicko = NavstivenePolicka[NavstivenePolicka.Count - 1];
                    NavstivenePolicka.RemoveAt(NavstivenePolicka.Count - 1);
                }

                List<Policko> sousedi = new List<Policko>();
                List<Policko> potencialnisousedi = new List<Policko>();
                potencialnisousedi.Add(mapakulozeni.NajdiRealnePolicko(aktualnipolicko.x + 1, aktualnipolicko.y));
                potencialnisousedi.Add(mapakulozeni.NajdiRealnePolicko(aktualnipolicko.x    , aktualnipolicko.y + 1));
                potencialnisousedi.Add(mapakulozeni.NajdiRealnePolicko(aktualnipolicko.x - 1, aktualnipolicko.y));
                potencialnisousedi.Add(mapakulozeni.NajdiRealnePolicko(aktualnipolicko.x    , aktualnipolicko.y - 1));

                foreach (Policko pol in potencialnisousedi)
                {
                    if (pol == null || pol.typ == Typpolicko.Zed || !pol.dostupnostprogeneraci)
                        continue;
                    sousedi.Add(pol);
                }
                if (sousedi.Count == 0)
                    continue;
                Policko vybrany = sousedi[nahoda.Next(sousedi.Count)];
                vybrany.dostupnostprogeneraci = false;
                aktualnipolicko.PridejSouseda(vybrany);
                NavstivenePolicka.Add(aktualnipolicko);
                NavstivenePolicka.Add(vybrany);
            }
            // Konstrukce
            for (int x = 0; x < mapakulozeni.mapa.GetLength(0); x++)
                for (int y = 0; y < mapakulozeni.mapa.GetLength(1); y++)
                {
                    mapakulozeni.mapa[x, y].typ = Typpolicko.Classic;
                    mapakulozeni.mapa[x, y].prohledanost = TypProhledanosti.Neprohledane;
                }

            for (int x = 0; x < mapakulozeni.mapa.GetLength(0); x++)
                for (int y = 0; y < mapakulozeni.mapa.GetLength(1); y++)
                    if (x % 2 == 0 || y % 2 == 0)
                        mapakulozeni.mapa[x, y].typ = Typpolicko.Zed;
            for (int x = 0; x < mapakulozeni.mapa.GetLength(0) / 2; x++)
                for (int y = 0; y < mapakulozeni.mapa.GetLength(1) / 2; y++)
                {
                    Policko policko = mapakulozeni.NajdiRealnePolicko(x, y);
                    int gridX = x * 2 + 1, gridY = y * 2 + 1;
                    mapakulozeni.mapa[gridX, gridY].typ = Typpolicko.Classic;

                    if (policko.jePodSousedem(mapakulozeni))
                        mapakulozeni.mapa[gridX, gridY + 1].typ = Typpolicko.Classic;

                    if (policko.JeVedleSouseda(mapakulozeni))
                        mapakulozeni.mapa[gridX + 1, gridY].typ = Typpolicko.Classic;
                }
        }
        public static void BinarniStrom(Mapa mapakulozeni)
        {
            Random nahoda = new Random();
            for (int i = 0; i < mapakulozeni.mapa.GetLength(0); i += 2)
            {
                for (int j = 0; j < mapakulozeni.mapa.GetLength(1); j += 2)
                {
                    Policko pol = mapakulozeni.mapa[i, j];
                    pol.typ = Typpolicko.Classic;

                    List<Policko> sousedi = new List<Policko>();

                    if (i != 0 && mapakulozeni.mapa[i - 2, j].typ == Typpolicko.Classic)
                        sousedi.Add(mapakulozeni.mapa[i - 1, j]);

                    if (j != 0 && mapakulozeni.mapa[i, j - 2].typ == Typpolicko.Classic)
                        sousedi.Add(mapakulozeni.mapa[i, j - 1]);

                    if (sousedi.Count != 0)
                    {
                        sousedi[nahoda.Next(0, sousedi.Count)].typ = Typpolicko.Classic;
                    }
                }
            }
        }
    }
}
