using System;

namespace LeetCode.TopInterviewQuestions
{
    public class PascalsTriangle3Solution
    {
        // https://leetcode.com/problems/pascals-triangle-ii
        //rowIndex  0 | 1    | 2       | 3          | 4
        //half      1 | 1    | 1, 2    | 1, 3       | 1, 4, 6
        //optimize    |      | 2       | 3          | 4, 6
        //result    1 | 1, 1 | 1, 2, 1 | 1, 3, 3, 1 | 1, 4, 6, 4, 1
        //start     0 | 1    | 2       | 4          | 6
        //end       0 | 1    | 3       | 5          | 8
        //lenght    1 | 1    | 2       | 2          | 3

        public IList<int> GetRow_TotalArray(int rowIndex)
        {
            int totalArraySize = (rowIndex + 1) * (rowIndex + 2) / 2;
            int[] numbers = new int[totalArraySize];
            int[] result = new int[rowIndex + 1];
            int number = 0, arrayIndex = 0, previousArrayIndex = 0;
            for (int ri = 0; ri <= rowIndex; ri++)
            {
                for (int ni = 0; ni <= ri; ni++)
                {
                    if (rowIndex == 0)
                    {
                        number = 1;
                    }
                    else if (ni == 0 || ni == ri)
                    {
                        number = 1;
                    }
                    else 
                    {
                        number = numbers[previousArrayIndex + (ni - 1)] + numbers[previousArrayIndex + (ni)];                    
                    }
                    numbers[arrayIndex + ni] = number;
                    if (ri == rowIndex)
                    {
                        result[ni] = number;
                    }
                }
                previousArrayIndex = arrayIndex;
                arrayIndex = arrayIndex + (ri + 1);
            }
            return result;
        }

        public IList<int> GetRow_HalfArray(int rowIndex)
        {
            // =(REDONDEAR.MENOS(B2/2,0)+1)*(B2+1-REDONDEAR.MENOS(B2/2,0))
            int totalArraySize = (rowIndex / 2 + 1) * ((rowIndex + 1) - (rowIndex / 2));
            int[] numbers = new int[totalArraySize];
            int[] result = new int[rowIndex + 1];
            int number = 0, arrayIndex = 0, previousArrayIndex = 0;
            for (int ri = 0; ri <= rowIndex; ri++)
            {
                for (int ni = 0; ni <= ((ri / 2) + 1); ni++)
                {
                    if (rowIndex == 0)
                    {
                        number = 1;
                    }
                    else if (ni == 0 || ni == ri)
                    {
                        number = 1;
                    }
                    else
                    {
                        number = numbers[previousArrayIndex + (ni - 1)] + numbers[previousArrayIndex + (ni)];
                    }
                    numbers[arrayIndex + ni] = number;
                    if (ri == rowIndex)
                    {
                        result[ni] = number;
                    }
                }
                previousArrayIndex = arrayIndex;
                arrayIndex = arrayIndex + (ri + 1);
            }
            return result;
        }

        public IList<int> GetRow_OptimizedArray(int rowIndex)
        {
            int arraySize = (rowIndex / 2) * 2;
            int[] numbers = new int[arraySize];
            for (int ri = 0; ri <= rowIndex; ri++)
            {


            }
            return null;
        }
    }
}
