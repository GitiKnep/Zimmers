using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZimmer.BLL
{
    static class Validation
    {
         public static bool IsHebrew(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < 'א' || s[i] > 'ת')
                    return false;
            }

            return true;
        }
       public static bool IsEnglish(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] < 'a' || s[i] > 'z') && (s[i] != ' '))
                    return false;
            }

            return true;
        }
        public static bool IsMail(string s)
        {
            int t = 0, c = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] < 'א' || s[i] >= 'ת') && (s[i] == ' '))
                    return false;
                if (s[i] == '@')
                {
                    c++;
                    if (c > 1)
                        return false;
                }

            }
            if (!s.Contains("@")) 
                return false;
            if (s.IndexOf('@') == 0)  
                return false;
            for (int i = s.IndexOf('@'); i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    if (t == 0)
                    {
                        t++;
                        if (s.IndexOf("@") + 1 >= i)
                            return false;
                        if (i == s.Length - 1)
                            return false;
                    }
                }
            }
            if (t == 0)
                return false;
            return true;

        }

          public static bool IsNum(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }

            return true;
        }

          public static bool IsTel(string s)
        {

            if (s == "")
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            if (s.IndexOf('0') != 0 || s.Length != 9)
                return false;
            return true;
        }
          public static bool IsPelepon(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            if (s.IndexOf('0') != 0 || s.Length != 10)
                return false;
            return true;
        }

         public static bool CheckId(string d)
        {
            while (d.Length < 9)
            {
                d = "0" + d;
            }


            int s = 0, t;
            for (int i = 0; i < d.Length; i++)
            {
                if (i % 2 == 0) 
                {
                    s += Convert.ToInt32(d[i].ToString());
                }
                if (i % 2 != 0)
                {
                    t = Convert.ToInt32(d[i].ToString()) * 2;
                    if (t < 10)
                        s += t;
                    else
                        s += t % 10 + t / 10;

                }
            }

            if (s % 10 == 0)
                return true;
            return false;

        }
        public static bool IsHebrewChar(char c)
        {
            string hebrewTav = "אבגדהוזחטיכךלמםנןסעפףצץקרשת";
            if (hebrewTav.IndexOf(c) == -1 && c != '\b' && c != ' ')
                return true;
            else
                return false;
        }
        public static bool IsNumberChar(char c)
        {
            if ((c >= '0' && c <= '9') || c == '\b')
                return false;
            return true;
        }

        public static int GetNumDay(string dayname)
        {
            string[] days = new string[] { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i] == dayname)
                    return i + 1;
            }
            return -1;
        }
        public static string GetNameDay(int numDay)
        {
            string[] days = new string[] { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
            return days[numDay];
        }

    }
}


