using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConceptUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testStrings = new string[]
                {
                    "001",
                    "099",
                    "999",
                    "A07",
                    "AB1",
                    "AZ9",
                    "ZZ9"
                };

            for (var i=0; i<testStrings.Length; i++)
            {
                //incrementString(ref testStrings[i]);
                inc2(ref testStrings[i]);
            }

        }

        private string[] digits = new string[]
                { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        private string[] chars = new string[] 
				{ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
				  "K", "L", "M", "N", "N", "O", "P", "Q", "R", "S",
				  "T", "U", "V", "W", "X", "Y", "Z"};

        private void inc2(ref string str)
        {
            var newstr = new string[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                newstr[i] = str[i].ToString();
            }
            for (var i=0; i<newstr.Length; i++)
            {
                Console.WriteLine("Value is " + ( (10 * i)));
            }
        }

        private void incrementString(ref string str)
        {
            var newstr = new string[str.Length];
            for (var i=0; i<str.Length; i++)
            {
                newstr[i] = str[i].ToString();
            }
            Console.WriteLine("Incrementing \"" + str + "\"");
            bool incremented = false;
            for (var i=newstr.Length-1; i>=0; i--)
            {
                if (!incremented)
                {
                    Console.WriteLine("  str[" + i + "] = " + newstr[i]);
                    var di = Array.IndexOf(digits, newstr[i]);
                    var ci = Array.IndexOf(chars, newstr[i]);
                    Console.WriteLine("    di=" + di.ToString() + ", ci=" + ci.ToString());
                    if (di > -1)
                    {
                        Console.WriteLine("  This is a digit");
                        if (di < 9)
                        {
                            newstr[i] = digits[di + 1];
                            incremented = true;
                        }
                        else if (di==9)
                        {
                            newstr[i] = ((i == newstr.Length - 1 && newstr[i-1]!=null && Array.IndexOf(digits, newstr[i-1])==-1) ? "1" : "0");
                            IncrementLeft(i, ref newstr);
                            incremented = true;
                        }
                    }
                    else if (ci > -1)
                    {
                        Console.WriteLine("    This is a character");
                        if (ci<25)
                        {
                            newstr[i] = chars[ci + 1];
                            incremented = true;
                        }
                        else if (ci==25)
                        {
                            if (i==newstr.Length-1)
                            {
                                Console.WriteLine("Unable to increment past " + string.Join("", newstr));
                            }
                            else if (newstr[i-1]!=null && Array.IndexOf(chars, newstr[i-1])==-1)
                            {
                                newstr[i] = "A";
                                IncrementLeft(i, ref newstr);
                                incremented = true;
                            }
                        }
                    }
                }
            }

            var ret = "";
            for (var i=0; i<newstr.Length; i++)
            {
                ret += newstr[i];
            }
            Console.WriteLine("Incremented Value is [" + ret + "]");
            Console.WriteLine("=====\r\n");
        }

        private void IncrementLeft(int i, ref string[] newstr)
        {
            var j = i - 1;
            if (j >= 0)
            {
                Console.WriteLine("  Incrementing LEFT of str[" + i + "] = " + newstr[i]);
                var di = Array.IndexOf(digits, newstr[j]);
                var ci = Array.IndexOf(chars, newstr[j]);
                Console.WriteLine("    di=" + di.ToString() + ", ci=" + ci.ToString());
                if (di > -1)
                {
                    Console.Write("  newstr[" + j + "]=" + newstr[j] + " ");
                    if (di < 9)
                    {
                        Console.WriteLine(" is updated to digits[di+1] " + digits[di + 1]);
                        newstr[j] = digits[di + 1];
                    }
                    else if (di == 9)
                    {
                        newstr[j] = ((j == newstr.Length - 1 && newstr[j - 1] != null && Array.IndexOf(digits, newstr[j - 1]) == -1) ? "1" : "0");
                        //Console.WriteLine(" is updated to newstr[j] " + newstr[j] + " and newstr[j-1] " + (newstr[j-1]!=null ? newstr[j - 1] : "ERROR") + " is updated");
                        IncrementLeft(j, ref newstr);
                    }
                }
                else if (ci > -1)
                {
                    Console.Write("  newstr[" + j + "]=" + newstr[j] + " ");
                    if (ci < 25)
                    {
                        Console.WriteLine(" is updated to chars[ci+1] " + chars[di + 1]);
                        newstr[j] = chars[ci + 1];
                    }
                    else if (ci == 25)
                    {
                        if (i == newstr.Length - 1)
                        {
                            Console.WriteLine("Unable to increment past " + string.Join("", newstr));
                        }
                        else if (j>0 && Array.IndexOf(chars, newstr[j - 1]) == -1)
                        {
                            newstr[j] = "A";
                            //Console.WriteLine(" is updated to newstr[j] " + newstr[j] + " and newstr[j-1] " + (newstr[j - 1] != null ? newstr[j - 1] : "ERROR") + " is updated");
                            IncrementLeft(j, ref newstr);
                        }
                    }
                }
            }
        }
    }
}
