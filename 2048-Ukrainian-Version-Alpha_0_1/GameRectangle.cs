using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;

namespace _2048_Ukrainian_Version_Alpha_0_1
{
    public enum Position { Up=1,Right=2,Down=3,Left=4}
    public class GameRectangle
    {
        public GameRectangle(PositionData Position_Value, int RowPosition_Value, int ColPosition_Value)
        {
            nowPosition = Position_Value;
            RowPosition = RowPosition_Value;
            colPosition = ColPosition_Value;
            contains = false;
            _value = 0;
            isUpContains = false;
            isRightContains = false;
            isDownContains = false;
            isLeftContains = false;
            IsPossibleToGenerate = false;
        }
        public GameRectangle()
        {
            nowPosition.FirstPosition = 0;
            nowPosition.TwoPosition = 0;
            contains = false;
            _value = 0;
            colPosition = 0;
            rowPosition = 0;
            isUpContains = false;
            isRightContains = false; 
            isDownContains = false; 
            isLeftContains = false;
            IsPossibleToGenerate = false;
        }
        public PositionData NowPosition  /* Указывает на текущее местоположение "Игрового Прямоугольника" относительно края */
        {
            get { return nowPosition; }
            set { nowPosition = value; }
        }
        public int Value  /* Описывает числовое значение "Игрового Прямоугольника" */
        {
            get { return _value; }
            set { _value = value; }
        }
        public void Clear()  /* Описывает функцию, освобождающая "Игровой Прямоугольник" */
        {
            colPosition = 0;
            rowPosition = 0;
            isUpContains = false;
            isRightContains = false;
            isDownContains = false;
            isLeftContains = false;
        }
        public bool Contains  /* Указывает, занят ли "Игровой Прямоугольник" */
        {
            get { return contains; }
            set { contains = value; }
        }

        // Список переменных
        private PositionData nowPosition;
        private bool contains;
        private int _value;
        private int colPosition;
        private int rowPosition;
        private bool isUpContains;
        private bool isRightContains; 
        private bool isDownContains; 
        private bool isLeftContains; 

         int ColPosition 
        { 
            get { return colPosition; } 
            set { colPosition = value; } 
        }
         int RowPosition
        {
            get { return rowPosition; }
            set { rowPosition = value; }
        }
         public void MoveUp(int index)
         {
             int Row = rowPosition-index;
             int Col = colPosition;
             if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value!=0)
             while (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].NowPosition.FirstPosition != Position.Up)
             {
                 if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row - 1][Col].Value == SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value)
                 {
                     SystemRuntimeMonitor.GameRectangleContainsMatrix[Row - 1][Col].Value *= 2;
                     SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value = 0;
                     IsPossibleToGenerate = true;
                     MoveUp(index+1);
                     return;
                 }
                 else if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row - 1][Col].Value == 0)
                 {
                     SystemRuntimeMonitor.GameRectangleContainsMatrix[Row - 1][Col].Value =
                        SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value;
                     SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value = 0;
                     IsPossibleToGenerate = true;
                     MoveUp(index + 1);
                     return;
                 } 
                 else
                 {
                     return;
                 }
                 
             }
         }
         public void MoveRight(int index)
         {
             int Row = rowPosition;
             int Col = colPosition + index;
             if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value != 0)
                 while (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].NowPosition.TwoPosition != Position.Right)
                 {
                     if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col + 1].Value == SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value)
                     {
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col+1].Value *= 2;
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value = 0;
                         IsPossibleToGenerate = true;
                         MoveRight(index+1);
                         return;
                     }
                     else if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col+1].Value == 0)
                     {
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col + 1].Value =
                             SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value;
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value = 0;
                         IsPossibleToGenerate = true;
                         MoveRight(index + 1);
                         return;
                     } 
                     else
                     {
                         return;
                     }

                 }
         }
         public void MoveDown(int index)
         {
             int Row = rowPosition + index;
             int Col = colPosition;
             if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value != 0)
                 while (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].NowPosition.FirstPosition != Position.Down)
                 {
                     if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row + 1][Col].Value == SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value)
                     {
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row + 1][Col].Value *= 2;
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value = 0;
                         IsPossibleToGenerate = true;

                         MoveDown(index + 1);
                         return;
                     }
                     else if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row + 1][Col].Value == 0)
                     {
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row + 1][Col].Value =
                            SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value;
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value = 0;
                         IsPossibleToGenerate = true;

                         MoveDown(index + 1);
                         return;
                     }
                     else
                     {
                         return;
                     }

                 }
         }
         public void MoveLeft(int index)
         {
             int Row = rowPosition;
             int Col = colPosition - index;
             if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value != 0)
                 while (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].NowPosition.TwoPosition != Position.Left)
                 {
                     if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col - 1].Value == SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value)
                     {
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col - 1].Value *= 2;
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value = 0;
                         IsPossibleToGenerate = true;
                         MoveLeft(index + 1);
                         return;
                     }
                     else if (SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col - 1].Value == 0)
                     {
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col - 1].Value =
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value;
                         SystemRuntimeMonitor.GameRectangleContainsMatrix[Row][Col].Value = 0;
                         IsPossibleToGenerate = true;
                         //todo: Присвоить пустому полю значение указанного.
                         MoveLeft(index + 1);
                         return;
                     }
                     else
                     {
                         return;
                     }

                 }
         }
         public bool IsUpContains
        {
            get { return isUpContains; }
            set { isUpContains = value; }
        }
         public bool IsRightContains
        {
            get { return isRightContains; }
            set { isRightContains = value; }
        }
         public bool IsDownContains
        {
            get { return isDownContains; }
            set { isDownContains = value; }
        }
         public bool IsLeftContains
        {
            get { return isLeftContains; }
            set { isLeftContains = value; }
        } 
         public GameRectangle DeepCopy()
         {
             return new GameRectangle(new PositionData(NowPosition.FirstPosition, NowPosition.TwoPosition), rowPosition, colPosition);
         }
         //public static event EventHandler ValueChanged;
         public static bool IsPossibleToGenerate { get; set; }
    }
}
