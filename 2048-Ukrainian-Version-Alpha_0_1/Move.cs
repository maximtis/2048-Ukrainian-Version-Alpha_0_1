using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Ukrainian_Version_Alpha_0_1
{
    public interface Move
    {
         int ColPosition { get; set; } /* Описывает координату "Столбца" в "Матрице Игровоых Прямоугольников" */
         int RowPosition { get; set; } /* Описывает координату "Строки" в "Матрице Игровоых Прямоугольников" */
         void MoveUp();  /*Описывает функцию смещения Игрового Прямоугольника "Вверх" */
         void MoveRight();  /*Описывает функцию смещения Игрового Прямоугольника "Вправо" */
         void MoveDown();  /*Описывает функцию смещения Игрового Прямоугольника "Вниз" */
         void MoveLeft();  /*Описывает функцию смещения Игрового Прямоугольника "Влево" */

         bool IsUpContains { get; set; }  /* Описывает свойство, есть ли выше "Игровой Прмоугольник" */
         bool IsRightContains { get; set; }  /* Описывает свойство, есть ли выше "Игровой Прмоугольник" */
         bool IsDownContains { get; set; }  /* Описывает свойство, есть ли выше "Игровой Прмоугольник" */
         bool IsLeftContains { get; set; }  /* Описывает свойство, есть ли выше "Игровой Прмоугольник" */
 
    }
}
