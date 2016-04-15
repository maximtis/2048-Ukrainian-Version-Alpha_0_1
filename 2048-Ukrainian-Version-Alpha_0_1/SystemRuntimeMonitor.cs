using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace _2048_Ukrainian_Version_Alpha_0_1
{
    public static class SystemRuntimeMonitor
    {
        public static List<List<PositionData>> NowPositionMatrix;
        public static List<List<GameRectangle>> GameRectangleContainsMatrix;
        public static List<RandomMatrixDataStruct> GameRectanglePossibleToGenerate;
        public static event EventHandler GameOverEvent;
        public static bool IsGameOver
        {
            get
            {
                return GameRectanglePossibleToGenerate.Count == 0;
            }
        }
        public static void RunGameOver() 
        {
            if(GameOverEvent!=null)
            {
                GameOverEvent(new object(), new EventArgs());
            }
        }
        public static void GameRectanglePossibleToGenerate_Initialize()
        {
            GameRectanglePossibleToGenerate = new List<RandomMatrixDataStruct>(4);
        }
        public static void GameRectanglePossibleToGenerate_Update()
        {
            GameRectanglePossibleToGenerate.Clear();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (GameRectangleContainsMatrix[i][j].Value == 0)
                        GameRectanglePossibleToGenerate.Add(new RandomMatrixDataStruct(i, j));

            if (IsGameOver)
                if (GameOverEvent != null)
                    GameOverEvent(new Object(), new EventArgs());
            
        }
        public static void GenerateGameRectangle()
        {
            GameRectanglePossibleToGenerate_Update();
            int RandomValue = new Random().Next(0, GameRectanglePossibleToGenerate.Count);
            GameRectangleContainsMatrix[GameRectanglePossibleToGenerate[RandomValue].Row][GameRectanglePossibleToGenerate[RandomValue].Col].Value = 2;
        }
        public static void NowPositionMatrix_Initialize()
        {
            NowPositionMatrix = new List<List<PositionData>>(4);
            for(int i = 0; i < 4 ; i++)
                NowPositionMatrix.Add(new List<PositionData>(4));
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    NowPositionMatrix[i].Add(new PositionData());

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i == 0 && j == 0)
                                NowPositionMatrix[i][j] = new PositionData(Position.Up, Position.Left);
                            else if (i == 0 && j == 3)
                                NowPositionMatrix[i][j] = new PositionData(Position.Up, Position.Right);
                            else if (i == 3 && j == 0)
                                NowPositionMatrix[i][j] = new PositionData(Position.Down, Position.Left);
                            else if (i == 3 && j == 3)
                                NowPositionMatrix[i][j] = new PositionData(Position.Down, Position.Right);
                            else if (i == 0 && j > 0 && j < 3)
                                NowPositionMatrix[i][j] = new PositionData(Position.Up, 0);
                            else if (i == 3 && j > 0 && j < 3)
                                NowPositionMatrix[i][j] = new PositionData(Position.Down, 0);
                            else if (i > 0 && i < 3 && j == 3)
                                NowPositionMatrix[i][j] = new PositionData(0, Position.Right);
                            else if (i > 0 && i < 3 && j == 0)
                                NowPositionMatrix[i][j] = new PositionData(0, Position.Left);
                            else
                                NowPositionMatrix[i][j] = new PositionData(0, 0);
                        }
                    }
            

        }
        public static void GameRectangleContainsMatrix_Initialize()
        {
            GameRectangleContainsMatrix = new List<List<GameRectangle>>(4);
            for (int i = 0; i < GameRectangleContainsMatrix.Capacity; i++)
                GameRectangleContainsMatrix.Add(new List<GameRectangle>(4));

            for (int i = 0; i < GameRectangleContainsMatrix.Capacity; i++)
                for (int j = 0; j < GameRectangleContainsMatrix.Capacity; j++)
                    GameRectangleContainsMatrix[i].Add(new GameRectangle(NowPositionMatrix[i][j],i,j));
            GameRectangleContainsMatrix[0][0].Value = 2;
        }
        public static void ReloadProgrammPosition()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    GameRectangleContainsMatrix[i][j].NowPosition = NowPositionMatrix[i][j];
        }
        public static void ReloadVisualPosition()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    MainWindow.VisualBorderList[i][j].InitializeFromGameRectangle(GameRectangleContainsMatrix[i][j]);
        }         
    }
}
