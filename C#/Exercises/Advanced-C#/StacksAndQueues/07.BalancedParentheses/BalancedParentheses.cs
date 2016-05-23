using System;
using System.Collections.Generic;

namespace _07.BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            string parantheses = Console.ReadLine();

            Stack<char> openParamtheses = new Stack<char>();

            bool areBalanced = true;

            for (int i = 0; i < parantheses.Length; i++)
            {
                if (parantheses[i] == '{' || parantheses[i] == '[' || parantheses[i] == '(')
                {
                    openParamtheses.Push(parantheses[i]);
                }
                else
                {
                    if (openParamtheses.Count <= 0)
                    {
                        areBalanced = false;
                        break;
                    }

                    if (openParamtheses.Peek() == '{' && parantheses[i] == '}')
                    {
                        openParamtheses.Pop();
                    }
                    else if (openParamtheses.Peek() == '[' && parantheses[i] == ']')
                    {
                        openParamtheses.Pop();
                    }
                    else if (openParamtheses.Peek() == '(' && parantheses[i] == ')')
                    {
                        openParamtheses.Pop();
                    }
                    else
                    {
                        areBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(areBalanced ? "YES" : "NO");
        }
    }
}