using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Board
    {
        private string[,] _grid;

        public void SetUpGrid()
        {
            _grid = new string[10,10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _grid[i, j] = " ";
                }
            }

        }
        
        public ShotStatus TakeShot(int shotX, int shotY, Ship[] shipList)
        {
           if (_grid[shotX, shotY] == "X" || _grid[shotX, shotY] == "O")
                return ShotStatus.Repeat;
          

            ShotStatus shotResult = checkShot(shotX, shotY, shipList);
            if (shotResult == ShotStatus.Hit)
            {
                _grid[shotX, shotY] = "X";
                return ShotStatus.Hit;
            }
            else
            {
                _grid[shotX, shotY] = "O";
                return ShotStatus.Miss;
            }

        }

        private ShotStatus checkShot(int shotX, int shotY, Ship[] ShipList)
        {
            foreach (Ship theShip in ShipList)
            {
                foreach (int position in theShip.locations)
                {
                    string coordinates = "" + shotX + shotY;
                    if (position.ToString() == coordinates)
                        return ShotStatus.Hit;
                }
            }
            return ShotStatus.Miss;
        }
    
        public string RetrieveMarkForPosition(int shotX, int shotY)
        {
            return _grid[shotX, shotY];
        }
    }
}
