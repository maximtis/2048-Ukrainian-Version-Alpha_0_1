using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Ukrainian_Version_Alpha_0_1
{
    public class PositionData
    {
        public PositionData(Position FirstPosition_Value, Position TwoPosition_Value )
        {
            firstPosition = FirstPosition_Value;
            twoPosition = TwoPosition_Value;
        }
        public PositionData()
        {
            FirstPosition = 0;
            TwoPosition = 0;
        }
        public Position FirstPosition 
        { 
            get 
            {
                return firstPosition; 
            }
            set
            {
                firstPosition = value;
            }
        }
        public Position TwoPosition
        {
            get
            {
                return twoPosition;
            }
            set
            {
                twoPosition = value;
            }
        }

        Position firstPosition;
        Position twoPosition;
    }
}
