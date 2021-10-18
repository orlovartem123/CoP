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
    }
}
