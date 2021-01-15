namespace FourRussianMethodFormsApp
{
    partial class ResultForm
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
            this.preprocessingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // preprocessingButton
            // 
            this.preprocessingButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.preprocessingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preprocessingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.preprocessingButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.preprocessingButton.Location = new System.Drawing.Point(17, 18);
            this.preprocessingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.preprocessingButton.Name = "preprocessingButton";
            this.preprocessingButton.Size = new System.Drawing.Size(246, 77);
            this.preprocessingButton.TabIndex = 0;
            this.preprocessingButton.Text = "Preprocessing";
            this.preprocessingButton.UseVisualStyleBackColor = false;
            this.preprocessingButton.Click += new System.EventHandler(this.preprocessingButton_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(2098, 996);
            this.Controls.Add(this.preprocessingButton);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button preprocessingButton;
    }
}