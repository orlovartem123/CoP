using ReznikovBusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ReznikovView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly StudentLogic logic;
        public FormMain(StudentLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            LoadData();
        }

        private void LoadData()
        {
            universityListBox1.LayoutString(" форма {EducationForm} ,  Id {Id} , Имя {FIO} , дата {ReceiptDate}", '{', '}');
            List<StudentViewModel> list = logic.Read(null);
            universityListBox1.Fill(list);
        }

        private void universityListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control)
        && e.KeyValue == 'A')
            {
                CreateStudent();
            }
            if (e.KeyCode == Keys.U && e.Control)
            {
                EditStudent();
            }
            if (e.KeyCode == Keys.D && e.Control)
            {
                DeleteStudent();
            }
            if (e.KeyCode == Keys.T && e.Control)
            {
                SaveToPDF();
            }
            if (e.KeyCode == Keys.S && e.Control)
            {
                SaveToExcel();
            }
            if (e.KeyCode == Keys.C && e.Control)
            {
                SaveToWord();  
            }
            if (e.KeyCode == Keys.R && e.Control)
            {
                LoadData();
            }
            if (e.KeyCode == Keys.E && e.Control)
            {
                CheckEducationForms();
            }
        }

        private void CheckEducationForms()
        {
            var form = Container.Resolve<FormList>();
            form.ShowDialog();
        }

        private void SaveToWord()
        {
        
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }

        private class StudentInnerClass
        {
            public int Id { set; get; }
            public string FIO { set; get; }
            public string EducationForm { set; get; }
            public DateTime ReceiptDate { set; get; }
        }
        private void SaveToExcel()
        {
            ExcelComponent excelComponent = new ExcelComponent();
            List<StudentInnerClass> students = new List<StudentInnerClass>();
            logic.Read(null).ForEach(rec=>students.Add(new StudentInnerClass { 
                Id=rec.Id,
                FIO=rec.FIO,
                EducationForm=rec.EducationForm,
                ReceiptDate=rec.ReceiptDate
            }));

            var dict = new Dictionary<string, int[]>();
            var array = new int[] { 2, 3 };
            var arrayHeader = new string[] { "Id", "ФИО", "Форма обучения", "Дата поступления"};
            var arrayHeight = new int[] { 20, 30, 20, 20 };

            dict.Add("Обучение", array);

            using (var dialog = new SaveFileDialog { Filter = "xls|*.xls" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    excelComponent.CreateFile(dialog.FileName, "Ученики", dict, arrayHeight, arrayHeader, students);
                }
            }
        }

        private void SaveToPDF()
        {
            FirstTableComponent TableComponent = new FirstTableComponent();

            List<StudentViewModel> students = logic.Read(null);
            string[,] tables = new string[students.Count,6];

            for (int i=0;i<students.Count;i++) {
                int j = 0;
                Dictionary<string, float> dictionary = students[i].AverageMarks;
                foreach (KeyValuePair<string, float> keyValue in dictionary) {
                    tables[i, j] = keyValue.Value.ToString();
                    j++;
                }
                for (; j < tables.GetLength(1); j++) {
                    tables[i, j] = " ";
                }
            }

            List<string[,]> list = new List<string[,]>();
            list.Add(tables);

            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TableComponent.SaveTable(dialog.FileName, "Отчет по студентам в таблице", list);
                }
            }
        }

        private void EditStudent()
        {
            var form = Container.Resolve<FormStudent>();
            StudentViewModel model = universityListBox1.GetItem<StudentViewModel>();
            form.Id = model.Id;
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DeleteStudent()
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    StudentViewModel model = universityListBox1.GetItem<StudentViewModel>();
                    logic.Delete(new StudentBindingModel { Id=model.Id});
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                LoadData();
            }
        }

        private void CreateStudent()
        {
            var form = Container.Resolve<FormStudent>();
            form.ShowDialog();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateStudent();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditStudent();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void создатьПростойДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToPDF();
        }

        private void создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToExcel();
        }

        private void создатьДокументСДаиграммамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToWord();
        }

    }
}
