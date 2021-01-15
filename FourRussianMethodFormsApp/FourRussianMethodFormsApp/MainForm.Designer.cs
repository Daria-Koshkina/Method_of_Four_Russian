namespace FourRussianMethodFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.sizeNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.fillFirstMatrixButton = new System.Windows.Forms.Button();
            this.fillSecondMatrixButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(119, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter matrix size";
            // 
            // sizeNumericUpDown1
            // 
            this.sizeNumericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeNumericUpDown1.Location = new System.Drawing.Point(205, 77);
            this.sizeNumericUpDown1.Name = "sizeNumericUpDown1";
            this.sizeNumericUpDown1.Size = new System.Drawing.Size(120, 38);
            this.sizeNumericUpDown1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(146, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "n =";
            // 
            // fillFirstMatrixButton
            // 
            this.fillFirstMatrixButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.fillFirstMatrixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillFirstMatrixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fillFirstMatrixButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fillFirstMatrixButton.Location = new System.Drawing.Point(115, 141);
            this.fillFirstMatrixButton.Name = "fillFirstMatrixButton";
            this.fillFirstMatrixButton.Size = new System.Drawing.Size(237, 49);
            this.fillFirstMatrixButton.TabIndex = 3;
            this.fillFirstMatrixButton.Text = "Fill first matrix";
            this.fillFirstMatrixButton.UseVisualStyleBackColor = false;
            this.fillFirstMatrixButton.Click += new System.EventHandler(this.fillFirstMatrixButton_Click);
            // 
            // fillSecondMatrixButton
            // 
            this.fillSecondMatrixButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.fillSecondMatrixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillSecondMatrixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fillSecondMatrixButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fillSecondMatrixButton.Location = new System.Drawing.Point(115, 214);
            this.fillSecondMatrixButton.Name = "fillSecondMatrixButton";
            this.fillSecondMatrixButton.Size = new System.Drawing.Size(237, 49);
            this.fillSecondMatrixButton.TabIndex = 4;
            this.fillSecondMatrixButton.Text = "Fill second matrix";
            this.fillSecondMatrixButton.UseVisualStyleBackColor = false;
            this.fillSecondMatrixButton.Click += new System.EventHandler(this.fillSecondMatrixButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(115, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 49);
            this.button1.TabIndex = 5;
            this.button1.Text = "Get result";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(480, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fillSecondMatrixButton);
            this.Controls.Add(this.fillFirstMatrixButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeNumericUpDown1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown sizeNumericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fillFirstMatrixButton;
        private System.Windows.Forms.Button fillSecondMatrixButton;
        private System.Windows.Forms.Button button1;
    }
}

