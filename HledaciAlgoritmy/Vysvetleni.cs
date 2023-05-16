using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HledaciAlgoritmy
{
    public partial class Vysvetleni : Form
    {
        public Vysvetleni(UvodniForm ukazovatkomenu)
        {
            InitializeComponent();
            this.ukazovatkomenu = ukazovatkomenu;
            tlacitka = new List<RadioButton>() { rb_a, rb_b, rb_c, rb_d };
            nadpisy = new List<Label>() { bp_quiz_odpoveda, bp_quiz_odpovedb, bp_quiz_odpovedc, bp_quiz_odpovedd };
            btns = new List<Button>() { bt_1, bt_2, bt_3, bt_4, bt_5, bt_6, bt_7, bt_8, bt_9, bt_10, bt_11, bt_12, bt_13, bt_14, bt_15, bt_16, bt_17, bt_18, bt_19, bt_20 };
            otazkyquiz = new List<Otazka>()
            {
                new Otazka("Pro cestu v grafu platí, že...", 4, new List<string> {"Jde o posloupnost vrcholů.", "Jde o posloupnost hran.", "Vrcholy se nesmějí opakovat.", "Hrany se nesmějí opakovat."}, 3),
                new Otazka("Který vrchol bude prohledán jako třetí při\n prohledávání do šířky, začne-li algoritmus ve vrcholu A?", 4, new List<string>(){"C", "D", "E", "F"}, 1, Properties.Resources.obrazek1),
                new Otazka("Časová složitost algoritmu BFS je...", 2, new List<string>() {"O(|V|+|E|)", "O(|V|*|E|)" }, 1),
                new Otazka("Kdo je považován za zakladatele teorie grafů?", 4, new List<string>() {"Isaac Newton", "Leonard Euler", "René Descartés", "Gottfried Leibniz"}, 2),
                new Otazka("Který algoritmus je časově rychlejší?", 3, new List<string>() {"Prohledávání do šířky (BFS)","Prohledávání do hloubky (DFS)", "Jsou stejně rychlý"}, 3),
                new Otazka("Co je v teorii grafů uzel?", 4, new List<string>() {"Vrchol","Hrana","Kružnice","Smyčka v grafu"}, 1),
                new Otazka("Který algoritmus nepatří mezi informované?", 4, new List<string>() {"Floyd-Warshall","Dijkstra","Bellman-Ford", "Prohledávání do hloubky"}, 4),
                new Otazka("Který vrchol bude prohledán jako třetí při\n prohledávání do hloubky, začne-li algoritmus ve vrcholu A?", 4, new List<string>(){"C","D","F","G"}, 2, Properties.Resources.obrazek1),
                new Otazka("Který z algoritmů vrací matici nejkratších\n vzdáleností mezi všemi dvojicemi vrcholů?", 4, new List<string>() {"Floyd-Warshall","Dijkstra","Bellman-Ford", "Prohledávání do hloubky"}, 1),
                new Otazka("Kolik maximálně hran tvoří strom prohledávání\n, který vznikne při prohledávání do hloubky, který má 8 vrcholů?", 4, new List<string>(){"6","7","8","Nelze určit"}, 2),
                new Otazka("Kolik vrcholů má nejkratší možná kružnice?", 4, new List<string>(){"2","3","4","5"}, 2),
                new Otazka("Je graf na obrázku strom?", 2, new List<string>(){"Ano","Ne"}, 2, Properties.Resources.obrazek2),
                new Otazka("Který z vybraných algoritmů je časově\n nejrychlejší?", 4, new List<string>(){"Prohledávání do šířky", "Dijkstra", "Bellman-Ford", "A*" }, 4),
                new Otazka("Počet vrcholů stromu...", 4, new List<string>(){"Je rovno počtu hran", "Je rovno počtu hran + 1", "Je rovno počtu hran - 1", "Nelze určit"}, 2),
                new Otazka("Který z vybraných algoritmů využívá heuristiku?", 4, new List<string>(){"Prohledávání do šířky", "Dijkstra", "Bellman-Ford", "A*" }, 4),
                new Otazka("Uvedený graf je...", 2, new List<string>(){"Orientovaný","Neorientovaný"}, 2, Properties.Resources.obrazek3),
                new Otazka("Uvedený graf je...", 2, new List<string>(){"Ohodnocený","Neohodnocený"},1,Properties.Resources.obrazek4),
                new Otazka("Definice grafu je...", 3, new List<string>(){"G=(V,E)","G=(V*E)","G=(V,E²)"}, 1),
                new Otazka("Časová složitost algoritmu Floyd-Warshall je...", 2, new List<string>(){"O(N³)", "O(N²)"},1),
                new Otazka("Vzdálenost mezi vrcholy A a B je...", 2, new List<string>(){"Nejkratší vzdálenost A a B", "Libovolná vzdálenost A a B"}, 1)
            };
            for (int i = 1; i <= 20; i++)
                btns[i - 1].Tag = i;
        }
        UvodniForm ukazovatkomenu;
        List<Otazka> otazkyquiz;
        List<RadioButton> tlacitka;
        List<Label> nadpisy;
        List<Button> btns;
        string cislo = "";
        bool vyhodnoceno = false;

        // Load
        private void Vysvetleni_Load(object sender, EventArgs e)
        {
            Selector("P_TR1_Uvod.pdf", false);
            bt_next.Enabled = false;
            bt_before.Enabled = false;
        }
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Operace s treeviewerem
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bp_quiz.Visible = false;
            // SELECTOVÁNÍ DOKUMENTACÍ - KAPITOLY - treeView.Program|N.Kapitola|N.M.Část
            for (int i = 0; i < 5; i++)
                if (treeView.SelectedNode != treeView.Nodes[i] && treeView.SelectedNode.Parent != null)
                {
                    lb_kapitola.Text = treeView.SelectedNode.Parent.Text;
                    AktualizacePN();
                }
            // 1. KAPITOLA

            if (treeView.SelectedNode == treeView.Nodes[0].Nodes[0])
                Selector("P_TR11_UvodniFormular.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[0].Nodes[1])
                Selector("P_TR12_Rozhrani.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[0].Nodes[2])
                Selector("P_TR13_Komparace.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[0].Nodes[3])
                Selector("P_TR14_Nastaveni.pdf", true);

            // 2. KAPITOLA

            else if (treeView.SelectedNode == treeView.Nodes[1].Nodes[0])
                Selector("P_TR21_Uvod.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[1].Nodes[1])
                Selector("P_TR22_Definice.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[1].Nodes[2])
                Selector("P_TR23_Typygrafu.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[1].Nodes[3])
                Selector("P_TR24_Problematika.pdf", true);

            // 3. KAPITOLA

            else if (treeView.SelectedNode == treeView.Nodes[2].Nodes[0])
                Selector("P_TR31_ZakladniAlgoritmy.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[2].Nodes[1])
                Selector("P_TR32_BFS.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[2].Nodes[2])
                Selector("P_TR33_DFS.pdf", true);

            // 4. KAPITOLA

            else if (treeView.SelectedNode == treeView.Nodes[3].Nodes[0])
                Selector("P_TR41_Dijkstra.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[3].Nodes[1])
                Selector("P_TR42_AStar.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[3].Nodes[2])
                Selector("P_TR43_FloydWarshall.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[3].Nodes[3])
                Selector("P_TR44_BellmanFord.pdf", true);

            // 5. KAPITOLA

            else if (treeView.SelectedNode == treeView.Nodes[4].Nodes[0])
                Selector("P_TR51_BinaryTree.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[4].Nodes[1])
                Selector("P_TR52_Recursive.pdf", true);

            // 6. KAPITOLA

            else if (treeView.SelectedNode == treeView.Nodes[5].Nodes[0])
                Selector("P_TR61_Zaver.pdf", true);
            else if (treeView.SelectedNode == treeView.Nodes[5].Nodes[1])
            {
                if (EventZprava.Show(TypZprava.Quiz, TypUcel.Varovani, TypEventOdpoved.YesNo) == Odpoved.Yes)
                {
                    Pozadi.Zamichani(otazkyquiz);
                    treeView.SelectedNode.NodeFont = new Font(treeView.SelectedNode.NodeFont.FontFamily, 12, FontStyle.Bold);
                    bp_quiz.Visible = true;
                    bt_click(bt_1, null);
                }
            }
        }
        private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.NodeFont.Size == 12 && e.Node.NodeFont.Size == 12)
                treeView.SelectedNode.NodeFont = new Font(treeView.SelectedNode.NodeFont.FontFamily, 12, FontStyle.Regular);
        }
        private void Selector(string soubor, bool selected)
        {
            string selector = Application.StartupPath + "\\Dokumentace\\" + soubor + "#toolbar=0";
            data.setLayoutMode("SinglePage");
            data.setView("Fit");
            data.src = selector;
            if (selected)
            {
                treeView.SelectedNode.NodeFont = new Font(treeView.SelectedNode.NodeFont.FontFamily, 12, FontStyle.Bold);
                bt_next.Enabled = true;
                bt_before.Enabled = true;
            }
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Tlačítka na přepínání
        private void bt_next_Click(object sender, EventArgs e)
        {
            if (bt_next.Text == "Vyhodnotit") // Quizová část
            {
                bt_next.Enabled = false; // Zablokování tlačítka
                int pocetSpravnych = 0;
                vyhodnoceno = true;
                for (int i = 0; i < otazkyquiz.Count; i++)
                    if (otazkyquiz[i].JeSpravny) // Zda je otázka správně
                    {
                        pocetSpravnych++;
                        btns[i].BackColor = Color.Lime;
                    }
                    else
                        btns[i].BackColor = Color.Red;

                // Informuj uživatele
                EventZprava.Show(TypZprava.Quiz, TypUcel.Uspech, TypEventOdpoved.Ok, new string[] { pocetSpravnych.ToString() });
            }
            // Přepínání kapitol
            else if (treeView.SelectedNode.NextNode == null) // Přepnutí do další kapitoly
                treeView.SelectedNode = treeView.SelectedNode.NextVisibleNode.FirstNode;
            else // Přepnutí na další stránku
                treeView.SelectedNode = treeView.SelectedNode.NextNode;
            AktualizacePN(); // Aktualizuje nadpisy a texty tlačítek
        }
        private void bt_before_Click(object sender, EventArgs e)
        {
            if (bt_before.Text == "Resetovat")
            {
                vyhodnoceno = false;
                for (int i = 0; i < otazkyquiz.Count; i++)
                {
                    btns[i].BackColor = Color.Gray;
                    otazkyquiz[i].zakliknutyRB = null;
                }
                bt_click(bt_1, null);
            }
            else if (treeView.SelectedNode.PrevNode == null) // Přepnutí do předchozí kapitoly
                treeView.SelectedNode = treeView.SelectedNode.PrevVisibleNode.FirstNode;
            else // Přepnutí na předchozí stránku
                treeView.SelectedNode = treeView.SelectedNode.PrevNode;
            AktualizacePN(); // Aktualizuje nadpisy a texty tlačítek
        }
        private void AktualizacePN()
        {
            try
            {
                bt_next.Text = "[" + treeView.SelectedNode.NextVisibleNode.Text + "]";
                bt_before.Text = "[" + treeView.SelectedNode.PrevVisibleNode.Text + "]";
            }
            catch (NullReferenceException)
            {
                if (treeView.SelectedNode.Name == "tr62_quiz")
                {
                    bt_next.Enabled = true;
                    bt_next.Text = "Vyhodnotit";
                    bt_before.Text = "Resetovat";
                    bt_before.Enabled = true;
                }
                else
                {
                    bt_next.Enabled = false;
                    bt_next.Text = "";
                    bt_before.Text = "[" + treeView.SelectedNode.PrevVisibleNode.Text + "]";
                }
            }
        }
        private void bt_click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++) // Povolení tlačítek
            {
                nadpisy[i].Visible = true; 
                tlacitka[i].Visible = true;
                tlacitka[i].Checked = false;
            }
            Button btn = (Button)sender; // Který tlačítko to je
            cislo = Convert.ToString(btn.Tag); // Číslo otázky

            bp_quiz_lb_nadpis.Text = "Otázka č. " + btn.Tag; // číslo otázky
            // Doplň číslo otázky do textu
            bp_quiz_otazka.Text = btn.Tag + ". " + otazkyquiz[Convert.ToInt32(btn.Tag) - 1].otazka;
            if (otazkyquiz[Convert.ToInt32(btn.Tag) - 1].obrazek != null) // Obrázek
                pb_obrazek.Image = otazkyquiz[Convert.ToInt32(btn.Tag) - 1].obrazek;
            else
                pb_obrazek.Image = null;
            // Zda není zakliknutá odpověd
            if (otazkyquiz[Convert.ToInt32(btn.Tag) - 1].zakliknutyRB != null)
            {
                // Odpovězení na otázku -> Obarvení tlačítka, že je zakliknutý
                otazkyquiz[Convert.ToInt32(btn.Tag) - 1].zakliknutyRB.Checked = true;
                btns[Convert.ToInt32(btn.Tag) - 1].BackColor = Color.Blue;
            }
            try
            {
                if (otazkyquiz[Convert.ToInt32(btn.Tag) - 1].zakliknutyRB.Checked == true)
                    btns[Convert.ToInt32(btn.Tag) - 1].BackColor = Color.Blue;
            }
            catch (NullReferenceException)
            {

            }

            // Doplnění odpovědí k výberu u otázek
            for (int i = 1; i < 5; i++)
            {
                if (otazkyquiz[Convert.ToInt32(btn.Tag) - 1].pocetOdpovedi >= i)
                    nadpisy[i - 1].Text = otazkyquiz[Convert.ToInt32(btn.Tag) - 1].vyberodpovedi[i - 1];
                else
                {
                    // Schovej tlačítka
                    for (int k = i; k < 5; k++)
                    {
                        tlacitka[k - 1].Visible = false;
                        nadpisy[k - 1].Visible = false;
                    }
                    break;
                }
            }
            if (!vyhodnoceno)
            {
                // Pokud je zodpovězena otázka obarvy tlačítko na modrý
                for (int i = 0; i < 20; i++)
                    if (otazkyquiz[i].zakliknutyRB != null)
                        btns[i].BackColor = Color.Blue;

                // Obarvy tlačítka na výchozí barvu, pokud není otázka zodpovězena
                foreach (Control ctl in gp_otazky.Controls)
                    if (ctl is Button && ctl.BackColor != Color.Blue)
                        ctl.BackColor = Color.Gray;

                // Aktuální tlačítko
                btn.BackColor = Color.Cyan;
            }
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        private void rb(object sender, EventArgs e)
        {
            otazkyquiz[Convert.ToInt32(cislo) - 1].zakliknutyRB = (RadioButton)sender;
        }

        private void Vysvetleni_FormClosed(object sender, FormClosedEventArgs e)
        {
            ukazovatkomenu.Show();
        }
    }
    public class Otazka
    {
        public string otazka;
        public int pocetOdpovedi;
        public List<string> vyberodpovedi;
        public int spravnyvyber; // index
        public Image obrazek;
        public RadioButton zakliknutyRB;
        public bool JeSpravny
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(zakliknutyRB.Tag) == spravnyvyber)
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public Otazka(string otazka, int pocetOdpovedi, List<string> vyberodpovedi, int spravnyvyber)
        {
            this.otazka = otazka;
            this.pocetOdpovedi = pocetOdpovedi;
            this.vyberodpovedi = vyberodpovedi;
            this.spravnyvyber = spravnyvyber;
        }
        public Otazka(string otazka, int pocetOdpovedi, List<string> vyberodpovedi, int spravnyvyber, Image obrazek)
        {
            this.otazka = otazka;
            this.pocetOdpovedi = pocetOdpovedi;
            this.vyberodpovedi = vyberodpovedi;
            this.spravnyvyber = spravnyvyber;
            this.obrazek = obrazek;
        }
    }
}
