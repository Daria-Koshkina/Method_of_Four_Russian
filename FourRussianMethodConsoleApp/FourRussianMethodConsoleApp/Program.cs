using System;
using System.Collections.Generic;
using System.Linq;

namespace FourRussianMethodConsoleApp
{
    class FourRussianMethod
    {
        int[,] firstMatrix;
        int[,] secondMatrix;
        public int k;
        int m;
        Dictionary<string, int> preprocessingDictionary;

        public FourRussianMethod(int[,] firstMatrix, int[,] secondMatrix)
        {
            this.firstMatrix = firstMatrix;
            this.secondMatrix = secondMatrix;
            this.k = 2;
            m = firstMatrix.GetLength(0) / k;
            if (firstMatrix.GetLength(0) % k != 0)
            {
                m++;
            }
            preprocessingDictionary = getPreprocessingDict(k);
        }

        public string[,] compressMatrix(int[,] matrix, int k, bool byColumns)
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
    class Program
    {
        static void calculateAndPrintTime(int start, int end, int step)
        {
            for (int i = start; i <= end; i += step)
            {
                // create random matrices
                int[,] leftMatrix = new int[i, i];
                int[,] rightMatrix = new int[i, i];
                var rand = new Random();
                for (int j = 0; j < i; ++j)
                {
                    for (int k = 0; k < i; ++k)
                    {
                        leftMatrix[j, k] = rand.Next(0, 2);
                        rightMatrix[j, k] = rand.Next(0, 2);
                    }
                }

                // start time
                var watch = System.Diagnostics.Stopwatch.StartNew();
                FourRussianMethod fourRussianMethod = new FourRussianMethod(leftMatrix, rightMatrix);
                string[,] modifiedFirst = fourRussianMethod.compressMatrix(leftMatrix, fourRussianMethod.k, false);
                string[,] modifiedSecond = fourRussianMethod.compressMatrix(rightMatrix, fourRussianMethod.k, true);
                int[,] result = fourRussianMethod.multiplyBitMatrixes(modifiedFirst, modifiedSecond);

                // stop time
                watch.Stop();
                // print results
                Console.WriteLine($"Matrix size: {i}, execution time: {watch.ElapsedMilliseconds} ms");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // small example on boundary values
            // create matrices
            int[,] first = new int[,]
            {
                {1, 0, 0, 1, 0},
                {0, 1, 0, 0, 0},
                {1, 1, 0, 1, 0},
                {0, 0, 0, 1, 1},
                {0, 1, 1, 0, 0}
            };
            int[,] second = new int[,]
            {
                {1, 0, 0, 1, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0},
                {1, 0, 0, 1, 1},
                {0, 1, 0, 1, 0}
            };
            // initialize new entity of class
            FourRussianMethod fourRussianMethod = new FourRussianMethod(first, second);
            // compress both matrices and print them
            string[,] modifiedFirst = fourRussianMethod.compressMatrix(first, fourRussianMethod.k, false);
            for (int i = 0; i < modifiedFirst.GetLength(0); ++i)
            {
                for (int j = 0; j < modifiedFirst.GetLength(1); ++j)
                {
                    Console.Write(modifiedFirst[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("*******************************************");

            string[,] modifiedSecond = fourRussianMethod.compressMatrix(second, fourRussianMethod.k, true);
            for (int i = 0; i < modifiedSecond.GetLength(0); ++i)
            {
                for (int j = 0; j < modifiedSecond.GetLength(1); ++j)
                {
                    Console.Write(modifiedSecond[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("*******************************************");

            // get result matrix and print it
            int[,] result = fourRussianMethod.multiplyBitMatrixes(modifiedFirst, modifiedSecond);
            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            // function for big tests and checking execution time
            calculateAndPrintTime(10, 1000, 10); // arguments: start matrix size, end matrix size, step
        }
    }
}
