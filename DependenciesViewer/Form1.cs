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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastSelectedDirectory))
            {
                openFileDialog1.InitialDirectory = Properties.Settings.Default.LastSelectedDirectory;
            }
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var fi = new FileInfo(openFileDialog1.FileName);
            if (!fi.Exists)
            {
                MessageBox.Show("Файл не найден");
                return;
            }

            Properties.Settings.Default.LastSelectedDirectory = fi.DirectoryName;
            Properties.Settings.Default.Save();

            DependenciesGraph.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.MDS;

            if (fi.Extension == ".sln")
            {
                var sln = new CSProjectSLN(fi.FullName);

                DependenciesGraph.Graph = sln.GenerateGraph();

            } 
            else if (fi.Extension == ".csproj")
            {
                var csproj = new CSSolve(fi.Name, fi.FullName);

                DependenciesGraph.Graph = csproj.GenerateGraph();
            }
            else
            {
                MessageBox.Show("Неверный формат файла! Ожидался .sln или .csproj");
                return;
            }

            Focus();
            try
            {
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
    }
}
