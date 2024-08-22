using LeetCode.Common;
using System.Text;

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
            var newNum = FindComplement(5);
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

        public int FindComplement(int num)
        {
            StringBuilder sb = new StringBuilder();
            var result = Convert.ToString(num, 2);
            for(int i = 0; i < result.Length; i++)
            {
                if (result[i] == '0') {
                    sb.Append('1');
                }
                else
                {
                    sb.Append('0');
                }
            }
            return Convert.ToInt32(sb.ToString(), 2);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            int leftLimit, rightLimit;
            int arrayLength = nums.Length;
            var sortedNums = (int[]) nums.Clone();
            Array.Sort(sortedNums);
            if (target >= 0)
            {
                leftLimit = target - sortedNums[arrayLength - 1];
                rightLimit = sortedNums[arrayLength - 1];
            }
            else 
            {
                leftLimit = sortedNums[0];
                rightLimit = target - sortedNums[0];
            }
            var indexCandidates = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= leftLimit && nums[i] <= rightLimit)
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
            return new int[] { };
        }

        public int[] TwoSumSeconApproach(int[] nums, int target)
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
                case 3:
                    nums = new int[] { 2, 7, 11, 15 };
                    target = 9;
                    break;
                case 4:
                    nums = new int[] { 3, 2, 4 };
                    target = 6;
                    break;
                case 5:
                    nums = new int[] { 0, 3, -3, 4, -1 };
                    target = -1;
                    break;
                default:
                    break;
            }
        }
    }
}
