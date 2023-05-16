using HledaciAlgoritmy.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public enum Typpolicko
{
    // KLASICKÁ ČÁST
    Classic,
    Zed,
    Start,
    Konec,
    Silnice,
    Obj5,
    Obj6,
    Obj7,
    Obj8,
}
public enum TypProhledanosti
{
    Cesta,
    Prohledane,
    Neprohledane
}
namespace HledaciAlgoritmy
{
    public class Policko
    {
        // -*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Základní atributy políčka 
        public bool dostupny; // Může se pohybovat
        public int x; // Souřadnice x
        public int y; // Souřadnice y
        #endregion
        // -*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Atributy pro autogeneraci bludiště
        public bool dostupnostprogeneraci = true; 
        public bool zed = true;
        #endregion
        // -*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Tělo, typ a sousedi políčka
        public Telo telo; // Tělo políčka
        public Bitmap obrazek; // Obrázek
        public Policko otec; // Každé políčko má "otce" ze kterého vychází pak ke zpětnému dohledání cesty
        public List<Policko> sousedi = new List<Policko>(); // sousedi políčka
        // Typ políčka pro orientaci k vykreslování
        private Typpolicko _typ;
        private TypProhledanosti _prohledanost;
        public TypProhledanosti prohledanost
        {
            get
            {
                return _prohledanost;
            }
            set
            {
                _prohledanost = value;
                switch (value)
                {
                    //
                    // VYKRESLOVACÍ TYPY
                    //
                    case TypProhledanosti.Cesta:
                        telo.tag = "Cesta";
                        telo.BackColor = new SolidBrush(Nastaveni.BarvaCesta);
                        break;
                    case TypProhledanosti.Prohledane:
                        telo.tag = "Prohledane";
                        telo.BackColor = new SolidBrush(Nastaveni.BarvaProhledany);
                        break;
                    case TypProhledanosti.Neprohledane:
                        telo.tag = "Neprohledane";
                        break;
                }
            }
        }
        public Typpolicko typ
        {
            get
            {
                return _typ;
            }
            set
            {
                _typ = value;
                // IMAGE, NAZEV, VAHA, DOSTUPNOST
                string[] str1 = Settings.Default.start.Split('|');
                string[] str2 = Settings.Default.konec.Split('|');
                string[] str3 = Settings.Default.zed.Split('|');
                string[] str4 = Settings.Default.silnice.Split('|');
                string[] str5 = Settings.Default.Obj5.Split('|');
                string[] str6 = Settings.Default.Obj6.Split('|');
                string[] str7 = Settings.Default.Obj7.Split('|');
                string[] str8 = Settings.Default.Obj8.Split('|');

                switch (value)
                {
                    //
                    // ZÁKLADNÍ TYPY
                    //
                    case Typpolicko.Classic:
                        obrazek = Properties.Resources.trava;
                        telo.tag = "Classic";
                        PenalizaceCesty = 0;
                        dostupny = true;
                        telo.BackColor = new SolidBrush(Color.White);
                        break;
                    case Typpolicko.Start:
                        obrazek = (Bitmap)Image.FromFile(str1[0]);
                        telo.tag = str1[1];
                        PenalizaceCesty = Convert.ToInt32(str1[2]);
                        dostupny = Convert.ToBoolean(str1[3]);
                        telo.BackColor = new SolidBrush(Color.Lime);
                        break;
                    case Typpolicko.Konec:
                        obrazek = (Bitmap)Image.FromFile(str2[0]);
                        telo.tag = str2[1];
                        PenalizaceCesty = Convert.ToInt32(str2[2]);
                        dostupny = Convert.ToBoolean(str2[3]);
                        telo.BackColor = new SolidBrush(Color.Red);
                        break;
                    case Typpolicko.Zed:
                        obrazek = (Bitmap)Image.FromFile(str3[0]);
                        telo.tag = str3[1];
                        PenalizaceCesty = Convert.ToInt32(str3[2]);
                        dostupny = Convert.ToBoolean(str3[3]);
                        telo.BackColor = new SolidBrush(Color.Black);
                        break;
                    case Typpolicko.Silnice:
                        obrazek = (Bitmap)Image.FromFile(str4[0]);
                        telo.tag = str4[1];
                        PenalizaceCesty = Convert.ToInt32(str4[2]);
                        dostupny = Convert.ToBoolean(str4[3]);
                        telo.BackColor = new SolidBrush(Color.Magenta);
                        break;
                    case Typpolicko.Obj5:
                        obrazek = (Bitmap)Image.FromFile(str5[0]);
                        telo.tag = str5[1];
                        PenalizaceCesty = Convert.ToInt32(str5[2]);
                        dostupny = Convert.ToBoolean(str5[3]);
                        telo.BackColor = new SolidBrush(Color.DarkGreen);
                        break;
                    case Typpolicko.Obj6:
                        obrazek = (Bitmap)Image.FromFile(str6[0]);
                        telo.tag = str6[1];
                        PenalizaceCesty = Convert.ToInt32(str6[2]);
                        dostupny = Convert.ToBoolean(str6[3]);
                        telo.BackColor = new SolidBrush(Color.Blue);
                        break;
                    case Typpolicko.Obj7:
                        obrazek = (Bitmap)Image.FromFile(str7[0]);
                        telo.tag = str7[1];
                        PenalizaceCesty = Convert.ToInt32(str7[2]);
                        dostupny = Convert.ToBoolean(str7[3]);
                        telo.BackColor = new SolidBrush(Color.Yellow);
                        break;
                    case Typpolicko.Obj8:
                        obrazek = (Bitmap)Image.FromFile(str8[0]);
                        telo.tag = str8[1];
                        PenalizaceCesty = Convert.ToInt32(str8[2]);
                        dostupny = Convert.ToBoolean(str8[3]);
                        telo.BackColor = new SolidBrush(Color.Orange);
                        break;
                    default:
                        throw new Exception("Neznámý typ políčka!");
                }
            }
        }
        #endregion
        // -*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Atributy pro algoritmy
        public int gCena; // Vzdálenost startu od cíle
        public int hCena; // Vzdálenost od cíle do startu
        public int PenalizaceCesty; // Váha políčka (výchozí 0)
        public int Celkem // Výpočet vzdálenosti mezi sebou
        {
            get
            {
                return gCena + hCena;
            }
        }
        #endregion
        // -*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        public Policko (bool dostupny, int x, int y, Telo telo)
        {
            this.dostupny = dostupny;
            this.x = x;
            this.y = y;
            this.telo = telo;
        }
        public Policko(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.zed = true;
        }
        public Policko(int x, int y, bool zed)
        {
            this.x = x;
            this.y = y;
            this.zed = zed;
        }
        public static bool SousedJeVLEVO(Policko soused, Policko hledanypolicko)
        {
            if (soused.x + 1 == hledanypolicko.x && soused.y == hledanypolicko.y)
                return true;
            else
                return false;
        }
        public static bool SousedJeVPRAVO(Policko soused, Policko hledanypolicko)
        {
            if (soused.x - 1 == hledanypolicko.x && soused.y == hledanypolicko.y)
                return true;
            else
                return false;
        }
        public static bool SousedJeNAHORE(Policko soused, Policko hledanypolicko)
        {
            if (soused.x == hledanypolicko.x && soused.y + 1== hledanypolicko.y)
                return true;
            else
                return false;
        }
        public static bool SousedJeDOLE(Policko soused, Policko hledanypolicko)
        {
            if (soused.x == hledanypolicko.x && soused.y - 1 == hledanypolicko.y)
                return true;
            else
                return false;
        }
        // Přidej souseda políčka
        public void PridejSouseda(Policko pol)
        {
            if (!this.sousedi.Contains(pol))
                this.sousedi.Add(pol);
            if (!pol.sousedi.Contains(this))
                pol.sousedi.Add(this);
        }
        public bool jePodSousedem(Mapa mapakulozeni)
        {
            return this.sousedi.Contains(new Policko(this.x, this.y + 1));
        }
        public bool JeVedleSouseda(Mapa mapakulozeni)
        {
            return this.sousedi.Contains(new Policko(this.x + 1, this.y));
        }
        public override bool Equals(object policko)
        {
            if (policko.GetType() != typeof(Policko))
                return false;
            Policko dalsipolicko = (Policko)policko;
            return (x == dalsipolicko.x) && (y == dalsipolicko.y);
        }
        public override int GetHashCode()
        {
            return x + y * 256;
        }
    }
}
