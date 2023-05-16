using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HledaciAlgoritmy
{
    public class Telo
    {
        // Tělo
        public string Name { get; set; }
        public Size Size { get; set; }
        public bool Enabled { get; set; }
        public string tag { get; set; }
        public Point Location { get; set; }
        public SolidBrush BackColor { get; set; }
        public Rectangle rectangle { get; set; }
    }
}
