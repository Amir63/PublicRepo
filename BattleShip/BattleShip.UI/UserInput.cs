using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class UserInput
    {
        public static int GetCoordinate(string prompt)
        {
            bool validData = false;
            int result = 0;

            while(!validData)
            {
                Console.Write(prompt);
                if(int.TryParse(Console.ReadLine(), out result))
                {
                    // valid number, in bounds?
                    if (result < 0 || result >9)
                    {
                        Console.WriteLine("That coordinate is out of range (0-9)!");
                    }
                    else
                    {
                        validData = true;
                    }
                }
            }

            return result;
        }
    }
}
