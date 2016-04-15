using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;

namespace _2048_Ukrainian_Version_Alpha_0_1
{
    public static class ColorSelection
    {
        public static Dictionary<int,SolidColorBrush> ColorBase;
        public static void ColorBaseInitialization()
        {
            ColorBase = new Dictionary<int, SolidColorBrush>();
            ColorBase.Add(0,Brushes.White);
            ColorBase.Add(2,Brushes.AntiqueWhite);
            ColorBase.Add(4,Brushes.Bisque);
            ColorBase.Add(8,Brushes.PeachPuff);
            ColorBase.Add(16, Brushes.LightSalmon);
            ColorBase.Add(32, Brushes.OrangeRed);
            ColorBase.Add(64, Brushes.Red);
            ColorBase.Add(128, Brushes.Yellow);
            ColorBase.Add(256, Brushes.Gold);
            ColorBase.Add(512, Brushes.DarkGoldenrod);
            ColorBase.Add(1024, Brushes.DarkGoldenrod);
            ColorBase.Add(2048, Brushes.Cyan);
            
        }
    }
}
