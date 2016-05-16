using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {      
        public int Add(string input)
        {
            
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiter = GetDelimiter(ref input);

            var numbers = input.Split('\n', delimiter);            

            NegativeNumberCheck(numbers);

            return numbers.Sum(Convert.ToInt32);
        }

        private static char GetDelimiter(ref string input)
        {
            var delimiter = ',';
            if (input.StartsWith("//"))
            {
                delimiter = input[2];
                input = input.Substring(input.IndexOf('\n') + 1);
            }
            return delimiter;
        }

        private void NegativeNumberCheck(string[] numbers)
        {
            List<string> negativeNumbers = new List<string>();

            foreach (string number in numbers)
            {
                if (Convert.ToInt32(number) < 0)
                {
                    negativeNumbers.Add(number);
                }
            }

            if (negativeNumbers.Count > 0)
            {                
                throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            }            
        }
    }
}