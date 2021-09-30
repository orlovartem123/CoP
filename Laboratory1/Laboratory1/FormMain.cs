using Laboratory1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory1
{
    public partial class FormMain : Form
    {
        List<String> list = new List<string> {
            "Liza","Andrey","Stephan"
        };

        List<Student> studList = new List<Student> {
            new Student{ Age=21,
             IsStuding=true,
             Name="Lisa"},
            new Student{  Age=22,
             IsStuding=false,
             Name="Andrey"},
            new Student{  Age=23,
             IsStuding=true,
             Name="Stephan"},
            new Student{  Age=24,
             IsStuding=true,
             Name="Vlad"}
        };

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            component11.FillList(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            component11.CleanList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(component21.Number.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            component21.Number = 5;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            component21.Number = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            component31.FillDataGrid<Student>(studList);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            component31.CleanStrings();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
            columns.Add(new DataGridViewColumn() {
             HeaderText="Age Column",
             Width=30,
             Visible=true,
             DataPropertyName="Age"
            });
            columns.Add(new DataGridViewColumn()
            {
                HeaderText = "GroupNumber column",
                Width = 50,
                Visible = true,
                DataPropertyName = "GroupNumber"
            });
            columns.Add(new DataGridViewColumn()
            {
                HeaderText = "Name column",
                Width = 40,
                Visible = false,
                DataPropertyName = "Name"
            });
            component31.ConfigureViewbox(columns);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(component31.SelectedIndex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(textBox1.Text);
                component31.SelectedIndex = index;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Student tmp = component31.GetSelectedObject<Student>();
            MessageBox.Show(tmp.ToString());
        }
    }
}
