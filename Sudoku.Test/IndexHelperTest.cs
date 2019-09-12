using System;
using System.Collections.Generic;
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
            Assert.AreEqual(18 + 6, IndexHelper.ToIndex((6, 3)));
        }

        [TestMethod]
        public void TestToSubscript()
        {
            Assert.AreEqual((0, 0), IndexHelper.ToSubscript(0));
            Assert.AreEqual((5, 0), IndexHelper.ToSubscript(5));
            Assert.AreEqual((0, 1), IndexHelper.ToSubscript(9));
            Assert.AreEqual((6, 3), IndexHelper.ToSubscript(18 + 6));
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
        public void TestExceptionToIndex()
        {
            try
            {
                IndexHelper.ToIndex((-1, 2));
                Assert.Fail();
            }
            catch (Exception ex) { }

            try
            {
                IndexHelper.ToIndex((1, -2));
                Assert.Fail();
            }
            catch (Exception ex) { }

            try
            {
                IndexHelper.ToIndex((-1, -2));
                Assert.Fail();
            }

            catch (Exception ex) { }
        }

        [TestMethod]
        public void TestExceptionToSubscript()
        {
            try
            {
                IndexHelper.ToSubscript(-2);
                Assert.Fail();
            }
            catch (Exception ex) { }
        }
    }
}