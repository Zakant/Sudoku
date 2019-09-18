using Sudoku.Data.Helper;
using Sudoku.Data.Solver;
using System;
using System.Collections.Generic;
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
            var sudoku = LadeHelper.LadeVonText(sudokuString);
            Console.WriteLine(sudoku.ToString());
            Console.WriteLine("\nSolving...");
            var result = SudokuLöser.Lösen(sudoku);
            Console.WriteLine("Solution:");
            Console.WriteLine(result.Feld);
            Console.ReadLine();
        }
    }
}
