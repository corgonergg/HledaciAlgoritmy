using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum Vysledek
{
    Yes,
    No,
    Ok,

}
namespace HledaciAlgoritmy
{
    public static class Pozadi
    {
        public static void InterakceControlu(bool truefalse, List<Control> controls)
        {
            // Zablokuje tlačítka
            foreach (Control ctrl in controls)
            {
                if (truefalse)
                    ctrl.Enabled = true;
                else
                    ctrl.Enabled = false;
            }
        }
        private static Random rnd = new Random();
        public static void Zamichani<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
