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
			var field = new Field(1, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void FieldThrowsExceptionFor0Width()
		{
			var field = new Field(0, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void FieldThrowsExceptionFor0Height()
		{
			var field = new Field(1, 0);
		}

		[TestMethod]
		public void FieldIsConstructedWithAllOffCells()
		{
			var field = new Field(1, 1);

			Assert.IsFalse(field.GetCell(0, 0));
		}

		[TestMethod]
		public void FieldThrowsExceptionWhenGettingCellsBeyondWidth()
		{
			var field = new Field(1, 1);
			Assert.IsFalse(field.GetCell(1, 0));
		}

		[TestMethod]
		public void FieldThrowsExceptionWhenGettingCellsBeyondHeight()
		{
			var field = new Field(1, 1);
			Assert.IsFalse(field.GetCell(0, 1));
		}

		[TestMethod]
		public void FieldThrowsExceptionWhenSettingCellsBeyondWidth()
		{
			var field = new Field(1, 1);
			Assert.IsFalse(field.GetCell(1, 0));
		}

		[TestMethod]
		public void FieldThrowsExceptionWhenSettingCellsBeyondHeight()
		{
			var field = new Field(1, 1);
			Assert.IsFalse(field.GetCell(0, 1));
		}

		[TestMethod]
		public void FieldCanHaveCellSet()
		{
			var field = new Field(1, 1);
			field.SetCell(0, 0);

			Assert.IsTrue(field.GetCell(0, 0));
		}

		[TestMethod]
		public void LonelyCellDies()
		{
			var field = new Field(3, 3);
			field.SetCell(1, 1);

			field.Update();

			Assert.IsFalse(field.GetCell(1, 1));
		}

		[TestMethod]
		public void CellWithEnoughNeighboursLives()
		{
			var field = new Field(3, 3);
			field.SetCell(1, 1);    //Test cell
			field.SetCell(0, 0);    //Neighbour
			field.SetCell(1, 0);    //Neighbour

			field.Update();

			Assert.IsTrue(field.GetCell(1, 1));
		}

		[TestMethod]
		public void OvercrowdedCellDies()
		{
			var field = new Field(3, 3);
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
			var field = new Field(3, 3);
			field.SetCell(0, 0);    //Neighbour
			field.SetCell(1, 0);    //Neighbour
			field.SetCell(2, 0);    //Neighbour

			field.Update();

			Assert.IsTrue(field.GetCell(1, 1));
		}
	}
}
