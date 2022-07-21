using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Optimizer
{
    public partial class Optimizer : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        enum RecycleFlags : int
        {
            SHRB_NOCONFIRMATION = 0x00000001, // Don't ask for confirmation
            SHRB_NOPROGRESSUI = 0x00000001, // Don't show progress
            SHRB_NOSOUND = 0x00000004 // Don't make sound when the action is executed
        }
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

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

        private void cleanRecycleBinButton_Click(object sender, EventArgs e)
        {
            try
            {
                uint IsSuccess = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION);
                MessageBox.Show("Successfully deleted items in the recycle bin!", "PC-Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete items in the recycle bin!" + ex.Message, "PC-Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void getSystemInfo_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";

            var sysWindows = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", null);
            var sysUserName = WindowsIdentity.GetCurrent().Name.ToString();
            var sysWindowsVersion = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "DisplayVersion", null);
            var sysOwner = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", null);
            var sysBrand = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "SystemManufacturer", null);
            var sysModelName = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "SystemFamily", null);
            var sysProductName = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "SystemProductName", null);
            var sysBoardBrand = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BaseBoardManufacturer", null);
            var sysBoardProduct = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BaseBoardProduct", null);
            var sysBoardVersion = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BaseBoardVersion", null);
            var sysBiosBrand = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSVendor", null);
            var sysBiosVersion = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSVersion", null);
            var sysCPU = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", null);

            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C wmic path win32_VideoController get name";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            string hwid = "";
            string sysGPU = "";
            while (!process.HasExited)
            {
                hwid += process.StandardOutput.ReadToEnd();
                sysGPU = hwid.Substring(4);
            }


            textBox3.Text += "Microsoft " + sysWindows + ", version " + sysWindowsVersion + Environment.NewLine + "System User Name: " + sysUserName + Environment.NewLine
                                 + "System owner: " + sysOwner + Environment.NewLine
                                + "System brand: " + sysBrand + Environment.NewLine + "System model: " + sysModelName + Environment.NewLine
                                + "System product: " + sysProductName + Environment.NewLine + "Motherboard brand: " + sysBoardBrand + Environment.NewLine
                                + "Motherboard model: " + sysBoardProduct + Environment.NewLine + "Motherboard version: " + sysBoardVersion + Environment.NewLine
                                + "Bios brand: " + sysBiosBrand + Environment.NewLine + "Bios version: " + sysBiosVersion + Environment.NewLine + "CPU: " + sysCPU + Environment.NewLine
                                + "GPU: " + sysGPU;
        }

        private void getHWIDButton_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";

            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C wmic diskdrive get serialnumber";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            string hwid = "";
            string hwid2 = "";
            while (!process.HasExited)
            {
                hwid += process.StandardOutput.ReadToEnd();
                hwid2 = hwid.Substring(12);
            }

            var sysUserHWID = WindowsIdentity.GetCurrent().User.Value;

            textBox3.Text += "Drive HWID: " + hwid2 + "System User HWID: " + sysUserHWID + Environment.NewLine;
        }

        private void shutDownButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you that you want to shut down the PC?", "PC-Optimizer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = "powershell.exe";
                processInfo.Arguments = "Stop-Computer";
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = processInfo;
                process.Start();
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you that you want to shut down the PC?", "PC-Optimizer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process process = new Process();
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C shutdown /r /f /t 0";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
            }
        }
    }
}