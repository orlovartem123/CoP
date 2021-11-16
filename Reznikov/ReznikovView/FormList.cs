using ReznikovBusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ReznikovView
{
    public partial class FormList : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        EducationFormLogic logic;
        public FormList(EducationFormLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            LoadData();
        }

        private void LoadData()
        {
            List<EducationFormViewModel> list = logic.Read(null);
            foreach (var edu in list)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = edu.Name;
                dataGridView1.Rows.Add(row);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == "")
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
            dataGridView1.Refresh();
        }

        private void universityListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control)
        && e.KeyValue == (char)Keys.Insert)
            {
                AddRow();
            }
            if (e.KeyCode == Keys.D && e.Control)
            {
                DeleteRow();
            }
        }

        private void AddRow()
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = "";
            dataGridView1.Rows.Add(row);
            dataGridView1.ClearSelection();
            row.Selected = true;
            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(true);
        }

        private void DeleteRow()
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows != null)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == "")
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        private void FormList_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<EducationFormBindingModel> list = new List<EducationFormBindingModel>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null) list.Add(new EducationFormBindingModel { Name = row.Cells[0].Value.ToString() });
            }
            logic.ReFill(list);
        }
    }
}
