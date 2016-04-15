using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2048_Ukrainian_Version_Alpha_0_1
{
    public class RandomMatrixDataStruct
    {
        public RandomMatrixDataStruct(int Row_Value,int Col_Value)
        {
            row = Row_Value;
            col = Col_Value;
        }
        public RandomMatrixDataStruct()
        {
            row = 0;
            col = 0;
        }

        private int row;
        private int col;
        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                col = value;
            }
        }
    }
}
