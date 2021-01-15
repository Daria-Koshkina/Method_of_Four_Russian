using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourRussianMethodFormsApp
{
    class FourRussianImplementationClass
    {
        int[,] firstMatrix;
        int[,] secondMatrix;
        int k; // by how many bits compress the matrix
        int m; // total number of compressed rows or columns
        public Dictionary<string, int> preprocessingDictionary;

        public FourRussianImplementationClass(int[,] firstMatrix, int[,] secondMatrix)
        {
            this.firstMatrix = firstMatrix;
            this.secondMatrix = secondMatrix;
            this.k = Convert.ToInt32(Math.Log(firstMatrix.GetLength(0)));
            m = firstMatrix.GetLength(0) / k;
            if (firstMatrix.GetLength(0) % k != 0)
            {
                m++;
            }
            preprocessingDictionary = getPreprocessingDict(k);
        }

        public string[,] compressMatrix(int[,] matrix, bool byColumns)
        {
            int n = matrix.GetLength(0);
            if (byColumns)
            {
                string[,] modifiedMatrix = new string[m, n];
                for (int i = 0; i < m; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        string str = "";
                        for (int l = 0; l < k; ++l)
                        {
                            if (i * k + l < n)
                            {
                                str += matrix[i * k + l, j];
                            }
                            else
                            {
                                str += 0;
                            }
                        }
                        modifiedMatrix[i, j] = str;
                    }
                }
                return modifiedMatrix;
            }
            else
            {
                string[,] modifiedMatrix = new string[n, m];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        string str = "";
                        for (int l = 0; l < k; ++l)
                        {
                            if (j * k + l < n)
                            {
                                str += matrix[i, j * k + l];
                            }
                            else
                            {
                                str += 0;
                            }
                        }
                        modifiedMatrix[i, j] = str;
                    }
                }
                return modifiedMatrix;
            }

        }

        public int[,] multiplyBitMatrixes(string[,] leftMatrix, string[,] rightMatrix)
        {
            int n = leftMatrix.GetLength(0);
            int[,] resultMatrix = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int num = 0;
                    for (int l = 0; l < m; ++l)
                    {
                        num += preprocessingDictionary[leftMatrix[i, l] + rightMatrix[l, j]];
                    }
                    resultMatrix[i, j] = num % 2;
                }
            }
            return resultMatrix;
        }

        public static Dictionary<string, int> getPreprocessingDict(int k)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < Math.Pow(2, k); ++i)
            {
                string bitLeftIndex = Convert.ToString(i, 2).PadLeft(k, '0');
                for (int j = 0; j < Math.Pow(2, k); ++j)
                {
                    string bitRightIndex = Convert.ToString(j, 2).PadLeft(k, '0');
                    int sum = bitLeftIndex.Zip(bitRightIndex, (left, right) => left == '1' && right == '1' ? 1 : 0).Sum();
                    dict[bitLeftIndex + bitRightIndex] = sum % 2;
                }
            }
            return dict;
        }
    }
}
