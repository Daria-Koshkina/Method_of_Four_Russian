using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourRussianMethodFormsApp
{
    public partial class ResultForm : Form
    {
        TextBox[,] firstMatrixTextBox = null;
        TextBox[,] secondMatrixTextBox = null;
        TextBox[,] resultMatrixTextBox = null;
        int[,] matrix1;
        int[,] matrix2;
        string[,] compressedMatrix1;
        string[,] compressedMatrix2;
        Dictionary<string, int> dict;
        int[,] resultMatrix;
        int dx = 40, dy = 30;

        private void ResultForm_Load(object sender, EventArgs e)
        {
            var firstLabel = new Label();
            firstLabel.Text = "Left matrix";
            firstLabel.Font = new Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            firstLabel.ForeColor = Color.MidnightBlue;
            firstLabel.TextAlign = ContentAlignment.MiddleCenter;
            firstLabel.Location = new System.Drawing.Point(10, 10);
            firstLabel.Width = matrix1.GetLength(1) * dx;
            firstLabel.Height = 20;
            this.Controls.Add(firstLabel);

            var secondLabel = new Label();
            secondLabel.Text = "Right matrix";
            secondLabel.Font = new Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            secondLabel.ForeColor = Color.MidnightBlue;
            secondLabel.TextAlign = ContentAlignment.MiddleCenter;
            secondLabel.Location = new System.Drawing.Point(30 + matrix1.GetLength(1) * dx, 10);
            secondLabel.Width = matrix1.GetLength(1) * dx;
            secondLabel.Height = 20;
            this.Controls.Add(secondLabel);

            var thirdLabel = new Label();
            thirdLabel.Text = "Result matrix";
            thirdLabel.Font = new Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            thirdLabel.ForeColor = Color.MidnightBlue;
            thirdLabel.TextAlign = ContentAlignment.MiddleCenter;
            thirdLabel.Location = new System.Drawing.Point(50 + 2 * matrix1.GetLength(1) * dx, 10);
            thirdLabel.Width = matrix1.GetLength(1) * dx;
            thirdLabel.Height = 20;
            this.Controls.Add(thirdLabel);

            var fourthLabel = new Label();
            fourthLabel.Text = "=";
            fourthLabel.Font = new Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            fourthLabel.ForeColor = Color.MidnightBlue;
            fourthLabel.TextAlign = ContentAlignment.MiddleCenter;
            fourthLabel.Location = new System.Drawing.Point(30 + 2 * matrix1.GetLength(1) * dx, (40 + matrix1.GetLength(1) * dy) / 2);
            fourthLabel.Width = 20;
            fourthLabel.Height = 20;
            this.Controls.Add(fourthLabel);

            var fifthLabel = new Label();
            fifthLabel.Text = "x";
            fifthLabel.Font = new Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            fifthLabel.ForeColor = Color.MidnightBlue;
            fifthLabel.TextAlign = ContentAlignment.MiddleCenter;
            fifthLabel.Location = new System.Drawing.Point(10 + matrix1.GetLength(1) * dx, (40 + matrix1.GetLength(1) * dy) / 2);
            fifthLabel.Width = 20;
            fifthLabel.Height = 20;
            this.Controls.Add(fifthLabel);

            firstMatrixTextBox = new TextBox[matrix1.GetLength(0), matrix1.GetLength(1)];
            secondMatrixTextBox = new TextBox[matrix2.GetLength(0), matrix2.GetLength(1)];
            resultMatrixTextBox = new TextBox[resultMatrix.GetLength(0), resultMatrix.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    firstMatrixTextBox[i, j] = new TextBox();
                    firstMatrixTextBox[i, j].Text = matrix1[i, j].ToString();
                    firstMatrixTextBox[i, j].Location = new System.Drawing.Point(10 + j * dx, 20 + firstLabel.Height + i * dy);
                    firstMatrixTextBox[i, j].Size = new System.Drawing.Size(dx, dy);
                    firstMatrixTextBox[i, j].Visible = true;
                    this.Controls.Add(firstMatrixTextBox[i, j]);
                }
            }

            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    secondMatrixTextBox[i, j] = new TextBox();
                    secondMatrixTextBox[i, j].Text = matrix2[i, j].ToString();
                    secondMatrixTextBox[i, j].Location = new System.Drawing.Point(20 + matrix1.GetLength(1) * dx + 10 + j * dx, 20 + firstLabel.Height + i * dy);
                    secondMatrixTextBox[i, j].Size = new System.Drawing.Size(dx, dy);
                    secondMatrixTextBox[i, j].Visible = true;
                    this.Controls.Add(secondMatrixTextBox[i, j]);
                }
            }

            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    resultMatrixTextBox[i, j] = new TextBox();
                    resultMatrixTextBox[i, j].Text = resultMatrix[i, j].ToString();
                    resultMatrixTextBox[i, j].Location = new System.Drawing.Point(50 + 2 * matrix1.GetLength(1) * dx + j * dx, 20 + firstLabel.Height + i * dy);
                    resultMatrixTextBox[i, j].Size = new System.Drawing.Size(dx, dy);
                    resultMatrixTextBox[i, j].Visible = true;
                    this.Controls.Add(resultMatrixTextBox[i, j]);
                }
            }

            preprocessingButton.Width = 120;
            preprocessingButton.Height = 30;
            preprocessingButton.Location = new System.Drawing.Point(50 + 3 * matrix1.GetLength(1) * dx - preprocessingButton.Width, 40 + matrix1.GetLength(1) * dy);
            this.Size = new Size(3 * matrix1.GetLength(0) * dx + 100, matrix1.GetLength(0) * dy + 130);
        }

        private void preprocessingButton_Click(object sender, EventArgs e)
        {
            PreprocessingForm preprocessingForm = new PreprocessingForm(compressedMatrix1, compressedMatrix2, dict);
            preprocessingForm.ShowDialog();
        }

        public ResultForm(string[,] compressedMatrix1, string[,] compressedMatrix2, int[,] matrix1, int[,] matrix2, int[,] resultMatrix, Dictionary<string, int> dict)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            this.resultMatrix = resultMatrix;
            this.compressedMatrix1 = compressedMatrix1;
            this.compressedMatrix2 = compressedMatrix2;
            this.dict = dict;
            InitializeComponent();
        }
    }
}
