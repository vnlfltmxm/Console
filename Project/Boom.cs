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

        //private int _dCount;
        //private int _uCount;
        //private int _lCount;
        //private int _rCount;



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
            //_dCount = 0;
            //_lCount = 0;
            //_rCount = 0;
            //_uCount = 0;
            _posX = posX;
            _posY = posY;
            _fireLength = fireLength;
            this.map = map;
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
                    //_lCount++;
                    //_l = true;
                    map.map[_posY, _posX - i] = eMapState.FIRE;
                    break;
                }
                if (map.map[_posY , _posX - i] == eMapState.BOOM && i != 0)
                {
                    //_lCount++;
                    map.map[_posY , _posX - i] = eMapState.BOOM;
                    continue;
                }
                //_lCount++;
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
                    //_rCount++;
                    //_r = true;
                    map.map[_posY, _posX + i] = eMapState.FIRE;
                    break;
                }
                if (map.map[_posY , _posX + i] == eMapState.BOOM && i != 0)
                {
                    //_rCount++;
                    map.map[_posY , _posX + i] = eMapState.BOOM;
                    continue;
                }
                //_rCount++;
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
                    //_dCount++;
                    //_d = true;
                    map.map[_posY + i, _posX] = eMapState.FIRE;
                    break;
                }
                if (map.map[_posY + i, _posX] == eMapState.BOOM && i != 0)
                {
                    //_dCount++;
                    map.map[_posY + i, _posX] = eMapState.BOOM;
                    continue;
                }
                //_dCount++;
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
                    //_uCount++;
                    map.map[_posY - i, _posX] = eMapState.FIRE;
                    break;
                }

                if(map.map[_posY - i, _posX] == eMapState.BOOM && i !=0 )
                {
                    //_uCount++;
                    map.map[_posY - i, _posX] = eMapState.BOOM;
                    continue;
                }

                //_uCount++;
                map.map[_posY - i, _posX] = eMapState.FIRE;
            }
        }

        //public void DownCheck()
        //{
        //    int n = 1;
        //    while (n < _dCount)
        //    {
        //        if (map.map[_posY + n, _posX] == eMapState.BOOM)
        //        {
        //            map.map[_posY + n, _posX] = eMapState.BOOM;
        //            n++;
        //            continue;
        //        }
        //        if (_d == true)
        //        {
        //            map.box[$"{_posY + n},{_posX}"].DistroyBox(map, _posX, _posY + n);
        //            map.box.Remove($"{_posY + n},{_posX}");
        //            break;
        //        }
        //        map.map[_posY + n, _posX] = eMapState.NULL;
        //        n++;
        //    }
        //}
        //public void UPCheck()
        //{
        //    int n = 1;

        //    for (int i = 1; i < _uCount; i++)
        //    {
        //        if (map.map[_posY - n, _posX] == eMapState.BOOM)
        //        {
        //            map.map[_posY - n, _posX] = eMapState.BOOM;
        //            n++;
        //            continue;
        //        }
        //        if (_u == true)
        //        {
        //            map.box[$"{_posY - n},{_posX}"].DistroyBox(map, _posX, _posY - n);
        //            map.box.Remove($"{_posY - n},{_posX}");
        //            break;
        //        }
        //        map.map[_posY - n, _posX] = eMapState.NULL;
        //        n++;
        //    }
        //    while (n < _uCount)
        //    {
        //        if (map.map[_posY - n, _posX] == eMapState.BOOM)
        //        {
        //            map.map[_posY - n, _posX] = eMapState.BOOM;
        //            n++;
        //            continue;
        //        }
        //        if (_u == true)
        //        {
        //            map.box[$"{_posY - n},{_posX}"].DistroyBox(map, _posX, _posY - n);
        //            map.box.Remove($"{_posY - n},{_posX}");
        //            break;
        //        }
        //        map.map[_posY - n, _posX] = eMapState.NULL;
        //        n++;
        //    }
        //}
        //public void LeftCheck()
        //{
        //    int n = 1;
        //    while (n < _lCount)
        //    {
        //        if (map.map[_posY, _posX - n] == eMapState.BOOM)
        //        {
        //            map.map[_posY, _posX - n] = eMapState.BOOM;
        //            n++;
        //            continue;
        //        }
        //        if (_l == true)
        //        {
        //            map.box[$"{_posY},{_posX - n}"].DistroyBox(map, _posX - n, _posY);
        //            map.box.Remove($"{_posY},{_posX - n}");
        //            break;
        //        }


        //        map.map[_posY, _posX - n] = eMapState.NULL;
        //        n++;
        //    }
        //}
        //public void RightCheck()
        //{
        //    int n = 1;
        //    while (n < _rCount)
        //    {
        //        if (map.map[_posY, _posX + n] == eMapState.BOOM)
        //        {

        //            map.map[_posY, _posX + n] = eMapState.BOOM;
        //            n++;
        //            continue;
        //        }
        //        if (_r == true)
        //        {
        //            map.box[$"{_posY},{_posX + n}"].DistroyBox(map, _posX + n, _posY);
        //            map.box.Remove($"{_posY},{_posX + n}");
        //            break;
        //        }
        //        map.map[_posY, _posX + n] = eMapState.NULL;
        //        n++;
        //    }
        //}


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
            //map.map[_posy, _posx] = emapstate.null;
            //leftcheck();
            //rightcheck();
            //upcheck();
            //downcheck();
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
