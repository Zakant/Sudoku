using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data
{
    /// <summary>
    /// Stellt eine einzelne Sudoku Zelle da. Jedes Sudoku Feld besteht aus 9x9 Zellen.
    /// </summary>
    public class SudokuZelle
    {
        /// <summary>
        /// Der Wert den die Sudoku Zelle aktuell hat.
        /// </summary>
        public SudokuWert Wert { get; set; }

        public override string ToString()
        {
            switch(Wert)
            {
                case SudokuWert.Leer: return " ";
                case SudokuWert.Eins: return "1";
                case SudokuWert.Zwei: return "2";
                case SudokuWert.Drei: return "3";
                case SudokuWert.Vier: return "4";
                case SudokuWert.Fünf: return "5";
                case SudokuWert.Sechs: return "6";
                case SudokuWert.Sieben: return "7";
                case SudokuWert.Acht: return "8";
                case SudokuWert.Neun: return "9";
                default: throw new Exception("Invalid value");
            }
        }
    }
}
