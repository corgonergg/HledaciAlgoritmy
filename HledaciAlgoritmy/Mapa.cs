using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;

namespace HledaciAlgoritmy
{
    public class Mapa
    {
        public int xVelikost; // Velikost mapy x
        public int yVelikost; // Velikost mapy y

        public int realnaVelikostx; // Reálná velikost mapy x
        public int realnaVelikosty; // Reálná velikost mapy y

        public bool aktivace; // Kontrolní promměná

        public BufferPanel panel; // Panel
        public string jmenoMapy; // 
        public string FileName; // Jméno souboru odkud pochází
        public List<Label> lbs; // Labely s informacemi pro zobrazení ve formu
        
        public Policko[,] mapa; // mapa celá
        private Policko[,] realnamapa; // reálná mapa

        public List<List<Policko>> Cesta; // cesta
        public int RealnaVzdalenostMeziSaK; // Reálná vzdálenost mezi startem a koncem

        public Bitmap platno;
        private Graphics gp;


        public Mapa(int xVelikost, int yVelikost, BufferPanel panel, string jmenoMapy, List<Label> lbs)
        {
            this.realnaVelikostx = xVelikost;
            this.realnaVelikosty = yVelikost;
            this.xVelikost = xVelikost * 2 + 1;
            this.yVelikost = yVelikost * 2 + 1;
            this.panel = panel;
            this.jmenoMapy = jmenoMapy;
            this.lbs = lbs;
            this.Cesta = new List<List<Policko>>();
        }
        public void VytvorMapu(bool zloadingu, Konfigurace konf)
        {
            // Pokud vytvářím znova mapu
            if (!zloadingu)
            {
                mapa = new Policko[xVelikost, yVelikost]; // 2D mapy políček
                realnamapa = new Policko[realnaVelikostx, realnaVelikosty]; // reálná mapa 2D

                platno = new Bitmap(panel.Width, panel.Height); // Vytvoř plátno
                gp = Graphics.FromImage(platno); // plátno
                gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

                // Doplnění do reálné mapy
                for (int x = 0; x < realnaVelikostx; x++)
                    for (int y = 0; y < realnaVelikosty; y++)
                        realnamapa[x, y] = new Policko(x, y, false); // Vytvoření políčka

                // Doplnění do celé mapy
                for (int i = 0; i < xVelikost; i++)
                    for (int j = 0; j < yVelikost; j++)
                        mapa[i, j] = new Policko(true, i, j, VytvorTelo(i,j, false, konf)); 
            }
            // Pokud načítám mapu z konfigurace
            else
            {
                mapa = new Policko[konf.xVelikost, konf.yVelikost];
                // Vyčisti mapu
                panel.Controls.Clear();
                //mapa = konf.Policka;

                // Vytvoř plátno
                platno = new Bitmap(panel.Width, panel.Height);
                gp = Graphics.FromImage(platno);
                gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

                for (int i = 0; i < konf.xVelikost; i++)
                    for (int j = 0; j < konf.yVelikost; j++)
                    {
                        mapa[i, j] = new Policko(konf.Policka[i, j].dostupny, i, j, VytvorTelo(i, j, true, konf));
                        mapa[i, j].otec = konf.Policka[i, j].otec;
                        mapa[i, j].sousedi = konf.Policka[i, j].sousedi;
                        mapa[i, j].typ = konf.Policka[i, j]._typ;
                        mapa[i, j].prohledanost = TypProhledanosti.Neprohledane;
                    }
                
            }
            panel.BackColor = Color.FromArgb(42, 40, 54);
        }
        public static void NactiMapu(ref Mapa mapaukazovatko, BufferPanel Platno, string FileName, List<Label> lbs)
        {
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            // NAČÍTÁNÍ MAPY
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Načtení souboru
            OpenFileDialog ofd = new OpenFileDialog();
            if (FileName == null)
            {
                // Loadování mapy
                ofd.InitialDirectory = Nastaveni.VychoziCesta;
                ofd.Title = "Načítání konfigurace";
                ofd.CheckFileExists = true;
                ofd.Filter = "Json (*.json)|*.json";
                // Pokud to selže
                if (ofd.ShowDialog() != DialogResult.OK)
                    throw new Exception("Chyba");
                FileName = ofd.FileName;
                // Čtení
            }
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Deserializace a čtení
            StreamReader sr = new StreamReader(FileName);
            try
            {
                string jsoncteni = sr.ReadToEnd();
                Konfigurace konf = JsonConvert.DeserializeObject<Konfigurace>(jsoncteni);
                mapaukazovatko = new Mapa(konf.xVelikost / 2, konf.yVelikost / 2, Platno, (string)Platno.Tag, lbs);
                mapaukazovatko.FileName = FileName;
                mapaukazovatko.VytvorMapu(true, konf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Chyba
            }
            finally
            {
                ofd.Dispose(); // Ukončí openfiledialog
                sr.Dispose(); // Ukonči streamreader
            }
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        }
        public static void UlozMapu(ref Mapa mapaukazovatko, bool docasny)
        {
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            // UKLÁDÁNÍ MAPY
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Vytvoření objektů
            // Vytvoření pole objektů
            Objekt[,] objektyKZapisu = new Objekt[mapaukazovatko.mapa.GetLength(0), mapaukazovatko.mapa.GetLength(1)];

            // Vytvoření objektů do serializace
            for (int i = 0; i < mapaukazovatko.mapa.GetLength(0); i++) 
                for (int j = 0; j < mapaukazovatko.mapa.GetLength(1); j++)
                {
                    // Vytvoření objektu
                    Objekt obk = new Objekt
                    {
                        x = mapaukazovatko.mapa[i, j].x, // x
                        y = mapaukazovatko.mapa[i, j].y, // y
                        dostupny = mapaukazovatko.mapa[i, j].dostupny, // dostupnost
                        otec = mapaukazovatko.mapa[i, j].otec, // otec
                        sousedi = mapaukazovatko.mapa[i, j].sousedi, // list sousedů
                        telo = mapaukazovatko.mapa[i, j].telo, // tělo
                        _typ = mapaukazovatko.mapa[i, j].typ, // typ
                    };
                    objektyKZapisu[i, j] = obk; // objekt
                }
            // Vytvoření konfigurace pro uložení
            Konfigurace konf = new Konfigurace
            {
                xVelikost = mapaukazovatko.xVelikost, // velikost mapy x
                yVelikost = mapaukazovatko.yVelikost, // velikost mapy y
                Policka = objektyKZapisu, // list vytvořených objektů
            };
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Nastavení lokace umístění podle výchozí cesty
            string soubor;
            if (docasny) 
                soubor = "Buffer"; // Pokud je to pouze dočasný
            else
                soubor = "\\Konf-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm");
            string slozka = "";
            try
            {
                slozka = Nastaveni.VychoziCesta; // Výchozí cesta
                if (!Directory.Exists(slozka)) // Pokud složka neexistuje
                    throw new Exception();
            }
            catch (Exception)
            {
                EventZprava.Show(TypZprava.Mapa, TypUcel.Chyba, TypEventOdpoved.Ok);
                slozka = Nastaveni.CestaUkladani();
            }
            finally
            {
                slozka += soubor; // Doplň soubor do složky
            }         
            Directory.CreateDirectory(slozka); // Vytvoření file dialogů
            Bitmap fotka = VytvorObrazekMapy(mapaukazovatko.panel); // Fotka
            fotka.Save(slozka + "\\fotka.bmp"); // Uložit fotku do složky

            // Savefiledialog
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.RestoreDirectory = true;
            sfd.Title = "Ukládání konfigurace";
            sfd.FileName = "Mapa";
            sfd.CheckFileExists = false;
            sfd.Filter = "Json (*.json)|*.json"; // Typ souborů
            mapaukazovatko.FileName = sfd.FileName; // Název
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Serializace a zápis
            // Zapisovač
            StreamWriter sw = new StreamWriter(slozka + "\\" + sfd.FileName + ".json");
            try
            {
                // Serializace na json zápis
                string jsonzapis = JsonConvert.SerializeObject(konf, Formatting.Indented);
                sw.Write(jsonzapis); // Zapsání do souboru
            }
            catch (Exception)
            {
                // Vyskytla se chyba, smaže složku
                EventZprava.Show(TypZprava.Soubor, TypUcel.Chyba, TypEventOdpoved.Ok);
                File.Delete(slozka + "\\Konf-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm"));
            }
            finally
            {
                if (!docasny)
                    EventZprava.Show(TypZprava.Soubor, TypUcel.Uspech, TypEventOdpoved.Ok);
                // Thrash
                sfd.Dispose();
                sw.Dispose();
            }
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        }
        public static void ExportniMapu(ref Mapa mapaukazovatko)
        {
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            // UKLÁDÁNÍ MAPY
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Vytvoření objektů
            // Vytvoření pole objektů

            int[,] Binarnipole = new int[mapaukazovatko.mapa.GetLength(0), mapaukazovatko.mapa.GetLength(1)];

            // Vytvoření objektů do serializace
            for (int i = 0; i < mapaukazovatko.mapa.GetLength(0); i++)
                for (int j = 0; j < mapaukazovatko.mapa.GetLength(1); j++)
                {
                    if (mapaukazovatko.mapa[i, j].dostupny)
                        Binarnipole[i, j] = 1;
                    else
                        Binarnipole[i, j] = 0;
                }

            // Vytvoření konfigurace pro uložení
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Nastavení lokace umístění podle výchozí cesty
            string soubor = "\\Export-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm");
            string slozka = Path.GetFullPath("Exports");
            slozka += soubor;
            Directory.CreateDirectory(slozka);

            //Bitmap fotka = VytvorObrazekMapy(mapaukazovatko.panel); // Fotka
            //fotka.Save(slozka + "\\fotka.bmp"); // Uložit fotku do složky

            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            #region Serializace a zápis
            // Zapisovač
            StreamWriter sw = new StreamWriter(slozka + "\\Binarnimapa.txt");
            try
            {
                for (int i = 0; i < Binarnipole.GetLength(0); i++)
                {
                    for (int j = 0; j < Binarnipole.GetLength(1); j++)
                        sw.Write(Binarnipole[i, j]);
                    sw.WriteLine();
                }
                   
            }
            catch (Exception)
            {
                // Vyskytla se chyba, smaže složku
                EventZprava.Show(TypZprava.Soubor, TypUcel.Chyba, TypEventOdpoved.Ok);
                File.Delete(slozka);
            }
            finally
            {
                EventZprava.Show(TypZprava.Soubor, TypUcel.Uspech, TypEventOdpoved.Ok);
                // Thrash
                sw.Dispose();
            }
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        }
        public Telo VytvorTelo(int i, int j, bool zloadingu, Konfigurace konf)
        {
            Telo telo = new Telo();
            if (!zloadingu)
            {
                telo.Name = "rec" + j + "_" + i;
                telo.Size = new Size(panel.Width / xVelikost, panel.Height / yVelikost);
                telo.Enabled = true;
                telo.Location = new Point(panel.Width / xVelikost * i, panel.Height / yVelikost * j);
            }
            else
            {
                telo = konf.Policka[i, j].telo;
                telo.Size = new Size(panel.Width / konf.xVelikost, panel.Height / konf.yVelikost);
                telo.Location = new Point(panel.Width / konf.xVelikost * i, panel.Height / konf.yVelikost * j);
            }
            telo.rectangle = new Rectangle(telo.Location, telo.Size);
            gp.DrawRectangle(new Pen(Color.Black, 2), telo.rectangle);
            return telo;
        }
        // Metoda sloužící k hledání sousedů políčka
        public List<Policko> NajdiSousedy(Policko policko, bool rezim)
        {
            List<Policko> sousedi = new List<Policko>();
            // POKRAČOVAT ZMĚNIT SOUSEDY
            if (rezim)
                for (int x = -1; x <= 1; x++)
                    for (int y = -1; y <= 1; y++)
                    {
                        // Doma
                        if (x == 0 && y == 0)
                            continue;

                        int KontrolaX = policko.x + x;
                        int KontrolaY = policko.y + y;

                        if (KontrolaX >= 0 && KontrolaX < xVelikost && KontrolaY >= 0 && KontrolaY < yVelikost)
                        {
                            sousedi.Add(mapa[KontrolaX, KontrolaY]);
                        }
                    }
            else
                for (int x = -1; x <= 1; x++)
                    for (int y = -1; y <= 1; y++)
                    {
                        if (x == 0 && y == 0)
                            continue;
                        else if ((x == -1 && y == -1) || (x == 1 && y == -1) || (x == -1 && y == 1) || (x == 1 && y == 1))
                            continue;

                        int KontrolaX = policko.x + x;
                        int KontrolaY = policko.y + y;

                        if (KontrolaX >= 0 && KontrolaX < xVelikost && KontrolaY >= 0 && KontrolaY < yVelikost)
                        {
                            sousedi.Add(mapa[KontrolaX, KontrolaY]);
                        }
                    }
            return sousedi;
        }
        public List<Policko> NajdiSousedyPodleTypu(Policko policko, Typpolicko podletypu)
        {
            List<Policko> sousedi = new List<Policko>();
            // POKRAČOVAT ZMĚNIT SOUSEDY
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;
                    else if ((x == -1 && y == -1) || (x == 1 && y == -1) || (x == -1 && y == 1) || (x == 1 && y == 1))
                        continue;

                    int KontrolaX = policko.x + x;
                    int KontrolaY = policko.y + y;

                    if (KontrolaX >= 0 && KontrolaX < xVelikost && KontrolaY >= 0 && KontrolaY < yVelikost)
                    {
                        if (mapa[KontrolaX, KontrolaY].typ == Typpolicko.Silnice)
                            sousedi.Add(mapa[KontrolaX, KontrolaY]);
                    }
                }
            }
            return sousedi;
        }
        public static void Paint(object sender, PaintEventArgs e, Mapa mapaukazovatko, Bitmap mapa, bool animovat)
        {
            int indexace = 0; 
            if (mapaukazovatko != null) // Jestli je vytvořená mapa
            {
                foreach (Policko pol in mapaukazovatko.mapa)
                {
                    indexace++;
                    if (Nastaveni.Vykreslovani == "objekty")
                    {
                        // KLASICKY VŠECHNA POLÍČKA
                        if (mapa == null && pol.typ != Typpolicko.Silnice)
                            e.Graphics.DrawImage(pol.obrazek, pol.telo.rectangle);
                        // SPECIÁLNĚ SILNICE ABY SE VYBRAL SPRÁVNÝ TVAR
                        else if (mapa == null && pol.typ == Typpolicko.Silnice)
                            e.Graphics.DrawImage(TypObrazkuSilnice(pol, mapaukazovatko), pol.telo.rectangle);

                        // Prohledané a cestovní políčka
                        if (((pol.prohledanost == TypProhledanosti.Prohledane) || (pol.prohledanost == TypProhledanosti.Cesta)) && (mapa != null) && animovat)
                            e.Graphics.FillEllipse(pol.telo.BackColor, pol.telo.rectangle.X + pol.telo.rectangle.Width / 4, pol.telo.rectangle.Y + pol.telo.rectangle.Height / 4, pol.telo.rectangle.Width / 2, pol.telo.rectangle.Height / 2);
                        else if (!animovat && pol.prohledanost == TypProhledanosti.Cesta && mapa != null)
                            e.Graphics.FillEllipse(pol.telo.BackColor, pol.telo.rectangle.X + pol.telo.rectangle.Width / 4, pol.telo.rectangle.Y + pol.telo.rectangle.Height / 4, pol.telo.rectangle.Width / 2, pol.telo.rectangle.Height / 2);
                    }
                    else if (Nastaveni.Vykreslovani == "ctverec")
                        e.Graphics.FillRectangle(pol.telo.BackColor, pol.telo.rectangle);
                }
            }
        }
        public static void BtPaint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            SolidBrush drawBrush = new SolidBrush(btn.ForeColor);
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            btn.Text = string.Empty;
            e.Graphics.DrawString((string)btn.Tag, btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }
        public static Bitmap VytvorObrazekMapy(BufferPanel bp)
        {
            Bitmap bitmap = new Bitmap(bp.Width, bp.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            Rectangle rect = bp.RectangleToScreen(bp.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, Point.Empty, bp.Size);

            return bitmap;
        }
        public static Image TypObrazkuSilnice(Policko hledanypolicko, Mapa mapaukazovatko)
        {
            List<Policko> sousedi = mapaukazovatko.NajdiSousedyPodleTypu(hledanypolicko, Typpolicko.Silnice);
            if (sousedi.Count == 0) // 0X SOUSEDŮ
                return Properties.Resources.cestaNIC;
            else if (sousedi.Count == 1) // 1X SOUSED
            {
                if (Policko.SousedJeVLEVO(sousedi[0], hledanypolicko)) // JE VLEVO OD CENTRA
                    return Properties.Resources.cestaKONECZPRAVA;
                else if (Policko.SousedJeNAHORE(sousedi[0], hledanypolicko)) // JE NAHORE OD CENTRA
                    return Properties.Resources.cestaKONECZHORA;
                else if (Policko.SousedJeVPRAVO(sousedi[0], hledanypolicko)) // JE VPRAVO OD CENTRA
                    return Properties.Resources.cestaKONECZLEVA;
                else if (Policko.SousedJeDOLE(sousedi[0], hledanypolicko)) // JE DOLE OD CENTRA
                    return Properties.Resources.cestaKONECZDOLA;
            }
            else if (sousedi.Count == 2) // 2X SOUSEDI
            {
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 1; j >= 0; j--)
                    {
                        if (i == j)
                            continue;
                        // PŘÍMÝ
                        // Z LEVA DO PRAVA NEBO OPAČNĚ
                        if (Policko.SousedJeVLEVO(sousedi[i], hledanypolicko) && Policko.SousedJeVPRAVO(sousedi[j], hledanypolicko))
                            return Properties.Resources.cestaLP;
                        // Z HORA DO DOLU NEBO OPAČNĚ
                        else if (Policko.SousedJeNAHORE(sousedi[i], hledanypolicko) && Policko.SousedJeDOLE(sousedi[j], hledanypolicko))
                            return Properties.Resources.cestaND;
                        // ZATÁČKY
                        // Z LEVA NAHORU NEBO OPAČNĚ
                        else if (Policko.SousedJeVLEVO(sousedi[i], hledanypolicko) && Policko.SousedJeNAHORE(sousedi[j], hledanypolicko))
                            return Properties.Resources.cestaLN;
                        // Z HORA DO PRAVA NEBO OPAČNĚ
                        else if (Policko.SousedJeNAHORE(sousedi[i], hledanypolicko) && Policko.SousedJeVPRAVO(sousedi[j], hledanypolicko))
                            return Properties.Resources.cestaNP;
                        // Z PRAVA DOLU NEBO OPAČNĚ
                        else if (Policko.SousedJeVPRAVO(sousedi[i], hledanypolicko) && Policko.SousedJeDOLE(sousedi[j], hledanypolicko))
                            return Properties.Resources.cestaPD;
                        // Z DOLA DO LEVA NEBO OPAČNĚ
                        else if (Policko.SousedJeDOLE(sousedi[i], hledanypolicko) && Policko.SousedJeVLEVO(sousedi[j], hledanypolicko))
                            return Properties.Resources.cestaDL;
                    }
                }
            }
            else if (sousedi.Count == 3) // 3X SOUSEDŮ
            {
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        for (int k = 0; k <= 2; k++)
                        {
                            // LEVO NAHORE PRAVO
                            if (Policko.SousedJeVLEVO(sousedi[i], hledanypolicko) && Policko.SousedJeNAHORE(sousedi[j], hledanypolicko) && Policko.SousedJeVPRAVO(sousedi[k], hledanypolicko))
                                return Properties.Resources.cestaLNP;
                            // NAHORE PRAVO DOLE
                            else if (Policko.SousedJeNAHORE(sousedi[i], hledanypolicko) && Policko.SousedJeVPRAVO(sousedi[j], hledanypolicko) && Policko.SousedJeDOLE(sousedi[k], hledanypolicko))
                                return Properties.Resources.cestaNPD;
                            // PRAVO DOLE VLEVO
                            else if (Policko.SousedJeVPRAVO(sousedi[i], hledanypolicko) && Policko.SousedJeDOLE(sousedi[j], hledanypolicko) && Policko.SousedJeVLEVO(sousedi[k], hledanypolicko))
                                return Properties.Resources.cestaPDL;
                            // DOLE VLEVO NAHORE
                            else if (Policko.SousedJeDOLE(sousedi[i], hledanypolicko) && Policko.SousedJeVLEVO(sousedi[j], hledanypolicko) && Policko.SousedJeNAHORE(sousedi[k], hledanypolicko))
                                return Properties.Resources.cestaLND;
                        }
                    }
                }
            }
            else if (sousedi.Count == 4) // 4X SOUSEDŮ
            {
                for (int i = 0; i <= 3; i++)
                    for (int j = 0; j <= 3; j++)
                        for (int k = 0; k <= 3; k++)
                            for (int l = 0; l <= 3; l++)
                                if (Policko.SousedJeVLEVO(sousedi[i], hledanypolicko) && Policko.SousedJeNAHORE(sousedi[j], hledanypolicko) && Policko.SousedJeVPRAVO(sousedi[k], hledanypolicko) && Policko.SousedJeDOLE(sousedi[l], hledanypolicko))
                                    return Properties.Resources.cestaNPDL;
            }
            return null;
        }
        public Policko NajdiPolicko(Typpolicko typ)
        {
            foreach (Policko pol in mapa)
                if (pol.typ == typ)
                    return pol;
            return null;
        }
        // Metoda sloužící k nalezení políčka
        public Policko NajdiPolicko(List<int> pozice)
        {
            try
            {
                return mapa[pozice[0], pozice[1]];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
        public Policko NajdiRealnePolicko(int x, int y)
        {
            try
            {
                return realnamapa[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
        public Policko NajdiPolicko(int pozicex, int pozicey)
        {
            try
            {
                return mapa[pozicex, pozicey];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
        public static void NastavTypProMapu(Typpolicko typ, Policko[,] mapa)
        {
            for (int i = 0; i < mapa.GetLength(0); i++)
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    mapa[i, j].typ = typ;
                    mapa[i, j].prohledanost = TypProhledanosti.Neprohledane;
                }
        }
    }
}
