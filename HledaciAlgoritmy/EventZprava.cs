using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HledaciAlgoritmy
{
    public enum TypEventOdpoved
    {
        YesNo, // Ano/Ne
        Ok, // Ok
    }
    public enum TypUcel
    {
        Uspech, // Úspěch
        Chyba, // Chyba
        Varovani, // Varování
        Informace // Informace
    }
    public enum TypZprava
    {
        Quiz,
        Proces,
        Soubor, // Chyba ohledně načítání/ukládání
        Data,
        Mapa // Chyba ohledně mapy, (např. není konec/start a nebo jinačí poškození)
    }
    public enum Odpoved
    {
        Yes, // Ano
        No, // Ne
        Ok // Ok
    }
    public partial class EventZprava : Form
    {
        public EventZprava()
        {
            InitializeComponent();
        }

        static EventZprava eventzprava;
        static Odpoved odpoved;

        public static Odpoved Show(TypZprava zprava, TypUcel ucel, TypEventOdpoved eve)
        {
            eventzprava = new EventZprava();
            DoplnData(zprava, ucel, eve, null);
            eventzprava.ShowDialog();
            return odpoved;
        }
        public static Odpoved Show(TypZprava zprava, TypUcel ucel, TypEventOdpoved eve, string[] data)
        {
            eventzprava = new EventZprava();
            DoplnData(zprava, ucel, eve, data);
            eventzprava.ShowDialog();
            return odpoved;
        }
        public static void DoplnData(TypZprava zprava, TypUcel ucel, TypEventOdpoved eve, string[] data)
        {
            // EventOdpoveď ok
            if (eve == TypEventOdpoved.Ok)
            {
                eventzprava.bt_yes.Visible = false;
                eventzprava.bt_no.Visible = false;
            }
            // EventOdpoved Yes/No
            else
                eventzprava.bt_ok.Visible = false;

            //
            // ÚČEL
            //
            switch (ucel)
            {
                case TypUcel.Chyba:
                    eventzprava.pb_obrazek.BackgroundImage = Properties.Resources.Chyba;
                    eventzprava.lb_Uvodninapis.Text = "Chyba";
                    eventzprava.Text = "Chyba";
                    eventzprava.lb_Uvodninapis.ForeColor = Color.Red;
                    break;
                case TypUcel.Informace:
                    eventzprava.pb_obrazek.BackgroundImage = Properties.Resources.Informace;
                    eventzprava.lb_Uvodninapis.Text = "Informace";
                    eventzprava.Text = "Informace";
                    eventzprava.lb_Uvodninapis.ForeColor = Color.FromArgb(235, 238, 111);
                    break;
                case TypUcel.Uspech:
                    eventzprava.pb_obrazek.BackgroundImage = Properties.Resources.Uspech;
                    eventzprava.lb_Uvodninapis.Text = "Úspěch";
                    eventzprava.Text = "Úspěch";
                    eventzprava.lb_Uvodninapis.ForeColor = Color.FromArgb(126, 211, 33);
                    break;
                case TypUcel.Varovani:
                    eventzprava.pb_obrazek.BackgroundImage = Properties.Resources.Varovani;
                    eventzprava.lb_Uvodninapis.Text = "Varování";
                    eventzprava.Text = "Varování";
                    eventzprava.lb_Uvodninapis.ForeColor = Color.FromArgb(245, 166, 35);
                    break;
            }
            //
            // ZPRÁVA
            //
            switch (zprava)
            {
                case TypZprava.Data:
                    if (ucel == TypUcel.Chyba)
                    {
                        eventzprava.tb_telo.Text = "Došlo k neočekávánému problému s daty"
                        + Environment.NewLine + "Možné příčiny:"
                        + Environment.NewLine + "- Byly zadány nevalidní data";
                    }
                    else if (ucel == TypUcel.Uspech)
                        eventzprava.tb_telo.Text = "Konfigurace byla úspěšně uložena!";
                    else if (ucel == TypUcel.Informace)
                        eventzprava.tb_telo.Text = "Konfigurace byla úspěšně uložena!";
                    break;
                case TypZprava.Mapa:
                    if (ucel == TypUcel.Chyba)
                    {
                        eventzprava.tb_telo.Text = "Došlo k neočekávanému problému v mapě!"
                            + Environment.NewLine + "Možné příčiny:"
                            + Environment.NewLine + " - Zkontroluj zda mapa obsahuje start a cíl"
                            + Environment.NewLine + " - Zkontroluj zda je možné se ke startu/cíli dostat"
                            + Environment.NewLine + " - Zkontroluj zda je mapa v pořádku";
                    }
                    else if (ucel == TypUcel.Uspech)
                    {
                        eventzprava.tb_telo.Text = "Porovnávání bylo úspěšně dokončeno!"
                            + Environment.NewLine + "Výsledky: "
                            + Environment.NewLine + "                       A*        BFS         DFS         Dijkstra"
                            + Environment.NewLine + "Cesta:           " + data[0] + "         " + data[3] + "         " + data[6] + "         " + data[9]
                            + Environment.NewLine + "Uzly:              " + data[1] + "         " + data[4] + "         " + data[7] + "         " + data[10]
                            + Environment.NewLine + "Vzdálenost:  " + data[2] + "       " + data[5] + "       " + data[8] + "      " + data[11];
                    }
                    break;
                case TypZprava.Quiz:
                    if (ucel == TypUcel.Uspech)
                    {
                        eventzprava.tb_telo.Text = "Quiz byl úspěšně dokončen!"
                            + Environment.NewLine + ""
                            + Environment.NewLine + "Celkem správně zodpovězeno: " + data[0] + "/20"
                            + Environment.NewLine + "Procentuálně: " + (Convert.ToDouble(data[0]) / 20) * 100 + "%"; 
                    }
                    else if (ucel == TypUcel.Chyba)
                    {

                    }
                    else if (ucel == TypUcel.Varovani)
                    {
                        eventzprava.tb_telo.Text = "Chystáte se spustit quiz."
                        + Environment.NewLine + " - Před jeho spuštěním je důležité projít výukou"
                        + Environment.NewLine + " - Po jeho spuštění je třeba ho dokončit"
                        + Environment.NewLine + ""
                        + Environment.NewLine + "Chcete spustit quiz?";
                    }
                    break;
                case TypZprava.Proces:
                    if (data != null)
                    {
                        eventzprava.tb_telo.Text = "Proces byl úspěšně dokončen!"
                        + Environment.NewLine + "Výsledek:"
                        + Environment.NewLine + " - Počet prohledaných uzlů: " + data[0]
                        + Environment.NewLine + " - Délka cesty podle počtu uzlů: " + data[1]
                        + Environment.NewLine + " - Délka cesty podle vzdálenosti: " + data[2]
                        + Environment.NewLine + " - Použitý algoritmus: " + data[3];
                    }
                    break;
                case TypZprava.Soubor:
                    if (ucel == TypUcel.Chyba)
                    {
                        eventzprava.tb_telo.Text = "Došlo neočekávanému problém se souborem."
                        + Environment.NewLine + "Možné příčiny:"
                        + Environment.NewLine + " - Soubor je poškozen"
                        + Environment.NewLine + " - Soubor nebyl správně načten"
                        + Environment.NewLine + " - Nebyl zvolen validní soubor";
                    }
                    else if (ucel == TypUcel.Uspech)
                        eventzprava.tb_telo.Text = "Soubor byl úspěšně uložen!";
                    break;
            }
            SystemSounds.Hand.Play();
        }
        private void bt_ok_Click(object sender, EventArgs e)
        {
            odpoved = Odpoved.Ok;
            eventzprava.Dispose();
        }

        private void bt_no_Click(object sender, EventArgs e)
        {
            odpoved = Odpoved.No;
            eventzprava.Dispose();
        }

        private void bt_yes_Click(object sender, EventArgs e)
        {
            odpoved = Odpoved.Yes;
            eventzprava.Dispose();
        }
    }
}
