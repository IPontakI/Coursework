using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Ringworm
    {
        public Ringworm(int n, int[,] arr, int[,] immuneArr) 
        {
            int center = n / 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == center && j == center)
                    {
                        arr[i, j] = 1;
                        immuneArr[i, j] = 10;
                        immune(arr, immuneArr, n);
                    }
                    else
                    {
                        arr[i, j] = 0;
                    }
                }
            }

        }

        public int[,] immune(int[,] arr, int[,] immuneArr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (immuneArr[i, j] > 0 && immuneArr[i, j] <= 10)
                    {
                        immuneArr[i, j] -= 1;
                    }
                    if (immuneArr[i, j] == 4)
                    {
                        arr[i, j] = 2;
                    }
                    if (immuneArr[i, j] == 0)
                    {
                        arr[i, j] = 0;
                    }
                }
            }
            return immuneArr;
        }

        public static int[,] transportTmpArr(int[,] arr, int[,] tmpArr, int n)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmpArr[i,j] = arr[i,j];
                }
            }

            return tmpArr;
        }

        public static int[,] infection2(int[,] arr, int[,] immuneArr, int n)
        {
            Random random = new Random();
            int rand;
            int[,] tmpArr = new int[n,n];
            transportTmpArr(arr, tmpArr, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (tmpArr[i,j] == 1)
                    {
                        //CENTER
                        if (i > 0 && j > 0 && i < n - 1 && j < n - 1)
                        {
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1,j] == 0)
                                {
                                    arr[i - 1,j] = 1;
                                    immuneArr[i - 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j + 1] == 0)
                                {
                                    arr[i,j + 1] = 1;
                                    immuneArr[i,j + 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1,j] == 0)
                                {
                                    arr[i + 1,j] = 1;
                                    immuneArr[i + 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j - 1] == 0)
                                {
                                    arr[i,j - 1] = 1;
                                    immuneArr[i,j - 1] = 10;
                                }
                            }
                        }
                        //CORNERS
                        if (i == 0 && j == 0)
                        { //left-up
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1,j] == 0)
                                {
                                    arr[i + 1,j] = 1;
                                    immuneArr[i + 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j + 1] == 0)
                                {
                                    arr[i,j + 1] = 1;
                                    immuneArr[i,j + 1] = 10;
                                }
                            }
                        }
                        if (i == n - 1 && j == 0)
                        { //left-down
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1,j] == 0)
                                {
                                    arr[i - 1,j] = 1;
                                    immuneArr[i - 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j + 1] == 0)
                                {
                                    arr[i,j + 1] = 1;
                                    immuneArr[i,j + 1] = 10;
                                }
                            }
                        }
                        if (i == n - 1 && j == n - 1)
                        { //right-down
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j - 1] == 0)
                                {
                                    arr[i,j - 1] = 1;
                                    immuneArr[i,j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1,j] == 0)
                                {
                                    arr[i - 1,j] = 1;
                                    immuneArr[i - 1,j] = 10;
                                }
                            }
                        }
                        /*00000000000000000000000000000000000000000000000000000000000*/
                        if (i == 0 && j == n - 1)
                        { //right-up
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1,j] == 0)
                                {
                                    arr[i + 1,j] = 1;
                                    immuneArr[i + 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j - 1] == 0)
                                {
                                    arr[i,j - 1] = 1;
                                    immuneArr[i,j - 1] = 10;
                                }

                            }
                        }
                        //BARS
                        if (i > 0 && i < n - 1 && j == 0)
                        { // left-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1,j] == 0)
                                {
                                    arr[i - 1,j] = 1;
                                    immuneArr[i - 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j + 1] == 0)
                                {
                                    arr[i,j + 1] = 1;
                                    immuneArr[i,j + 1] = 10;
                                }

                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1,j] == 0)
                                {
                                    arr[i + 1,j] = 1;
                                    immuneArr[i + 1,j] = 10;
                                }

                            }
                        }
                        if (j > 0 && j < n - 1 && i == 0)
                        { // up-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j - 1] == 0)
                                {
                                    arr[i,j - 1] = 1;
                                    immuneArr[i,j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1,j] == 0)
                                {
                                    arr[i + 1,j] = 1;
                                    immuneArr[i + 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j + 1] == 0)
                                {
                                    arr[i,j + 1] = 1;
                                    immuneArr[i,j + 1] = 10;
                                }
                            }
                        }
                        if (i > 0 && i < n - 1 && j == n - 1)
                        { // right-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1,j] == 0)
                                {
                                    arr[i - 1,j] = 1;
                                    immuneArr[i - 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j - 1] == 0)
                                {
                                    arr[i,j - 1] = 1;
                                    immuneArr[i,j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1,j] == 0)
                                {
                                    arr[i + 1,j] = 1;
                                    immuneArr[i + 1,j] = 10;
                                }
                            }
                        }
                        if (j > 0 && j < n - 1 && i == n - 1)
                        { // down-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j - 1] == 0)
                                {
                                    arr[i,j - 1] = 1;
                                    immuneArr[i,j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1,j] == 0)
                                {
                                    arr[i - 1,j] = 1;
                                    immuneArr[i - 1,j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i,j + 1] == 0)
                                {
                                    arr[i,j + 1] = 1;
                                    immuneArr[i,j + 1] = 10;
                                }
                            }
                        }
                    }
                }
            }
            return arr;
        }
    }
}
