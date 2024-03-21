using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IUnit
    {
        public void MoveAction();
        public void Die();
    }
    public abstract class Unit
    {
        private Map map;
        private int _posX;
        private int _posY;
        private int _beforePosX;
        private int _beforePosY;
        private bool _die;


        public int posX { get { return _posX; } set { _posX = value; } }
        public int posY { get { return _posY; } set { _posY = value; } }

        public int beforePosX { get { return _beforePosX; }set { _beforePosX = value; } }
        public int beforePosY { get { return _beforePosY; } set { _beforePosY = value; } }

        public bool die { get { return _die; } set { _die = value; } }

        public Unit(Map map,int posX,int posY,bool die=false) 
        {
            this.map = map;
            this._posX = posX;
            this._posY = posY;
            _beforePosX = posX;
            _beforePosY = posY;

        }

        public virtual bool LeftMoveCheck()
        {
            switch (map.map[posY, posX - 1])
            {
                case eMapState.WILL:
                    return false;
                case eMapState.BOX:
                    return false;
                case eMapState.BOOM:
                    return false;
                default:
                    return true;
            }
        }
        public virtual bool RightMoveCheck()
        {
            switch (map.map[posY, posX + 1])
            {
                case eMapState.WILL:
                    return false;
                case eMapState.BOX:
                    return false;
                case eMapState.BOOM:
                    return false;
                default:
                    return true;
            }
        }
        
        public virtual bool UPMoveCheck()
        {
            switch (map.map[posY - 1, posX])
            {
                case eMapState.WILL:
                    return false;
                case eMapState.BOX:
                    return false;
                case eMapState.BOOM:
                    return false;
                default:
                    return true;
            }
        }
        public virtual bool DownMoveCheck()
        {
            switch (map.map[posY + 1, posX])
            {
                case eMapState.WILL:
                    return false;
                case eMapState.BOX:
                    return false;
                case eMapState.BOOM:
                    return false;
                default:
                    return true;
            }
        }

        public virtual void RightMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posX++;
        }
        public virtual void LeftMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posX--;
        }
        public virtual void UPMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posY--;
        }
        public virtual void DownMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posY++;
        }

    }
}
