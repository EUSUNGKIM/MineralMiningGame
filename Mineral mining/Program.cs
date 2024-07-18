using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Mineral_mining.Program;

namespace Mineral_mining
{
    internal class Program
    {
        public struct GameData
        {
            public bool running;
            public bool[,] map;
            public ConsoleKey inputKey;
            public Point playerPos;
            public Point MineralPos;
            public Point MineralPos2;
            public Point ShopPos;
            public int Mineralscor;
            public int Money;
            public int GOD;
        }
        public struct Point
        {
            public int x;
            public int y;
        }
        static void Start()
        {
            Console.CursorVisible = false;

            //게임 데이터 세팅
            data = new GameData();

            data.running = true;
            data.map = new bool[,]
            {
                {false,false,false,false,false,false,false,false,false, false, false,false,false,false,false,false,false,false, false, false,},
                {false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false,},
                {false, true, true, true, true, true, true, false,true, true, true, false, true, true, true, true, true, true, true, false,},
                {false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false,},
                {false, true, true, true, false, true, true, true, true, true, true, true, true, true, true, true, false,true,true, false,},
                {false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false,},
                {false, true, true, true, true, true, true, true, true, true, true, true, false, true, true, true,true,true, true, false,},
                {false, true, true, false, true, true, false,true, true, true, true, true, true, true, true, true, true, true, true, false,},
                {false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false,},
                {false, false,false,false,false,false,false,false,false, false,false,false,false,false,false,false,false,false, false, false,}
            };
            
            //캐릭터 위치
            data.playerPos = new Point()
            { x = 2, y = 1 };
            data.ShopPos = new Point()
            { x = 9, y = 8 };
            data.MineralPos = RandumP();
            data.MineralPos2 = RandumP();

            data.Mineralscor = 0;
            data.Money = 0;

            // 타이틀
            Console.Clear();
            Console.WriteLine("      게임시작!      ");
            Console.WriteLine(" 황금곡갱이를 찾아서 ");
            Console.WriteLine("(아무키를 눌러주세요)");
            Console.ReadKey();
        }
        static void End()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=           황금곡갱이를           =");
            Console.WriteLine("=              구매했습니다!!      =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
        }
        static void PrintMap()
        {
            for (int y = 0; y < data.map.GetLength(0); y++)
            {
                for (int x = 0; x < data.map.GetLength(1); x++)
                {
                    if (data.map[y, x])
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write("■");
                    }
                }
                Console.WriteLine();
            }
        }
        static Point RandumP()
        {
            Point p = new Point();
            int y = data.map.GetLength(0);
            int x = data.map.GetLength(1);
            Random rand = new Random();
            bool a = true;
            while (a)
            {
                p.y = rand.Next(1, y - 1);
                p.x = rand.Next(1, x - 1);
                if (data.map[p.y, p.x] && (p.x != data.MineralPos.x || p.y != data.MineralPos.y))
                {
                    a = false;
                }
            }
            return p;
        }
        static void PrintMineral()
        {
            Console.SetCursorPosition(data.MineralPos.x * 2, data.MineralPos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("▲");
            Console.ResetColor();
            Console.SetCursorPosition(data.MineralPos2.x * 2, data.MineralPos2.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("▲");
            Console.ResetColor();
        }
        static void min2()
        {
            if (data.inputKey == ConsoleKey.Spacebar)
            {
                if (data.MineralPos.x == data.playerPos.x && data.MineralPos.y == data.playerPos.y)
                {
                    data.Mineralscor++;
                    data.MineralPos = RandumP();
                }
                else if (data.MineralPos2.x == data.playerPos.x && data.MineralPos2.y == data.playerPos.y)
                {
                    data.Mineralscor++;
                    data.MineralPos2 = RandumP();
                }
            }
        }
        static void Motion()
        {
            Console.SetCursorPosition(data.playerPos.x*2, data.playerPos.y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ⓐ");
            Console.ResetColor();
            Thread.Sleep(300);
            Console.SetCursorPosition(data.playerPos.x*2, data.playerPos.y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  ");
            Console.ResetColor();
            Thread.Sleep(300);
        }
        static void PrintPlayer()
        {

            if (data.inputKey == ConsoleKey.Spacebar)
            {
                if (data.playerPos.x == data.MineralPos.x && data.playerPos.y == data.MineralPos.y)
                {
                    Motion();
                    Motion();
                    Motion();
                    Console.SetCursorPosition(data.playerPos.x*2, data.playerPos.y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("♧");
                    Console.ResetColor();
                }
                else if (data.playerPos.x == data.MineralPos2.x && data.playerPos.y == data.MineralPos2.y)
                {
                    Motion();
                    Motion();
                    Motion();
                    Console.SetCursorPosition(data.playerPos.x * 2, data.playerPos.y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("♧");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(data.playerPos.x * 2, data.playerPos.y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("♧");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.SetCursorPosition(data.playerPos.x * 2, data.playerPos.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("♧");
                Console.ResetColor();
            }
        }
        static void Shopuser()
        {
            Console.SetCursorPosition(data.ShopPos.x * 2, data.ShopPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("∩");
            Console.ResetColor();
        }
        static void Render()
        {
            Console.Clear();
            PrintMap();
            PrintPlayer();
            min2();
            PrintMineral();
            Shopuser();
            if (data.running == true)
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine($"광물의 갯수 : {data.Mineralscor}개 입니다.");
                Console.Write($"현재 소지금은 : {data.Money}원 입니다.");
            }
        }
        static void Move()
        {
            switch (data.inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                case ConsoleKey.Spacebar:
                    break;
            }
        }
        static void MoveUp()
        {
            Point next = new Point() { x = data.playerPos.x, y = data.playerPos.y - 1 };
            if (data.map[next.y, next.x])
            {
                data.playerPos = next;
            }
        }
        static void MoveDown()
        {
            Point next = new Point() { x = data.playerPos.x, y = data.playerPos.y + 1 };
            if (data.map[next.y, next.x])
            {
                data.playerPos = next;
            }
        }
        static void text()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.ResetColor();
        }
        static void text2()
        {
            Console.Clear();
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Thread.Sleep(500);
        }
        static void text3()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=======================================");
            Console.WriteLine("=     황금곡갱이 가격은 20원 입니다.  =");
            Console.WriteLine($"=            {data.Mineralscor}개 있습니다.            =");
            Console.WriteLine("=======================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=           파시겠습니까?             =");
            Console.WriteLine("=               (Y,N)                 =");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=         (황금곡갱이 구매)           =");
            Console.WriteLine("=                (G)                  =");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=======================================");
            Console.WriteLine("               나가기 (T)              ");
            Console.ResetColor();
            Console.SetCursorPosition(0, 12);
            Console.WriteLine($"광물의 갯수 : {data.Mineralscor}개 입니다.");
            Console.WriteLine($"현재 소지금은 : {data.Money}원 입니다.");
            Console.ResetColor();
        }
        static void MoveLeft()
        {
            Point next = new Point() { x = data.playerPos.x - 1, y = data.playerPos.y };
            if (data.map[next.y, next.x])
            {
                data.playerPos = next;
            }
        }

        static void MoveRight()
        {
            Point next = new Point() { x = data.playerPos.x + 1, y = data.playerPos.y };
            if (data.map[next.y, next.x])
            {
                data.playerPos = next;
            }
        }
        static void Input()
        {
            data.inputKey = Console.ReadKey(true).Key;
        }
        static void CheckGameClear()
        {
            data.running = false;
        }
        static void Update()
        {
            Move();
            Jmt();
        }
        static void Jmt()
        {
            if (data.playerPos.x == 9 && data.playerPos.y == 8)
            {
                if (data.inputKey == ConsoleKey.Spacebar)
                {
                    bool b = true;
                    while (b)
                    {
                        Console.CursorVisible = true;
                        bool a = true;
                        text3();
                        while (a)
                        {
                            string panbul = Console.ReadLine();
                            if (panbul == "Y" || panbul == "y")
                            {
                                data.Money += data.Mineralscor;
                                data.Mineralscor = 0;
                                a = false;
                            }
                            else if (panbul == "N" || panbul == "n")
                            {
                                a = false;
                            }
                            else if (panbul == "G" || panbul == "g")
                            {
                                if (data.Money >= 20)
                                {
                                    text2();
                                    text();
                                    text2();
                                    text();
                                    Thread.Sleep(500);
                                    a = false;
                                    b = false;
                                    data.running = false;
                                }
                                else
                                {
                                    Console.WriteLine("소지금이 부족합니다.");
                                }
                            }
                            else if (panbul == "T" || panbul == "t")
                            {
                                a = false;
                                b = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("잘못입력 하셨습니다.");
                            }
                        }
                        Console.CursorVisible = false;
                    }
                }
            }
        }
        static GameData data;
        static void Main(string[] args)
         {
            Start();
            while (data.running)
            {
                Render();
                Input();
                Update();
            }
            End();
        }
    }
}
