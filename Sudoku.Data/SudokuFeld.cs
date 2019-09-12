using Sudoku.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data
{
    /// <summary>
    /// Stellt ein Sudoku Feld mit 9x9 Zellen da.
    /// </summary>
    public class SudokuFeld
    {

        /// <summary>
        /// Sammlung aller Zellen dieses Sudoku Feldes in der Row-Major Darstellung.
        /// </summary>
        private SudokuZelle[] _zellen = new SudokuZelle[81];

        /// <summary>
        /// Bestimmt alle <see cref="SudokuZelle" /> die zu der Spalte mit dem Index <paramref name="index"/> gehören.
        /// </summary>
        /// <param name="index">Der Index der Spalte.</param>
        /// <returns>Eine Aufzählung aller <see cref="SudokuZelle" /> die zu der Spalte gehören.</returns>
        public IEnumerable<SudokuZelle> HoleSpalte(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Bestimmt alle <see cref="SudokuZelle" /> die zu der Zeile mit dem Index <paramref name="index"/> gehören.
        /// </summary>
        /// <param name="index">Der Index der Zeile.</param>
        /// <returns>Eine Aufzählung aller <see cref="SudokuZelle" /> die zu der Zeile gehören.</returns>
        public IEnumerable<SudokuZelle> HoleZeile(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Bestimmt alle <see cref="SudokuZelle" /> die zu dem Block mit dem Index <paramref name="index"/> gehören.
        /// </summary>
        /// <param name="index">Der Index des Blocks.</param>
        /// <returns>Eine Aufzählung aller <see cref="SudokuZelle" /> die zu dem Block gehören.</returns>
        public IEnumerable<SudokuZelle> HoleBlock(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt das gesamte <see cref="SudokuFeld"/> Zeilweise aus. Die äußere Aufzählung sind die Zeilen, während die innere die entsprechenden <see cref="SudokuZelle"/> beinhaltet.
        /// </summary>
        /// <returns>Zeilweisedarstellung des <see cref="SudokuFeld"/></returns>
        public IEnumerable<IEnumerable<SudokuZelle>> HoleZeilenweise() => Enumerable.Range(0, 8).Select(x => HoleZeile(x));

        /// <summary>
        /// Gibt das gesamte <see cref="SudokuFeld"/> Spaltenweise aus. Die äußere Aufzählung sind die Spalten, während die innere die entsprechenden <see cref="SudokuZelle"/> beinhaltet.
        /// </summary>
        /// <returns>Spaltenweisedarstellung des <see cref="SudokuFeld"/></returns>
        public IEnumerable<IEnumerable<SudokuZelle>> HoleSpaltenweise() => Enumerable.Range(0, 8).Select(x => HoleSpalte(x));

        /// <summary>
        /// Gibt das gesamte <see cref="SudokuFeld"/> Blockweise aus. Die äußere Aufzählung sind die Blöcke, während die innere die entsprechenden <see cref="SudokuZelle"/> beinhaltet.
        /// </summary>
        /// <returns>Blockweisedarstellung des <see cref="SudokuFeld"/></returns>
        public IEnumerable<IEnumerable<SudokuZelle>> HoleBlockweise() => Enumerable.Range(0, 8).Select(x => HoleBlock(x));

        /// <summary>
        /// Überprüft, ob das Sudoku Feld den Regeln entspricht.
        /// </summary>
        /// <returns>true, wenn das Sudoku valide ist, andernfalls false.</returns>
        public bool IstValide()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var rows = HoleZeilenweise().ToList();
            for (int i = 0; i < rows.Count; i++)
            {
                sb.AppendFormat("{0} {1} {2} | {3} {4} {5} | {6} {7} {8}", rows[i].Select(x => x.ToString()));
                if (i == 2 || i == 5)
                    sb.AppendLine("------+-------+------");
            }
            return sb.ToString();
        }
    }
}
