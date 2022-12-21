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
            this.List_Count = new System.Windows.Forms.TextBox();
            this.LOAD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.BackColor = System.Drawing.Color.Green;
            this.Generate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Generate.ForeColor = System.Drawing.Color.Transparent;
            this.Generate.Location = new System.Drawing.Point(1345, 146);
            this.Generate.Margin = new System.Windows.Forms.Padding(6);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(206, 87);
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
            this.SAVE_Button.Location = new System.Drawing.Point(1345, 245);
            this.SAVE_Button.Margin = new System.Windows.Forms.Padding(6);
            this.SAVE_Button.Name = "SAVE_Button";
            this.SAVE_Button.Size = new System.Drawing.Size(206, 87);
            this.SAVE_Button.TabIndex = 1;
            this.SAVE_Button.Text = "SAVE";
            this.SAVE_Button.UseVisualStyleBackColor = false;
            this.SAVE_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // NumGen_Box
            // 
            this.NumGen_Box.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NumGen_Box.Location = new System.Drawing.Point(1298, 31);
            this.NumGen_Box.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.NumGen_Box.Name = "NumGen_Box";
            this.NumGen_Box.Size = new System.Drawing.Size(286, 93);
            this.NumGen_Box.TabIndex = 2;
            this.NumGen_Box.TextChanged += new System.EventHandler(this.NumGen_Box_TextChanged);
            // 
            // List_Count
            // 
            this.List_Count.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.List_Count.Location = new System.Drawing.Point(1298, 454);
            this.List_Count.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.List_Count.Name = "List_Count";
            this.List_Count.Size = new System.Drawing.Size(286, 93);
            this.List_Count.TabIndex = 9;
            // 
            // LOAD
            // 
            this.LOAD.BackColor = System.Drawing.Color.Gold;
            this.LOAD.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LOAD.ForeColor = System.Drawing.Color.Transparent;
            this.LOAD.Location = new System.Drawing.Point(1345, 344);
            this.LOAD.Margin = new System.Windows.Forms.Padding(6);
            this.LOAD.Name = "LOAD";
            this.LOAD.Size = new System.Drawing.Size(206, 87);
            this.LOAD.TabIndex = 10;
            this.LOAD.Text = "LOAD";
            this.LOAD.UseVisualStyleBackColor = false;
            this.LOAD.Click += new System.EventHandler(this.LOAD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1154, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 71);
            this.label1.TabIndex = 11;
            this.label1.Text = "SIZE";
            // 
            // Dynamic_UI_gen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1653, 981);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LOAD);
            this.Controls.Add(this.List_Count);
            this.Controls.Add(this.NumGen_Box);
            this.Controls.Add(this.SAVE_Button);
            this.Controls.Add(this.Generate);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Dynamic_UI_gen";
            this.Text = "Dynamic_Ui_gen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Generate;
        private Button SAVE_Button;
        private TextBox NumGen_Box;
        private TextBox List_Count;
        private Button LOAD;
        private Label label1;
    }
}