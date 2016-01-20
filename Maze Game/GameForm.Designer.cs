namespace Maze_Game
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.nameLbl = new System.Windows.Forms.Label();
            this.showNameLbl = new System.Windows.Forms.Label();
            this.resultlbl = new System.Windows.Forms.Label();
            this.movesLeftLbl = new System.Windows.Forms.Label();
            this.timeLeftLbl = new System.Windows.Forms.Label();
            this.newLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.BackColor = System.Drawing.Color.Transparent;
            this.nameLbl.Location = new System.Drawing.Point(75, 459);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(0, 13);
            this.nameLbl.TabIndex = 0;
            // 
            // showNameLbl
            // 
            this.showNameLbl.AutoSize = true;
            this.showNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.showNameLbl.Location = new System.Drawing.Point(12, 459);
            this.showNameLbl.Name = "showNameLbl";
            this.showNameLbl.Size = new System.Drawing.Size(63, 13);
            this.showNameLbl.TabIndex = 1;
            this.showNameLbl.Text = "Your Name:";
            // 
            // resultlbl
            // 
            this.resultlbl.AutoSize = true;
            this.resultlbl.BackColor = System.Drawing.Color.Transparent;
            this.resultlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultlbl.ForeColor = System.Drawing.Color.Yellow;
            this.resultlbl.Location = new System.Drawing.Point(44, 122);
            this.resultlbl.Name = "resultlbl";
            this.resultlbl.Size = new System.Drawing.Size(70, 25);
            this.resultlbl.TabIndex = 2;
            this.resultlbl.Text = "label1";
            this.resultlbl.Visible = false;
            // 
            // movesLeftLbl
            // 
            this.movesLeftLbl.AutoSize = true;
            this.movesLeftLbl.BackColor = System.Drawing.Color.Transparent;
            this.movesLeftLbl.Location = new System.Drawing.Point(385, 459);
            this.movesLeftLbl.Name = "movesLeftLbl";
            this.movesLeftLbl.Size = new System.Drawing.Size(35, 13);
            this.movesLeftLbl.TabIndex = 3;
            this.movesLeftLbl.Text = "label1";
            // 
            // timeLeftLbl
            // 
            this.timeLeftLbl.AutoSize = true;
            this.timeLeftLbl.BackColor = System.Drawing.Color.Transparent;
            this.timeLeftLbl.Location = new System.Drawing.Point(165, 460);
            this.timeLeftLbl.Name = "timeLeftLbl";
            this.timeLeftLbl.Size = new System.Drawing.Size(35, 13);
            this.timeLeftLbl.TabIndex = 4;
            this.timeLeftLbl.Text = "label1";
            // 
            // newLabel
            // 
            this.newLabel.AutoSize = true;
            this.newLabel.BackColor = System.Drawing.Color.Transparent;
            this.newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 62.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newLabel.ForeColor = System.Drawing.Color.Yellow;
            this.newLabel.Location = new System.Drawing.Point(0, 0);
            this.newLabel.Name = "newLabel";
            this.newLabel.Size = new System.Drawing.Size(264, 95);
            this.newLabel.TabIndex = 5;
            this.newLabel.Text = "label1";
            this.newLabel.Visible = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 481);
            this.Controls.Add(this.newLabel);
            this.Controls.Add(this.timeLeftLbl);
            this.Controls.Add(this.movesLeftLbl);
            this.Controls.Add(this.resultlbl);
            this.Controls.Add(this.showNameLbl);
            this.Controls.Add(this.nameLbl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label showNameLbl;
        private System.Windows.Forms.Label resultlbl;
        private System.Windows.Forms.Label movesLeftLbl;
        private System.Windows.Forms.Label timeLeftLbl;
        public System.Windows.Forms.Label newLabel;
    }
}

