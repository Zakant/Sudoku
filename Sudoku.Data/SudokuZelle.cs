using Sudoku.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Data
{
    /// <summary>
    /// Stellt eine einzelne Sudoku Zelle da. Jedes Sudoku Feld besteht aus 9x9 Zellen.
    /// </summary>
    public class SudokuZelle
    {
        /// <summary>
        /// Der Wert den die Sudoku Zelle aktuell hat.
        /// </summary>
        public SudokuWert Wert { get; set; }

        /// <summary>
        /// Index der Zeile, in der sich die Zelle befindet.
        /// </summary>
        public int ZeilenPosition { get; protected set; }

        /// <summary>
        /// Index der Spalte, in der sich die Zelle befindet.
        /// </summary>
        public int SpaltenPosition { get; protected set; }

        /// <summary>
        /// Index der Zelle im Datenspeicher des <see cref="SudokuFeld"/>.
        /// </summary>
        public int Index { get; protected set; }

        /// <summary>
        /// Erzeugt eine neue Sudokuzelle mit dem Werte <see cref="SudokuWert.Leer"/>.
        /// </summary>
        /// <param name="spaltenPosition">Der Index der Spalte, in der sich die Zelle befindet.</param>
        /// <param name="zeilenPositon">Der Index der Zeile, in der sich die Zelle befindet.</param>
        public SudokuZelle(int spaltenPosition, int zeilenPositon) : this(SudokuWert.Leer, spaltenPosition, zeilenPositon)
        { }

        /// <summary>
        /// Erzeugt eine neue Sudokuzelle mit dem Werte <see cref="SudokuWert.Leer"/>.
        /// </summary>
        /// <param name="position">Die Position der Zelle. Der erste Wert ist der Index der Spalte, der zweite der Index der Zeile.</param>
        public SudokuZelle((int, int) position) : this(SudokuWert.Leer, position.Item1, position.Item2)
        { }

        /// <summary>
        /// Erzeugt eine Sudokuzelle mit dem Wert der in <paramref name="wert"/> übergeben wird.
        /// </summary>
        /// <param name="wert">Der Wert der Zelle.</param>
        /// <param name="position">Die Position der Zelle. Der erste Wert ist der Index der Spalte, der zweite der Index der Zeile.</param>
        public SudokuZelle(SudokuWert wert, (int, int) position) : this(wert, position.Item1, position.Item2)
        { }

        /// <summary>
        /// Erzeugt eine Sudokuzelle mit dem Wert der in <paramref name="wert"/> übergeben wird.
        /// </summary>
        /// <param name="wert">Der Wert der Zelle.</param>
        /// <param name="spaltenPosition">Der Index der Spalte, in der sich die Zelle befindet.</param>
        /// <param name="zeilenPositon">Der Index der Zeile, in der sich die Zelle befindet.</param>
        public SudokuZelle(SudokuWert wert, int spaltenPosition, int zeilenPosition)
        {
            Wert = wert;
            ZeilenPosition = zeilenPosition;
            SpaltenPosition = spaltenPosition;
            Index = IndexHelper.ToIndex((spaltenPosition, zeilenPosition));
        }

        /// <summary>
        /// Erzeugt eine Kopie der Sudoku Zelle.
        /// </summary>
        /// <returns>Die erzeugte Kopie.</returns>
        public SudokuZelle Clone() => new SudokuZelle(Wert, SpaltenPosition, ZeilenPosition);

        public override string ToString() => Wert.ToChar().ToString();

        public override bool Equals(object obj)
        {
            return obj is SudokuZelle zelle &&
                   Wert == zelle.Wert &&
                   ZeilenPosition == zelle.ZeilenPosition &&
                   SpaltenPosition == zelle.SpaltenPosition;
        }

        public override int GetHashCode()
        {
            var hashCode = -1088555071;
            hashCode = hashCode * -1521134295 + Wert.GetHashCode();
            hashCode = hashCode * -1521134295 + ZeilenPosition.GetHashCode();
            hashCode = hashCode * -1521134295 + SpaltenPosition.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SudokuZelle left, SudokuZelle right)
        {
            return EqualityComparer<SudokuZelle>.Default.Equals(left, right);
        }

        public static bool operator !=(SudokuZelle left, SudokuZelle right)
        {
            return !(left == right);
        }
    }
}
