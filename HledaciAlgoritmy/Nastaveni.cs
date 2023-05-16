using HledaciAlgoritmy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HledaciAlgoritmy
{
    public partial class Nastaveni : Form
    {
        public Nastaveni(UvodniForm ukazovatkomenu)
        {
            InitializeComponent();
            this.ukazovatkomenu = ukazovatkomenu;

            string[] str1 = start.Split('|'); // Objekt 1
            string[] str2 = konec.Split('|'); // Objekt 2
            string[] str3 = zed.Split('|'); // Objekt 3
            string[] str4 = silnice.Split('|'); // Objekt 4
            string[] str5 = obj5.Split('|'); // Objekt 5 
            string[] str6 = obj6.Split('|'); // Objekt 6
            string[] str7 = obj7.Split('|'); // Objekt 7
            string[] str8 = obj8.Split('|'); // Objekt 8
            cestyKObrObjs = new string[8]
            {
                str1[0],
                str2[0],
                str3[0],
                str4[0],
                str5[0],
                str6[0],
                str7[0],
                str8[0],
            };
        }
        UvodniForm ukazovatkomenu;
        string[] cestyKObrObjs;

        // typ vykreslování k odeslání pro editor
        public static bool _Vykreslovani = true;
        public static string Vykreslovani = Settings.Default.Vykreslovani;
        public static string VychoziCesta = Settings.Default.VychoziCesta;
        public static Color BarvaCesta = Settings.Default.BarvaCesta;
        public static Color BarvaProhledany = Settings.Default.BarvaProhledany;
        public static string start = Settings.Default.start;
        public static string konec = Settings.Default.konec;
        public static string zed = Settings.Default.zed;
        public static string silnice = Settings.Default.silnice;
        public static string obj5 = Settings.Default.Obj5;
        public static string obj6 = Settings.Default.Obj6;
        public static string obj7 = Settings.Default.Obj7;
        public static string obj8 = Settings.Default.Obj8;

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Loadování a doplnění konfigurace do interfaců
        private void Nastaveni_Load(object sender, EventArgs e)
        {
            //ConvertujObjs();

            // Výchozí hodnoty
            rb_ctverec.Enabled = true;
            rb_elipsa.Enabled = true;

            if (Vykreslovani == "ctverec")
                rb_ctverec.Checked = true;
            else if (Vykreslovani == "objekty")
                rb_elipsa.Checked = true;

            tb_cfd_cesta.BackColor = BarvaCesta;
            tb_cfd_prohledany.BackColor = BarvaProhledany;
            tb_cestaukladani.Text = VychoziCesta;


            _Vykreslovani = Settings.Default._Vykreslovani;
            Vykreslovani = Settings.Default.Vykreslovani;
            VychoziCesta = Settings.Default.VychoziCesta;
            BarvaCesta = Settings.Default.BarvaCesta;
            BarvaProhledany = Settings.Default.BarvaProhledany;

            DeconvertujObjs();
        }
        public void ConvertujObjs()
        {
            start = cestyKObrObjs[0] + "|" + tb_obj1_nazev.Text + "|" + tb_obj1_hodnota.Text + "|" + tb_obj1_dostupnost.SelectedItem + "|" + tb_obj1_limitTF.SelectedItem + "|" + tb_obj1_limitPOCET.Text;
            konec = cestyKObrObjs[1] + "|" + tb_obj2_nazev.Text + "|" + tb_obj2_hodnota.Text + "|" + tb_obj2_dostupnost.SelectedItem + "|" + tb_obj2_limitTF.SelectedItem + "|" + tb_obj2_limitPOCET.Text;
            zed = cestyKObrObjs[2] + "|" + tb_obj3_nazev.Text + "|" + tb_obj3_hodnota.Text + "|" + tb_obj3_dostupnost.SelectedItem + "|" + tb_obj3_limitTF.SelectedItem + "|" + tb_obj3_limitPOCET.Text;
            silnice = cestyKObrObjs[3] + "|" + tb_obj4_nazev.Text + "|" + tb_obj4_hodnota.Text + "|" + tb_obj4_dostupnost.SelectedItem + "|" + tb_obj4_limitTF.SelectedItem + "|" + tb_obj4_limitPOCET.Text;
            obj5 = cestyKObrObjs[4] + "|" + tb_obj5_nazev.Text + "|" + tb_obj5_hodnota.Text + "|" + tb_obj5_dostupnost.SelectedItem + "|" + tb_obj5_limitTF.SelectedItem + "|" + tb_obj5_limitPOCET.Text;
            obj6 = cestyKObrObjs[5] + "|" + tb_obj6_nazev.Text + "|" + tb_obj6_hodnota.Text + "|" + tb_obj6_dostupnost.SelectedItem + "|" + tb_obj6_limitTF.SelectedItem + "|" + tb_obj6_limitPOCET.Text;
            obj7 = cestyKObrObjs[6] + "|" + tb_obj7_nazev.Text + "|" + tb_obj7_hodnota.Text + "|" + tb_obj7_dostupnost.SelectedItem + "|" + tb_obj7_limitTF.SelectedItem + "|" + tb_obj7_limitPOCET.Text;
            obj8 = cestyKObrObjs[7] + "|" + tb_obj8_nazev.Text + "|" + tb_obj8_hodnota.Text + "|" + tb_obj8_dostupnost.SelectedItem + "|" + tb_obj8_limitTF.SelectedItem + "|" + tb_obj8_limitPOCET.Text;
        }
        public void DeconvertujObjs()
        {
            // Doplň do textboxů
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            #region TB1 - Ukon1
            string[] str1 = start.Split('|');
            bt_obj1.BackgroundImage = Image.FromFile(str1[0]);
            bt_obj1.Text = "";
            tb_obj1_nazev.Text = str1[1];
            tb_obj1_hodnota.Text = str1[2];
            tb_obj1_dostupnost.SelectedItem = str1[3];
            tb_obj1_limitTF.SelectedItem = str1[4];
            tb_obj1_limitPOCET.Text = str1[5];
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            #region TB2 - Ukon2
            string[] str2 = konec.Split('|');
            bt_obj2.BackgroundImage = Image.FromFile(str2[0]);
            bt_obj2.Text = "";
            tb_obj2_nazev.Text = str2[1];
            tb_obj2_hodnota.Text = str2[2];
            tb_obj2_dostupnost.SelectedItem = str2[3];
            tb_obj2_limitTF.SelectedItem = str2[4];
            tb_obj2_limitPOCET.Text = str2[5];
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            #region TB3 - Ukon3
            string[] str3 = zed.Split('|');
            bt_obj3.BackgroundImage = Image.FromFile(str3[0]);
            bt_obj3.Text = "";
            tb_obj3_nazev.Text = str3[1];
            tb_obj3_hodnota.Text = str3[2];
            tb_obj3_dostupnost.SelectedItem = str3[3];
            tb_obj3_limitTF.SelectedItem = str3[4];
            tb_obj3_limitPOCET.Text = str3[5];
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            #region TB4 - Ukon4
            string[] str4 = silnice.Split('|');
            bt_obj4.BackgroundImage = Image.FromFile(str4[0]);
            bt_obj4.Text = "";
            tb_obj4_nazev.Text = str4[1];
            tb_obj4_hodnota.Text = str4[2];
            tb_obj4_dostupnost.SelectedItem = str4[3];
            tb_obj4_limitTF.SelectedItem = str4[4];
            tb_obj4_limitPOCET.Text = str4[5];
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            #region TB5 - Ukon5
            string[] str5 = obj5.Split('|');
            bt_obj5.BackgroundImage = Image.FromFile(str5[0]);
            bt_obj5.Text = "";
            tb_obj5_nazev.Text = str5[1];
            tb_obj5_hodnota.Text = str5[2];
            tb_obj5_dostupnost.SelectedItem = str5[3];
            tb_obj5_limitTF.SelectedItem = str5[4];
            tb_obj5_limitPOCET.Text = str5[5];
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            #region TB6 - Ukon6
            string[] str6 = obj6.Split('|');
            bt_obj6.BackgroundImage = Image.FromFile(str6[0]);
            bt_obj6.Text = "";
            tb_obj6_nazev.Text = str6[1];
            tb_obj6_hodnota.Text = str6[2];
            tb_obj6_dostupnost.SelectedItem = str6[3];
            tb_obj6_limitTF.SelectedItem = str6[4];
            tb_obj6_limitPOCET.Text = str6[5];
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            #region TB7 - Ukon7
            string[] str7 = obj7.Split('|');
            bt_obj7.BackgroundImage = Image.FromFile(str7[0]);
            bt_obj7.Text = "";
            tb_obj7_nazev.Text = str7[1];
            tb_obj7_hodnota.Text = str7[2];
            tb_obj7_dostupnost.SelectedItem = str7[3];
            tb_obj7_limitTF.SelectedItem = str7[4];
            tb_obj7_limitPOCET.Text = str7[5];
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            #region TB8 - Ukon8
            string[] str8 = obj8.Split('|');
            bt_obj8.BackgroundImage = Image.FromFile(str8[0]);
            bt_obj8.Text = "";
            tb_obj8_nazev.Text = str8[1];
            tb_obj8_hodnota.Text = str8[2];
            tb_obj8_dostupnost.SelectedItem = str8[3];
            tb_obj8_limitTF.SelectedItem = str8[4];
            tb_obj8_limitPOCET.Text = str8[5];
            #endregion
            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        }
        private void zmena(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "rb_ctverec":
                    Vykreslovani = "ctverec";
                    break;
                case "rb_elipsa":
                    Vykreslovani = "objekty";
                    break;
                case "cb_vykreslovanipolicek":
                    _Vykreslovani = !_Vykreslovani;
                    if (_Vykreslovani)
                    {
                        rb_ctverec.Enabled = true;
                        rb_elipsa.Enabled = true;
                    }
                    else
                    {
                        rb_ctverec.Enabled = false;
                        rb_elipsa.Enabled = false;
                    }
                    break;
                case "tb_cestaukladani":
                    VychoziCesta = tb_cestaukladani.Text;
                    break;
                case "tb_cfd_cesta":
                    BarvaCesta = tb_cfd_cesta.BackColor;
                    break;
                case "tb_cfd_prohledany":
                    BarvaProhledany = tb_cfd_prohledany.BackColor;
                    break;
                default:
                    throw new Exception("Neznám sendera!");              
            }
                
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Editace objektů
        private void bt_ulozit_Click(object sender, EventArgs e)
        {
            // Ostatní objekty
            Settings.Default.Vykreslovani = Vykreslovani;
            Settings.Default._Vykreslovani = _Vykreslovani;
            Settings.Default.VychoziCesta = VychoziCesta;
            Settings.Default.BarvaCesta = BarvaCesta;
            Settings.Default.BarvaProhledany = BarvaProhledany;
            // Objekty
            ConvertujObjs();

            Settings.Default.start = start;
            Settings.Default.konec = konec;
            Settings.Default.zed = zed;
            Settings.Default.silnice = silnice;
            Settings.Default.Obj5 = obj5;
            Settings.Default.Obj6 = obj6;
            Settings.Default.Obj7 = obj7;
            Settings.Default.Obj8 = obj8;

            Settings.Default.Save();
            EventZprava.Show(TypZprava.Data, TypUcel.Informace, TypEventOdpoved.Ok);
        }
        private void bt_zmenitcestu_Click(object sender, EventArgs e)
        {
            tb_cestaukladani.Text = CestaUkladani();
        }
        private void bt_ZmenObrazek(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // Určení na který obrázek bylo kliknuto.
            OpenFileDialog ofd = new OpenFileDialog(); // OpenFileDialog
            ofd.Title = "Najdi příslušný obrázek"; // Titulek
            ofd.CheckFileExists = true; 
            ofd.Filter = "Image Files(*.PNG;*.JPG;*.BMP)|*.PNG;*.JPG;*.BMP|All files (*.*) | *.*";
            try
            {
                if (ofd.ShowDialog() != DialogResult.OK) // Pokud vše proběhla jak má
                    throw new Exception("Chyba");
                btn.BackgroundImage = Image.FromFile(ofd.FileName); // Nastav obrázek do pozadí tlačítku
                btn.Text = ""; 
                int index = Convert.ToInt32(btn.Name[btn.Name.Length - 1].ToString()) - 1;
                cestyKObrObjs[index] = ofd.FileName; // Cesta k obrázku
            }
            catch (Exception)
            {

            }
            finally
            {
                ofd.Dispose();
            }
        }
        private void smazatObj(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // Určení na který obrázek bylo kliknuto
            string cestakObr = Application.StartupPath + "\\ImagesZaloha" + "\\"; 
            switch (btn.Name[btn.Name.Length - 1].ToString())
            {
                case "1":
                    bt_obj1.BackgroundImage = Image.FromFile(cestakObr + "obj1.png");
                    cestyKObrObjs[0] = cestakObr + "obj1.png";
                    tb_obj1_nazev.Text = "Start";
                    tb_obj1_hodnota.Value = 0;
                    tb_obj1_dostupnost.SelectedItem = "True";
                    tb_obj1_limitTF.SelectedItem = "True";
                    tb_obj1_limitPOCET.Value = 1;
                    break;
                case "2":
                    bt_obj2.BackgroundImage = Image.FromFile(cestakObr + "obj2.png");
                    cestyKObrObjs[1] = cestakObr + "obj2.png";
                    tb_obj2_nazev.Text = "Konec";
                    tb_obj2_hodnota.Value = 0;
                    tb_obj2_dostupnost.SelectedItem = "True";
                    tb_obj2_limitTF.SelectedItem = "False";
                    tb_obj2_limitPOCET.Value = 0;
                    break;
                case "3":
                    bt_obj3.BackgroundImage = Image.FromFile(cestakObr + "obj3.png");
                    cestyKObrObjs[2] = cestakObr + "obj3.png";
                    tb_obj3_nazev.Text = "Zed";
                    tb_obj3_hodnota.Value = 0;
                    tb_obj3_dostupnost.SelectedItem = "False";
                    tb_obj3_limitTF.SelectedItem = "False";
                    tb_obj3_limitPOCET.Value = 0;
                    break;
                case "4":
                    bt_obj4.BackgroundImage = Image.FromFile(cestakObr + "obj4.png");
                    cestyKObrObjs[3] = cestakObr + "obj4.png";
                    tb_obj4_nazev.Text = "Cesta";
                    tb_obj4_hodnota.Value = 0;
                    tb_obj4_dostupnost.SelectedItem = "True";
                    tb_obj4_limitTF.SelectedItem = "False";
                    tb_obj4_limitPOCET.Value = 0;
                    break;
                case "5":
                    bt_obj5.BackgroundImage = Image.FromFile(cestakObr + "obj5.png");
                    cestyKObrObjs[4] = cestakObr + "obj5.png";
                    tb_obj5_nazev.Text = "Les";
                    tb_obj5_hodnota.Value = 80;
                    tb_obj5_dostupnost.SelectedItem = "True";
                    tb_obj5_limitTF.SelectedItem = "False";
                    tb_obj5_limitPOCET.Value = 0;
                    break;
                case "6":
                    bt_obj6.BackgroundImage = Image.FromFile(cestakObr + "obj6.png");
                    cestyKObrObjs[5] = cestakObr + "obj6.png";
                    tb_obj6_nazev.Text = "Voda";
                    tb_obj6_hodnota.Value = 0;
                    tb_obj6_dostupnost.SelectedItem = "False";
                    tb_obj6_limitTF.SelectedItem = "False";
                    tb_obj6_limitPOCET.Value = 0;
                    break;
                case "7":
                    bt_obj7.BackgroundImage = Image.FromFile(cestakObr + "obj7.png");
                    cestyKObrObjs[6] = cestakObr + "obj7.png";
                    bt_obj7.Text = "+";
                    tb_obj7_nazev.Text = "None";
                    tb_obj7_hodnota.Value = 0;
                    tb_obj7_dostupnost.SelectedItem = "True";
                    tb_obj7_limitTF.SelectedItem = "False";
                    tb_obj7_limitPOCET.Value = 0;
                    break;
                case "8":
                    bt_obj8.BackgroundImage = Image.FromFile(cestakObr + "obj8.png");
                    cestyKObrObjs[7] = cestakObr + "obj8.png";
                    bt_obj8.Text = "+";
                    tb_obj8_nazev.Text = "None";
                    tb_obj8_hodnota.Value = 0;
                    tb_obj8_dostupnost.SelectedItem = "True";
                    tb_obj8_limitTF.SelectedItem = "False";
                    tb_obj8_limitPOCET.Value = 0;
                    break;
            }
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        #region Ostatní
        private void tb_cfd_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.AnyColor = true;
            cd.FullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
                ((Control)sender).BackColor = cd.Color;
        }
        public static string CestaUkladani()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Zvol výchozí cestu ukládání";
            fbd.SelectedPath = VychoziCesta;
            DialogResult vysledek = fbd.ShowDialog();
            if (vysledek == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                Nastaveni.VychoziCesta = fbd.SelectedPath;
            return fbd.SelectedPath;
        }

        private void Nastaveni_FormClosed(object sender, FormClosedEventArgs e)
        {
            ukazovatkomenu.Show();
        }
        #endregion
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

    }
}
