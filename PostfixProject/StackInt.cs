﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PostfixProject
{
    class StackInt
    {
        private int[] stackArray;
        int top;

        public StackInt()
        {
            stackArray = new int[10];
            top = -1;
        }
        public StackInt(int maxSize)
        {
            stackArray = new int[maxSize];
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
        public void push(int x)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is overflow ");
                return;
            }
            top = top + 1;
            stackArray[top] = x;
        }
        public int Pop()
        {
            int x;
            if (IsEmpty())
            {
                Console.WriteLine("Stack underflow ");
                throw new System.InvalidOperationException();
            }
            x = stackArray[top];
            top = top - 1;
            return x;
        }
        public int Peek()
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