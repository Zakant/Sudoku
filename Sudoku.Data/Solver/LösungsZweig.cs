using Sudoku.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data.Solver
{
    public class LösungsZweig
    {
        internal Guid ProblemID { get; private set; }

        public SudokuFeld Feld { get; protected set; }

        readonly List<SudokuWert>[] _möglicheWerte = new List<SudokuWert>[81];

        public LösungsZweig(Guid problemID, SudokuFeld sudokuFeld)
        {
            ProblemID = problemID;
            Feld = sudokuFeld;
        }

        public void Init()
        {
            for (int i = 0; i < 81; i++)
                _möglicheWerte[i] = new List<SudokuWert>() { SudokuWert.Eins, SudokuWert.Zwei, SudokuWert.Drei, SudokuWert.Vier, SudokuWert.Fünf, SudokuWert.Sechs, SudokuWert.Sieben, SudokuWert.Acht, SudokuWert.Neun };
        }

        public bool BerechneMöglichkeiten()
        {
            foreach (var entry in Feld.HoleAlle())
            {
                var data = entry.ToList();
                foreach (var cell in data.Where(x => x.Wert != SudokuWert.Leer))
                {
                    _möglicheWerte[cell.Index].Clear();
                    foreach (var otherCell in data)
                        _möglicheWerte[otherCell.Index].Remove(cell.Wert);
                }
            }
            return !_möglicheWerte.Where((x, i) => Feld[i].Wert == SudokuWert.Leer && !x.Any()).Any();
        }

        public bool SetzteFelder()
        {
            bool hasSet = false;
            // Alle Felder setzen, in denen nur eine Möglichkeit existiert.
            foreach (var entry in _möglicheWerte.Select((x, i) => (x, i)).Where(x => x.x.Count == 1))
            {
                hasSet = true;
                Feld[entry.i].Wert = entry.x[0];
            }

            // Alle Felder setzen, für die es eine Lösung gibt, die sonst nicht  mehr möglich ist.
            foreach (var cell in Feld.HoleAlleZellen().Where(x => x.Wert == SudokuWert.Leer))
            {
                List<SudokuWert> werte = new List<SudokuWert>();
                foreach (var wert in _möglicheWerte[cell.Index])
                    werte.Add(wert);
                var others = Feld.HoleZeile(cell.ZeilenPosition)
                                 .Concat(Feld.HoleSpalte(cell.SpaltenPosition))
                                 .Concat(Feld.HoleBlock(IndexHelper.BlockIndexFromSubscript((cell.SpaltenPosition, cell.ZeilenPosition))));
                // Remove cell and duplicates
                others = others.Distinct().Where(x => x != cell);

                foreach (var otherCell in others)
                    werte.RemoveAll(x => _möglicheWerte[otherCell.Index].Contains(x));
                if (werte.Count == 1)
                {
                    hasSet = true;
                    Feld[cell.Index].Wert = werte[0];
                }
            }
            return hasSet && !Feld.IstVollständig();
        }

        public IEnumerable<LösungsZweig> FindeZweige()
        {
            var chosenEntry = _möglicheWerte.Select((x, i) => (x, i)).Where(x => x.x.Count > 0).OrderBy(x => x.x.Count).FirstOrDefault();
            foreach(var path in chosenEntry.x)
            {
                var field = Feld.Clone();
                field[chosenEntry.i].Wert = path;
                yield return new LösungsZweig(ProblemID, field);
            }
        }
    }
}
