namespace Tetris
{
    partial class Menu
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
            this.Game = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.multiplayerButton = new System.Windows.Forms.Button();
            this.createServerButton = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.Button();
            this.ipAdress = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.Label();
            this.ipAdressTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.resultsTab = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Game
            // 
            this.Game.Location = new System.Drawing.Point(13, 31);
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(120, 25);
            this.Game.TabIndex = 3;
            this.Game.Text = "Начать игру";
            this.Game.UseVisualStyleBackColor = true;
            this.Game.Click += new System.EventHandler(this.Game_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(12, 188);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(120, 25);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // multiplayerButton
            // 
            this.multiplayerButton.Location = new System.Drawing.Point(13, 62);
            this.multiplayerButton.Name = "multiplayerButton";
            this.multiplayerButton.Size = new System.Drawing.Size(119, 26);
            this.multiplayerButton.TabIndex = 5;
            this.multiplayerButton.Text = "Найти сервер";
            this.multiplayerButton.UseVisualStyleBackColor = true;
            this.multiplayerButton.Click += new System.EventHandler(this.multiplayerButton_Click);
            // 
            // createServerButton
            // 
            this.createServerButton.Location = new System.Drawing.Point(12, 94);
            this.createServerButton.Name = "createServerButton";
            this.createServerButton.Size = new System.Drawing.Size(120, 26);
            this.createServerButton.TabIndex = 6;
            this.createServerButton.Text = "Создать Сервер";
            this.createServerButton.UseVisualStyleBackColor = true;
            this.createServerButton.Click += new System.EventHandler(this.createServerButton_Click);
            // 
            // options
            // 
            this.options.Location = new System.Drawing.Point(12, 125);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(120, 25);
            this.options.TabIndex = 7;
            this.options.Text = "Опции";
            this.options.UseVisualStyleBackColor = true;
            // 
            // ipAdress
            // 
            this.ipAdress.AutoSize = true;
            this.ipAdress.Location = new System.Drawing.Point(176, 43);
            this.ipAdress.Name = "ipAdress";
            this.ipAdress.Size = new System.Drawing.Size(48, 13);
            this.ipAdress.TabIndex = 10;
            this.ipAdress.Text = "ip адрес";
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Location = new System.Drawing.Point(176, 101);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(25, 13);
            this.port.TabIndex = 11;
            this.port.Text = "port";
            // 
            // ipAdressTextBox
            // 
            this.ipAdressTextBox.Location = new System.Drawing.Point(179, 66);
            this.ipAdressTextBox.Name = "ipAdressTextBox";
            this.ipAdressTextBox.Size = new System.Drawing.Size(93, 20);
            this.ipAdressTextBox.TabIndex = 12;
            this.ipAdressTextBox.Text = "127.0.0.1";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(179, 123);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(93, 20);
            this.portTextBox.TabIndex = 13;
            this.portTextBox.Text = "61100";
            // 
            // resultsTab
            // 
            this.resultsTab.Location = new System.Drawing.Point(12, 156);
            this.resultsTab.Name = "resultsTab";
            this.resultsTab.Size = new System.Drawing.Size(120, 26);
            this.resultsTab.TabIndex = 14;
            this.resultsTab.Text = "Результаты игр";
            this.resultsTab.UseVisualStyleBackColor = true;
            this.resultsTab.Click += new System.EventHandler(this.resultsTabButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.resultsTab);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipAdressTextBox);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ipAdress);
            this.Controls.Add(this.options);
            this.Controls.Add(this.createServerButton);
            this.Controls.Add(this.multiplayerButton);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Game);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Game;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button multiplayerButton;
        private System.Windows.Forms.Button createServerButton;
        private System.Windows.Forms.Button options;
        private System.Windows.Forms.Label ipAdress;
        private System.Windows.Forms.Label port;
        private System.Windows.Forms.TextBox ipAdressTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button resultsTab;
    }
}