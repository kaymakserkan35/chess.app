namespace ChessApp.final.Controls
{
    partial class AChessBoardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// /*

        #endregion
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.forward = new System.Windows.Forms.Button();
            this.backward = new System.Windows.Forms.Button();
            this.backwardMax = new System.Windows.Forms.Button();
            this.forwardMax = new System.Windows.Forms.Button();
            this.variantsContainer = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(672, 804);
            this.splitContainer1.SplitterDistance = 569;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(672, 569);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.forward);
            this.splitContainer2.Panel1.Controls.Add(this.backward);
            this.splitContainer2.Panel1.Controls.Add(this.backwardMax);
            this.splitContainer2.Panel1.Controls.Add(this.forwardMax);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.variantsContainer);
            this.splitContainer2.Size = new System.Drawing.Size(672, 231);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.TabIndex = 0;
            // 
            // forward
            // 
            this.forward.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.forward.Dock = System.Windows.Forms.DockStyle.Right;
            this.forward.Location = new System.Drawing.Point(426, 0);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(86, 30);
            this.forward.TabIndex = 0;
            this.forward.Text = ">";
            this.forward.UseVisualStyleBackColor = false;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // backward
            // 
            this.backward.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.backward.Dock = System.Windows.Forms.DockStyle.Left;
            this.backward.Location = new System.Drawing.Point(123, 0);
            this.backward.Name = "backward";
            this.backward.Size = new System.Drawing.Size(90, 30);
            this.backward.TabIndex = 0;
            this.backward.Text = "<";
            this.backward.UseVisualStyleBackColor = false;
            this.backward.Click += new System.EventHandler(this.backward_Click);
            // 
            // backwardMax
            // 
            this.backwardMax.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.backwardMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.backwardMax.Location = new System.Drawing.Point(0, 0);
            this.backwardMax.Name = "backwardMax";
            this.backwardMax.Size = new System.Drawing.Size(123, 30);
            this.backwardMax.TabIndex = 1;
            this.backwardMax.Text = "<<";
            this.backwardMax.UseVisualStyleBackColor = false;
            this.backwardMax.Click += new System.EventHandler(this.backwardMax_Click);
            // 
            // forwardMax
            // 
            this.forwardMax.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.forwardMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.forwardMax.Location = new System.Drawing.Point(512, 0);
            this.forwardMax.Name = "forwardMax";
            this.forwardMax.Size = new System.Drawing.Size(160, 30);
            this.forwardMax.TabIndex = 1;
            this.forwardMax.Text = ">>";
            this.forwardMax.UseVisualStyleBackColor = false;
            this.forwardMax.Click += new System.EventHandler(this.forwardMax_Click);
            // 
            // variantsContainer
            // 
            this.variantsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.variantsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variantsContainer.Location = new System.Drawing.Point(0, 0);
            this.variantsContainer.Name = "variantsContainer";
            this.variantsContainer.Size = new System.Drawing.Size(672, 197);
            this.variantsContainer.TabIndex = 0;
            // 
            // AChessBoardControl
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "AChessBoardControl";
            this.Size = new System.Drawing.Size(672, 804);
            this.Load += new System.EventHandler(this.ChessBoardControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button backwardMax;
        private Button backward;
        private Button forwardMax;
        private Button forward;
        private FlowLayoutPanel variantsContainer;
    }
}
