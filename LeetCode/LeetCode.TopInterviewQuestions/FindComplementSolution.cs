using LeetCode.Common;
using System.Text;

namespace LeetCode.TopInterviewQuestions
{
    public class FindComplementSolution : BaseSolution, IBaseSolution
    {
        public FindComplementSolution() : base("https://leetcode.com/problems/number-complement")
        {
                
        }

        int num;

        public void Execute()
        {
            var result = FindComplement(num);
            Console.WriteLine($"Input: {num}");
            Console.WriteLine($"Output: {result}");
        }

        public int FindComplement(int num)
        {
            StringBuilder sb = new StringBuilder();
            var result = Convert.ToString(num, 2);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '0')
                {
                    sb.Append('1');
                }
                else
                {
                    sb.Append('0');
                }
            }
            return Convert.ToInt32(sb.ToString(), 2);
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultExample(int testCase = 0)
        {
            int[] testCases = { 5 };
            if (testCase < 0 && testCase > testCases.Length) 
            {
                throw new ArgumentOutOfRangeException();
            }
            num = testCases[testCase];
        }
    }
}
