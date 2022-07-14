using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Optimizer
{
    public partial class Optimizer : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        public Optimizer()
        {
            InitializeComponent();
        }

        private void Optimizer_Load(object sender, System.EventArgs e)
        {

        }

        private void minimizeButton_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region moveApp
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void brandLabel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }
        private void brandLabel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void brandLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        #endregion

        private void windowsTempButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            string folderPath = @"C:\Windows\Temp";
            string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories); //this gets the files in all subdirectories as well
            List<string> lockedFiles = new List<string>();
            foreach (var file in files)
            {
                try
                {
                    File.Delete(file);
                    textBox1.Text += file + Environment.NewLine;
                }
                catch (IOException)
                {
                    lockedFiles.Add(file);
                    foreach (var fileError in lockedFiles)
                    {
                        textBox2.Text += fileError + Environment.NewLine;
                    }
                }
            }

            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Temp");
            DirectoryInfo[] subDirectories = dir.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                try
                {
                    subDirectory.Delete(true);
                    textBox1.Text += folderPath + "\\" + subDirectory + Environment.NewLine;
                }
                catch (IOException)
                {
                    lockedFiles.Add(subDirectory.ToString());
                    foreach (var fileError in lockedFiles)
                    {
                        textBox2.Text += fileError + Environment.NewLine;
                    }
                }
            }
            MessageBox.Show("Successfully deleted Windows temp files!", "PC-Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CleanAppTemp_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            string folderPath = Environment.GetEnvironmentVariable("TEMP"); ;
            string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories); //this gets the files in all subdirectories as well
            List<string> lockedFiles = new List<string>();
            foreach (var file in Directory.GetFiles(folderPath))
            {
                try
                {
                    File.Delete(file);
                    textBox1.Text += file + Environment.NewLine;
                }
                catch (IOException)
                {
                    lockedFiles.Add(file);
                    foreach (var fileError in lockedFiles)
                    {
                        textBox2.Text += fileError + Environment.NewLine;
                    }
                }
            }

            DirectoryInfo dir = new DirectoryInfo(Environment.GetEnvironmentVariable("TEMP"));
            DirectoryInfo[] subDirectories = dir.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                try
                {
                    subDirectory.Delete(true);
                    textBox1.Text += folderPath + "\\" + subDirectory + Environment.NewLine;
                }
                catch (IOException)
                {
                    lockedFiles.Add(subDirectory.ToString());
                    foreach (var fileError in lockedFiles)
                    {
                        textBox2.Text += fileError + Environment.NewLine;
                    }
                }
            }
            MessageBox.Show("Successfully deleted AppData temp files!", "PC-Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
