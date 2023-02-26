using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using Wintellect.PowerCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerCollections.Tests
{
    [TestClass]
    public class StackTests
    {
        //Testing main methods
        [TestMethod]
        public void PushMethodAddElementOnTheTopOfStack()
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(4);
            Assert.AreEqual(4, stack.Top());
        }

        [TestMethod]
        public void PopMethodExtractsElementFromTheTopOfStackAndReturnThisValue()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(101);
            stack.Push(23);
            stack.Push(3);
            Assert.AreEqual(3, stack.Pop());
        }

        [TestMethod]
        public void TopMethodReturnTheValueOfTheElementAtTheTopOfTheStackButNotExtract()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("101");
            stack.Push("test");
            Assert.AreEqual("test", stack.Pop());
            Assert.AreNotEqual("test", stack.Top());
        }

        //Testing constructors
        [TestMethod]
        public void DefaultCapacityEquals10AndStackCapacitySetViaOverload()
        {
            int testCapacity = 10;
            Stack<int> stack1 = new Stack<int>();
            Stack<string> stack2 = new Stack<string>(testCapacity);
            Assert.AreEqual(stack1.Capacity, stack2.Capacity);
        }

        //Testing Exception
        [TestMethod]
        [ExpectedException(typeof(Exception), "Stack is full")]
        public void WhenAStackOverflowThrowAnExceptionStackIsFull()
        {
            Stack<int> stack = new Stack<int>(3);
            for (int i = 0; i <= 5; i++)
            {
                stack.Push(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Stack is empty")]
        public void WhenPopAllDataFromTheStackThrowAnExceptionStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Push(1);
            stack.Push(4);
            stack.Pop();
            stack.Pop();
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Stack is empty")]
        public void WhenPopEmptyTheStackThrowAnExceptionStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The top of the stack is empty")]
        public void WhenTopEmptyStackThrowAnExceptionTheTopOfTheStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Top();
        }

        //Testing properties
        [TestMethod]
        public void WhenFillingTheStackWithItsCapacityItsCountAndCapacityWillBeEqual()
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < stack.Capacity; i++)
            {
                stack.Push(i);
            }
            Assert.AreEqual(stack.Count, stack.Capacity);
        }
        
        //Testing IEnumerator
        [TestMethod]
        public void GetEnumeratorReturnReverseArray()
        {
            Stack<int> stack = new Stack<int>(5);
            int[] items = new int[] { 1, 2, 3, 4, 5 };
            foreach (int i in items)
            {
                stack.Push(i);
            }
            var reverse = from A in stack select A;
            CollectionAssert.AreEqual(reverse.ToArray(), items.Reverse().ToArray());
        }
    }
}