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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Übersetzt einen fortlaufenden Index in eine Zeilen- und Spaltenangabe.
        /// </summary>
        /// <param name="value">Der fortlaufende Index.</param>
        /// <returns>Die Zeilen- und Spaltenangabe. Der erste Eintrag stellt die Spalte, der zweite die Zeile dar.</returns>
        public static (int, int) ToSubscript(this int value)
        {
            throw new NotImplementedException();
        }
    }
}
