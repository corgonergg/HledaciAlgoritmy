using HledaciAlgoritmy.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HledaciAlgoritmy
{
    public partial class Rozhrani : Form
    {
        public Rozhrani(UvodniForm ukazovatkonamenu)
        {
            InitializeComponent();
            this.ukazovatkonamenu = ukazovatkonamenu;
            kontroly = new List<Control>() { gb_generace, gb_algoritmy, gb_animace, gb_hledanicesty, gb_loadsave, gb_nastroje, bt_find, bt_rychlyload1, bt_rychlyload2, bt_rychlyload3, bt_rychlyload4 };
            ukony = new List<Ukon>()
            {
                //       FYZICKÉ    LOGICKÉ zastoupení
                new Ukon(bt_start, Typukon.Start, true), // Úkon1 - START
                new Ukon(bt_konec, Typukon.Konec, true), // Úkon2 - KONEC
                new Ukon(bt_zed, Typukon.Zed, true), // Úkon3 - ZED
                new Ukon(bt_cesta, Typukon.Silnice, true), // Úkon4 - CESTA
                new Ukon(bt_obj5, Typukon.Obj5, true), // Úkon5 - LIBOVOLNÝ
                new Ukon(bt_obj6, Typukon.Obj6, true), // Úkon6 - LIBOVOLNÝ
                new Ukon(bt_obj7, Typukon.Obj7, true), // Úkon7 - LIBOVOLNÝ
                new Ukon(bt_obj8, Typukon.Obj8, true) // Úkon8 - LIBOVOLNÝ
            };
            //
            // Načti obrázky
            //
            bool[] zkusil = new bool[4] { false, false, false, false };
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    if (bt_rychlyload1.BackgroundImage == null && !zkusil[0])
                    {
                        zkusil[0] = true;
                        bt_rychlyload1.BackgroundImage = Image.FromFile(Settings.Default.CestaObr1 + "\\fotka.bmp");
                        bt_rychlyload1.Text = "";
                    }
                    if (bt_rychlyload2.BackgroundImage == null && !zkusil[1])
                    {
                        zkusil[1] = true;
                        bt_rychlyload2.BackgroundImage = Image.FromFile(Settings.Default.CestaObr2 + "\\fotka.bmp");
                        bt_rychlyload2.Text = "";
                    }
                    if (bt_rychlyload3.BackgroundImage == null && !zkusil[2])
                    {
                        zkusil[2] = true;
                        bt_rychlyload3.BackgroundImage = Image.FromFile(Settings.Default.CestaObr3 + "\\fotka.bmp");
                        bt_rychlyload3.Text = "";
                    }
                    if (bt_rychlyload4.BackgroundImage == null && !zkusil[3])
                    {
                        zkusil[3] = true;
                        bt_rychlyload4.BackgroundImage = Image.FromFile(Settings.Default.CestaObr4 + "\\fotka.bmp");
                        bt_rychlyload4.Text = "";
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            tb1.Text = Settings.Default.tb1.ToString();
            tb2.Text = Settings.Default.tb2.ToString();
            gb_nastroje.Enabled = false;

            if (Directory.Exists("MapBuffer"))
            {
                try
                {
                    Directory.Delete("MapBuffer", true);
                }
                catch (Exception)
                {
                    
                }
            }
        }
        Mapa mapaukazovatko;
        UvodniForm ukazovatkonamenu;
        List<Control> kontroly;
        List<Ukon> ukony;
        List<List<Policko>> ObsazenaPolicka = new List<List<Policko>>();
        bool rezim = true;
        Bitmap bm;
        int rychlostanimace = 0;
        int cislo = 0;
        bool animovat = true;
        bool moving = false;

        private void bt_generovat_Click(object sender, EventArgs e)
        {
            // OBNOV NA VÝCHOZÍ

            foreach (Ukon ukon in ukony)
                ukon.pocet = 0;

            Platno.BackgroundImage = null;

            Settings.Default.tb1 = Convert.ToInt32(tb1.Text);
            Settings.Default.tb2 = Convert.ToInt32(tb2.Text);
            Settings.Default.Save();

            bt_find.Enabled = true;
            bt_save.Enabled = true;
            bt_export.Enabled = true;
            gb_nastroje.Enabled = true;

            lb_cesta.Text = "0";
            lb_prohledany.Text = "0";
            lb_realnacesta.Text = "0";

            Button btn = (Button)sender;

            // Zadání parametrů velikosti
            int xVelikost = 0;
            int yVelikost = 0;
            try
            {
                xVelikost = Convert.ToInt32(tb1.Text);
                yVelikost = Convert.ToInt32(tb2.Text);

                if (xVelikost % 2 == 0)
                    xVelikost--;
                if (yVelikost % 2 == 0)
                    yVelikost--;
            }
            catch (Exception)
            {
                EventZprava.Show(TypZprava.Data, TypUcel.Chyba, TypEventOdpoved.Ok);
                Application.Restart();
            }

            mapaukazovatko = new Mapa(xVelikost / 2, yVelikost / 2, Platno, "ClassicEdit", null);
            mapaukazovatko.VytvorMapu(false, null);

            if ((string)btn.Tag == "Prázdná")
                Mapa.NastavTypProMapu(Typpolicko.Classic, mapaukazovatko.mapa);
            else if ((string)btn.Tag == "Classic")
                Bludiste.Recursive(mapaukazovatko);
            else if ((string)btn.Tag == "Strom")
            {
                Mapa.NastavTypProMapu(Typpolicko.Zed, mapaukazovatko.mapa);
                Bludiste.BinarniStrom(mapaukazovatko);
            }
            Refresh();
        }
        private void bt_find_Click(object sender, EventArgs e)
        {
            tb_animace.Enabled = false;
            gb_nastroje.Enabled = false;
            mapaukazovatko.Cesta.Clear();
            foreach (Policko pol in mapaukazovatko.mapa)
                if (pol.prohledanost != TypProhledanosti.Neprohledane)
                    pol.prohledanost = TypProhledanosti.Neprohledane;

            Pozadi.InterakceControlu(false, kontroly); // Zablokování kontrolů
            // Výběr režimu
            if (rb_teoretical.Checked)
                rezim = true;
            else if (rb_realistic.Checked)
                rezim = false;

            // Hledání cesty - VÝBĚR ALGORITMU
            if (rb_astar.Checked)
                ObsazenaPolicka = Algoritmus.AStar(mapaukazovatko, rezim); // ASTAR
            else if (rb_dijkstra.Checked)
                ObsazenaPolicka = Algoritmus.Dijkstra(mapaukazovatko, rezim); // DIJKSTRA
            else if (rb_bfs.Checked)
                ObsazenaPolicka = Algoritmus.BFS(mapaukazovatko, rezim); // BFS
            else if (rb_dfs.Checked)
                ObsazenaPolicka = Algoritmus.DFS(mapaukazovatko, rezim); // DFS
            try
            {
                // Pokud nebyla nalezena cesta
                if (ObsazenaPolicka[0][0] == null)
                    throw new Exception();

                // Konvertuj na obrázek
                string slozka = Application.StartupPath;
                string soubor = "\\MapBuffer";
                bm = Mapa.VytvorObrazekMapy(Platno);
                if (Directory.Exists("MapBuffer"))
                {
                    bm.Save(slozka + soubor + "\\bm" + cislo + ".bmp");
                    Platno.BackgroundImage = Image.FromFile(slozka + soubor + "\\bm" + cislo + ".bmp");
                }
                else
                {
                    slozka += soubor;
                    //MessageBox.Show(slozka);
                    Directory.CreateDirectory(slozka);
                    bm.Save(slozka + "\\bm.bmp");
                    Platno.BackgroundImage = Image.FromFile(slozka + "\\bm.bmp");
                    //MessageBox.Show("Podařilo se");
                }
                cislo++;

                for (int i = 0; i < ObsazenaPolicka.Count; i++)
                    if (ObsazenaPolicka[i].Count > 0)
                        Algoritmus.VykresliCestu(mapaukazovatko.NajdiPolicko(Typpolicko.Start), mapaukazovatko.NajdiPolicko(new List<int>() { ObsazenaPolicka[i].Last().x, ObsazenaPolicka[i].Last().y }), mapaukazovatko);

                rychlostanimace = tb_animace.Value;

                background.RunWorkerAsync();
            }
            catch (Exception)
            {
                EventZprava.Show(TypZprava.Mapa, TypUcel.Chyba, TypEventOdpoved.Ok);
                Pozadi.InterakceControlu(true, kontroly);
            }
        }

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Události s plátnem
        // Konkrétní události
        private void Platno_Paint(object sender, PaintEventArgs e)
        {
            Mapa.Paint(sender, e, mapaukazovatko, bm, cb_animation.Checked);
        }
        private void Platno_MouseClick(object sender, MouseEventArgs e)
        {
            if (mapaukazovatko != null)
                Interakce(sender, e);
        }
        private void Platno_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
        }
        private void Platno_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && mapaukazovatko != null)
            {
                Interakce(sender, e);
            }
        }
        private void Platno_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }
        // Interakce
        public void Interakce(object sender, MouseEventArgs e)
        {
            foreach (Policko pol in mapaukazovatko.mapa)
            {
                int x = e.X; // Získej souřadnice myši x
                int y = e.Y; // Získej souřadnice myši y

                // Jsou souřadnice v aktuálním rectanglu?
                if (pol.telo.rectangle.X + pol.telo.rectangle.Width > x && pol.telo.rectangle.Y + pol.telo.rectangle.Height > y)
                {
                    if (e.Button == MouseButtons.Left) // Levé tlačítko
                    {
                        foreach (Ukon ukon in ukony)
                        {
                            // Vyber příslušný úkon
                            if (ukon.status && pol.typ == Typpolicko.Classic && (ukon.maxukonu > ukon.pocet || !ukon.omezenypocet))
                            {
                                ukon.pocet++;
                                pol.typ = ukon.typ; // Nastav podle úkonu typ políčku
                            }
                        }
                    }
                    else if (e.Button == MouseButtons.Right) // Pravé tlačítko
                    {                       
                        foreach (Ukon ukon in ukony)
                        {
                            if (pol.typ == ukon.typ)
                            {
                                ukon.pocet--;
                                pol.typ = Typpolicko.Classic; // Vrať tlačítko do úvodní pozice
                            }
                        }
                    }
                    Refresh(); // Refreshni mapu
                    break;
                }
            }
        }
        // Výběr objektů (Úkonu)
        private void bt_ukon_Click(object sender, EventArgs e)
        {
            foreach (Ukon ukon in ukony)
            {
                if (ukon.vytvorenyukon)
                {
                    if ((Button)sender == ukon.btn)
                        ukon.status = true;
                    else
                        ukon.status = false;
                }
            }
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Ukládání/Načítání - Export map
        private void bt_save_Click(object sender, EventArgs e)
        {
            // Uložení mapy
            Mapa.UlozMapu(ref mapaukazovatko, false);
        }
        private void bt_load_Click(object sender, EventArgs e)
        {
            // Loadování mapy
            Platno.BackgroundImage = null;

            bt_find.Enabled = true;
            bt_save.Enabled = true;

            try
            {
                Mapa.NactiMapu(ref mapaukazovatko, Platno, null, null);
            }
            catch (Exception ex)
            {
                if (ex.Message != "Chyba")
                    EventZprava.Show(TypZprava.Soubor, TypUcel.Chyba, TypEventOdpoved.Ok);
                if (mapaukazovatko == null)
                {
                    bt_save.Enabled = false;
                    bt_find.Enabled = false;
                }
            }
        }
        private void bt_export_Click(object sender, EventArgs e)
        {
            Mapa.ExportniMapu(ref mapaukazovatko);
        }
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Vyhledávání cíle v pozadí
        public void VybarveniASYNC(List<List<Policko>> ObsazenaPolicka, Mapa mapaukazovatko, int rozmermapy, int animace)
        {
            int prohledany = 0, cesta = 0, k = 0, vzdalenostcesty = 0; // Deklarace proměnných

            for (int i = 0; i < ObsazenaPolicka.Count; i++)
            {
                for (int j = 0; j < ObsazenaPolicka[i].Count; j++) // Prohledávání políček
                {
                    if (i != 0 && j == 0)
                        j = ObsazenaPolicka[i - 1].Count;
                    
                    // Pokud není políčko prohledané, tak ho přidej
                    if (ObsazenaPolicka[i][j].typ != Typpolicko.Start && ObsazenaPolicka[i][j].typ != Typpolicko.Konec && ObsazenaPolicka[i][j].prohledanost != TypProhledanosti.Prohledane && ObsazenaPolicka[i][j].prohledanost != TypProhledanosti.Cesta)
                    {
                        ObsazenaPolicka[i][j].prohledanost = TypProhledanosti.Prohledane;
                        prohledany++; // Přidej počet prohledaných políček
                    }
                    
                    if (j % animace == 0) // Průběžně vykresli
                    {
                        background.ReportProgress(0, new object[] { prohledany, cesta, vzdalenostcesty }); // Reportni progres kvůli postupnému vykreslení
                        Thread.Sleep(200); // Zpomal vykreslování k docílení hezký animace
                    }
                }
                for (int j = 0; j < mapaukazovatko.Cesta[i].Count; j++) // Prohledávání cesty
                {
                    k++;
                    // Pokud to není start ani cíl, tak z něj udělej cestu
                    if (mapaukazovatko.Cesta[i][j].typ != Typpolicko.Start && mapaukazovatko.Cesta[i][j].typ != Typpolicko.Konec)
                    {
                        mapaukazovatko.Cesta[i][j].prohledanost = TypProhledanosti.Cesta;
                        cesta++;
                        vzdalenostcesty += mapaukazovatko.Cesta[i][j].gCena - mapaukazovatko.Cesta[i][j].otec.gCena;
                    }
                    if (k % animace == 0) // Průběžně vykresli
                    {
                        background.ReportProgress(0, new object[] { prohledany, cesta, vzdalenostcesty });
                        Thread.Sleep(200);
                    }
                }
            }
            // Průběžně vykresli
            background.ReportProgress(0, new object[] { prohledany, cesta, vzdalenostcesty });
        }
        private void background_DoWork(object sender, DoWorkEventArgs e)
        {
            VybarveniASYNC(ObsazenaPolicka, mapaukazovatko, Convert.ToInt32(tb1.Text), rychlostanimace);
        }
        private void background_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lb_prohledany.Text = ((object[])e.UserState)[0].ToString();
            lb_cesta.Text = ((object[])e.UserState)[1].ToString();
            lb_realnacesta.Text = ((object[])e.UserState)[2].ToString();
            Refresh();
        }
        private void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Jaký byl použit algoritmus
            string pouzityal = "";
            foreach (Control ctrl in gb_algoritmy.Controls)
                if (ctrl is RadioButton && ((RadioButton)ctrl).Checked)
                    pouzityal = ctrl.Text;

            EventZprava.Show(TypZprava.Proces, TypUcel.Uspech, TypEventOdpoved.Ok, new string[] {lb_prohledany.Text, lb_cesta.Text, lb_realnacesta.Text, pouzityal});
            background.CancelAsync();
            background.Dispose();
            bm = null;
            tb_animace.Enabled = true;
            mapaukazovatko.Cesta.Clear();
            Pozadi.InterakceControlu(true, kontroly);
            bt_save.Enabled = false;
            gb_nastroje.Enabled = true;
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Tlačítka rychlého výběru mapy
        private void bt_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.MidnightBlue;
            Refresh();
        }
        private void bt_rychlyload_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            Platno.BackgroundImage = null;

            //
            // Zdali je již obsazený interface
            //
            if (btn.BackgroundImage == null)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Zvol konfiguraci k výběru";
                fbd.SelectedPath = Nastaveni.VychoziCesta;
                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    try
                    {
                        // Zkus doplnit příslušný obrázek
                        btn.BackgroundImage = Image.FromFile(fbd.SelectedPath + "\\fotka.bmp");
                        if (btn.Name == "bt_rychlyload1")
                            Settings.Default.CestaObr1 = fbd.SelectedPath;
                        else if (btn.Name == "bt_rychlyload2")
                            Settings.Default.CestaObr2 = fbd.SelectedPath;
                        else if (btn.Name == "bt_rychlyload3")
                            Settings.Default.CestaObr3 = fbd.SelectedPath;
                        else if (btn.Name == "bt_rychlyload4")
                            Settings.Default.CestaObr4 = fbd.SelectedPath;
                        Settings.Default.Save();
                    }
                    catch (Exception)
                    {
                        EventZprava.Show(TypZprava.Soubor, TypUcel.Chyba, TypEventOdpoved.Ok);
                    }
                    btn.Text = "";
                }
            }
            else
            {
                string cesta = "";
                if (btn.Name == "bt_rychlyload1")
                    cesta = Settings.Default.CestaObr1;
                else if (btn.Name == "bt_rychlyload2")
                    cesta = Settings.Default.CestaObr2;
                else if (btn.Name == "bt_rychlyload3")
                    cesta = Settings.Default.CestaObr3;
                else if (btn.Name == "bt_rychlyload4")
                    cesta = Settings.Default.CestaObr4;

                Mapa.NactiMapu(ref mapaukazovatko, Platno, cesta + "\\mapa.json", null);

                bt_find.Enabled = true;
                bt_save.Enabled = true;
            }
        }
        private void bt_paint(object sender, PaintEventArgs e)
        {
            Mapa.BtPaint(sender, e);
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Načtení/Zavření formuláře
        private void Rozhrani_Load(object sender, EventArgs e)
        {

        }
        private void Rozhrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            background.CancelAsync();
            background.Dispose();
            ukazovatkonamenu.Show();
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Ostatní
        private void Smazani_MapySObr(object sender, EventArgs e)
        {
            if (((Control)sender).Name == "bt_rychlyload1_smazat")
            {
                Settings.Default.CestaObr1 = "";
                bt_rychlyload1.BackgroundImage = null;
                bt_rychlyload1.Text = "+";
            }
            else if (((Control)sender).Name == "bt_rychlyload2_smazat")
            {
                Settings.Default.CestaObr2 = "";
                bt_rychlyload2.BackgroundImage = null;
                bt_rychlyload2.Text = "+";
            }
            else if (((Control)sender).Name == "bt_rychlyload3_smazat")
            {
                Settings.Default.CestaObr3 = "";
                bt_rychlyload3.BackgroundImage = null;
                bt_rychlyload3.Text = "+";
            }
            else if (((Control)sender).Name == "bt_rychlyload4_smazat")
            {
                Settings.Default.CestaObr4 = "";
                bt_rychlyload4.BackgroundImage = null;
                bt_rychlyload4.Text = "+";
            }
            Settings.Default.Save();
        }
        private void tb_animace_Scroll(object sender, EventArgs e)
        {
            lb_scroll_animace.Text = tb_animace.Value.ToString();
        }
        private void cb_animation_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_animation.Checked)
            {
                animovat = true;
                tb_animace.Enabled = true;
            }
            else
            {
                animovat = false;
                tb_animace.Enabled = false;
            }
        }

        private void panel_hlavicka_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
    }
    //
    // BufferPanel -) Lepší než klasický panel
    //
    public class BufferPanel : Panel
    {
        public BufferPanel() : base()
        {
            DoubleBuffered = true;
        }
    }
    public enum Typukon 
    {
        Start, // Start
        Konec, // Konec
        Zed, // Zeď
        Silnice, // Silnice
        Obj5, // Les
        Obj6, // Voda
        Obj7, // None
        Obj8, // None
    }
    public class Ukon
    {
        public string nazev; // Název úkonu
        public bool status; // Zda je na políčko zrovna kliknutý
        public Button btn; // Fyzické zastoupení
        public int pocet; // Kolik jich už je těch úkonů
        public Typpolicko typ; // Jaký typ políčka úkon zastupuje
        public bool omezenypocet; // Má omezený počet
        public int maxukonu; // maximální počet úkonů
        public bool vytvorenyukon; // Je úkon vytvořený nebo prázdný
        private Typukon _ukon;
        public Typukon ukon // Zástupce úkonu pro následnou práci
        {
            get
            {
                return _ukon;
            }
            set
            {
                _ukon = value;
                status = false;
                pocet = 0;

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
                    case Typukon.Start:
                        btn.BackgroundImage = Image.FromFile(str1[0]);
                        nazev = str1[1];
                        status = true;
                        typ = Typpolicko.Start;
                        omezenypocet = Convert.ToBoolean(str1[4]);
                        maxukonu = Convert.ToInt32(str1[5]);
                        break;
                    case Typukon.Konec:
                        btn.BackgroundImage = Image.FromFile(str2[0]);
                        nazev = str2[1];;
                        typ = Typpolicko.Konec;
                        omezenypocet = Convert.ToBoolean(str2[4]);
                        maxukonu = Convert.ToInt32(str2[5]);
                        break;
                    case Typukon.Zed:
                        btn.BackgroundImage = Image.FromFile(str3[0]);
                        nazev = str3[1];
                        typ = Typpolicko.Zed;
                        omezenypocet = Convert.ToBoolean(str3[4]);
                        maxukonu = Convert.ToInt32(str3[5]);
                        break;
                    case Typukon.Silnice:
                        btn.BackgroundImage = Image.FromFile(str4[0]);
                        nazev = str4[1];
                        typ = Typpolicko.Silnice;
                        omezenypocet = Convert.ToBoolean(str4[4]);
                        maxukonu = Convert.ToInt32(str4[5]);
                        break;
                    case Typukon.Obj5:
                        btn.BackgroundImage = Image.FromFile(str5[0]);
                        nazev = str5[1];
                        typ = Typpolicko.Obj5;
                        omezenypocet = Convert.ToBoolean(str5[4]);
                        maxukonu = Convert.ToInt32(str5[5]);
                        break;
                    case Typukon.Obj6:
                        btn.BackgroundImage = Image.FromFile(str6[0]);
                        nazev = str6[1];
                        typ = Typpolicko.Obj6;
                        omezenypocet = Convert.ToBoolean(str6[4]);
                        maxukonu = Convert.ToInt32(str6[5]);
                        break;
                    case Typukon.Obj7:
                        btn.BackgroundImage = Image.FromFile(str7[0]);
                        nazev = str7[1];
                        typ = Typpolicko.Obj7;
                        omezenypocet = Convert.ToBoolean(str7[4]);
                        maxukonu = Convert.ToInt32(str7[5]);
                        break;
                    case Typukon.Obj8:
                        btn.BackgroundImage = Image.FromFile(str8[0]);
                        nazev = str8[1];
                        typ = Typpolicko.Obj8;
                        omezenypocet = Convert.ToBoolean(str8[4]);
                        maxukonu = Convert.ToInt32(str8[5]);
                        break;
                }
            }
        }

        public Ukon(Button btn, Typukon ukon, bool vytvorenyukon)
        {
            this.btn = btn;
            this.ukon = ukon;
            this.vytvorenyukon = vytvorenyukon;
        }
    }
}
