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
    public partial class PreprocessingForm : Form
    {
        TextBox[,] firstCompressedMatrix = null;
        TextBox[,] secondCompressedMatrix = null;
        TextBox[,] dictTextBox = null;
        string[,] compressedMatrix1;
        string[,] compressedMatrix2;
        Dictionary<string, int> dict;
        int dx = 40, dy = 30;
        public PreprocessingForm(string[,] compressedMatrix1, string[,] compressedMatrix2, Dictionary<string, int> dict)
        {
            this.compressedMatrix1 = compressedMatrix1;
            this.compressedMatrix2 = compressedMatrix2;
            this.dict = dict;
            InitializeComponent();
        }

        private void PreprocessingForm_Load(object sender, EventArgs e)
        {
            var firstLabel = new Label();
            if (compressedMatrix1.GetLength(1) < 3)
            {
                firstLabel.Text = "Left";
            }
            else
            {
                firstLabel.Text = "Left" + "\n" + "compressed matrix";
            }
            firstLabel.Font = new Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            firstLabel.ForeColor = Color.MidnightBlue;
            firstLabel.Location = new System.Drawing.Point(10, 10);
            firstLabel.Height = 20;
            firstLabel.AutoSize = true;
            this.Controls.Add(firstLabel);

            var secondLabel = new Label();
            if (compressedMatrix2.GetLength(1) < 3)
            {
                secondLabel.Text = "Right";
            } else
            {
                secondLabel.Text = "Right" + "\n" + "compressed matrix";
            }
            secondLabel.Font = new Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            secondLabel.ForeColor = Color.MidnightBlue;
            secondLabel.Location = new System.Drawing.Point(30 + compressedMatrix1.GetLength(1) * dx, 10);
            secondLabel.Height = 20;
            secondLabel.AutoSize = true;
            this.Controls.Add(secondLabel);

            var thirdLabel = new Label();
            thirdLabel.Text = "Preprocessing" + "\n" + "Dictionary";
            thirdLabel.Font = new Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            thirdLabel.ForeColor = Color.MidnightBlue;
            thirdLabel.Location = new System.Drawing.Point(50 + compressedMatrix1.GetLength(1) * dx + compressedMatrix2.GetLength(1) * dx, 10);
            thirdLabel.Height = 20;
            thirdLabel.AutoSize = true;
            this.Controls.Add(thirdLabel);

            firstCompressedMatrix = new TextBox[compressedMatrix1.GetLength(0), compressedMatrix1.GetLength(1)];
            secondCompressedMatrix = new TextBox[compressedMatrix2.GetLength(0), compressedMatrix2.GetLength(1)];
            dictTextBox = new TextBox[dict.Count, 2];
            for (int i = 0; i < compressedMatrix1.GetLength(0); i++)
            {
                for (int j = 0; j < compressedMatrix1.GetLength(1); j++)
                {
                    firstCompressedMatrix[i, j] = new TextBox();
                    firstCompressedMatrix[i, j].Text = compressedMatrix1[i,j];
                    firstCompressedMatrix[i, j].Location = new System.Drawing.Point(10 + j * dx, 20 + firstLabel.Height + i * dy);
                    firstCompressedMatrix[i, j].Size = new System.Drawing.Size(dx, dy);
                    firstCompressedMatrix[i, j].Visible = true;
                    this.Controls.Add(firstCompressedMatrix[i, j]);
                }
            }

            for (int i = 0; i < compressedMatrix2.GetLength(0); i++)
            {
                for (int j = 0; j < compressedMatrix2.GetLength(1); j++)
                {
                    secondCompressedMatrix[i, j] = new TextBox();
                    secondCompressedMatrix[i, j].Text = compressedMatrix2[i,j];
                    secondCompressedMatrix[i, j].Location = new System.Drawing.Point(20 + compressedMatrix1.GetLength(1) * dx + 10 + j * dx, 20 + firstLabel.Height + i * dy);
                    secondCompressedMatrix[i, j].Size = new System.Drawing.Size(dx, dy);
                    secondCompressedMatrix[i, j].Visible = true;
                    this.Controls.Add(secondCompressedMatrix[i, j]);
                }
            }

            int l = 0;
            foreach (KeyValuePair<string, int> keyValue in dict)
            {
                dictTextBox[l, 0] = new TextBox();
                dictTextBox[l, 0].Text = keyValue.Key;
                dictTextBox[l, 0].Location = new System.Drawing.Point(50 + compressedMatrix1.GetLength(1) * dx + compressedMatrix2.GetLength(1) * dx, 20 + firstLabel.Height + l * dy);
                dictTextBox[l, 0].Size = new System.Drawing.Size(dx, dy);
                dictTextBox[l, 0].Visible = true;
                this.Controls.Add(dictTextBox[l, 0]);

                dictTextBox[l, 1] = new TextBox();
                dictTextBox[l, 1].Text = keyValue.Value.ToString();
                dictTextBox[l, 1].Location = new System.Drawing.Point(60 + dx + compressedMatrix1.GetLength(1) * dx + compressedMatrix2.GetLength(1) * dx, 20 + firstLabel.Height + l * dy);
                dictTextBox[l, 1].Size = new System.Drawing.Size(dx, dy);
                dictTextBox[l, 1].Visible = true;
                this.Controls.Add(dictTextBox[l, 1]);

                l++;
            }

            this.Size = new Size(110 + firstCompressedMatrix.GetLength(1) * dx + secondCompressedMatrix.GetLength(1) * dx + 2 * dx,
                                 100 + Math.Max(firstCompressedMatrix.GetLength(0), dict.Count) * dy);
        }
    }
}
