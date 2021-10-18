using Library;
using Library.HelperModels;
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

            TestSecondComponent();
            TestThirdComponent();
        }



        private static void TestSecondComponent() {
            SecondTableComponent secondTableComponent = new SecondTableComponent();
            string foulder = "D:\\foulder.pdf";
            string title = "Title";

            List<TableColumnHelper> columnHelpers = new List<TableColumnHelper>();
            TableRowHelper[] rowHelpers = new TableRowHelper[2];
            List<Student> students = new List<Student>();

            List<string> names = new List<string>();
            names.Add("Vania");
            names.Add("Sasha");
            names.Add("Aleksey");
            names.Add("Danila");

            List<string> surnames = new List<string>();
            surnames.Add("Kon");
            surnames.Add("Tron");
            surnames.Add("Sort");
            surnames.Add("Tort");

            List<string> middleNames = new List<string>();
            middleNames.Add("Vaniavich");
            middleNames.Add("Sashevich");
            middleNames.Add("Aleksevich");
            middleNames.Add("Danilich");

            List<string> groups = new List<string>();
            groups.Add("PIbd");
            groups.Add("ISEbd");

            Random random = new Random();
            for (int i = 0; i < names.Count; i++)
            {
                Student student = new Student();
                student.Name = names[i];
                student.Surname = surnames[i];
                student.MiddleName = middleNames[i];

                student.Id = i;
                student.GroupName = random.NextDouble() >= 0.5 ? groups[1] : groups[0];
                student.IsStuding = random.NextDouble() >= 0.5;
                student.Age = random.Next(15, 30);
                student.Rating = random.NextDouble() * 100;

                students.Add(student);
            }

            columnHelpers.Add(new TableColumnHelper { Name = "Name", PropertyName = "Name" });
            columnHelpers.Add(new TableColumnHelper { Name = "Age", PropertyName = "Age" });
            columnHelpers.Add(new TableColumnHelper { Name = "Rating", PropertyName = "Rating" });

            rowHelpers[0] = new TableRowHelper() { Height = 50 };
            rowHelpers[1] = new TableRowHelper() { Height = 50 };

            secondTableComponent.SaveTable(foulder, title, columnHelpers, rowHelpers, students);
        }



        private static void TestThirdComponent() {
            
        }
    }
}
