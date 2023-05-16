using HledaciAlgoritmy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HledaciAlgoritmy
{
    public partial class UvodniForm : Form
    {
        public UvodniForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.route;
        } 

        private void bt_start_Click(object sender, EventArgs e)
        {
            new Rozhrani(this).Show();
            this.Hide();
        }

        private void bt_information_Click(object sender, EventArgs e)
        {
            new Vysvetleni(this).Show();
            this.Hide();
        }

        private void bt_comparation_Click(object sender, EventArgs e)
        {
            new Comparation(this).Show();
            this.Hide();
        }

        private void bt_option_Click(object sender, EventArgs e)
        {
            new Nastaveni(this).Show();
            this.Hide();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UvodniForm_Load(object sender, EventArgs e)
        {
            //
            // DOPLNĚNÍ VÝCHOZÍCH STAVŮ POKUD NEJSOU
            //
            background.RunWorkerAsync();

            // VÝCHOZÍ CESTY

            if (Application.StartupPath + "\\Saves" != Settings.Default.VychoziCesta)
            {
                Nastaveni.VychoziCesta = Application.StartupPath + "\\Saves";
                Settings.Default.VychoziCesta = Application.StartupPath + "\\Saves";
                Settings.Default.Save();
            }

            string[] str1 = Settings.Default.start.Split('|');
            string[] str2 = Settings.Default.konec.Split('|');
            string[] str3 = Settings.Default.zed.Split('|');
            string[] str4 = Settings.Default.silnice.Split('|');
            string[] str5 = Settings.Default.Obj5.Split('|');
            string[] str6 = Settings.Default.Obj6.Split('|');
            string[] str7 = Settings.Default.Obj7.Split('|');
            string[] str8 = Settings.Default.Obj8.Split('|');

            string[][] cesty = new string[][] { str1, str2, str3, str4, str5, str6, str7, str8 };

            //MessageBox.Show(str1[0] + " " + str1[1] + " " + str1[2] + " " + str1[3] + " " + str1[4] + " " + str1[5]);

            for (int i = 1; i <= 8; i++)
            {
                try
                {
                    File.Copy(cesty[i - 1][0], Application.StartupPath + "\\Images" + "\\obj" + i + ".png", true);
                }
                catch (Exception)
                {

                }


                string cestakSouboru = "";
                string nazev = "";
                string vaha = "";
                string dostupnost = "";
                string limit = "";
                string limitPocet = "";


                ////////////////////////////////////////
                // CESTA K SOUBORU 1.
                if (cesty[i - 1][0] != Application.StartupPath + "\\Images" + "\\obj" + i + ".png")
                {
                    cesty[i - 1][0] = Application.StartupPath + "\\Images" + "\\obj" + i + ".png"; // ODKAZY NA OBRÁZKY
                    cestakSouboru = cesty[i - 1][0] + "|"; // OK
                }
                else
                    cestakSouboru = cesty[i - 1][0] + "|"; // OK
                ////////////////////////////////////////
                
                ////////////////////////////////////////
                // NÁZEV 2.
                if (cesty[i - 1][1] != "")
                    nazev = cesty[i - 1][1] + "|";
                else
                {
                    switch (i)
                    {
                        case 1:
                            nazev = "Start|";
                            break;
                        case 2:
                            nazev = "Konec|";
                            break;
                        case 3:
                            nazev = "Zed|";
                            break;
                        case 4:
                            nazev = "Cesta|";
                            break;
                        case 5:
                            nazev = "Les|";
                            break;
                        case 6:
                            nazev = "Voda|";
                            break;
                        case 7:
                            nazev = "None|";
                            break;
                        case 8:
                            nazev = "None|";
                            break;
                    } // VÝBĚR NÁZVU V ZÁVISLOSTI NA I
                }
                ////////////////////////////////////////

                ////////////////////////////////////////
                // VÁHA 3.
                if (int.TryParse(cesty[i - 1][2], out int result))
                    vaha = cesty[i - 1][2] + "|";
                else
                {
                    if (i == 5)
                        vaha = "80|";
                    else
                        vaha = "0|";
                }
                ////////////////////////////////////////

                ////////////////////////////////////////
                // DOSTUPNOST
                if (bool.TryParse(cesty[i - 1][3], out bool result2))
                    dostupnost = cesty[i - 1][3] + "|";
                else
                {
                    if (i == 3 || i == 6)
                        dostupnost = "False|";
                    else
                        dostupnost = "True|";
                }
                ////////////////////////////////////////

                ////////////////////////////////////////
                // LIMIT
                if (bool.TryParse(cesty[i - 1][4], out bool result3))
                    limit = cesty[i - 1][4] + "|";
                else
                {
                    if (i == 1)
                        limit = "True|";
                    else
                        limit = "False|";
                }
                ////////////////////////////////////////

                ////////////////////////////////////////
                // LIMIT POCET
                if (int.TryParse(cesty[i - 1][5], out int result4))
                    limitPocet = cesty[i - 1][5];
                else
                {
                    if (i == 1)
                        limitPocet = "1";
                    else
                        limitPocet = "0";
                }
                ////////////////////////////////////////

                // SPOJENÍ ÚDAJŮ
                string udaje = cestakSouboru + nazev + vaha + dostupnost + limit + limitPocet;
                //string udaje = cesty[i - 1][0] + "|" + cesty[i - 1][1] + "|" + cesty[i - 1][2] + "|" + cesty[i - 1][3] + "|" + cesty[i - 1][4] + "|" + cesty[i - 1][5];
                switch (i)
                {
                    case 1:
                        Settings.Default.start = udaje;
                        break;
                    case 2:
                        Settings.Default.konec = udaje;
                        break;
                    case 3:
                        Settings.Default.zed = udaje;
                        break;
                    case 4:
                        Settings.Default.silnice = udaje;
                        break;
                    case 5:
                        Settings.Default.Obj5 = udaje;
                        break;
                    case 6:
                        Settings.Default.Obj6 = udaje;
                        break;
                    case 7:
                        Settings.Default.Obj7 = udaje;
                        break;
                    case 8:
                        Settings.Default.Obj8 = udaje;
                        break;
                }
                Settings.Default.Save();
            }
            //MessageBox.Show(str1[0] + " " + str1[1] + " " + str1[2] + " " + str1[3] + " " + str1[4] + " " + str1[5]);
        }

        private void background_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // HOTOVO
            background.CancelAsync();
        }

        private void background_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value += e.ProgressPercentage;
        }
    }
}
