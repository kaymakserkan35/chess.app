namespace ChessApp.final
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chessBoardControl1 = new ChessApp.final.Controls.ChessBoardControl();
            this.loadPosition = new System.Windows.Forms.Button();
            this.loadGame = new System.Windows.Forms.Button();
            this.autoPlay = new System.Windows.Forms.Button();
            this.getAlLines = new System.Windows.Forms.Button();
            this.positionAnalyses = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chessBoardControl1
            // 
            this.chessBoardControl1.Location = new System.Drawing.Point(28, 25);
            this.chessBoardControl1.Name = "chessBoardControl1";
            this.chessBoardControl1.Size = new System.Drawing.Size(620, 671);
            this.chessBoardControl1.TabIndex = 0;
            // 
            // loadPosition
            // 
            this.loadPosition.Location = new System.Drawing.Point(63, 717);
            this.loadPosition.Name = "loadPosition";
            this.loadPosition.Size = new System.Drawing.Size(94, 23);
            this.loadPosition.TabIndex = 1;
            this.loadPosition.Text = "loadPosition";
            this.loadPosition.UseVisualStyleBackColor = true;
            this.loadPosition.Click += new System.EventHandler(this.loadPosition_Click);
            // 
            // loadGame
            // 
            this.loadGame.Location = new System.Drawing.Point(225, 717);
            this.loadGame.Name = "loadGame";
            this.loadGame.Size = new System.Drawing.Size(75, 23);
            this.loadGame.TabIndex = 2;
            this.loadGame.Text = "loadGame";
            this.loadGame.UseVisualStyleBackColor = true;
            this.loadGame.Click += new System.EventHandler(this.loadGame_Click);
            // 
            // autoPlay
            // 
            this.autoPlay.Location = new System.Drawing.Point(679, 25);
            this.autoPlay.Name = "autoPlay";
            this.autoPlay.Size = new System.Drawing.Size(98, 112);
            this.autoPlay.TabIndex = 3;
            this.autoPlay.Text = "autoPlay";
            this.autoPlay.UseVisualStyleBackColor = true;
            this.autoPlay.Click += new System.EventHandler(this.autoPlay_Click_1);
            // 
            // getAlLines
            // 
            this.getAlLines.Location = new System.Drawing.Point(349, 717);
            this.getAlLines.Name = "getAlLines";
            this.getAlLines.Size = new System.Drawing.Size(75, 23);
            this.getAlLines.TabIndex = 4;
            this.getAlLines.Text = "getAlLines";
            this.getAlLines.UseVisualStyleBackColor = true;
            this.getAlLines.Click += new System.EventHandler(this.getAlLines_Click);
            // 
            // positionAnalyses
            // 
            this.positionAnalyses.Location = new System.Drawing.Point(470, 717);
            this.positionAnalyses.Name = "positionAnalyses";
            this.positionAnalyses.Size = new System.Drawing.Size(113, 23);
            this.positionAnalyses.TabIndex = 5;
            this.positionAnalyses.Text = "positionAnalyses";
            this.positionAnalyses.UseVisualStyleBackColor = true;
            this.positionAnalyses.Click += new System.EventHandler(this.positionAnalyses_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 778);
            this.Controls.Add(this.positionAnalyses);
            this.Controls.Add(this.getAlLines);
            this.Controls.Add(this.autoPlay);
            this.Controls.Add(this.loadGame);
            this.Controls.Add(this.loadPosition);
            this.Controls.Add(this.chessBoardControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private Controls.ChessBoardControl chessBoardControl1;
        private Button loadPosition;
        private Button loadGame;
        private Button autoPlay;
        private Button getAlLines;
        private Button positionAnalyses;
    }
}