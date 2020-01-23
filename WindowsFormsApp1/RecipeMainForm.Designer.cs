namespace Recipes
{
    partial class RecipeMainForm
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
            this.sQLDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecipelistBox = new System.Windows.Forms.ListBox();
            this.RecipeLabel = new System.Windows.Forms.Label();
            this.AddRecipeButton = new System.Windows.Forms.Button();
            this.jnb = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.sQLDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RecipelistBox
            // 
            this.RecipelistBox.FormattingEnabled = true;
            this.RecipelistBox.ItemHeight = 25;
            this.RecipelistBox.Location = new System.Drawing.Point(221, 131);
            this.RecipelistBox.Name = "RecipelistBox";
            this.RecipelistBox.Size = new System.Drawing.Size(494, 729);
            this.RecipelistBox.TabIndex = 0;
            this.RecipelistBox.DoubleClick += new System.EventHandler(this.RecipelistBox_DoubleClick);
            // 
            // RecipeLabel
            // 
            this.RecipeLabel.AutoSize = true;
            this.RecipeLabel.Location = new System.Drawing.Point(319, 78);
            this.RecipeLabel.Name = "RecipeLabel";
            this.RecipeLabel.Size = new System.Drawing.Size(296, 25);
            this.RecipeLabel.TabIndex = 2;
            this.RecipeLabel.Text = "Double Click to Select Recipe";
            // 
            // AddRecipeButton
            // 
            this.AddRecipeButton.Location = new System.Drawing.Point(324, 927);
            this.AddRecipeButton.Name = "AddRecipeButton";
            this.AddRecipeButton.Size = new System.Drawing.Size(238, 57);
            this.AddRecipeButton.TabIndex = 3;
            this.AddRecipeButton.Text = "Add New Recipe";
            this.AddRecipeButton.UseVisualStyleBackColor = true;
            this.AddRecipeButton.Click += new System.EventHandler(this.AddRecipeButton_Click);
            // 
            // jnb
            // 
            this.jnb.Location = new System.Drawing.Point(12, 12);
            this.jnb.Name = "jnb";
            this.jnb.Size = new System.Drawing.Size(922, 1056);
            this.jnb.TabIndex = 4;
            this.jnb.TabStop = false;
            // 
            // RecipeMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(946, 1080);
            this.Controls.Add(this.AddRecipeButton);
            this.Controls.Add(this.RecipeLabel);
            this.Controls.Add(this.RecipelistBox);
            this.Controls.Add(this.jnb);
            this.Name = "RecipeMainForm";
            this.Text = "Debbie\'s Recipes";
            ((System.ComponentModel.ISupportInitialize)(this.sQLDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource sQLDataBindingSource;
        private System.Windows.Forms.ListBox RecipelistBox;
        private System.Windows.Forms.Label RecipeLabel;
        private System.Windows.Forms.Button AddRecipeButton;
        private System.Windows.Forms.GroupBox jnb;
    }
}

