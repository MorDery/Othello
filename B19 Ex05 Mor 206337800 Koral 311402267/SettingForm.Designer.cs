namespace Ex05_Othelo
{
    partial class FormSetting
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
            this.buttonSize = new System.Windows.Forms.Button();
            this.buttonAgainstFriend = new System.Windows.Forms.Button();
            this.buttonAgainstComputer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSize
            // 
            this.buttonSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSize.ForeColor = System.Drawing.Color.Black;
            this.buttonSize.Location = new System.Drawing.Point(53, 26);
            this.buttonSize.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSize.Name = "buttonSize";
            this.buttonSize.Size = new System.Drawing.Size(223, 53);
            this.buttonSize.TabIndex = 0;
            this.buttonSize.Text = "Board Size 6X6 (click to increase)";
            this.buttonSize.UseVisualStyleBackColor = true;
            this.buttonSize.Click += new System.EventHandler(this.buttonSize_Click);
            // 
            // buttonAgainstFriend
            // 
            this.buttonAgainstFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAgainstFriend.Location = new System.Drawing.Point(172, 114);
            this.buttonAgainstFriend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAgainstFriend.Name = "buttonAgainstFriend";
            this.buttonAgainstFriend.Size = new System.Drawing.Size(126, 48);
            this.buttonAgainstFriend.TabIndex = 1;
            this.buttonAgainstFriend.Text = "Play against your friend";
            this.buttonAgainstFriend.UseVisualStyleBackColor = true;
            this.buttonAgainstFriend.Click += new System.EventHandler(this.buttonAgainstFriend_Click);
            // 
            // buttonAgainstComputer
            // 
            this.buttonAgainstComputer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAgainstComputer.Location = new System.Drawing.Point(21, 114);
            this.buttonAgainstComputer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAgainstComputer.Name = "buttonAgainstComputer";
            this.buttonAgainstComputer.Size = new System.Drawing.Size(107, 48);
            this.buttonAgainstComputer.TabIndex = 2;
            this.buttonAgainstComputer.Text = "Play against the computer";
            this.buttonAgainstComputer.UseVisualStyleBackColor = true;
            this.buttonAgainstComputer.Click += new System.EventHandler(this.buttonAgainstComputer_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(320, 182);
            this.Controls.Add(this.buttonAgainstComputer);
            this.Controls.Add(this.buttonAgainstFriend);
            this.Controls.Add(this.buttonSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(336, 221);
            this.MinimumSize = new System.Drawing.Size(336, 221);
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game setting";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSize;
        private System.Windows.Forms.Button buttonAgainstFriend;
        private System.Windows.Forms.Button buttonAgainstComputer;
    }
}

