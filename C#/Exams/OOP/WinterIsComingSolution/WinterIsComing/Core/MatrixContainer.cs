namespace WinterIsComing.Core
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Exceptions;

    public class MatrixContainer : IUnitContainer
    {
        private const int MinimumBorder = 0;
        private const int RowsCount = 5;
        private const int ColumnsCount = 5;

        private IUnit[,] unitsMatrix;

        public MatrixContainer()
        {
            this.unitsMatrix = new IUnit[RowsCount, ColumnsCount];
        }

        public IEnumerable<IUnit> GetUnitsInRange(int row, int col, int range)
        {
            ValidateCoordinates(row, col);

            var targets = new List<IUnit>();

            int minRow = Math.Max(row - range, 0);
            int maxRow = Math.Min(row + range, RowsCount - 1);
            int minCol = Math.Max(col - range, 0);
            int maxCol = Math.Min(col + range, ColumnsCount - 1);

            for (int r = minRow; r <= maxRow; r++)
            {
                for (int c = minCol; c <= maxCol; c++)
                {
                    if (this.unitsMatrix[r, c] != null && (r != row || c != col))
                    {
                        IUnit unit = this.unitsMatrix[r, c];
                        targets.Add(unit);
                    }
                }
            }

            return targets;
        }

        public void Add(IUnit unit)
        {
            int row = unit.Y;
            int col = unit.X;

            ValidateCoordinates(row, col);

            if (this.unitsMatrix[row, col] != null)
            {
                throw new GameException(GlobalMessages.CellIsTaken);               
            }

            this.unitsMatrix[row, col] = unit;
        }

        public void Remove(IUnit unit)
        {
            int row = unit.Y;
            int col = unit.X;

            ValidateCoordinates(row, col);

            if (this.unitsMatrix[row, col] != unit)
            {
                throw new GameException(GlobalMessages.UnitNotPresent);
            }

            this.unitsMatrix[row, col] = null;
        }

        public void ChangePosition(IUnit unit, int newRow, int newCol)
        {
            ValidateCoordinates(newRow, newCol);

            int row = unit.Y;
            int col = unit.X;

            ValidateCoordinates(row, col);

            if (this.unitsMatrix[row, col] != unit)
            {
                throw new GameException(GlobalMessages.UnitNotPresent);
            }
            else if (this.unitsMatrix[newRow, newCol] != null)
            {
                throw new GameException(GlobalMessages.CellIsTaken);
            }

            this.Remove(unit);

            unit.Y = newRow;
            unit.X = newCol;

            this.Add(unit);
        }

        private void ValidateCoordinates(int row, int col)
        {
            if (row < MinimumBorder || row >= RowsCount)
            {
                throw new GameException(GlobalMessages.InvalidCoordinate);
            }
            else if (col < MinimumBorder || col >= ColumnsCount)
            {
                throw new GameException(GlobalMessages.InvalidCoordinate);
            }
        }
    }
}