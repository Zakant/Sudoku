using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data.Solver
{
    internal class SolverPool
    {
        internal SolverPool Instance { get; } = new SolverPool();
    }
}
