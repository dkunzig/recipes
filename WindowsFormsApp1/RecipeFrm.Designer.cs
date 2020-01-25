namespace Recipes

{
    partial class RecipeFrm
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
            this.IngredientsTextBox = new System.Windows.Forms.TextBox();
            this.InstructionsTextBox = new System.Windows.Forms.TextBox();
            this.RecipeNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.CreditToTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eMailButton = new System.Windows.Forms.Button();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IngredientsTextBox
            // 
            this.IngredientsTextBox.Location = new System.Drawing.Point(1304, 170);
            this.IngredientsTextBox.Multiline = true;
            this.IngredientsTextBox.Name = "IngredientsTextBox";
            this.IngredientsTextBox.Size = new System.Drawing.Size(655, 918);
            this.IngredientsTextBox.TabIndex = 0;
            // 
            // InstructionsTextBox
            // 
            this.InstructionsTextBox.Location = new System.Drawing.Point(255, 265);
            this.InstructionsTextBox.Multiline = true;
            this.InstructionsTextBox.Name = "InstructionsTextBox";
            this.InstructionsTextBox.Size = new System.Drawing.Size(912, 640);
            this.InstructionsTextBox.TabIndex = 1;
            // 
            // RecipeNameTextBox
            // 
            this.RecipeNameTextBox.Location = new System.Drawing.Point(845, 81);
            this.RecipeNameTextBox.Name = "RecipeNameTextBox";
            this.RecipeNameTextBox.Size = new System.Drawing.Size(627, 31);
            this.RecipeNameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reicpe Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cooking Instructions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1543, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ingredients";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(2107, 491);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(198, 53);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(2107, 586);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(198, 53);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Done";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(2107, 667);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(198, 53);
            this.PrintButton.TabIndex = 8;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // CreditToTextBox
            // 
            this.CreditToTextBox.Location = new System.Drawing.Point(666, 1051);
            this.CreditToTextBox.Name = "CreditToTextBox";
            this.CreditToTextBox.Size = new System.Drawing.Size(363, 31);
            this.CreditToTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(775, 1013);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Credit To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.emailTextBox);
            this.groupBox1.Controls.Add(this.eMailButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.PrintButton);
            this.groupBox1.Controls.Add(this.InstructionsTextBox);
            this.groupBox1.Controls.Add(this.IngredientsTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2438, 1260);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // eMailButton
            // 
            this.eMailButton.Location = new System.Drawing.Point(2107, 758);
            this.eMailButton.Name = "eMailButton";
            this.eMailButton.Size = new System.Drawing.Size(198, 53);
            this.eMailButton.TabIndex = 9;
            this.eMailButton.Text = "eMail";
            this.eMailButton.UseVisualStyleBackColor = true;
            this.eMailButton.Click += new System.EventHandler(this.eMailButton_Click);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(2005, 884);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(410, 31);
            this.emailTextBox.TabIndex = 10;
            // 
            // RecipeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2458, 1264);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CreditToTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RecipeNameTextBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecipeFrm";
            this.Text = "AddRecipe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IngredientsTextBox;
        private System.Windows.Forms.TextBox InstructionsTextBox;
        private System.Windows.Forms.TextBox RecipeNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.TextBox CreditToTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button eMailButton;
        private System.Windows.Forms.TextBox emailTextBox;
    }
}