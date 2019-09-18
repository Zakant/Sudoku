using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Data.Helper
{
    /// <summary>
    /// Stellt statische Methoden bereit um mit <see cref="SudokuWert"/> zu arbeiten
    /// </summary>
    public static class SudokuWertHelper
    {
        /// <summary>
        /// Konvertiert einen <see cref="SudokuWert"/> in ein <see cref="char"/>.
        /// </summary>
        /// <param name="wert">Der zu konvertierende <see cref="SudokuWert"/>.</param>
        /// <returns>Der <see cref="char"/> der dem <see cref="SudokuWert"/> entspricht.</returns>
        public static char ToChar(this SudokuWert wert)
        {
            return wert switch
            {
                SudokuWert.Leer => ' ',
                SudokuWert.Eins => '1',
                SudokuWert.Zwei => '2',
                SudokuWert.Drei => '3',
                SudokuWert.Vier => '4',
                SudokuWert.Fünf => '5',
                SudokuWert.Sechs => '6',
                SudokuWert.Sieben => '7',
                SudokuWert.Acht => '8',
                SudokuWert.Neun => '9',
                _ => throw new Exception("Invalid value"),
            };
        }

        /// <summary>
        /// Konvertiert ein <see cref="char"/> in einen <see cref="SudokuWert"/>.
        /// </summary>
        /// <param name="wert">Der zu konvertierende <see cref="char"/>.</param>
        /// <returns>Der <see cref="SudokuWert"/> der dem übergebenem Buchstaben entspricht.</returns>
        public static SudokuWert ToSudokuWert(this char wert)
        {
            return wert switch
            {
                ' ' => SudokuWert.Leer,
                '0' => SudokuWert.Leer,
                '1' => SudokuWert.Eins,
                '2' => SudokuWert.Zwei,
                '3' => SudokuWert.Drei,
                '4' => SudokuWert.Vier,
                '5' => SudokuWert.Fünf,
                '6' => SudokuWert.Sechs,
                '7' => SudokuWert.Sieben,
                '8' => SudokuWert.Acht,
                '9' => SudokuWert.Neun,
                _ => throw new Exception("Invalid value"),
            };
        }
    }
}
