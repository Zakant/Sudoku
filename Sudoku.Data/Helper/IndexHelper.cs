﻿using System;
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
        /// <param name="value">Die Spalten- und Zeilenangabe. Der erste Eintrag stellt die Spalte, der zweite die Zeile dar.</param>
        /// <returns>Der fortlaufende Index.</returns>
        public static int ToIndex(this (int, int) value)
        {
            if (value.Item1 < 0 || value.Item1 > 8 || value.Item2 < 0 || value.Item2 > 8)
                throw new ArgumentOutOfRangeException();
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
                throw new ArgumentOutOfRangeException();
            int zeile = value / 9;
            int spalte = value - 9 * zeile;
            return (spalte, zeile);
        }

        /// <summary>
        /// Übersetzt einen Blockindex in die Indices der enthaltenen Zellen.
        /// </summary>
        /// <param name="blockIndex">Der zu verwendende Blockindex.</param>
        /// <returns>Auflistung aller Indices der enthaltenen Zellen.</returns>
        public static IEnumerable<(int, int)> SubscriptsFromBlockIndex(this int blockIndex)
        {
            if (blockIndex < 0 || blockIndex > 8)
                throw new ArgumentOutOfRangeException();
            int blockZeile = blockIndex / 3;
            int blockSpalte = blockIndex - 3 * blockZeile;

            return Enumerable.Range(blockZeile * 3, 3)
                .SelectMany(zeilenIndex => Enumerable.Range(blockSpalte * 3, 3).Select(spaltenIndex => (spaltenIndex, zeilenIndex)));
        }

        /// <summary>
        /// Übersetzt eine Spalten- und Zeilenposition in einen Blockindex.
        /// </summary>
        /// <param name="value">Die Spalten und Zeilenangabe. Der erste Eintrag stellt die Spalte, der zweite die Zeile dar.</param>
        /// <returns>Der Index des Blockes.</returns>
        public static int BlockIndexFromSubscript(this (int, int) value)
        {
            int blockSpalte = value.Item1 % 3;
            int blockZeile = value.Item2 % 3;

            return blockSpalte + blockZeile * 3;
        }
    }
}
