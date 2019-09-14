using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Data.Helper;

namespace Sudoku.Test
{
    [TestClass]
    public class IndexHelperTest
    {
        [TestMethod]
        public void TestToIndex()
        {
            Assert.AreEqual(0, IndexHelper.ToIndex((0, 0)));
            Assert.AreEqual(5, IndexHelper.ToIndex((5, 0)));
            Assert.AreEqual(9, IndexHelper.ToIndex((0, 1)));
            Assert.AreEqual(27 + 6, IndexHelper.ToIndex((6, 3)));
        }

        [TestMethod]
        public void TestToSubscript()
        {
            Assert.AreEqual((0, 0), IndexHelper.ToSubscript(0));
            Assert.AreEqual((5, 0), IndexHelper.ToSubscript(5));
            Assert.AreEqual((0, 1), IndexHelper.ToSubscript(9));
            Assert.AreEqual((6, 3), IndexHelper.ToSubscript(27 + 6));
        }

        [TestMethod]
        public void ToIndexToSubscript()
        {
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    Assert.AreEqual((r, c), IndexHelper.ToSubscript(IndexHelper.ToIndex((r, c))));
        }

        [TestMethod]
        public void ToSubscriptToIndex()
        {
            for (int i = 0; i < 81; i++)
                Assert.AreEqual(i, IndexHelper.ToIndex(IndexHelper.ToSubscript(i)));
        }

        [TestMethod]
        public void TestSubscriptsFromBlockIndex()
        {
            (int, int)[] expected0 = new (int, int)[] { (0, 0), (1, 0), (2, 0), (0, 1), (1, 1), (2, 1), (0, 2), (1, 2), (2, 2) };
            (int, int)[] expected4 = new (int, int)[] { (3, 3), (4, 3), (5, 3), (3, 4), (4, 4), (5, 4), (3, 5), (4, 5), (5, 5) };
            (int, int)[] expected7 = new (int, int)[] { (3, 6), (4, 6), (5, 6), (3, 7), (4, 7), (5, 7), (3, 8), (4, 8), (5, 8) };

            Assert.IsTrue(Enumerable.SequenceEqual(expected0, IndexHelper.SubscriptsFromBlockIndex(0)));
            Assert.IsTrue(Enumerable.SequenceEqual(expected4, IndexHelper.SubscriptsFromBlockIndex(4)));
            Assert.IsTrue(Enumerable.SequenceEqual(expected7, IndexHelper.SubscriptsFromBlockIndex(7)));
        }

        public void TestExceptionSubscriptsFromBlockIndex()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.SubscriptsFromBlockIndex(-2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.SubscriptsFromBlockIndex(9));
        }

        [TestMethod]
        public void TestExceptionToIndex()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.ToIndex((-1, 2)));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.ToIndex((1, -2)));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.ToIndex((-1, -2)));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.ToIndex((1, 9)));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.ToIndex((9, 0)));
        }

        [TestMethod]
        public void TestExceptionToSubscript()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.ToSubscript(-2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IndexHelper.ToSubscript(81));
        }
    }
}