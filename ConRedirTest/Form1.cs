using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ConRedirTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool ProcessStarted;
        public string output;
        private void button1_Click(object sender, EventArgs e)
        {
            ProgramShit();
        }
        Process ProcessASDF;
        public void ProgramShit()
        {
            string path = "ConReditTestApp.exe";
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.FileName = path;
            StartInfo.Arguments = "";
            StartInfo.UseShellExecute = false;
            StartInfo.RedirectStandardOutput = true;

            ProcessASDF = new Process();
            ProcessASDF.StartInfo = StartInfo;
            ProcessASDF.EnableRaisingEvents = true;
            // Process.Exited += Process_Exited;
            ProcessASDF.Start();
            ProcessStarted = true;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ProcessStarted == true)
            {
                textBox1.AppendText(ProcessASDF.StandardOutput.ReadLine() + System.Environment.NewLine);
                textBox1.ScrollToCaret();
            }
            else
            {
                Console.WriteLine("Process not started...");
            }
        }
    }
}
