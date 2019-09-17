using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data.Solver
{
    public class LösungsErgebnis
    {
        public LösungsStatus Status { get; protected set; }

        public SudokuFeld Feld { get; protected set; }

        public LösungsErgebnis(LösungsStatus status) : this(status, null) { }

        public LösungsErgebnis(LösungsStatus status, SudokuFeld feld)
        {
            Status = status;
            if (Status == LösungsStatus.Erfolgreich && feld == null)
                throw new ArgumentNullException("Status ist erfolgreich, aber feld ist null!");
            Feld = feld;
        }
    }
}
