namespace Dynamic_UI_gen_demo // This one is in the program name "Dynamic_UI_gen_demo"
{
    partial class Dynamic_UI_gen 
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null; // defined a variable
        // "System.ComponentModel.IContainer is class used to defined component .

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            // disposed == released
            // if the resource want to dispose a resouce and the components of Form1 isn't null ---> released a task 
            if (disposing && (components != null)) 
            {
                components.Dispose();
            }
            base.Dispose(disposing); // release the others resource that Form1.cs used 
                                     // if the others is null ---> return False
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Generate = new System.Windows.Forms.Button();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.NumGen_Box = new System.Windows.Forms.TextBox();
            this.X_Label = new System.Windows.Forms.Label();
            this.O_Label = new System.Windows.Forms.Label();
            this.Colon_Label1 = new System.Windows.Forms.Label();
            this.Colon_Label2 = new System.Windows.Forms.Label();
            this.O_score = new System.Windows.Forms.Label();
            this.X_Score = new System.Windows.Forms.Label();
            this.List_Count = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.BackColor = System.Drawing.Color.Green;
            this.Generate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Generate.ForeColor = System.Drawing.Color.Transparent;
            this.Generate.Location = new System.Drawing.Point(828, 86);
            this.Generate.Margin = new System.Windows.Forms.Padding(4);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(127, 54);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = false;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Reset_Button
            // 
            this.Reset_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Reset_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Reset_Button.ForeColor = System.Drawing.Color.Transparent;
            this.Reset_Button.Location = new System.Drawing.Point(828, 148);
            this.Reset_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(127, 54);
            this.Reset_Button.TabIndex = 1;
            this.Reset_Button.Text = "RESET";
            this.Reset_Button.UseVisualStyleBackColor = false;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // NumGen_Box
            // 
            this.NumGen_Box.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NumGen_Box.Location = new System.Drawing.Point(799, 13);
            this.NumGen_Box.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.NumGen_Box.Name = "NumGen_Box";
            this.NumGen_Box.Size = new System.Drawing.Size(178, 61);
            this.NumGen_Box.TabIndex = 2;
            this.NumGen_Box.TextChanged += new System.EventHandler(this.NumGen_Box_TextChanged);
            // 
            // X_Label
            // 
            this.X_Label.AutoSize = true;
            this.X_Label.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.X_Label.Location = new System.Drawing.Point(799, 221);
            this.X_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X_Label.Name = "X_Label";
            this.X_Label.Size = new System.Drawing.Size(49, 54);
            this.X_Label.TabIndex = 3;
            this.X_Label.Text = "X";
            // 
            // O_Label
            // 
            this.O_Label.AutoSize = true;
            this.O_Label.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.O_Label.Location = new System.Drawing.Point(799, 281);
            this.O_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.O_Label.Name = "O_Label";
            this.O_Label.Size = new System.Drawing.Size(53, 54);
            this.O_Label.TabIndex = 4;
            this.O_Label.Text = "O";
            // 
            // Colon_Label1
            // 
            this.Colon_Label1.AutoSize = true;
            this.Colon_Label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Colon_Label1.Location = new System.Drawing.Point(854, 221);
            this.Colon_Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Colon_Label1.Name = "Colon_Label1";
            this.Colon_Label1.Size = new System.Drawing.Size(34, 54);
            this.Colon_Label1.TabIndex = 5;
            this.Colon_Label1.Text = ":";
            // 
            // Colon_Label2
            // 
            this.Colon_Label2.AutoSize = true;
            this.Colon_Label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Colon_Label2.Location = new System.Drawing.Point(856, 281);
            this.Colon_Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Colon_Label2.Name = "Colon_Label2";
            this.Colon_Label2.Size = new System.Drawing.Size(34, 54);
            this.Colon_Label2.TabIndex = 6;
            this.Colon_Label2.Text = ":";
            // 
            // O_score
            // 
            this.O_score.AutoSize = true;
            this.O_score.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.O_score.Location = new System.Drawing.Point(911, 281);
            this.O_score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.O_score.Name = "O_score";
            this.O_score.Size = new System.Drawing.Size(46, 54);
            this.O_score.TabIndex = 7;
            this.O_score.Text = "0";
            // 
            // X_Score
            // 
            this.X_Score.AutoSize = true;
            this.X_Score.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.X_Score.Location = new System.Drawing.Point(911, 221);
            this.X_Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X_Score.Name = "X_Score";
            this.X_Score.Size = new System.Drawing.Size(46, 54);
            this.X_Score.TabIndex = 8;
            this.X_Score.Text = "0";
            // 
            // List_Count
            // 
            this.List_Count.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.List_Count.Location = new System.Drawing.Point(799, 348);
            this.List_Count.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.List_Count.Name = "List_Count";
            this.List_Count.Size = new System.Drawing.Size(178, 61);
            this.List_Count.TabIndex = 9;
            // 
            // Dynamic_UI_gen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.List_Count);
            this.Controls.Add(this.X_Score);
            this.Controls.Add(this.O_score);
            this.Controls.Add(this.Colon_Label2);
            this.Controls.Add(this.Colon_Label1);
            this.Controls.Add(this.O_Label);
            this.Controls.Add(this.X_Label);
            this.Controls.Add(this.NumGen_Box);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Generate);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dynamic_UI_gen";
            this.Text = "Dynamic_Ui_gen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Generate;
        private Button Reset_Button;
        private TextBox NumGen_Box;
        private Label X_Label;
        private Label O_Label;
        private Label Colon_Label1;
        private Label Colon_Label2;
        private Label O_score;
        private Label X_Score;
        private TextBox List_Count;
    }
}