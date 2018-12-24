using System;
using System.Drawing;

namespace Conway_Terminal
{
    class Conway
    {
        const int _upperY = 15;
        const int _upperX = 15;
        private char[,] map = new char[_upperY, _upperX];
        private int _alive, _start;


        public Conway()
        {

            DrawStart();

            for (int col = 0; col < _upperY; col++)
                for (int row = 0; row < _upperX; row++)
                    map[col, row] = '0';
            var rdm = new Random();

            do
            {
                int rdmY = rdm.Next(0, _upperY);
                int rdmX = rdm.Next(0, _upperX);
                if (map[rdmY, rdmX] == '1') continue;
                map[rdmY, rdmX] = '1';
            } while (Count() < _start);


        }

        private void DrawStart()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"
   _____                                              _            _____                            
  / ____|                                            ( )          / ____|                           
 | |        ___    _ __   __      __   __ _   _   _  |/   ___    | |  __    __ _   _ __ ___     ___ 
 | |       / _ \  | '_ \  \ \ /\ / /  / _` | | | | |     / __|   | | |_ |  / _` | | '_ ` _ \   / _ \
 | |____  | (_) | | | | |  \ V  V /  | (_| | | |_| |     \__ \   | |__| | | (_| | | | | | | | |  __/
  \_____|  \___/  |_| |_|   \_/\_/    \__,_|  \__, |     |___/    \_____|  \__,_| |_| |_| |_|  \___|
                                               __/ |                                                
                                              |___/                                                 ");  //big font
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"
                                                             ___            ___          _ _       
                                                            | _ )  _  _    / __|  _ __  | | |   __ 
                                                            | _ \ | || |   \__ \ | '_ \ |_  _| / _|
                                                            |___/  \_, |   |___/ | .__/   |_|  \__|
                                                                    |__/          |_|               "); //small font
                                                                                                        //fonts by messletters.com
            Console.Write("\n");
            Console.ResetColor();
            _start = Convert.ToInt32(Program.Prompt("Start Count: "));
        }
        private void ApplyRules()
        {
            char[,] oldMap = map;
            for (int y = 0; y < _upperY; y++)
            {
                for (int x = 0; x < _upperX; x++)
                {
                    switch (Count(x, y, oldMap))
                    {
                        case 0:
                        case 1:
                            if (oldMap[y, x] == '1')
                                map[y, x] = '0';
                            break;
                        case 2:
                            break;
                        case 3:
                            map[y, x] = '1';
                            break;
                        case 4:
                        default:
                            map[y, x] = '0'; //would it be bad practice to use an if
                            break;           //either way the value is 0 but it makes it more readable but also more slow
                    }
                }
                Console.Write("\n");
            }

        }
        private int Count(int gx, int gy, char[,] oldMap)
        {
            int neighbors = 0;
            _alive = 0;
            for (int y = 0; y < _upperY; y++)
                for (int x = 0; x < _upperX; x++)
                {
                    if (oldMap[y, x] == '0') continue;
                    /*  you are at 0
                         1 2 3
                         8 0 4
                         7 6 5
                     */
                    _alive += 1;
                    if (x + 1 == gx && y + 1 ==gy) neighbors++;  // position 7
                    if (x + 1 == gx && y - 1 == gy) neighbors++; // position 1
                    if (x - 1 == gx && y + 1 == gy) neighbors++; // position 5
                    if (x - 1 == gx && y - 1 == gy) neighbors++; // position 3
                    if (x + 1 == gx && y == gy) neighbors++;     // position 8
                    if (x - 1 == gx && y == gy) neighbors++;     // position 4
                    if (x == gx && y + 1 == gy) neighbors++;     // position 6
                    if (x == gx && y - 1 == gy) neighbors++;     // position 2
                }
            return neighbors;
        }
                private int Count()
        {
            _alive = 0;
            for (int y = 0; y < _upperY; y++)
                for (int x = 0; x < _upperX; x++)
                    if (map[y, x] == '1')
                        _alive += 1;
            return _alive;
        }
        public void DrawFrame()
        {

            for (int y = 0; y < _upperY; y++)
            {
                for (int x = 0; x < _upperX; x++)
                {
                    Console.Write(map[y, x] + " ");
                }
                Console.Write("\n");
            }
            ApplyRules();
        }
        
        public void DrawBoth()
        {

            for (int y = 0; y < _upperY; y++)
            {
                for (int x = 0; x < _upperX; x++)
                {
                    Console.Write(map[y, x] + " ");
                }
                Console.Write(@"    |     ");
                for (int x = 0; x < _upperX; x++)
                {
                    Console.Write(Count(x, y, map) + " ");
                }
                Console.Write("\n");
            }
            ApplyRules();
        }
        

    }
}
