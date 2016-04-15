using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2048_Ukrainian_Version_Alpha_0_1
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public event EventHandler DoMove;
        public static List<List<Border>> VisualBorderList;
        public void InitializeVisualBorderList()
        {
            VisualBorderList = new List<List<Border>>(4);
            for (int i = 0; i < VisualBorderList.Capacity; i++)
                VisualBorderList.Add(new List<Border>(4));
            for (int i = 0; i < VisualBorderList.Capacity; i++)
                for (int j = 0; j < VisualBorderList.Capacity; j++)
                    VisualBorderList[i].Add(new Border());

            VisualBorderList[0][0] = Border_One_One_Rect;
            VisualBorderList[0][1] = Border_One_Two_Rect;
            VisualBorderList[0][2] = Border_One_Three_Rect;
            VisualBorderList[0][3] = Border_One_Four_Rect;
            VisualBorderList[1][0] = Border_Two_One_Rect;
            VisualBorderList[1][1] = Border_Two_Two_Rect;
            VisualBorderList[1][2] = Border_Two_Three_Rect;
            VisualBorderList[1][3] = Border_Two_Four_Rect;
            VisualBorderList[2][0] = Border_Three_One_Rect;
            VisualBorderList[2][1] = Border_Three_Two_Rect;
            VisualBorderList[2][2] = Border_Three_Three_Rect;
            VisualBorderList[2][3] = Border_Three_Four_Rect;
            VisualBorderList[3][0] = Border_Four_One_Rect;
            VisualBorderList[3][1] = Border_Four_Two_Rect;
            VisualBorderList[3][2] = Border_Four_Three_Rect;
            VisualBorderList[3][3] = Border_Four_Four_Rect;
 
        }
        public MainWindow()
        {
            InitializeComponent();
            ColorSelection.ColorBaseInitialization();
            InitializeVisualBorderList();
           
            SystemRuntimeMonitor.NowPositionMatrix_Initialize();
            SystemRuntimeMonitor.GameRectangleContainsMatrix_Initialize();
            SystemRuntimeMonitor.ReloadVisualPosition();
            SystemRuntimeMonitor.GameRectanglePossibleToGenerate_Initialize();
            SystemRuntimeMonitor.GameOverEvent += GameOverEvent_Click;
            Button_DragMove.PreviewMouseDown += Button_DragMoveMouseLeftButtonDown;
            Grid_General.Background = new ImageBrush(new BitmapImage(new Uri("Cosmic.jpg", UriKind.Relative)));
        }
        private void Button_DragMoveMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Up_Click(object sender, EventArgs e)
        {
            GameRectangle.IsPossibleToGenerate = false;
            foreach (List<GameRectangle> elem in SystemRuntimeMonitor.GameRectangleContainsMatrix)
                foreach (GameRectangle x in elem)
                    x.MoveUp(0);
            foreach (List<GameRectangle> elem in SystemRuntimeMonitor.GameRectangleContainsMatrix)
                foreach (GameRectangle x in elem)
                    x.MoveUp(0);
            SystemRuntimeMonitor.GameRectanglePossibleToGenerate_Update();
            if (GameRectangle.IsPossibleToGenerate)
                UpdateInfo();
            else
                if (SystemRuntimeMonitor.IsGameOver)  
                    SystemRuntimeMonitor.RunGameOver();
        }
        private void Button_Right_Click(object sender, EventArgs e)
        {
            GameRectangle.IsPossibleToGenerate = false;
            foreach (List<GameRectangle> elem in SystemRuntimeMonitor.GameRectangleContainsMatrix)
                foreach (GameRectangle x in elem)
                    x.MoveRight(0);
            foreach (List<GameRectangle> elem in SystemRuntimeMonitor.GameRectangleContainsMatrix)
                foreach (GameRectangle x in elem)
                    x.MoveRight(0);
            SystemRuntimeMonitor.GameRectanglePossibleToGenerate_Update();
            if (GameRectangle.IsPossibleToGenerate)
                UpdateInfo();
            else
                if (SystemRuntimeMonitor.IsGameOver)
                    SystemRuntimeMonitor.RunGameOver();
            
        }
        private void Button_Down_Click(object sender, EventArgs e)
        {
            GameRectangle.IsPossibleToGenerate = false;
            foreach (List<GameRectangle> elem in SystemRuntimeMonitor.GameRectangleContainsMatrix)
                foreach (GameRectangle x in elem)
                    x.MoveDown(0);
            foreach (List<GameRectangle> elem in SystemRuntimeMonitor.GameRectangleContainsMatrix)
                foreach (GameRectangle x in elem)
                    x.MoveDown(0);
            SystemRuntimeMonitor.GameRectanglePossibleToGenerate_Update();
            if (GameRectangle.IsPossibleToGenerate)
                UpdateInfo();
            else
                if (SystemRuntimeMonitor.IsGameOver)
                    SystemRuntimeMonitor.RunGameOver();

        }
        private void Button_Left_Click(object sender, EventArgs e)
        {
            GameRectangle.IsPossibleToGenerate = false;
            foreach (List<GameRectangle> elem in SystemRuntimeMonitor.GameRectangleContainsMatrix)
                foreach (GameRectangle x in elem)
                    x.MoveLeft(0);
            foreach (List<GameRectangle> elem in SystemRuntimeMonitor.GameRectangleContainsMatrix)
                foreach (GameRectangle x in elem)
                    x.MoveLeft(0);
            SystemRuntimeMonitor.GameRectanglePossibleToGenerate_Update();
            if (GameRectangle.IsPossibleToGenerate)
                UpdateInfo();
            else
                if (SystemRuntimeMonitor.IsGameOver)
                    SystemRuntimeMonitor.RunGameOver();
        }
        public void UpdateInfo()
        {
            SystemRuntimeMonitor.ReloadVisualPosition();
            SystemRuntimeMonitor.GenerateGameRectangle();
            SystemRuntimeMonitor.ReloadVisualPosition();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                Button_Maximize.Content = "Full";
            }
            else{
                this.WindowState = System.Windows.WindowState.Maximized;
                Button_Maximize.Content = "Normal";
            }
        }

        private void KeyEvents(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up) Button_Up_Click(sender, new EventArgs());
            else if (e.Key == Key.Right) Button_Right_Click(sender, new EventArgs());
            else if (e.Key == Key.Down) Button_Down_Click(sender, new EventArgs());
            else if (e.Key == Key.Left) Button_Left_Click(sender, new EventArgs());
            else return;
        }

        public void GameOverEvent_Click(object sender,EventArgs e)
        {
            Border Border_GameOver = new Border();
            Border_GameOver.Opacity = 0;
            Border_GameOver.Width = this.Width;
            Border_GameOver.Height = this.Height;
            Border_GameOver.HorizontalAlignment = HorizontalAlignment.Center;
            Border_GameOver.VerticalAlignment = VerticalAlignment.Center;
            Border_GameOver.Background = new ImageBrush(new BitmapImage(new Uri("Gameover.jpg",UriKind.Relative)));
            Grid_General.Children.Add(Border_GameOver);
            Border_GameOver.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1)));

        }
    }
}
