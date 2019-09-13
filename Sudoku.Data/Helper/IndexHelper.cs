using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data.Helper
{
    public static class IndexHelper
    {
        /// <summary>
        /// Übersetzt einen Zeilen- und Spaltenangabe in einen fortlaufenden Index.
        /// </summary>
        /// <param name="value">Die Zeilen- und Spaltenangabe. Der erste Eintrag stellt die Spalte, der zweite die Zeile dar.</param>
        /// <returns>Der fortlaufende Index.</returns>
        public static int ToIndex(this (int, int) value)
        {
            if (value.Item1 < 0 || value.Item1 > 8 || value.Item2 < 0 || value.Item2 > 8)
                throw new ArgumentException("Argument out of bound!");
            return value.Item1 + value.Item2 * 9;
        }

        /// <summary>
        /// Übersetzt einen fortlaufenden Index in eine Zeilen- und Spaltenangabe.
        /// </summary>
        /// <param name="value">Der fortlaufende Index.</param>
        /// <returns>Die Zeilen- und Spaltenangabe. Der erste Eintrag stellt die Spalte, der zweite die Zeile dar.</returns>
        public static (int, int) ToSubscript(this int value)
        {
            if (value < 0 || value > 80)
                throw new ArgumentException("Argument out of bound!");
            int zeile = value / 9;
            int spalte = value - 9 * zeile;
            return (spalte, zeile);
        }
    }
}
