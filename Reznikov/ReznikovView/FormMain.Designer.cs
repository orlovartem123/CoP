
namespace ReznikovView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПростойДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДокументСДаиграммамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.universityListBox1 = new TeammatesComponents.UniversityListBox();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.создатьПростойДокументToolStripMenuItem,
            this.создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem,
            this.создатьДокументСДаиграммамиToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(436, 148);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(435, 24);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(435, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(435, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // создатьПростойДокументToolStripMenuItem
            // 
            this.создатьПростойДокументToolStripMenuItem.Name = "создатьПростойДокументToolStripMenuItem";
            this.создатьПростойДокументToolStripMenuItem.Size = new System.Drawing.Size(435, 24);
            this.создатьПростойДокументToolStripMenuItem.Text = "Создать простой документ";
            this.создатьПростойДокументToolStripMenuItem.Click += new System.EventHandler(this.создатьПростойДокументToolStripMenuItem_Click);
            // 
            // создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem
            // 
            this.создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem.Name = "создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem";
            this.создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem.Size = new System.Drawing.Size(435, 24);
            this.создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem.Text = "Создать документ с настаиваемыми оглавлениями";
            this.создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem.Click += new System.EventHandler(this.создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem_Click);
            // 
            // создатьДокументСДаиграммамиToolStripMenuItem
            // 
            this.создатьДокументСДаиграммамиToolStripMenuItem.Name = "создатьДокументСДаиграммамиToolStripMenuItem";
            this.создатьДокументСДаиграммамиToolStripMenuItem.Size = new System.Drawing.Size(435, 24);
            this.создатьДокументСДаиграммамиToolStripMenuItem.Text = "Создать документ с даиграммами";
            this.создатьДокументСДаиграммамиToolStripMenuItem.Click += new System.EventHandler(this.создатьДокументСДаиграммамиToolStripMenuItem_Click);
            // 
            // universityListBox1
            // 
            this.universityListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.universityListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.universityListBox1.index = -1;
            this.universityListBox1.Location = new System.Drawing.Point(0, 0);
            this.universityListBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.universityListBox1.Name = "universityListBox1";
            this.universityListBox1.Size = new System.Drawing.Size(549, 285);
            this.universityListBox1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 285);
            this.Controls.Add(this.universityListBox1);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "Список студентов";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.universityListBox1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private TeammatesComponents.UniversityListBox universityListBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПростойДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДокументСНастаиваемымиОглавлениямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДокументСДаиграммамиToolStripMenuItem;
    }
}

