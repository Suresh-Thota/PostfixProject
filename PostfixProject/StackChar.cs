using System;
using System.Collections.Generic;
using System.Text;

namespace PostfixProject
{
    class StackChar
    {
        private char[] stackArray;
        int top;

        public StackChar()
        {
            stackArray = new char[10];
            top = -1;
        }
        public StackChar(int maxSize)
        {
            stackArray = new char[maxSize];
            top = -1;
        }
        public int Size()
        {
            return top + 1;
        }
        public bool IsEmpty()
        {
            return (top == -1);
        }
        public bool IsFull()
        {
            return (top == stackArray.Length - 1);
        }
        public void push(char x)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is overflow ");
                return;
            }
            top = top + 1;
            stackArray[top] = x;
        }
        public char Pop()
        {
            char x;
            if (IsEmpty())
            {
                Console.WriteLine("Stack underflow ");
                throw new System.InvalidOperationException();
            }
            x = stackArray[top];
            top = top - 1;
            return x;
        }
        public char Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack underflow ");
                throw new System.InvalidOperationException();
            }
            return stackArray[top];
        }
    }
}
