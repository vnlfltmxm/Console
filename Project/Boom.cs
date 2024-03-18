using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Project
{
    internal class Boom
    {
        Map map;

        private int _timer;
        private int _posX;
        private int _posY;
        private int _fireLength;
        private bool _explosion;
        System.Timers.Timer timer = new System.Timers.Timer(500);

        public bool explosion { get { return _explosion; } }

        public Boom(int timer, int posX, int posY, int fireLength, Map map)
        {
            _timer = timer;
            _posX = posX;
            _posY = posY;
            _fireLength = fireLength;
            _explosion = false;
            this.map = map;
        }

        public void DownTimer()
        {
            _timer--;
        }

        public void LeftEX()
        {
            for (int i = 0; i < _fireLength; i++)
            {
                if (map.map[_posY, _posX - i] == eMapState.WILL)
                {
                    break;
                }
                if (map.map[_posY, _posX - i] == eMapState.BOX)
                {
                    map.map[_posY, _posX - i] = eMapState.FIRE;
                    break;
                }
                map.map[_posY, _posX - i] = eMapState.FIRE;
            }
        }
        public void RightEX()
        {
            for (int i = 0; i < _fireLength; i++)
            {
                if (map.map[_posY, _posX + i] == eMapState.WILL)
                {
                    break;
                }
                if (map.map[_posY, _posX + i] == eMapState.BOX)
                {
                    map.map[_posY, _posX + i] = eMapState.FIRE;
                    break;
                }
                map.map[_posY, _posX + i] = eMapState.FIRE;
            }
        }
        public void DownEX()
        {
            for (int i = 0; i < _fireLength; i++)
            {
                if (map.map[_posY + i, _posX] == eMapState.WILL)
                {
                    break;
                }

                if (map.map[_posY + i, _posX] == eMapState.BOX)
                {
                    map.map[_posY + i, _posX] = eMapState.FIRE;
                    break;
                }

                map.map[_posY + i, _posX] = eMapState.FIRE;
            }
        }

        public void UPEX()
        {
            for (int i = 0; i < _fireLength; i++)
            {

                if (map.map[_posY - i, _posX] == eMapState.WILL)
                {
                    break;
                }
                if (map.map[_posY - i, _posX] == eMapState.BOX)
                {
                    map.map[_posY - i, _posX] = eMapState.FIRE;
                    break;
                }
                map.map[_posY - i, _posX] = eMapState.FIRE;
            }
        }

        public void DownCheck()
        {
            int n = 1;
            while (n < _fireLength && map.map[_posY + n, _posX] != eMapState.WILL)
            {
                map.map[_posY + n, _posX] = eMapState.NULL;
                n++;
            }
        }
        public void UPCheck()
        {
            int n = 1;
            while (n < _fireLength && map.map[_posY - n, _posX] != eMapState.WILL)
            {
                map.map[_posY - n, _posX] = eMapState.NULL;
                n++;
            }
        }
        public void LeftCheck()
        {
            int n = 1;
            while (n < _fireLength && map.map[_posY, _posX - n] != eMapState.WILL)
            {
                map.map[_posY, _posX - n] = eMapState.NULL;
                n++;
            }
        }
        public void RightCheck()
        {
            int n = 1;
            while (n < _fireLength && map.map[_posY, _posX + n] != eMapState.WILL)
            {
                map.map[_posY, _posX + n] = eMapState.NULL;
                n++;
            }
        }


        public void Explosion()
        {
            if (_timer == 0)
            {
                UPEX();
                DownEX();
                RightEX();
                LeftEX();


                //timer.AutoReset = true;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Start();

                _explosion = true;


            }
        }
        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            map.map[_posY, _posX] = eMapState.NULL;
            LeftCheck();
            RightCheck();
            UPCheck();
            DownCheck();




            timer.AutoReset = false;
            timer.Dispose();
        }


    }
}
