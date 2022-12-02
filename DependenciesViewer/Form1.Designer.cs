namespace DependenciesViewer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DependenciesGraph = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // DependenciesGraph
            // 
            this.DependenciesGraph.ArrowheadLength = 10D;
            this.DependenciesGraph.AsyncLayout = false;
            this.DependenciesGraph.AutoScroll = true;
            this.DependenciesGraph.BackwardEnabled = false;
            this.DependenciesGraph.BuildHitTree = true;
            this.DependenciesGraph.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.DependenciesGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DependenciesGraph.EdgeInsertButtonVisible = true;
            this.DependenciesGraph.FileName = "";
            this.DependenciesGraph.ForwardEnabled = false;
            this.DependenciesGraph.Graph = null;
            this.DependenciesGraph.InsertingEdge = false;
            this.DependenciesGraph.LayoutAlgorithmSettingsButtonVisible = true;
            this.DependenciesGraph.LayoutEditingEnabled = true;
            this.DependenciesGraph.Location = new System.Drawing.Point(0, 0);
            this.DependenciesGraph.LooseOffsetForRouting = 0.25D;
            this.DependenciesGraph.MouseHitDistance = 0.05D;
            this.DependenciesGraph.Name = "DependenciesGraph";
            this.DependenciesGraph.NavigationVisible = true;
            this.DependenciesGraph.NeedToCalculateLayout = true;
            this.DependenciesGraph.OffsetForRelaxingInRouting = 0.6D;
            this.DependenciesGraph.PaddingForEdgeRouting = 8D;
            this.DependenciesGraph.PanButtonPressed = false;
            this.DependenciesGraph.SaveAsImageEnabled = true;
            this.DependenciesGraph.SaveAsMsaglEnabled = true;
            this.DependenciesGraph.SaveButtonVisible = true;
            this.DependenciesGraph.SaveGraphButtonVisible = true;
            this.DependenciesGraph.SaveInVectorFormatEnabled = true;
            this.DependenciesGraph.Size = new System.Drawing.Size(800, 450);
            this.DependenciesGraph.TabIndex = 0;
            this.DependenciesGraph.TightOffsetForRouting = 0.125D;
            this.DependenciesGraph.ToolBarIsVisible = true;
            this.DependenciesGraph.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("DependenciesGraph.Transform")));
            this.DependenciesGraph.UndoRedoButtonsVisible = true;
            this.DependenciesGraph.WindowZoomButtonPressed = false;
            this.DependenciesGraph.ZoomF = 1D;
            this.DependenciesGraph.ZoomWindowThreshold = 0.05D;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "C# Решение|*.sln|C# Проект|*.csproj|Все файлы|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DependenciesGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer DependenciesGraph;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

