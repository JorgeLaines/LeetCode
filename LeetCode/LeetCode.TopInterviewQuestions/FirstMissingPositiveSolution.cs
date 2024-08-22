using LeetCode.Common;

namespace LeetCode.TopInterviewQuestions
{
    public class FirstMissingPositiveSolution : BaseSolution, IBaseSolution
    {
        public FirstMissingPositiveSolution() : base("https://leetcode.com/problems/first-missing-positive")
        {
                
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public int FirstMissingPositive(int[] nums)
        {
            Array.Sort(nums);
            int last = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 1)
                {
                    if (last == 0 && nums[i] > 1) return 1;
                    if (nums[i] != 1 && last != nums[i] && i > 0 && last + 1 != nums[i]) return last + 1;
                    last = nums[i];
                }
            }
            return last + 1;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultExample(int testCase = 0)
        {
            throw new NotImplementedException();
        }
    }
}
