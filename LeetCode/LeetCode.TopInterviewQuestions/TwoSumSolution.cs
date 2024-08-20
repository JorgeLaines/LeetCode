using LeetCode.Common;

namespace LeetCode.TopInterviewQuestions
{
    public class TwoSumSolution : BaseSolution, IBaseSolution
    {
        public TwoSumSolution() : base("https://leetcode.com/problems/two-sum/")
        {
                
        }

        int[] nums; 
        int target;

        public void Execute()
        {
            var result = TwoSum(nums, target);
            if (result.Count() != 0)
            {
                Console.WriteLine($"[{result[0]}, {result[1]}]");
            }
            else
            { 
                Console.WriteLine("[]");
            }
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var minCandidateValue = 0;
            var indexCandidates = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                foreach (var indexCandidate in indexCandidates)
                {
                    if (nums[indexCandidate] + nums[i] == target)
                    {
                        return new int[] { indexCandidate, i };
                    }
                }
                if (nums[i] <= target - minCandidateValue)
                {
                    minCandidateValue = nums[i] < minCandidateValue ? nums[i] : minCandidateValue;
                    indexCandidates.Add(i);
                }
            }
            return new int[] { };
        }

        public int[] TwoSumFirstApproach(int[] nums, int target)
        {
            var indexCandidates = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= target)
                {
                    if(indexCandidates.Count == 0)
                    {
                        indexCandidates.Add(i);
                    }
                    else
                    {
                        foreach (var indexCandidate in indexCandidates)
                        {
                            if (nums[indexCandidate] + nums[i] == target)
                            {
                                return new int[] { indexCandidate, i };
                            }
                        }
                        indexCandidates.Add(i);
                    }
                }
            }
            return new int[] {  };
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultExample(int testCase = 0)
        {
            switch (testCase)
            {

                case 0:
                    nums = new int[] { 0, 4, 3, 0 };
                    target = 0;
                    break;
                case 1:
                    nums = new int[] { -3, 4, 3, 90 };
                    target = 0;
                    break;
                case 2:
                    nums = new int[] { -1, -2, -3, -4, -5 };
                    target = -8;
                    break;
                default:
                    break;
            }
        }
    }
}
