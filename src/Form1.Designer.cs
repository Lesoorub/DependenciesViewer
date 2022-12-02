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
            this.button1 = new System.Windows.Forms.Button();
            this.layoutMethod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DependenciesGraph
            // 
            this.DependenciesGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DependenciesGraph.ArrowheadLength = 10D;
            this.DependenciesGraph.AsyncLayout = true;
            this.DependenciesGraph.AutoScroll = true;
            this.DependenciesGraph.BackwardEnabled = false;
            this.DependenciesGraph.BuildHitTree = true;
            this.DependenciesGraph.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.Ranking;
            this.DependenciesGraph.EdgeInsertButtonVisible = true;
            this.DependenciesGraph.FileName = "";
            this.DependenciesGraph.ForwardEnabled = false;
            this.DependenciesGraph.Graph = null;
            this.DependenciesGraph.InsertingEdge = false;
            this.DependenciesGraph.LayoutAlgorithmSettingsButtonVisible = true;
            this.DependenciesGraph.LayoutEditingEnabled = true;
            this.DependenciesGraph.Location = new System.Drawing.Point(0, 41);
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
            this.DependenciesGraph.Size = new System.Drawing.Size(800, 401);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // layoutMethod
            // 
            this.layoutMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layoutMethod.FormattingEnabled = true;
            this.layoutMethod.Location = new System.Drawing.Point(94, 13);
            this.layoutMethod.Name = "layoutMethod";
            this.layoutMethod.Size = new System.Drawing.Size(206, 21);
            this.layoutMethod.TabIndex = 2;
            this.layoutMethod.SelectedIndexChanged += new System.EventHandler(this.layoutMethod_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutMethod);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DependenciesGraph);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Dependencies Viewer 1.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer DependenciesGraph;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox layoutMethod;
    }
}

