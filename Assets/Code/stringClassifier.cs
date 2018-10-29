using System;
using UnityEngine.UI;

namespace backupGame
{
    class StringClassifier //checks the user's input to see if it is an ip address, and in the correct range of values. (0-255).
    {
        public static bool getIP(string IP)
        {
            string[] numbers = IP.Split('.');

            bool isA = false;
            bool isB = false;
            bool isC = false;
            bool isD = false;
            bool inRange = false;

            if (numbers.Length == 4)
            {
                isA = Int32.TryParse(numbers[0], out int a);
                isB = Int32.TryParse(numbers[1], out int b);
                isC = Int32.TryParse(numbers[2], out int c);
                isD = Int32.TryParse(numbers[3], out int d);

                inRange = CheckIP(a, b, c, d);
            }

            if ((isA && isB && isC && isD == true) && (inRange)) //if all are true, it's an ip address
            {
                return true;
            }

            else return false;
            
        }

        public static bool CheckIP(int a, int b, int c, int d) //simulates fact that real ip's must be between 0-255
        {
            bool error = false;

            if (0 > a | a > 255) error = true;
            if (0 > b | b > 255) error = true;
            if (0 > c | c > 255) error = true;
            if (0 > d | d > 255) error = true;


            if (!error) return true;
            else return false;
        }

    }
}
