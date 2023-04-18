using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DZ_PT_WinForms2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Выбор файла и заполнение TextBox
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string fileContent = File.ReadAllText(fileName);
                int fileLength = (int)new FileInfo(fileName).Length;                
                int bytesRead = 0;
                byte[] buffer = new byte[1024];
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    while (bytesRead < fileLength)
                    {
                        int bytes = fs.Read(buffer, 0, buffer.Length);
                        bytesRead += bytes;
                        progressBar1.Value = (int)(((double)bytesRead / (double)fileLength) * 100);
                        textBox1.Text += System.Text.Encoding.Default.GetString(buffer, 0, bytes);
                    }
                }
                MessageBox.Show("Файл прочитан");
                MessageBox.Show("Количество символов в файле: " + fileLength.ToString());
            }
        }
    }
}