using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<String[,]> list = new List<String[,]>() {
                new String[,]{ { "Liza1","Liza2","Liza3"},{ "Andrey1","Andrey2","Andrey3"},{"Stephan1","Stephan2","Stephan3" }, {"Jan1","Jan2","Jan3" } }
            };
            TableComponent tc = new TableComponent();
            tc.SaveTable("D://foulder.pdf", "Title", list);

            Application.Run(new FormMain());
        }
    }
}
