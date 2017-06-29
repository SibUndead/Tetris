namespace Tetris
{
    partial class TetrisScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TetView = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timerrender = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.scoreLine = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TetView
            // 
            this.TetView.AccumBits = ((byte)(0));
            this.TetView.AutoCheckErrors = false;
            this.TetView.AutoFinish = false;
            this.TetView.AutoMakeCurrent = true;
            this.TetView.AutoSwapBuffers = true;
            this.TetView.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.TetView.BackColor = System.Drawing.Color.Black;
            this.TetView.ColorBits = ((byte)(32));
            this.TetView.DepthBits = ((byte)(16));
            this.TetView.Location = new System.Drawing.Point(5, 45);
            this.TetView.Name = "TetView";
            this.TetView.Size = new System.Drawing.Size(445, 565);
            this.TetView.StencilBits = ((byte)(0));
            this.TetView.TabIndex = 5;
            // 
            // timerrender
            // 
            this.timerrender.Interval = 50;
            this.timerrender.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(456, 72);
            this.textBox1.MaxLength = 0;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisScreen_KeyUp);
            // 
            // scoreLine
            // 
            this.scoreLine.AutoSize = true;
            this.scoreLine.Location = new System.Drawing.Point(13, 13);
            this.scoreLine.Name = "scoreLine";
            this.scoreLine.Size = new System.Drawing.Size(0, 13);
            this.scoreLine.TabIndex = 6;
            // 
            // TetrisScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(454, 612);
            this.Controls.Add(this.scoreLine);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TetView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TetrisScreen";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Screen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TetrisScreen_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Tao.Platform.Windows.SimpleOpenGlControl TetView;
        private System.Windows.Forms.Timer timerrender;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label scoreLine;
    }
}