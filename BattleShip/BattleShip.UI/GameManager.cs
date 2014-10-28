using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class GameManager
    {
        private Board _board;
        private Ship[] _shipList;
        private Random rnd = new Random();

        public void SetUpGame()
        {
            _board = new Board();
            _board.SetUpGrid();
            CreateShips();
            PlayGame();
        }

        private void PlayGame()
        {
            int hitsLeft = CalculateHitsLeft();
            int shotsTaken = GameLogic(hitsLeft);

          
            Console.WriteLine("Congratulations, you won the Game!");
            Console.WriteLine("It took you {0} shots.", shotsTaken);
            Console.ReadLine();

        }

        private int GameLogic(int hitsLeft)
        {
            int totalShots = 0;
            while (hitsLeft > 0)
            {
                int shotX;
                int shotY;
                
                DisplayGrid();

                shotX = UserInput.GetCoordinate("\nPlease enter your the Row for your next shot: ");
                shotY = UserInput.GetCoordinate("Please enter your the Column for your next shot: ");

                bool invalidInput = true;
                while (invalidInput)
                {

                    Console.Write("\nPlease enter your the Row for your next shot: ");
                    testX = int.TryParse(Console.ReadLine(), out shotX);
*
                    if (testX && testY && shotX >= 0 && shotX < 10 && shotY >= 0 && shotY < 10)
                    {
                        ShotStatus thisShot = _board.TakeShot(shotX, shotY, _shipList);
                        if (thisShot == ShotStatus.Hit)
                        {
                            hitsLeft--;
                            Console.WriteLine("Congratulations, it was a hit!");
                            totalShots++;
                        }
                        else if (thisShot == ShotStatus.Miss)
                        {
                            Console.WriteLine("Sorry, you missed.");
                            totalShots++;
                        }
                        else if (thisShot == ShotStatus.Repeat)
                        {
                            Console.WriteLine("You have already entered this cell, please try again.");

                        }
                        invalidInput = false;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid cell, please try again.");
                    }
                    Console.WriteLine("Please press any key to continue.");
                    Console.ReadKey();

                }
                 
            }
           return totalShots;
        }

        private void DisplayGrid()
        {
            Console.Clear();
            Console.WriteLine("              BattleShip ");
            Console.Write("   ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("  " + i + " ");
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\n  " + i + " ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" " +_board.RetrieveMarkForPosition(i, j)+" |");
                }

                Console.WriteLine("\n---------------------------------------------");
            }

        }

        private int CalculateHitsLeft()
        {
            int hitsCounter = 0;
            foreach (Ship thisShip in _shipList)
                hitsCounter += thisShip.size;
            return hitsCounter;
        }

        private void CreateShips()
        {
            _shipList = new Ship[5];

            _shipList[0] = new Ship();
            _shipList[0].size = 2;
            _shipList[0].hitsLeft = _shipList[0].size;
            PlaceShip(_shipList[0]);

            _shipList[1] = new Ship();
            _shipList[1].size = 3;
            _shipList[1].hitsLeft = _shipList[1].size;
            PlaceShip(_shipList[1]);

            _shipList[2] = new Ship();
            _shipList[2].size = 3;
            _shipList[2].hitsLeft = _shipList[2].size;
            PlaceShip(_shipList[2]);

            _shipList[3] = new Ship();
            _shipList[3].size = 4;
            _shipList[3].hitsLeft = _shipList[3].size;
            PlaceShip(_shipList[3]);

            _shipList[4] = new Ship();
            _shipList[4].size = 5;
            _shipList[4].hitsLeft = _shipList[4].size;
            PlaceShip(_shipList[4]);
            //insert custom ship creation code here
        }

        private void PlaceShip(Ship thisShip)
        {
            bool invalidPosition = true;
            while (invalidPosition)
            {
                //generate random starting position
                int shipStartX = rnd.Next(0, 10);
                int shipStartY = rnd.Next(0, 10);
                thisShip.locations = new int[thisShip.size];
                //Choose ship direction
                if (rnd.Next(0, 2) == 1)
                {
                    //up or down
                    if ((shipStartX + thisShip.size) > 10)
                    {
                        //ship goes up from start location
                        for (int i = 0; i < thisShip.size; i++)
                        {
                            thisShip.locations[i] = (shipStartX - i) * 10 + shipStartY;
                        }
                    }
                    else
                    {
                        //ship goes down from start location
                        for (int i = 0; i < thisShip.size; i++)
                        {
                            thisShip.locations[i] = (shipStartX + i) * 10 + shipStartY;
                        }
                    }
                }
                else
                {
                    //left or right
                    if ((shipStartY + thisShip.size) > 10)
                    {
                        //ship goes left from start location
                        for (int i = 0; i < thisShip.size; i++)
                        {
                            thisShip.locations[i] = shipStartX * 10 + (shipStartY - i);
                        }
                    }
                    else
                    {
                        //ship goes right from start location
                        for (int i = 0; i < thisShip.size; i++)
                        {
                            thisShip.locations[i] = shipStartX * 10 + shipStartY + i;
                        }
                    }
                }
                invalidPosition = CheckForOverlap(thisShip);
            }
        }

        private bool CheckForOverlap(Ship thisShip)
        {

            foreach (int thisShipLocation in thisShip.locations)
            {
                foreach (Ship otherShip in _shipList)
                {
                    if (otherShip != thisShip && otherShip != null)
                    {
                        foreach (int otherShipLocation in otherShip.locations)
                        {
                            if (thisShipLocation == otherShipLocation)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

    }
}
