using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DependenciesViewer
{
    public partial class Form1 : Form
    {
        IHasGraph lastGraph;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastDirectory))
            {
                openFileDialog1.InitialDirectory = Properties.Settings.Default.LastDirectory;
            }
            layoutMethod.Items.Clear();
            layoutMethod.Items.AddRange(Enum.GetNames(typeof(LayoutMethod)));
            layoutMethod.SelectedIndex = Math.Min(0, Math.Min(layoutMethod.Items.Count - 1, Properties.Settings.Default.LayoutMethodIndex));
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                var fi = new FileInfo(openFileDialog1.FileName);
                if (!fi.Exists)
                {
                    MessageBox.Show("Файл не найден");
                    return;
                }

                Properties.Settings.Default.LastDirectory = fi.DirectoryName;
                Properties.Settings.Default.Save();

                if (fi.Extension == ".sln")
                {
                    lastGraph = new CSProjectSLN(fi.FullName);
                }
                else if (fi.Extension == ".csproj")
                {
                    lastGraph = new CSSolve(fi.Name, fi.FullName); 
                }
                else
                {
                    MessageBox.Show("Неверный формат файла! Ожидался .sln или .csproj");
                    return;
                }
                ReDrawGraph();

                Focus();
            }
            catch
#if DEBUG
            (Exception ex)
#endif
            {
#if DEBUG
                throw ex;
#else
                MessageBox.Show("Неизвестная ошибка");
#endif
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void layoutMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DependenciesGraph.CurrentLayoutMethod = (LayoutMethod)layoutMethod.SelectedIndex;
            Properties.Settings.Default.LayoutMethodIndex = layoutMethod.SelectedIndex;
            if (lastGraph != null)
                ReDrawGraph();
        }

        void ReDrawGraph()
        {
            try
            {
                DependenciesGraph.AsyncLayout = true;
                DependenciesGraph.Graph = lastGraph.GenerateGraph();
            }
            catch
            {

            }
        }
    }
}
