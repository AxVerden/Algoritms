using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Program
    {
        public class LevenshteinDistance
        {
            private static int isEqualElements(int firstIndex, int secondIndex,string firstLine, string secondLine)
            {
                if (firstLine[firstIndex-1] == secondLine[secondIndex-1])
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            private static int algorithmOfWagnerFisher(int i, int j,int[,] array, string firstLine, string secondLine)
            {
                int[] tempArray = new int[3];
                if (i == 0 && j == 0)
                {
                    return 0;
                }
                else if (i > 0 && j == 0)
                {
                    return i;
                }
                else if (i == 0 && j > 0)
                {
                    return j;
                }
                else
                {
                    tempArray[0] = array[i, j - 1] + 1;
                    tempArray[1] = array[i -1, j] + 1;
                    tempArray[2] = array[i - 1, j - 1] + isEqualElements(i,j,firstLine,secondLine);
                    return tempArray.Min();
                }
            }
            public static int findLevenshteinDistance(string firstLine, string secondLine)
            {
                int[,] matrix = new int[firstLine.Length + 1,secondLine.Length+1];
                for (int i = 0; i < firstLine.Length+1; i++)
                {
                    for (int j = 0; j < secondLine.Length+1; j++)
                    {
                        matrix[i, j] = algorithmOfWagnerFisher(i,j,matrix,firstLine,secondLine);
                    }
                }
                return matrix[firstLine.Length, secondLine.Length];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(LevenshteinDistance.findLevenshteinDistance("cat", "dots"));
        }
    }
}
