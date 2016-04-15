using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace _2048_Ukrainian_Version_Alpha_0_1
{
    static class BorderModificator
    {
        public static void InitializeFromGameRectangle(this Border Border_Value, GameRectangle GameRectangle_Value)
        {

            SolidColorBrush temp = new SolidColorBrush();
            ColorSelection.ColorBase.TryGetValue(GameRectangle_Value.Value, out temp);
            Border_Value.Background = temp;
            if (GameRectangle_Value.Value == 0)
                (Border_Value.Child as TextBlock).Text = string.Empty;
            else
            (Border_Value.Child as TextBlock).Text = GameRectangle_Value.Value.ToString();
        }
    }

}
