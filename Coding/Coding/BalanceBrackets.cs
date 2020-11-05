using System.Collections.Generic;

namespace Coding
{
    public class BalanceBrackets
    {
        private static bool IsValid(int open, char close)
        {
            if ((open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']'))
            {
                return true;
            }

            return false;
        }

        public static bool Run(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return true;
            }

            var bracStack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s[i]))
                    continue;

                if(s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    bracStack.Push(i);
                }
                else
                {
                    if (bracStack.Count == 0 || !IsValid(s[bracStack.Peek()], s[i]))
                    {
                        return false;
                    }
                    else
                    {
                        bracStack.Pop();
                    }
                }
            }

            return bracStack.Count == 0;
        }
    }
}
