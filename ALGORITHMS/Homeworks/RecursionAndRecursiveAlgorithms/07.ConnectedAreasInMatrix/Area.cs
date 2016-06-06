using System;

namespace _07.ConnectedAreasInMatrix
{
    public class Area : IComparable<Area>
    {
        public Area(int topRow, int topCol, int size)
        {
            this.TopRow = topRow;
            this.TopCol = topCol;
            this.Size = size;
        }

        public int TopRow { get; }

        public int TopCol { get; }

        public int Size { get; }

        public int CompareTo(Area other)
        {
            int sizeResult = this.Size.CompareTo(other.Size);
            if (sizeResult == 0)
            {
                int rowResult = other.TopRow.CompareTo(this.TopRow);
                if (rowResult == 0)
                {
                    int colResult = other.TopCol.CompareTo(this.TopCol);
                    return colResult;
                }
                else
                {
                    return rowResult;
                }
            }
            else
            {
                return sizeResult;
            }
        }        
    }
}