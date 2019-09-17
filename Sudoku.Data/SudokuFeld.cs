using Sudoku.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Data
{
    /// <summary>
    /// Stellt ein Sudoku Feld mit 9x9 <see cref="SudokuZelle"/> dar.
    /// </summary>
    public class SudokuFeld
    {

        /// <summary>
        /// Sammlung aller Zellen dieses Sudoku Feldes in der Row-Major Darstellung.
        /// </summary>
        private readonly SudokuZelle[] _zellen = new SudokuZelle[81];

        /// <summary>
        /// Bestimmt die <see cref="SudokuZelle"/> an der durch <paramref name="spaltePosition"/> und <paramref name="zeilePosition"/> angegebenen Position.
        /// </summary>
        /// <param name="spaltePosition">Die Spalten Position der Zelle.</param>
        /// <param name="zeilePosition">Die Zeilen Position der Zelle.</param>
        /// <returns>Die <see cref="SudokuZelle"/> an der angegebenen Position.</returns>
        public SudokuZelle this[int spaltePosition, int zeilePosition] => HoleZelle(spaltePosition, zeilePosition);

        /// <summary>
        /// Bestimmt die <see cref="SudokuZelle"/> an der durch <paramref name="position"/> angegebene Position.
        /// </summary>
        /// <param name="position">Die Position der Zelle.</param>
        /// <returns>Die <see cref="SudokuZelle"/> an der angegebenen Position.</returns>
        public SudokuZelle this[(int, int) position] => HoleZelle(position);

        /// <summary>
        /// Bestimmt die <see cref="SudokuZelle"/> an dem durch <paramref name="index"/> angegebenen Index.
        /// </summary>
        /// <param name="index">Der Index der Zelle.</param>
        /// <returns>Die <see cref="SudokuZelle"/> an dem angegebenen Index.</returns>
        public SudokuZelle this[int index] => _zellen[index];

        /// <summary>
        /// Erzeugt ein neues leeres Sudokufeld.
        /// </summary>
        public SudokuFeld()
        {
            for (int i = 0; i < 81; i++)
                _zellen[i] = new SudokuZelle(IndexHelper.ToSubscript(i));
        }

        /// <summary>
        /// Erzeugt ein neues Sudokufeld, dass dem übergebenen in <paramref name="source"/> entspricht.
        /// </summary>
        /// <param name="source">Das zu kopierende Feld.</param>
        public SudokuFeld(SudokuFeld source)
        {
            for (int i = 0; i < 81; i++)
                _zellen[i] = source._zellen[i].Clone();
        }

        /// <summary>
        /// Bestimmt die <see cref="SudokuZelle"/> an der durch <paramref name="position"/> angegebene Position.
        /// </summary>
        /// <param name="position">Die Position der Zelle.</param>
        /// <returns>Die <see cref="SudokuZelle"/> an der angegebenen Position.</returns>
        public SudokuZelle HoleZelle((int, int) position) => HoleZelle(position.Item1, position.Item2);

        /// <summary>
        /// Bestimmt die <see cref="SudokuZelle"/> an der durch <paramref name="spaltePosition"/> und <paramref name="zeilePosition"/> angegebenen Position.
        /// </summary>
        /// <param name="spaltePosition">Die Spalten Position der Zelle.</param>
        /// <param name="zeilePosition">Die Zeilen Position der Zelle.</param>
        /// <returns>Die <see cref="SudokuZelle"/> an der angegebenen Position.</returns>
        public SudokuZelle HoleZelle(int spaltePosition, int zeilePosition) => _zellen[IndexHelper.ToIndex((spaltePosition, zeilePosition))];

        /// <summary>
        /// Bestimmt alle <see cref="SudokuZelle" /> die zu der Spalte mit dem Index <paramref name="index"/> gehören.
        /// </summary>
        /// <param name="index">Der Index der Spalte.</param>
        /// <returns>Eine Aufzählung aller <see cref="SudokuZelle" /> die zu der Spalte gehören.</returns>
        public IEnumerable<SudokuZelle> HoleSpalte(int index)
        {
            return Enumerable.Range(0, 8).Select(x => HoleZelle(index, x));
        }

        /// <summary>
        /// Bestimmt alle <see cref="SudokuZelle" /> die zu der Zeile mit dem Index <paramref name="index"/> gehören.
        /// </summary>
        /// <param name="index">Der Index der Zeile.</param>
        /// <returns>Eine Aufzählung aller <see cref="SudokuZelle" /> die zu der Zeile gehören.</returns>
        public IEnumerable<SudokuZelle> HoleZeile(int index)
        {
            return Enumerable.Range(0, 8).Select(x => HoleZelle(x, index));
        }

        /// <summary>
        /// Bestimmt alle <see cref="SudokuZelle" /> die zu dem Block mit dem Index <paramref name="index"/> gehören.
        /// </summary>
        /// <param name="index">Der Index des Blocks.</param>
        /// <returns>Eine Aufzählung aller <see cref="SudokuZelle" /> die zu dem Block gehören.</returns>
        public IEnumerable<SudokuZelle> HoleBlock(int index)
        {
            return IndexHelper.SubscriptsFromBlockIndex(index).Select(x => HoleZelle(x));
        }

        /// <summary>
        /// Gibt das gesamte <see cref="SudokuFeld"/> Zeilweise aus. Die äußere Aufzählung sind die Zeilen, während die innere die entsprechenden <see cref="SudokuZelle"/> beinhaltet.
        /// </summary>
        /// <returns>Zeilweisedarstellung des <see cref="SudokuFeld"/>.</returns>
        public IEnumerable<IEnumerable<SudokuZelle>> HoleZeilenweise() => Enumerable.Range(0, 8).Select(x => HoleZeile(x));

        /// <summary>
        /// Gibt das gesamte <see cref="SudokuFeld"/> Spaltenweise aus. Die äußere Aufzählung sind die Spalten, während die innere die entsprechenden <see cref="SudokuZelle"/> beinhaltet.
        /// </summary>
        /// <returns>Spaltenweisedarstellung des <see cref="SudokuFeld"/>.</returns>
        public IEnumerable<IEnumerable<SudokuZelle>> HoleSpaltenweise() => Enumerable.Range(0, 8).Select(x => HoleSpalte(x));

        /// <summary>
        /// Gibt das gesamte <see cref="SudokuFeld"/> Blockweise aus. Die äußere Aufzählung sind die Blöcke, während die innere die entsprechenden <see cref="SudokuZelle"/> beinhaltet.
        /// </summary>
        /// <returns>Blockweisedarstellung des <see cref="SudokuFeld"/>.</returns>
        public IEnumerable<IEnumerable<SudokuZelle>> HoleBlockweise() => Enumerable.Range(0, 8).Select(x => HoleBlock(x));

        /// <summary>
        /// Gibt das gesamte <see cref="SudokuFeld"/> aus. Zunächst erfolgt die Ausgabe der Spalten (<see cref="HoleSpaltenweise"/>), dann die Ausgabe der Zeilen (<see cref="HoleSpaltenweise"/>) 
        /// und abschließend die Ausgabe der Blöcke (<see cref="HoleBlockweise"/>). Auf diese Weise wird des Feld effektiv drei mal ausgegeben!
        /// </summary>
        /// <returns>Die Sammlung aller Zeilen, Spalten und Blöcke.</returns>
        public IEnumerable<IEnumerable<SudokuZelle>> HoleAlle() => HoleZeilenweise().Concat(HoleSpaltenweise()).Concat(HoleBlockweise());

        /// <summary>
        /// Gibt alle <see cref="SudokuZelle"/> des Feldes zurück. 
        /// </summary>
        /// <returns>Alle Zellen des Feldes.</returns>
        public IEnumerable<SudokuZelle> HolleAlleZellen() => Enumerable.Range(0, 81).Select(x => _zellen[x]);

        /// <summary>
        /// Überprüft, ob das Sudokufeld den Regeln entspricht.
        /// </summary>
        /// <returns>true, wenn das Sudoku valide ist, andernfalls false.</returns>
        public bool IstValide()
        {
            return HoleAlle().Select(x => CheckZellen(x)).All(x => x);

            static bool CheckZellen(IEnumerable<SudokuZelle> zellen)
            {
                return !zellen.GroupBy(x => x.Wert).Where(x => x.Count() > 1 && x.Key != SudokuWert.Leer).Any();
            }
        }

        /// <summary>
        /// Überprüft, ob das Sudokufeld vollständig ist.
        /// </summary>
        /// <returns>true, falls das Feld vollästndig ist, anderfalls false.</returns>
        public bool IstVollständig() => _zellen.All(x => x.Wert != SudokuWert.Leer);

        /// <summary>
        /// Erzeugt eine Kopie des Sudokufeldes. Die erzeugt Kopie ist tief. 
        /// </summary>
        /// <returns></returns>
        public SudokuFeld Clone() => new SudokuFeld(this);

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

        public override bool Equals(object obj)
        {
            return obj is SudokuFeld feld &&
                Enumerable.SequenceEqual(_zellen, feld._zellen);
        }

        public override int GetHashCode()
        {
            return -1285944036 + EqualityComparer<SudokuZelle[]>.Default.GetHashCode(_zellen);
        }

        public static bool operator ==(SudokuFeld left, SudokuFeld right)
        {
            return EqualityComparer<SudokuFeld>.Default.Equals(left, right);
        }

        public static bool operator !=(SudokuFeld left, SudokuFeld right)
        {
            return !(left == right);
        }
    }
}
