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
            this.SAVE_Button = new System.Windows.Forms.Button();
            this.NumGen_Box = new System.Windows.Forms.TextBox();
            this.LOAD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Turn_temp = new System.Windows.Forms.Label();
            this.Total_Move = new System.Windows.Forms.Label();
            this.num_Move = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.BackColor = System.Drawing.Color.Green;
            this.Generate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Generate.ForeColor = System.Drawing.Color.Transparent;
            this.Generate.Location = new System.Drawing.Point(828, 91);
            this.Generate.Margin = new System.Windows.Forms.Padding(4);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(127, 54);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Play";
            this.Generate.UseVisualStyleBackColor = false;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // SAVE_Button
            // 
            this.SAVE_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SAVE_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SAVE_Button.ForeColor = System.Drawing.Color.Transparent;
            this.SAVE_Button.Location = new System.Drawing.Point(828, 153);
            this.SAVE_Button.Margin = new System.Windows.Forms.Padding(4);
            this.SAVE_Button.Name = "SAVE_Button";
            this.SAVE_Button.Size = new System.Drawing.Size(127, 54);
            this.SAVE_Button.TabIndex = 1;
            this.SAVE_Button.Text = "SAVE";
            this.SAVE_Button.UseVisualStyleBackColor = false;
            this.SAVE_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // NumGen_Box
            // 
            this.NumGen_Box.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NumGen_Box.Location = new System.Drawing.Point(799, 19);
            this.NumGen_Box.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.NumGen_Box.Name = "NumGen_Box";
            this.NumGen_Box.Size = new System.Drawing.Size(178, 61);
            this.NumGen_Box.TabIndex = 2;
            this.NumGen_Box.TextChanged += new System.EventHandler(this.NumGen_Box_TextChanged);
            // 
            // LOAD
            // 
            this.LOAD.BackColor = System.Drawing.Color.Gold;
            this.LOAD.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LOAD.ForeColor = System.Drawing.Color.Transparent;
            this.LOAD.Location = new System.Drawing.Point(828, 215);
            this.LOAD.Margin = new System.Windows.Forms.Padding(4);
            this.LOAD.Name = "LOAD";
            this.LOAD.Size = new System.Drawing.Size(127, 54);
            this.LOAD.TabIndex = 10;
            this.LOAD.Text = "LOAD";
            this.LOAD.UseVisualStyleBackColor = false;
            this.LOAD.Click += new System.EventHandler(this.LOAD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(710, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 46);
            this.label1.TabIndex = 11;
            this.label1.Text = "SIZE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(789, 281);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 46);
            this.label2.TabIndex = 12;
            this.label2.Text = "Current Turn";
            // 
            // Turn_temp
            // 
            this.Turn_temp.AutoSize = true;
            this.Turn_temp.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Turn_temp.Location = new System.Drawing.Point(862, 331);
            this.Turn_temp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Turn_temp.Name = "Turn_temp";
            this.Turn_temp.Size = new System.Drawing.Size(74, 81);
            this.Turn_temp.TabIndex = 13;
            this.Turn_temp.Text = "X";
            // 
            // Total_Move
            // 
            this.Total_Move.AutoSize = true;
            this.Total_Move.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Total_Move.Location = new System.Drawing.Point(799, 411);
            this.Total_Move.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Total_Move.Name = "Total_Move";
            this.Total_Move.Size = new System.Drawing.Size(198, 46);
            this.Total_Move.TabIndex = 14;
            this.Total_Move.Text = "Total Move";
            // 
            // num_Move
            // 
            this.num_Move.AutoSize = true;
            this.num_Move.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.num_Move.Location = new System.Drawing.Point(862, 458);
            this.num_Move.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.num_Move.Name = "num_Move";
            this.num_Move.Size = new System.Drawing.Size(70, 81);
            this.num_Move.TabIndex = 15;
            this.num_Move.Text = "0";
            // 
            // Dynamic_UI_gen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 753);
            this.Controls.Add(this.num_Move);
            this.Controls.Add(this.Total_Move);
            this.Controls.Add(this.Turn_temp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LOAD);
            this.Controls.Add(this.NumGen_Box);
            this.Controls.Add(this.SAVE_Button);
            this.Controls.Add(this.Generate);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dynamic_UI_gen";
            this.Text = "Dynamic_Ui_gen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Generate;
        private Button SAVE_Button;
        private TextBox NumGen_Box;
        private Button LOAD;
        private Label label1;
        private Label label2;
        private Label Turn_temp;
        private Label Total_Move;
        private Label num_Move;
    }
}