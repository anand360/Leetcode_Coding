using System;
using System.Collections.Generic;
using System.Text;

namespace Coding
{
    public class RotationalCipher
    {
        public static string Run(string input, int rotationFactor)
        {
            if (string.IsNullOrWhiteSpace(input) || rotationFactor == 0)
            {
                return input;
            }

            var inputArr = input.ToCharArray();
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (char.IsLetterOrDigit(inputArr[i]))
                {
                    if (char.IsLetter(inputArr[i]))
                    {
                        int newRot = rotationFactor % 26;
                        if (char.IsUpper(inputArr[i]))
                        {
                            int curC = inputArr[i] + newRot;
                            if (curC > (int)'Z')
                            {
                                var a = curC - (int)'Z';
                                inputArr[i] = (char)('A' + a - 1);
                            }
                            else
                            {
                                inputArr[i] = (char)(curC);
                            }
                        }
                        else
                        {
                            int curC = inputArr[i] + newRot;
                            if (curC > (int)'z')
                            {
                                var a = curC - (int)'z';
                                inputArr[i] = (char)('a' + a - 1);
                            }
                            else
                            {
                                inputArr[i] = (char)(curC);
                            }
                        }
                    }
                    else
                    {
                        int newRot = rotationFactor % 10;
                        int curC = inputArr[i] + newRot;
                        if (curC > (int)'9')
                        {
                            var a = curC - (int)'9';
                            inputArr[i] = (char)('0' + a - 1);
                        }
                        else
                        {
                            inputArr[i] = (char)(curC);
                        }
                    }
                }
            }

            Console.WriteLine();
            return new string(inputArr);
        }
    }
}
