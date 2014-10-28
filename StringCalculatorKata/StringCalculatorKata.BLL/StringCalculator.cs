using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.BLL
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            
            if (numbers == "")
                return 0;

            string newDelimiter = ",";
            if (numbers.StartsWith("//"))
            {
                newDelimiter = numbers.Substring(2, 1);
                numbers = numbers.Remove(0,4);

            }
            if (!numbers.Contains(',') && !numbers.Contains("\n"))
            {
                return int.Parse(numbers);
            }

            string[] separators = { ",", "\n", newDelimiter };
            String[] nums = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                sum += int.Parse(nums[i]);

            }
            return sum;
        }
    }
}
