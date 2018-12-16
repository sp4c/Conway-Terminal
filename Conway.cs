using System;

namespace Conway_Terminal
{
    class Conway
    {
        const int _upperY = 5;
        const int _upperX = 5;
        private Char[,] map = new Char[_upperY, _upperX];
        private int _alive, _start, _neighbors;


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
                Count();
            } while (_alive < _start);


        }

        private void DrawStart()
        {
            Console.WriteLine(@"
   ___                                       _           ___                      
  / __|  ___   _ _   __ __ __  __ _   _  _  ( )  ___    / __|  __ _   _ __    ___ 
 | (__  / _ \ | ' \  \ V  V / / _` | | || | |/  (_-<   | (_ | / _` | | '  \  / -_)
  \___| \___/ |_||_|  \_/\_/  \__,_|  \_, |     /__/    \___| \__,_| |_|_|_| \___|
                                      |__/                                        ");  //standard font (theres a good chance im wrong)
            _start = Convert.ToInt32(Program.Prompt("How many do you want to start alive"));
            Console.WriteLine(@"
 ____  ____  ____  ____  ____  ____  _________  ____  ____  ____  ____  ____ 
||P ||||r ||||e ||||a ||||s ||||s ||||       ||||S ||||t ||||a ||||r ||||t ||
||__||||__||||__||||__||||__||||__||||_______||||__||||__||||__||||__||||__||
|/__\||/__\||/__\||/__\||/__\||/__\||/_______\||/__\||/__\||/__\||/__\||/__\|"); //smkeyboard font
            Console.ReadKey();
        }
        private void ApplyRules()
        {
            throw new NotImplementedException();
        }
        private int Count(int gx, int gy)
        {
            _alive = 0;
            for (int y = 0; y < _upperY; y++)
                for (int x = 0; x < _upperX; x++)
                    if (map[y, x] == '1')
                    {
                        _alive += 1;
                        if (x + 1 == gx || x - 1 == gx && y + 1 == gy || y - 1 == gy)
                        {
                            _neighbors += 1;
                            continue;
                        }
                        else if (x + 1 == gx || x - 1 == gx)
                        {
                            _neighbors += 1;
                            continue;
                        }
                        else if (y + 1 == gy || y - 1 == gy)
                            _neighbors += 1;
                    }
            return _neighbors;

        }
        private int Count()
        {
            _alive = 0;
            for (int y = 0; y < _upperY; y++)
                for (int x = 0; x < _upperX; x++)
                    if (x == 1)
                        _alive += 1;
            return _alive;
        }
        public void DrawFrame()
        {

            foreach (int y in map)
            {
                foreach (int x in map)
                {
                    Console.Write(' ' + (x));
                }
                Console.WriteLine();
            }
            //ApplyRules();
        }

    }
}