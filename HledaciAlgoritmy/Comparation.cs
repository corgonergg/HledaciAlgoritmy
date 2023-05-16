using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using HledaciAlgoritmy.Properties;

namespace HledaciAlgoritmy
{
    public partial class Comparation : Form
    {
        public Comparation(UvodniForm ukazovatkomenu)
        {
            InitializeComponent();
            this.ukazovatkomenu = ukazovatkomenu;
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

            tb1.Text = Settings.Default.tb1.ToString();
            tb2.Text = Settings.Default.tb2.ToString();
            panely = new BufferPanel[] { bpanel_astar, bpanel_dijk, bpanel_bfs, bpanel_dfs };
            kontroly = new List<Control>() { gp_animace, bt_porovnat, gp_loadsave, gp_typcesty, gb_parametry };

        }
        UvodniForm ukazovatkomenu;
        Mapa mapaastar, mapadijkstra, mapabfs, mapadfs;
        BufferPanel[] panely;
        List<Control> kontroly;
        List<Mapa> mapy;
        bool rezim = true;
        List<List<List<Policko>>> ObsazenaPolicka = new List<List<List<Policko>>>();
        Mapa mapa;
        Bitmap bm;
        int cislo = 0;
        int animace = 0;

        private void bt_load_Click(object sender, EventArgs e)
        {
            try
            {
                Mapa.NactiMapu(ref mapaastar, bpanel_astar, null, new List<Label>() { lb_astar_rozs, lb_astar_krok, lb_astar_RVzdalenost });
                Mapa.NactiMapu(ref mapadijkstra, bpanel_dijk, mapaastar.FileName, new List<Label>() { lb_dijk_rozs, lb_dijk_krok, lb_dijk_RVzdalenost });
                Mapa.NactiMapu(ref mapabfs, bpanel_bfs, mapaastar.FileName, new List<Label>() { lb_bfs_rozs, lb_bfs_krok, lb_bfs_RVzdalenost });
                Mapa.NactiMapu(ref mapadfs, bpanel_dfs, mapaastar.FileName, new List<Label>() { lb_dfs_rozs, lb_dfs_krok, lb_dfs_RVzdalenost });
                mapy = new List<Mapa>() { mapaastar, mapadijkstra, mapabfs, mapadfs };
                Refresh();
                bt_porovnat.Enabled = true;
            }
            catch (Exception ex)
            {
                if (ex.Message != "Chyba")
                    EventZprava.Show(TypZprava.Soubor, TypUcel.Chyba, TypEventOdpoved.Ok);
            }
        }
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Generace a prohledávání
        private void bt_randomgenerate_Click(object sender, EventArgs e)
        {
            bt_porovnat.Enabled = true;
            bpanel_astar.BackgroundImage = null;
            bpanel_dijk.BackgroundImage = null;
            bpanel_bfs.BackgroundImage = null;
            bpanel_dfs.BackgroundImage = null;


            Settings.Default.tb1 = Convert.ToInt32(tb2.Text);
            Settings.Default.tb2 = Convert.ToInt32(tb2.Text);
            Settings.Default.Save();

            int xVelikost = 0;
            int yVelikost = 0;
            try
            {
                xVelikost = Convert.ToInt32(tb2.Text);
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
            //
            // Vytvoř mapy
            //
            mapa = new Mapa(xVelikost / 2, yVelikost / 2, bpanel_astar, "test", null);
            mapa.VytvorMapu(false, null);
            Bludiste.Recursive(mapa);
            Mapa.UlozMapu(ref mapa, true);
            string cesta = Nastaveni.VychoziCesta + "Buffer" + "\\Mapa.json";
            Mapa.NactiMapu(ref mapaastar, bpanel_astar, cesta, new List<Label>() { lb_astar_rozs, lb_astar_krok, lb_astar_RVzdalenost });
            Mapa.NactiMapu(ref mapadijkstra, bpanel_dijk, cesta, new List<Label>() { lb_dijk_rozs, lb_dijk_krok, lb_dijk_RVzdalenost });
            Mapa.NactiMapu(ref mapabfs, bpanel_bfs, cesta, new List<Label>() { lb_bfs_rozs, lb_bfs_krok, lb_bfs_RVzdalenost });
            Mapa.NactiMapu(ref mapadfs, bpanel_dfs, cesta, new List<Label>() { lb_dfs_rozs, lb_dfs_krok, lb_dfs_RVzdalenost });

            mapy = new List<Mapa>() { mapaastar, mapadijkstra, mapabfs, mapadfs };

            Random nahoda = new Random();
            int xnahoda = -5;
            int ynahoda = -5;
            bool povoleni = true;
            bool uzBylStart = false;
            int[] souradnicestart = new int[2] { -5, -5 };
            int[] souradnicekonec = new int[2] { -5, -5 };

            foreach (Mapa mapa in mapy)
            {
                mapa.panel.BackColor = Color.FromArgb(42, 40, 54);
                while (povoleni)
                {
                    if (xnahoda == -5 && ynahoda == -5)
                    {
                        xnahoda = nahoda.Next(0, xVelikost);
                        ynahoda = nahoda.Next(0, yVelikost);
                    }
                    if (mapa.mapa[xnahoda, ynahoda].typ == Typpolicko.Classic && !uzBylStart)
                    {
                        mapa.mapa[xnahoda, ynahoda].typ = Typpolicko.Start;
                        souradnicestart[0] = xnahoda;
                        souradnicestart[1] = ynahoda;
                        uzBylStart = true;
                    }
                    if (mapa.mapa[xnahoda, ynahoda].typ == Typpolicko.Classic)
                    {
                        mapa.mapa[xnahoda, ynahoda].typ = Typpolicko.Konec;
                        souradnicekonec[0] = xnahoda;
                        souradnicekonec[1] = ynahoda;
                        povoleni = false;
                    }
                    xnahoda = -5;
                    ynahoda = -5;
                }
                mapa.mapa[souradnicestart[0], souradnicestart[1]].typ = Typpolicko.Start;
                mapa.mapa[souradnicekonec[0], souradnicekonec[1]].typ = Typpolicko.Konec;
            }
            Refresh();


            /*if ((string)btn.Tag == "empty")
                Mapa.NastavTypProMapu(Typpolicko.Classic, mapaukazovatko.mapa);
            else if ((string)btn.Tag == "random")
                Bludiste.Recursive(ref mapaukazovatko);
            else if ((string)btn.Tag == "strom")
            {
                Mapa.NastavTypProMapu(Typpolicko.Zed, mapaukazovatko.mapa);
                Bludiste.BinarniStrom(mapaukazovatko);
            }*/
        }
        private void bt_porovnat_Click(object sender, EventArgs e)
        {
            Pozadi.InterakceControlu(false, kontroly);

            // Výběr režimu
            if (rb_teoretical.Checked)
                rezim = true;
            else if (rb_realistic.Checked)
                rezim = false;

            ObsazenaPolicka.Clear();

            ObsazenaPolicka.Add(Algoritmus.AStar(mapaastar, rezim));

            try
            {
                if (ObsazenaPolicka[0][0][0] == null)
                    throw new Exception();

                string slozka = Application.StartupPath;
                string soubor = "\\MapBuffer";
                bm = Mapa.VytvorObrazekMapy(mapaastar.panel);
                if (Directory.Exists("MapBuffer"))
                {
                    bm.Save(slozka + soubor + "\\bm" + cislo + ".bmp");
                    mapaastar.panel.BackgroundImage = Image.FromFile(slozka + soubor + "\\bm" + cislo + ".bmp");
                    mapadijkstra.panel.BackgroundImage = Image.FromFile(slozka + soubor + "\\bm" + cislo + ".bmp");
                    mapabfs.panel.BackgroundImage = Image.FromFile(slozka + soubor + "\\bm" + cislo + ".bmp");
                    mapadfs.panel.BackgroundImage = Image.FromFile(slozka + soubor + "\\bm" + cislo + ".bmp");
                }
                else
                {
                    slozka += soubor;
                    Directory.CreateDirectory(slozka);
                    bm.Save(slozka + "\\bm.bmp");
                    mapaastar.panel.BackgroundImage = Image.FromFile(slozka + "\\bm.bmp");
                    mapadijkstra.panel.BackgroundImage = Image.FromFile(slozka + "\\bm.bmp");
                    mapabfs.panel.BackgroundImage = Image.FromFile(slozka + "\\bm.bmp");
                    mapadfs.panel.BackgroundImage = Image.FromFile(slozka + "\\bm.bmp");
                }
                cislo++;

                // Astar
                Algoritmus.VykresliCestu(mapaastar.NajdiPolicko(Typpolicko.Start), mapaastar.NajdiPolicko(new List<int>() { ObsazenaPolicka[0][0].Last().x, ObsazenaPolicka[0][0].Last().y }), mapaastar);
                // Dijkstra
                ObsazenaPolicka.Add(Algoritmus.Dijkstra(mapadijkstra, rezim));
                Algoritmus.VykresliCestu(mapadijkstra.NajdiPolicko(Typpolicko.Start), mapadijkstra.NajdiPolicko(new List<int>() { ObsazenaPolicka[1][0].Last().x, ObsazenaPolicka[1][0].Last().y }), mapadijkstra);
                // BFS
                ObsazenaPolicka.Add(Algoritmus.BFS(mapabfs, rezim));
                Algoritmus.VykresliCestu(mapabfs.NajdiPolicko(Typpolicko.Start), mapabfs.NajdiPolicko(new List<int>() { ObsazenaPolicka[2][0].Last().x, ObsazenaPolicka[2][0].Last().y }), mapabfs);
                // DFS
                ObsazenaPolicka.Add(Algoritmus.DFS(mapadfs, rezim));
                Algoritmus.VykresliCestu(mapadfs.NajdiPolicko(Typpolicko.Start), mapadfs.NajdiPolicko(new List<int>() { ObsazenaPolicka[3][0].Last().x, ObsazenaPolicka[3][0].Last().y }), mapadfs);

                animace = tb_animace.Value;

                if (!background.IsBusy)
                    background.RunWorkerAsync();
                else
                    background.CancelAsync();

                // Vybarveni
                //MultiVybarveni(ObsazenaPolicka, mapy);
            }
            catch (Exception)
            {
                EventZprava.Show(TypZprava.Mapa, TypUcel.Chyba, TypEventOdpoved.Ok);
                Pozadi.InterakceControlu(true, kontroly);
            }

        }
        public void MultiVybarveniASYNC(List<List<List<Policko>>> ObsazenaPolicka, List<Mapa> mapy, int animace)
        {
            long cas = 0;
            int[] indexy = new int[4] {0,0,0,0};
            int[] mapapocetPROHLEDANYCH = new int[4] { 0, 0, 0, 0 };
            int[] mapapocetCEST = new int[4] { 0, 0, 0, 0 };
            int[] realnavzdalenost = new int[4] { 0, 0, 0, 0 };

            for (int i = 0; i < ObsazenaPolicka[3].Count; i++) // DRUHÁ ÚROVEŇ POČET KONCŮ
            {
                for (int j = 0; j < ObsazenaPolicka.Max(llp => llp.Last().Count); j++) // TŘETÍ ÚROVEŇ JEDNOTLIVÁ SLOVÍČKA
                {
                    cas++;
                    for (int k = 0; k < 4; k++)
                    {
                        if (!(j >= ObsazenaPolicka[k][i].Count))
                        {
                            ProhledejPolicko(ObsazenaPolicka[k][i][j]);
                            mapapocetPROHLEDANYCH[k]++;
                        }
                        else
                        {
                            if (!(indexy[k] >= mapy[k].Cesta[0].Count))
                            {
                                OznacPolicko(mapy[k].Cesta[0][indexy[k]]);
                                mapapocetCEST[k]++;
                                realnavzdalenost[k] += mapy[k].Cesta[0][indexy[k]].gCena - mapy[k].Cesta[0][indexy[k]].otec.gCena;
                            }
                            indexy[k]++;
                        }
                    }
                    if (j % animace == 0)
                    {
                        background.ReportProgress(2, new object[] {mapapocetPROHLEDANYCH, mapapocetCEST, realnavzdalenost});
                        Thread.Sleep(100);
                    }
                }
            }
            //
            // Vykreslení cesty
            //
            for (int i = 0; i < mapy.Max(lm => lm.Cesta[0].Count); i++)
            {
                cas++;
                for (int k = 0; k < 4; k++)
                    if (!(i >= mapy[k].Cesta[0].Count))
                    {
                        OznacPolicko(mapy[k].Cesta[0][i]);
                        if (i >= Convert.ToInt32(mapy[k].lbs[1].Text))
                        {
                            mapapocetCEST[k]++;
                            realnavzdalenost[k] += mapy[k].Cesta[0][i].gCena - mapy[k].Cesta[0][i].otec.gCena;
                        }
                    }
                if (i % animace == 0)
                {
                    background.ReportProgress(2, new object[] { mapapocetPROHLEDANYCH, mapapocetCEST, realnavzdalenost });
                    Thread.Sleep(100);
                }
            }
            background.ReportProgress(0, new object[] { mapapocetPROHLEDANYCH, mapapocetCEST, realnavzdalenost });
            Thread.Sleep(100);

            void ProhledejPolicko(Policko pol)
            {
                if (pol.typ != Typpolicko.Start && pol.typ != Typpolicko.Konec && pol.prohledanost != TypProhledanosti.Prohledane && pol.prohledanost != TypProhledanosti.Cesta)
                    pol.prohledanost = TypProhledanosti.Prohledane;
            }
            void OznacPolicko(Policko pol)
            {
                if (pol.typ != Typpolicko.Start && pol.typ != Typpolicko.Konec)
                    pol.prohledanost = TypProhledanosti.Cesta;
            }
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Paint eventy pláten
        private void bt_paint(object sender, PaintEventArgs e)
        {
            Mapa.BtPaint(sender, e);
        }
        private void bpanel_dijk_Paint(object sender, PaintEventArgs e)
        {
            Mapa.Paint(sender, e, mapadijkstra, bm, true);
        }
        private void bpanel_dfs_Paint(object sender, PaintEventArgs e)
        {
            Mapa.Paint(sender, e, mapadfs, bm, true);
        }
        private void bpanel_bfs_Paint(object sender, PaintEventArgs e)
        {
            Mapa.Paint(sender, e, mapabfs, bm, true);
        }
        private void bpanel_astar_Paint(object sender, PaintEventArgs e)
        {
            Mapa.Paint(sender, e, mapaastar, bm, true);
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Operace s plátny v pozadí
        private void background_DoWork(object sender, DoWorkEventArgs e)
        {
            // Vybarveni
            MultiVybarveniASYNC(ObsazenaPolicka, mapy, animace);
        }
        private void background_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value += e.ProgressPercentage;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    mapy[j].lbs[i].Text = ((int[])((object[])e.UserState)[i])[j].ToString();
            Refresh();
        }
        private void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EventZprava.Show(TypZprava.Mapa, TypUcel.Uspech, TypEventOdpoved.Ok, new string[] { lb_astar_krok.Text, lb_astar_rozs.Text, lb_astar_RVzdalenost.Text, lb_bfs_krok.Text, lb_bfs_rozs.Text, lb_bfs_RVzdalenost.Text, lb_dfs_krok.Text, lb_dfs_rozs.Text, lb_dfs_RVzdalenost.Text, lb_dijk_krok.Text, lb_dijk_rozs.Text, lb_dijk_RVzdalenost.Text });
            background.CancelAsync();
            background.Dispose();
            bm = null;
            Pozadi.InterakceControlu(true, new List<Control>() { gp_animace, bt_porovnat, gp_loadsave, gp_typcesty, gb_parametry });
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Ostatní
        private void tb_animace_Scroll(object sender, EventArgs e)
        {
            lb_scroll_animace.Text = tb_animace.Value.ToString();
            animace = tb_animace.Value;
        }

        private void Comparation_FormClosed(object sender, FormClosedEventArgs e)
        {
            ukazovatkomenu.Show();
        }

        private void Comparation_Load(object sender, EventArgs e)
        {
            animace = Convert.ToInt32(tb_animace.Value);
            bt_porovnat.Enabled = false;
        }
        private void cb_animation_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_animation.Checked)
                tb_animace.Enabled = true;
            else
                tb_animace.Enabled = false;
        }
        private void Comparation_Resize(object sender, EventArgs e)
        {
            /*foreach (BufferPanel bp in panely)
                bp.Size = new Size(bp.Size.Width - 1, bp.Height);*/
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
    }
}
