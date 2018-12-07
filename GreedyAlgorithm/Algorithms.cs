using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithm
{
    class Algorithms
    {
        public void Swap(ref List<int> p, int a, int b)
        {
            int c;
            c = p[a];
            p[a] = p[b];
            p[b] = c;
        }

        public bool GenerateNextPermutation(ref List<int> p)
        {
            bool result;
            int i;
            int n;
            int j;
            n = p.Count;
            i = n - 1;
            while ((i > 0) && (p[i] < p[i - 1]))
                i--;
            if (i == 1)
                result = false;
            else
            {
                j = n - 1;
                while (p[j] < p[i - 1])
                    j--;
                Swap(ref p, i - 1, j);
                j = 0;
                while (j <= (n - i) / 2 - 1)
                {
                    Swap(ref p, i + j, n - j - 1);
                    j++;
                }
                result = true;
            }
            return result;
        }

        public int CountKilometrsInWay(ref List<int> X, ref int[,] TR)
        {
            int n = X.Count;
            int result = 0;
            for (int i = 0; i <= n - 2; i++)
                result = result + TR[X[i] - 1, X[i + 1] - 1];
            result = result + TR[X[n - 1] - 1, X[0] - 1];
            return result;
        }

        //полный перебор
        public List<int> FindMinWayExhaustiveSearch(int[,] TR, ref int min)
        {
            int n;
            int tmp;
            n = TR.GetLength(1);
            List<int> X = new List<int>(n);
            for (int i = X.Count; i < n; i++) X.Add(0);
            for (int i = 0; i <= n - 1; i++) X[i] = i + 1;
            List<int> Result = new List<int>(n);
            for (int i = Result.Count; i < n; i++) Result.Add(0);
            min = CountKilometrsInWay(ref X, ref TR);
            do
            {
                tmp = CountKilometrsInWay(ref X, ref TR);
                if (tmp < min)
                {
                    min = tmp;
                    for (int i = 0; i < n; i++)
                        Result[i] = X[i];
                }
            }
            while (GenerateNextPermutation(ref X));
            return Result;
        }
    }
}
