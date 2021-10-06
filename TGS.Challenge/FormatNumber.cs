using System;
using System.Text;

namespace TGS.Challenge
{
    /*
        Devise a function that takes an input 'n' (integer) and returns a string that is the
        decimal representation of that number grouped by commas after every 3 digits. 
        
        NOTES: You cannot use any built-in formatting functions to complete this task.

        Assume: 0 <= n < 1000000000

        1 -> "1"
        10 -> "10"
        100 -> "100"
        1000 -> "1,000"
        10000 -> "10,000"
        100000 -> "100,000"
        1000000 -> "1,000,000"
        35235235 -> "35,235,235"

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class FormatNumber
    {
        public string Format(int value)
        {
            if (value > 1000000000 || value < 0)
                throw new ArgumentOutOfRangeException("range should be : 0 <= value < 1000000000");
            StringBuilder sb = new StringBuilder();
            string num = value.ToString();
            int count = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                count++;
                sb.Append(num[i]);

                if (count == 3)
                {
                    sb.Append(',');
                    count = 0;
                }
            }

            var results = Reverse(sb.ToString());

            if (results.Length % 4 == 0)
            {
                results = results.Substring(1);
            }

            return results;
        }

        public string Reverse(string str)
        {
            if (str == null) return null;

            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }
    }
}
