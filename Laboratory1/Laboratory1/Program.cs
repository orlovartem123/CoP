using Library;
using System;
using System.Collections.Generic;
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
                new String[,]{ { "Liza1","Liza2","Liza3"},{ "Andrey1","Andrey2","Andrey3"},{"Stephan1","Stephan2","Stephan3" }, {"Jan1","Jan2","Jan3" } },
                new String[,]{ { "1","2","3","4"},{ "11","22","33", "44"},{"111","222","333", "444"} }
            };
            TableComponent tc = new TableComponent();
            tc.SaveTable("D://foulder.pdf", "Title", list);

            //Application.Run(new FormMain());
        }
    }
}
