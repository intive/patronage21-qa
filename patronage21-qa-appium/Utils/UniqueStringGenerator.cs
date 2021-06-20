using System;
using System.Collections.Generic;

namespace patronage21_qa_appium.Utils
{
    internal class UniqueStringGenerator
    {
        public static string GenerateLettersBasedOnTimestamp()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            List<string> letters = new() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            for (int i = 0; i < letters.Count; i++)
            {
                timestamp = timestamp.Replace(i.ToString(), letters[i]);
            }
            return timestamp;
        }

        public static string GenerateNumbersBasedOnTimestamp()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            return timestamp;
        }

        public static string GenerateShortLettersBasedOnTimestamp()
        {
            string timestamp = DateTime.Now.ToString("MMddHHmmss");
            List<string> letters = new() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            for (int i = 0; i < letters.Count; i++)
            {
                timestamp = timestamp.Replace(i.ToString(), letters[i]);
            }
            return timestamp;
        }

        public static string GenerateShortNumbersBasedOnTimestamp()
        {
            string timestamp = DateTime.Now.ToString("MMddHHmmss");
            return timestamp;
        }
    }
}