using System;

namespace TGS.Challenge
{
    /*
        Devise a function that takes a string & returns the number of 
        vowels (aeiou) in that string.

        "Hi there!" = 3
        "What do you mean?"  = 6

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class VowelCount
    {
        public int Count(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("must be assigned and non-empty", "value");
            }
                
            int vowelCount = 0;
            int len = value.Length;

            for (int i = 0; i < len; i++)
            {

                if (value[i] == 'a' || value[i] == 'e' || value[i] == 'i' || value[i] == 'o' || value[i] == 'u' || value[i] == 'A' || value[i] == 'E' || value[i] == 'I' || value[i] == 'O' || value[i] == 'U')
                {
                    vowelCount++;
                }
            }
            return vowelCount;
        }
    }
}
