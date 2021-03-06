﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmNote;

namespace UnitTest
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void TestArrayStack()
        {
            var stack = new ArrayStack<int>();
            for (var i = 0; i < 5; i++)
            {
                stack.Push(i);
                Console.WriteLine(stack);
            }

            stack.Pop();
            Console.WriteLine(stack);
        }

        [TestMethod]
        public void TestLinkedListStack()
        {
            var stack = new LinkedListStack<int>();
            for (var i = 0; i < 5; i++)
            {
                stack.Push(i);
                Console.WriteLine(stack);
            }

            stack.Pop();
            Console.WriteLine(stack);
        }
    }
}
