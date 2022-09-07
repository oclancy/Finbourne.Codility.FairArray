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

            long[] aRevAccumulationArr = new long[arrayLength];
            long[] bRevAccumulationArr = new long[arrayLength];

            long aAccumulation = 0;
            long bAccumulation = 0;

            var aRevAccumulation = 0;
            var bRevAccumulation = 0;
            for (int index = 0, revIndex = arrayLength - 1; index < arrayLength; ++index, --revIndex)
            {
                aAccumulation += A[index];
                aAccumulationArr[index] = aAccumulation;

                bAccumulation += B[index];
                bAccumulationArr[index] = bAccumulation;

                aRevAccumulation += A[revIndex];
                aRevAccumulationArr[revIndex] = aRevAccumulation;

                bRevAccumulation += B[revIndex];
                bRevAccumulationArr[revIndex] = bRevAccumulation;
            }

            var fairCount = 0;
            for (int index = 0; index < arrayLength-1; ++index)
            {
                if (aAccumulationArr[index] == bAccumulationArr[index] &&
                   aAccumulationArr[index] == aRevAccumulationArr[index+1] &&
                   aAccumulationArr[index] == bRevAccumulationArr[index+1])
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