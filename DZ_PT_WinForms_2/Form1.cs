using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DZ_PT_WinForms_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                int fileLength = (int)new FileInfo(filePath).Length;
                progressBar.Maximum = fileLength;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    int charCount = 0;
                    while (!reader.EndOfStream)
                    {
                        reader.Read();
                        charCount++;
                        progressBar.Value = charCount;
                    }
                }

                progressBar.Value = 0;
            }
        }

        private void buttonOpenFile_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                int fileLength = (int)new FileInfo(filePath).Length;
                progressBar.Maximum = fileLength;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    int charCount = 0;
                    while (!reader.EndOfStream)
                    {
                        reader.Read();
                        charCount++;
                        progressBar.Value = charCount;
                    }
                }

                progressBar.Value = 0;
            }
        }
    }
}