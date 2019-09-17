using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data.Solver
{
    /// <summary>
    /// Stellt statische und erweiterungs Methode zum lösen von Sudokus bereit.
    /// </summary>
    public static class SudokuLöser
    {
        /// <summary>
        /// Löst ein Sudoku.
        /// </summary>
        /// <param name="feld">Das Feld des Sudokus, dass gelöst werden soll.</param>
        /// <returns>Ein Objekt, dass das Ergebniss der Lösungsoperation enthält. Sollte das Lösen erfolgreich verlaufen sein, ist auch das gelöste Feld enthalten.</returns>
        public static LösungsErgebnis Lösen(this SudokuFeld feld)
        {
            if (!feld.IstValide())
                return new LösungsErgebnis(LösungsStatus.Ungültig);
            Guid problemId = Guid.NewGuid();
            Stack<LösungsZweig> _zweige = new Stack<LösungsZweig>();
            _zweige.Push(new LösungsZweig(problemId, feld.Clone()));

            while (_zweige.Count != 0)
            {
                var currentZweig = _zweige.Pop();
                currentZweig.Init();
                if (BearbeiteZweig(currentZweig))
                    if (currentZweig.Feld.IstVollständig() && currentZweig.Feld.IstValide())
                        return new LösungsErgebnis(LösungsStatus.Erfolgreich, currentZweig.Feld);
                    else
                        foreach (var zweig in currentZweig.FindeZweige())
                            _zweige.Push(zweig);
            }
            return new LösungsErgebnis(LösungsStatus.Fehlerhaft);

            static bool BearbeiteZweig(LösungsZweig zweig)
            {
                do
                {
                    if (!zweig.BerechneMöglichkeiten())
                        return false;
                } while (zweig.SetzteFelder());
                return true;
            }
        }

        /// <summary>
        /// Löst ein Sudoku asynchron.
        /// </summary>
        /// <param name="feld">Das Feld des Sudokus, dass gelöst werden soll.</param>
        /// <returns>Ein Task, der nach fertigstellung ein Objekt beihnaltet, welches das Ergebniss der Lösungsoperation beinhaltet. Sollte das Lösen erfolgreich verlaufen sein, ist auch das gelöste Feld enthalten.</returns>
        public static Task<LösungsErgebnis> LösenAsync(this SudokuFeld feld) => Task.Run(() => Lösen(feld));
    }
}
