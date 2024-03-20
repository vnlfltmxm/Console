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

        private int _posX;
        private int _posY;
        private int _fireLength;
        public bool _ex;
        public bool _c;
        public bool _u;
        public bool _d;
        public bool _r;
        public bool _l;

        


        System.Timers.Timer timer = new System.Timers.Timer(500);
        System.Timers.Timer timer2 = new System.Timers.Timer(3000);


        public Boom(int posX, int posY, int fireLength, Map map)
        {
            _d = false;
            _u = false;
            _l = false;
            _r = false;
            _c=false;
            _ex = false;
            
            _posX = posX;
            _posY = posY;
            _fireLength = fireLength;
            this.map = map;

            this.DownTimer();
        }

        public void DownTimer()
        {
            _c = true;
            timer2.Elapsed += new ElapsedEventHandler(timer_Elapsed2);
            timer2.Start();
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
                if (map.map[_posY , _posX - i] == eMapState.BOOM && i != 0)
                {
                    
                    map.map[_posY , _posX - i] = eMapState.BOOM;
                    continue;
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
                if (map.map[_posY , _posX + i] == eMapState.BOOM && i != 0)
                {
                    map.map[_posY , _posX + i] = eMapState.BOOM;
                    continue;
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
                if (map.map[_posY + i, _posX] == eMapState.BOOM && i != 0)
                {
                    map.map[_posY + i, _posX] = eMapState.BOOM;
                    continue;
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
                if (map.map[_posY - i, _posX] == eMapState.BOOM && i !=0 )
                {
                    map.map[_posY - i, _posX] = eMapState.BOOM;
                    continue;
                }

                map.map[_posY - i, _posX] = eMapState.FIRE;
            }
        }
        public void Explosion()
        {
                UPEX();
                DownEX();
                RightEX();
                LeftEX();
            
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Start();
            


        }
        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            Thread.Sleep(100);
            
            map.MapCheck();
            map.MapClear();



            timer.AutoReset = false;
            timer.Dispose();
            _ex = true;
        }
        public void timer_Elapsed2(object sender, ElapsedEventArgs e)
        {
            Explosion();

            timer2.AutoReset = false;
            timer2.Dispose();
        }


    }
}
