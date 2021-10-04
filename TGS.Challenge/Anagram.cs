using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TGS.Challenge
{
  /*
        Devise a function that checks if 1 word is an anagram of another, if the words are anagrams of
        one another return true, else return false

        "Anagram": An anagram is a type of word play, the result of rearranging the letters of a word or
        phrase to produce a new word or phrase, using all the original letters exactly once; for example
        orchestra can be rearranged into carthorse.

        areAnagrams("horse", "shore") should return true
        areAnagrams("horse", "short") should return false

        NOTE: Punctuation, including spaces should be ignored, e.g.

        horse!! shore = true
        horse  !! shore = true
          horse? heroes = true

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class Anagram
    {
        public bool AreAnagrams(string word1, string word2)
        {
            bool result = false;
            if (!String.IsNullOrEmpty(word1) && !String.IsNullOrEmpty(word2))
            {
                word1 = RemoveSpecialCharacters(word1);
                word2 = RemoveSpecialCharacters(word2);
                if (word1.Length == word2.Length)
                {
                    if (word1.ToLower() != word2.ToLower())
                    {
                        var word1Dictionary = CharCount(word1);
                        var word2Dictionary = CharCount(word2);

                        result = AreEqual(word1Dictionary, word2Dictionary);
                    }
                }
            }
            else 
            {
                throw new ArgumentException("Both Words must be assigned and non-empty", "word1 and word2");
            }
            return result;
        }

        public string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled); //_.
        }

        public string RemoveSpecialCharacters2(string word)
        {
            var str = Regex.Replace(word, @"\s", "");
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') ) 
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private bool AreEqual(Dictionary<char, int> word1, Dictionary<char, int> word2)
        {
            bool retval = false;

            if (word1 != null && word2 != null && word1 != word2)
            {
                if (word1.Count == word2.Count)
                {
                    if (!word1.Keys.Except(word2.Keys).Any() &&
                        !word2.Keys.Except(word1.Keys).Any())
                    {
                        retval = true;

                        foreach (var kvp in word1)
                        {
                            if (kvp.Value != word2[kvp.Key])
                            {
                                retval = false;
                                break;
                            }
                        }
                    }
                }
            }

            return retval;
        }
        private Dictionary<char, int> CharCount(string word)
        {
            Dictionary<char, int> charDict = new Dictionary<char, int>();

            foreach (char c in word)
            {
                
                char lowerCaseChar = char.ToLower(c);

                if (charDict.ContainsKey(lowerCaseChar))
                {
                    charDict[lowerCaseChar]++;
                }
                else
                {
                    charDict[lowerCaseChar] = 1;
                }
            }

            return charDict;
        }
    }
}
