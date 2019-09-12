using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data
{
    /// <summary>
    /// Auflistung mit allen Werten, die eine <see cref="SudokuZelle"/> haben kann.
    /// </summary>
    public enum SudokuWert : byte
    {
        Leer = 0,
        Eins = 1,
        Zwei = 2,
        Drei = 3,
        Vier = 4,
        Fünf = 5,
        Sechs = 6,
        Sieben = 7,
        Acht = 8,
        Neun = 9
    }
}
