using System;
using UnityEngine;

namespace  Code.Helper
{
    public  class Helper 
    {
        public static string getStringBeforeParenthesis(string input)
        {
            int index = input.IndexOf('(');
            if (index < 0) return input;
            return input.Substring(0, index);
        }

        public static int CaculateStar(int timelimit, int currenttime)
        {
            float parttime = (float) timelimit / 3;
            int star =  (int)Math.Ceiling(currenttime / parttime);
            return star;
        }
        
        
        public static string GetLastPart(string fullClassName)
        {
            if (string.IsNullOrEmpty(fullClassName))
            {
                return string.Empty;
            }
            int lastDotIndex = fullClassName.LastIndexOf('.');
            if (lastDotIndex == -1)
            {
                return fullClassName; 
            }

            return fullClassName.Substring(lastDotIndex + 1);
        }
       
    }

}

