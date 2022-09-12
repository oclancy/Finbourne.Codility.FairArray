namespace TestProject1
{

    using System;
    using System.Collections.Generic;
    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    class Solution
    {
        public int solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int arrayLength = A.Length;
            long[] aAccumulationArr = new long[arrayLength];
            long[] bAccumulationArr = new long[arrayLength];

            for (int index = 0; index < arrayLength; ++index)
            {
                aAccumulationArr[index] = index == 0 ? A[index] :
                                                       A[index] + aAccumulationArr[index - 1];

                bAccumulationArr[index] = index == 0 ? B[index] :
                                                       B[index] + bAccumulationArr[index - 1];

            }

            var fairCount = 0;
            var sumA = aAccumulationArr[arrayLength-1];
            var sumB = bAccumulationArr[arrayLength-1];

            for (int index = 0; index < arrayLength-1; ++index)
            {
                if (aAccumulationArr[index] == bAccumulationArr[index] &&
                   aAccumulationArr[index] == sumA - aAccumulationArr[index] &&
                   aAccumulationArr[index] == sumB - bAccumulationArr[index] )
                {
                    fairCount = fairCount + 1;
                }
            }
            return fairCount;
        }
    }



    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new Solution();

            var A = new int[] { 0, 4, -1, 0, 3 };
            var B = new int[] { 0,-2,5,0,3};
            Assert.AreEqual(2,test.solution(A,B));

           
        }
    }
}