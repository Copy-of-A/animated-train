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

        //генерация новой перестановки
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
            for (int i = X.Count; i < n; i++) X.Add(i + 1);
            List<int> Result = new List<int>(n);
            for (int i = Result.Count; i < n; i++) Result.Add(X[i]);
            min = Int32.MaxValue;
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

        /*--------------------------------------------------------------*/

        //обнуляем значения для города, в котором только что побывали
        public void DeleteCities(ref int[,] a, int n, int col)
        {
            //удаляем столбец
            for (int i = 0; i < n; i++)
            {
                if (a[i, col] != 0)
                {
                    a[i, col] = 0;
                }
            } 
        }

        public int FindFirstMin(ref int[,] a, int n, ref int str, ref int col)
        {
            int min = 1000;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j != i && a[i,j] < min)
                    {
                        min = a[i, j];
                        str = i;
                        col = j;
                    }
                }
            }
            return min;
        }

        public int FindNextMin(ref int[,] a, int n, ref int str, ref int col)
        {
            int min = 1000;
            for (int j = 0; j < n; j++)
            {              
                if (a[str, j] != 0 && a[str, j] < min)
                {
                    min = a[str, j];
                    col = j;
                }
                
            }
            return min;
        }

        public List<int> FindWayGreedyAlgorithm(int[,] D, ref int min)
        {
            List<int> Result = new List<int>();
            int n = D.GetLength(1);
            int[] mas = new int[n];
            int city_in = 0; //куда
            int city_out = 0; //откуда
            // находим первый город, в который в конце пути вернёмся
            int localmin = FindFirstMin(ref D, n, ref city_out, ref city_in);
            Result.Add(city_out);
            min += localmin;
            //запоминаем координаты возврата
            for (int i = 0; i < n; i++)
            {
                mas[i] = D[i,city_out];
            }
            //обнули столбец (куда) — (в этот город больше не поедем)
            DeleteCities(ref D, n, city_in);
            //обнуляем столбец для первого города (откуда начинаем путь), чтобы в него нельзя было попасть, не пройдя по всем
            for (int i = 0; i < n; i++)
            {
                D[i, city_out] = 0;
            }
            // для остальных городов
            for (int i = 1; i < n-1; i++)
            {
                city_out = city_in; //пришли в новый город
                localmin = FindNextMin(ref D, n, ref city_out, ref city_in);
                Result.Add(city_out);
                min += localmin;
                DeleteCities(ref D, n, city_in);
            }
            //возвращаемся из последнего посещённого в начальный
            Result.Add(city_in);
            min += mas[city_in];
            return Result;
        }
    }
}
