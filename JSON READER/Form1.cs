using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JSON_READER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
             OpenFileDialog openFileDialog1 = new OpenFileDialog
             {
                 Title = "Mở File...",
                 CheckFileExists = true,
                 CheckPathExists = true,
                 RestoreDirectory = true,
                 Filter = "txt file (*.txt)|*.txt",
                 FilterIndex = 2,
                 /*ReadOnlyChecked = true,
                 ShowReadOnly = true,*/
             };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                Test.file = textBox1.Text;

                dataGridView1.DataSource = Test.DataTableFromTextFile(textBox1.Text);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
