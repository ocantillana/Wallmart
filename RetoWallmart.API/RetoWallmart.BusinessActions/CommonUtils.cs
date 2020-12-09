using System;
using System.Collections.Generic;
using System.Text;

namespace RetoWallmart.BusinessActions
{
    public class CommonUtils
    {
        public static bool CheckPalindrome(string input)
        {
            bool resp = false;

            input = input.Trim();

            string _reversestr = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                _reversestr += input[i].ToString();
            }

            resp = input == _reversestr;

            return resp;
        }
    }
}
