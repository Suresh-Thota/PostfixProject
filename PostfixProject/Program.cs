using System;

namespace PostfixProject
{
    class Program
    {
        static void Main(string[] args)
        {
            String infix;
            Console.Write("Enter an expression :");
            infix = Console.ReadLine();
            String postFix = infixToPostFix(infix);
            Console.WriteLine("postfix expression is : " + postFix);
            Console.WriteLine("Evaluation of post fix expression is :" + EvaluatePostFixExpression(postFix));
        }
        public static String infixToPostFix(String infix)
        {
            StackChar st = new StackChar();
            char next, symbol;
            String postFix = "";
            for (int i = 0; i < infix.Length; i++)
            {
                symbol = infix[i];
                if (symbol == ' ' || symbol == '\t')
                {
                    continue;
                }
                switch (symbol)
                {
                    case '(':
                        st.push(symbol);
                        break;
                    case ')':
                        while ((next = st.Pop()) != '(')
                            postFix = postFix + next;
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '^':
                    case '/':
                    case '%':
                        while (!st.IsEmpty() && Precedence(st.Peek()) >= Precedence(symbol))
                            postFix = postFix + st.Pop();
                        st.push(symbol);
                        break;
                    default:
                        postFix = postFix + infix[i];
                        break;
                }
            }
            while (!st.IsEmpty())
            {
                postFix = postFix + st.Pop();
            }

            return postFix; ;
        }
        public static int Precedence(char symbol)
        {
            switch (symbol)
            {
                case '(':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                case '%':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }
        }
        public static int EvaluatePostFixExpression(String postFix)
        {
            int x, y;
            StackInt st = new StackInt();

            for (int i = 0; i < postFix.Length; i++)
            {
                if (char.IsDigit(postFix[i]))
                    st.push(Convert.ToInt32(char.GetNumericValue(postFix[i])));
                else
                {
                    x = st.Pop();
                    y = st.Pop();
                    switch (postFix[i])
                    {
                        case '+':
                            st.push(y + x);
                            break;
                        case '-':
                            st.push(y - x);
                            break;
                        case '*':
                            st.push(y * x);
                            break;
                        case '/':
                            st.push(y / x);
                            break;
                        case '%':
                            st.push(y % x);
                            break;
                        case '^':
                            st.push(power(y, x));
                            break;

                    }
                }
            }
            return st.Pop();
        }
        public static int power(int b, int a)
        {
            int x = 1;
            for (int i = 1; i <= a; i++)
                x = x * b;
            return x;
        }
        
       
    }
}
