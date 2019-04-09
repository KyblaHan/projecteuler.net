using System;
using System.Collections.Generic;

/*
 * Su Doku (Japanese meaning number place) is the name given to a popular puzzle concept. Its origin is unclear,
 * but credit must be attributed to Leonhard Euler who invented a similar, and much more difficult,
 * puzzle idea called Latin Squares. The objective of Su Doku puzzles, however,
 * is to replace the blanks (or zeros) in a 9 by 9 grid in such that each row, column,
 * and 3 by 3 box contains each of the digits 1 to 9. Below is an example of a typical starting puzzle grid and its solution grid.
A well constructed Su Doku puzzle has a unique solution and can be solved by logic, 
although it may be necessary to employ "guess and test" methods in order to eliminate options (there is much contested opinion over this).
The complexity of the search determines the difficulty of the puzzle; the example above is considered easy because it can be solved by straight forward direct deduction.

The 6K text file, sudoku.txt (right click and 'Save Link/Target As...'), contains fifty different Su Doku puzzles ranging in difficulty, 
but all with unique solutions (the first puzzle in the file is the example above).

By solving all fifty puzzles find the sum of the 3-digit numbers found in the top left corner of each solution grid; for example,
483 is the 3-digit number found in the top left corner of the solution grid above.
 */
namespace _96_Su_Doku
{
    class Coords
    {
        public int I;
        public int J;

        public Coords(int I, int J)
        {
            this.I = I;
            this.J = J;
        }
    }

    class Program
    {
        private static int[,] _sudoky = { { 0,0,3,0,2,0,6,0,0 },
                                         { 9,0,0,3,0,5,0,0,1 },
                                         { 0,0,1,8,0,6,4,0,0 },
                                         { 0,0,8,1,0,2,9,0,0 },
                                         { 7,0,0,0,0,0,0,0,8 },
                                         { 0,0,6,7,0,8,2,0,0 },
                                         { 0,0,2,6,0,9,5,0,0 },
                                         { 8,0,0,2,0,3,0,0,9 },
                                         { 0,0,5,0,1,0,3,0,0 } };
        /// <summary>
        /// Прогноз
        /// </summary>
        public static List<int>[,] Forecasts = new List<int>[9, 9];

        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    Forecasts[i, j] = new List<int>();

            
            AnalizeForecasts();

            // WriteForecast();
            // WriteTable();

            BaseCheck();

             WriteForecast();
            // WriteTable();
            CheckDoubles();
            WriteTable();
           ExcessForecast();
            // WriteForecast();
            WriteTable();
        }
        /// <summary>
        /// Для каждой пустой ячейки + для каждой прогнозной цифры в этой ячейке ищем хотя бы одну другую пустую ячейку
        /// (в строке, колонке или блоке), где эта цифра тоже присутствует. Если не найдено, заполняем этой цифрой ячейку.
        /// </summary>
        static void ExcessForecast()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (_sudoky[i, j] == 0 && Forecasts[i, j].Count > 1)
                    {
                        for (int k = 0; k < Forecasts[i, j].Count; k++)
                        {
                            for (int l = 0; l < 9; l++)
                            {
                                if (_sudoky[i, l] == 0 && !Forecasts[i, l].Contains(Forecasts[i, j][k]) && l!=j)
                                {
                                    _sudoky[i, j] = Forecasts[i, j][k];
                                }
                            }
                        }
                    }
        }
        /// <summary>
        /// Для каждой пустой ячейки ищем другие ячейки с таким же прогнозом — для строки,
        /// колонки и блока. Если общее количество таких ячеек (для колонки, строки или блока)
        /// равно длине прогноза, убираем прогнозные цифры из всех остальных ячеек, кроме найденных.
        /// Если в ячейке осталась только одна прогнозная цифра, заполнить её этой цифрой
        /// </summary>
        static void CheckDoubles()
        {
            int left, right;
            int down, up;
            List<int> indexes = new List<int>();

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (_sudoky[i, j] == 0)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            if (Forecasts[i, j] == Forecasts[k, j] && k != i)
                                indexes.Add(k);
                        }
                        if (Forecasts[i, j].Count == indexes.Count)
                            for (int k = 0; k < 9; k++)
                            {
                                if (!indexes.Contains(k))
                                    foreach (var VARIABLE in Forecasts[i, j])
                                    {
                                        Forecasts[k, j].Remove(VARIABLE);
                                    }
                            }
                        indexes.Clear();
                        for (int k = 0; k < 9; k++)
                        {
                            if (Forecasts[i, j] == Forecasts[i, k] && k != j)
                                indexes.Add(k);
                        }
                        if (Forecasts[i, j].Count == indexes.Count)
                            for (int k = 0; k < 9; k++)
                            {
                                if (!indexes.Contains(k))
                                    foreach (var VARIABLE in Forecasts[i, j])
                                    {
                                        Forecasts[i, k].Remove(VARIABLE);
                                    }
                            }


                        if (i <= 2)
                            left = 0;
                        else if (i <= 5)
                            left = 3;
                        else
                            left = 6;

                        if (j <= 2)
                            up = 0;
                        else if (j <= 5)
                            up = 3;
                        else
                            up = 6;

                        right = left + 2;
                        down = up + 2;

                        List<Coords> position = new List<Coords>();

                        for (int Ii = left; Ii <= right; Ii++)
                            for (int Jj = up; Jj < down; Jj++)
                            {
                                if (Forecasts[i, j] == Forecasts[Ii, Jj] && Ii != i && Jj != j)
                                {
                                    position.Add(new Coords(Ii, Jj));
                                }

                            }
                        if (Forecasts[i, j].Count == position.Count)
                            for (int Ii = left; Ii <= right; Ii++)
                                for (int Jj = up; Jj < down; Jj++)
                                {
                                    if (!position.Contains(new Coords(Ii, Jj)))
                                        foreach (var VARIABLE in Forecasts[i, j])
                                        {
                                            Forecasts[Ii, Jj].Remove(VARIABLE);
                                        }
                                }
                    }

            SoloForecasts();
        }

        /// <summary>
        /// Проверка на наличие 1 эл-та в прогнозе
        /// </summary>
        static void SoloForecasts()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (Forecasts[i, j].Count == 1)
                    {
                        _sudoky[i, j] = Forecasts[i, j][0];
                    }
        }
        /// <summary>
        /// Для каждой пустой ячейки: из прогноза убираем цифры
        /// из соответствующих полных ячеек (по горизонтали, вертикали и в блоке).
        /// Если в ячейке осталась только одна прогнозная цифра, заполнить её этой цифрой. 
        /// </summary>
        static void BaseCheck()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (_sudoky[i, j] == 0)
                    {
                        for (int k = 0; k < Forecasts[i, j].Count; k++)
                        {
                            if (!CheckPos(i, j, Forecasts[i, j][k]))
                            {
                                Forecasts[i, j].RemoveAt(k);
                                k = 0;
                            }
                        }

                    }

            SoloForecasts();
        }
        static void WriteForecast()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Forecasts[i, j].Count > 0)
                    {
                        Console.Write("Position: " + i + ", " + j + " => ");
                        foreach (var VARIABLE in Forecasts[i, j])
                        {
                            Console.Write(VARIABLE + ", ");
                        }
                        Console.WriteLine();
                    }


                }
            Console.WriteLine("==================");
        }
        /// <summary>
        /// Вывод Судоку
        /// </summary>
        static void WriteTable()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(_sudoky[i, j] + " ");
                    if (j == 2 || j == 5)
                        Console.Write("|");
                }


                if (i == 2 || i == 5)
                    Console.WriteLine("\n------|------|------");
                else
                    Console.WriteLine();


            }

            Console.WriteLine("========================");
        }

        /// <summary>
        /// В соответствии с правилами судоку и текущим состоянием полных и пустых ячеек,
        /// для каждой пустой ячейки собрать список возможных значений. Если в ячейке осталась только одна прогнозная цифра, заполнить её этой цифрой. 
        /// </summary>
        static void AnalizeForecasts()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (_sudoky[i, j] == 0)
                    {
                        for (int k = 1; k <= 9; k++)
                            if (CheckPos(i, j, k))
                                Forecasts[i, j].Add(k);
                    }
            SoloForecasts();
        }
        /// <summary>
        /// Проверка ворзможности поставить указанное число на указанную позицию
        /// </summary>
        /// <param name="posI"></param>
        /// <param name="posJ"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        static bool CheckPos(int posI, int posJ, int num)
        {
            int left, right;
            int down, up;

            for (int i = 0; i < 9; i++)
                if (_sudoky[i, posJ] == num)
                    return false;

            for (int j = 0; j < 9; j++)
                if (_sudoky[posI, j] == num)
                    return false;

            if (posI <= 2)
                left = 0;
            else if (posI <= 5)
                left = 3;
            else
                left = 6;

            if (posJ <= 2)
                up = 0;
            else if (posJ <= 5)
                up = 3;
            else
                up = 6;

            right = left + 2;
            down = up + 2;

            for (int i = left; i <= right; i++)
                for (int j = up; j < down; j++)
                    if (_sudoky[i, j] == num)
                        return false;

            return true;
        }
    }
}
