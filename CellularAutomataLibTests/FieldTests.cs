using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellularAutomataLib;

namespace CellularAutomataLibTests
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void FieldTakesWidthAndHeight()
        {
            Field field = new Field(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FieldThrowsExceptionFor0Width()
        {
            Field field = new Field(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FieldThrowsExceptionFor0Height()
        {
            Field field = new Field(1, 0);
        }

        [TestMethod]
        public void FieldIsConstructedWithAllOffCells()
        {
            Field field = new Field(1, 1);

            Assert.IsFalse(field.GetCell(0, 0));
        }

        [TestMethod]
        public void FieldThrowsExceptionWhenGettingCellsBeyondWidth()
        {
            Field field = new Field(1, 1);
            Assert.IsFalse(field.GetCell(1, 0));
        }

        [TestMethod]
        public void FieldThrowsExceptionWhenGettingCellsBeyondHeight()
        {
            Field field = new Field(1, 1);
            Assert.IsFalse(field.GetCell(0, 1));
        }

        [TestMethod]
        public void FieldThrowsExceptionWhenSettingCellsBeyondWidth()
        {
            Field field = new Field(1, 1);
            Assert.IsFalse(field.GetCell(1, 0));
        }

        [TestMethod]
        public void FieldThrowsExceptionWhenSettingCellsBeyondHeight()
        {
            Field field = new Field(1, 1);
            Assert.IsFalse(field.GetCell(0, 1));
        }

        [TestMethod]
        public void FieldCanHaveCellSet()
        {
            Field field = new Field(1, 1);
            field.SetCell(0, 0);
            
            Assert.IsTrue(field.GetCell(0, 0));
        }

        [TestMethod]
        public void LonelyCellDies()
        {
            Field field = new Field(3, 3);
            field.SetCell(1, 1);

            field.Update();

            Assert.IsFalse(field.GetCell(1, 1));
        }

        [TestMethod]
        public void CellWithEnoughNeighboursLives()
        {
            Field field = new Field(3, 3);
            field.SetCell(1, 1);    //Test cell
            field.SetCell(0, 0);    //Neighbour
            field.SetCell(1, 0);    //Neighbour

            field.Update();

            Assert.IsTrue(field.GetCell(1, 1));
        }

        [TestMethod]
        public void OvercrowdedCellDies()
        {
            Field field = new Field(3, 3);
            field.SetCell(1, 1);    //Test cell
            field.SetCell(0, 0);    //Neighbour
            field.SetCell(1, 0);    //Neighbour
            field.SetCell(2, 0);    //Neighbour
            field.SetCell(0, 1);    //Neighbour

            field.Update();

            Assert.IsFalse(field.GetCell(1, 1));
        }

        [TestMethod]
        public void DeadCellWith3NeighboursLives()
        {
            Field field = new Field(3, 3);
            field.SetCell(0, 0);    //Neighbour
            field.SetCell(1, 0);    //Neighbour
            field.SetCell(2, 0);    //Neighbour

            field.Update();

            Assert.IsTrue(field.GetCell(1, 1));
        }
    }
}
