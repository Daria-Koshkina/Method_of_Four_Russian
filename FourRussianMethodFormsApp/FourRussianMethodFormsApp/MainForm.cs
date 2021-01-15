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
    public partial class MainForm : Form
    {
        const int MaxN = 10;
        int n;
        TextBox[,] MatrText = null;
        int[,] firstMatrix = new int[MaxN, MaxN]; 
        int[,] secondMatrix = new int[MaxN, MaxN];
        string[,] compressedFirstMatrix;
        string[,] compressedSecondMatrix;
        int[,] resultMatrix;
        bool f1;
        bool f2;
        int dx = 40, dy = 30;
        FillMatrixDataForm matrixDataForm = null;
        FourRussianImplementationClass fourRussianImplementationClass;

        private void MainForm_Load(object sender, EventArgs e)
        {
            f1 = f2 = false;
            int i, j;
            matrixDataForm = new FillMatrixDataForm();
            MatrText = new TextBox[MaxN, MaxN];
            for (i = 0; i < MaxN; i++)
            {
                for (j = 0; j < MaxN; j++)
                {
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new System.Drawing.Point(10 + j * dx, 10 + i * dy);
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    MatrText[i, j].Visible = false;
                    matrixDataForm.Controls.Add(MatrText[i, j]);
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void fillFirstMatrixButton_Click(object sender, EventArgs e)
        {
            if (sizeNumericUpDown1.Value <= 1) return;
            n = Convert.ToInt32(sizeNumericUpDown1.Value);
            Clear_MatrText();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].Visible = true;
                }

            matrixDataForm.Width = 30 + n * dx;
            matrixDataForm.Height = 60 + n * dy + matrixDataForm.OKbutton.Height;
            matrixDataForm.OKbutton.Left = 10;
            matrixDataForm.OKbutton.Top = 20 + n * dy;
            matrixDataForm.OKbutton.Width = matrixDataForm.Width - 30;

            if (matrixDataForm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            firstMatrix[i, j] = Convert.ToInt32(MatrText[i, j].Text);
                        else
                            firstMatrix[i, j] = 0;
                f1 = true;
            }
        }

        private void fillSecondMatrixButton_Click(object sender, EventArgs e)
        {
            if (sizeNumericUpDown1.Value <= 1) return;
            n = Convert.ToInt32(sizeNumericUpDown1.Value);
            Clear_MatrText();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].Visible = true;
                }

            matrixDataForm.Width = 30 + n * dx;
            matrixDataForm.Height = 60 + n * dy + matrixDataForm.OKbutton.Height;

            matrixDataForm.OKbutton.Left = 10;
            matrixDataForm.OKbutton.Top = 20 + n * dy;
            matrixDataForm.OKbutton.Width = matrixDataForm.Width - 30;

            if (matrixDataForm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        secondMatrix[i, j] = Convert.ToInt32(MatrText[i, j].Text);
                f2 = true;
            }
        }

        private void Clear_MatrText()
        {
            for (int i = 0; i < MaxN; i++)
            {
                for (int j = 0; j < MaxN; j++)
                {
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(f1 == true && f2 == true))
            {
                return;
            }
            int[,] matrix1 = new int[n,n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    matrix1[i, j] = firstMatrix[i, j];
                }
            }

            int[,] matrix2 = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    matrix2[i, j] = secondMatrix[i, j];
                }
            }
            fourRussianImplementationClass = new FourRussianImplementationClass(matrix1, matrix2);
            compressedFirstMatrix = fourRussianImplementationClass.compressMatrix(matrix1, false);
            compressedSecondMatrix = fourRussianImplementationClass.compressMatrix(matrix2, true);
            resultMatrix = fourRussianImplementationClass.multiplyBitMatrixes(compressedFirstMatrix,
                                                                              compressedSecondMatrix);
            ResultForm resultForm = new ResultForm(compressedFirstMatrix,
                                                   compressedSecondMatrix,
                                                   matrix1,
                                                   matrix2,
                                                   resultMatrix,
                                                   fourRussianImplementationClass.preprocessingDictionary);
            resultForm.ShowDialog();
        }

        
    }
}
