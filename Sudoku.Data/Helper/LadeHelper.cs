using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku.Data.Helper
{
    /// <summary>
    /// Stellt statische Methode zum Laden von Sudokus bereit.
    /// </summary>
    public static class LadeHelper
    {
        /// <summary>
        /// Lädt ein Sudoku aus einer Datei.
        /// </summary>
        /// <param name="pfad">Der Pfad zu der Datei.</param>
        /// <returns>Das geladenen <see cref="SudokuFeld"/>.</returns>
        public static SudokuFeld LadeVonDatei(string pfad)
        {
            return LadeVonText(File.ReadAllText(pfad));
        }

        /// <summary>
        /// Lädt ein Sudoku aus einem Text.
        /// </summary>
        /// <param name="text">Der Text, der ein Sudoku enthält.</param>
        /// <returns>Das geladene <see cref="SudokuFeld"/>.</returns>
        public static SudokuFeld LadeVonText(string text)
        {
            var lines = text.Split(Environment.NewLine).Select(x => x.Trim()).ToArray();
            var field = new SudokuFeld();
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                {
                    char wert = lines[r][c];
                    field[(c, r)].Wert = wert.ToSudokuWert();
                }
            return field;
        }
    }
}
