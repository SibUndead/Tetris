namespace Tetris
{
    partial class TetrisScreenForMultiplayer
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
            this.tetViewMultipayer = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timerrender = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.scoreLineMy = new System.Windows.Forms.Label();
            this.scoreLineOpponent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tetViewMultipayer
            // 
            this.tetViewMultipayer.AccumBits = ((byte)(0));
            this.tetViewMultipayer.AutoCheckErrors = false;
            this.tetViewMultipayer.AutoFinish = false;
            this.tetViewMultipayer.AutoMakeCurrent = true;
            this.tetViewMultipayer.AutoSwapBuffers = true;
            this.tetViewMultipayer.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.tetViewMultipayer.BackColor = System.Drawing.Color.Black;
            this.tetViewMultipayer.ColorBits = ((byte)(32));
            this.tetViewMultipayer.DepthBits = ((byte)(16));
            this.tetViewMultipayer.Location = new System.Drawing.Point(5, 45);
            this.tetViewMultipayer.Name = "tetViewMultipayer";
            this.tetViewMultipayer.Size = new System.Drawing.Size(920, 565);
            this.tetViewMultipayer.StencilBits = ((byte)(0));
            this.tetViewMultipayer.TabIndex = 5;
            this.tetViewMultipayer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TetrisScreen_KeyUp);
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
            this.textBox1.Location = new System.Drawing.Point(932, 140);
            this.textBox1.MaxLength = 0;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisScreen_KeyUp);
            // 
            // scoreLineMy
            // 
            this.scoreLineMy.AutoSize = true;
            this.scoreLineMy.Location = new System.Drawing.Point(13, 13);
            this.scoreLineMy.Name = "scoreLineMy";
            this.scoreLineMy.Size = new System.Drawing.Size(0, 13);
            this.scoreLineMy.TabIndex = 6;
            // 
            // scoreLineOpponent
            // 
            this.scoreLineOpponent.AutoSize = true;
            this.scoreLineOpponent.Location = new System.Drawing.Point(547, 13);
            this.scoreLineOpponent.Name = "scoreLineOpponent";
            this.scoreLineOpponent.Size = new System.Drawing.Size(0, 13);
            this.scoreLineOpponent.TabIndex = 7;
            // 
            // TetrisScreenForMultiplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(934, 612);
            this.Controls.Add(this.scoreLineOpponent);
            this.Controls.Add(this.scoreLineMy);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tetViewMultipayer);
            this.Name = "TetrisScreenForMultiplayer";
            this.Text = "Tetris Multiplayer";
            this.Load += new System.EventHandler(this.Screen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TetrisScreen_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Tao.Platform.Windows.SimpleOpenGlControl tetViewMultipayer;
        private System.Windows.Forms.Timer timerrender;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label scoreLineMy;
        private System.Windows.Forms.Label scoreLineOpponent;
    }
}