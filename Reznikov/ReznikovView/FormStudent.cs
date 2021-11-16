using ReznikovBusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ReznikovView
{
    public partial class FormStudent : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly StudentLogic logic;
        private readonly EducationFormLogic educationFormLogic;
        public int Id { set { id = value; } }
        private int? id;
        public FormStudent(StudentLogic logic, EducationFormLogic educationFormLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.educationFormLogic = educationFormLogic;
            LoadData();
        }

        private void LoadData()
        {
            List<EducationFormViewModel> list = educationFormLogic.Read(null);
            List<string> names = new List<string>();
            foreach (var model in list) {
                names.Add(model.Name);
            }
            universityComboBox1.Fill(names);

            inputControl1.FirstDate = DateTime.Now.AddYears(-6);
            inputControl1.LastDate = DateTime.Now;
            inputControl1.value = DateTime.Now;

            if (id.HasValue) {
                StudentViewModel model = logic.Read(new StudentBindingModel { Id = id })[0];
                textBox1.Text = model.FIO;
                inputControl1.value = model.ReceiptDate;
                universityComboBox1.item = model.EducationForm;

                foreach (var pair in model.AverageMarks) {
                    dataGridView1.Rows.Add(pair.Key,pair.Value);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxPeriod.Text==null) {
                MessageBox.Show("Enter some period");
                return;
            }
            try {
                float number = float.Parse(textBoxMark.Text);
                string period = textBoxPeriod.Text;
                dataGridView1.Rows.Add(period,number);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==null)
            {
                MessageBox.Show("Enter FIO");
                return;
            }
            try
            {
                EducationFormViewModel educationForm = educationFormLogic.Read(new EducationFormBindingModel { 
                    Name = universityComboBox1.item 
                })[0];

                Dictionary<string, float> pairs = new Dictionary<string, float>();
                for (int i=0;i<dataGridView1.RowCount-1;i++) {
                    float number = float.Parse(dataGridView1[1, i].Value.ToString());
                    pairs.Add(dataGridView1[0,i].Value.ToString(), number);
                }

                StudentBindingModel model = new StudentBindingModel()
                {
                    ReceiptDate = inputControl1.value,
                    FIO = textBox1.Text,
                    EducationFormName = educationForm.Name,
                    AverageMarks = pairs,
                    Id = id
                };
                logic.CreateOrUpdate(model);
                MessageBox.Show("object added to the database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Данные будут утеряны", "Предупреждение",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK){
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null) {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                MessageBox.Show("String is deleted");
            }
        }
    }
}
