using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HledaciAlgoritmy
{
    public class Konfigurace
    {
        // Mapa plátno
        public int xVelikost { get; set; }
        public int yVelikost { get; set; }
        // Mapa políčka
        public Objekt[,] Policka { get; set; }
    }
    public class Objekt
    {
        public bool dostupny { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Telo telo { get; set; }
        public Policko otec { get; set; }
        public List<Policko> sousedi { get; set; }
        public Typpolicko _typ { get; set; }
    }
}
