using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data.Solver
{

    public static class SudokuLöser
    {
        public static LösungsErgebnis Lösen(this SudokuFeld feld)
        {
            
        }

        public static Task<LösungsErgebnis> LösenAsync(this SudokuFeld feld)
        {
            return Task.Run(() => Lösen(feld));
        }
    }
}
