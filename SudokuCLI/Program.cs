using Sudoku.Data.Helper;
using Sudoku.Data.Solver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string sudokuString = @"530070000
                                    600195000
                                    098000060
                                    800060003
                                    400803001
                                    700020006
                                    060000280
                                    000419005
                                    000080079";
            // var sudoku = LadeHelper.LadeVonText(sudokuString);
            var sudoku = LadeHelper.LadeVonDatei(".\\Examples\\Schwer2.txt");
            Console.WriteLine("Input sudoku is:");
            Console.WriteLine(sudoku.ToString());
            Console.WriteLine("\nSolving...");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = SudokuLöser.Lösen(sudoku);
            sw.Stop();
            Console.WriteLine($"Solution computed in {sw.ElapsedMilliseconds}ms");
            Console.WriteLine("Solution:");
            Console.WriteLine(result.Feld);
            Console.ReadLine();
        }
    }
}
