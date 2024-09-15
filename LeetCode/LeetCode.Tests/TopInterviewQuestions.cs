using LeetCode.TopInterviewQuestions;

namespace LeetCode.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("eleetminicoworoep", 13)]
        [TestCase("leetcodeisgreat", 5)]
        [TestCase("bcbcbc", 6)]
        public void FindTheLongestSubstringTests(string input, int expected) {
            var solution = new FindTheLongestSubstringSolution();
            var result = solution.FindTheLongestSubstring(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2, 0 }, 3)]
        [TestCase(new int[] { 3, 4, -1, 1 }, 2)]
        [TestCase(new int[] { 7, 8, 9, 11, 12 }, 1)]
        [TestCase(new int[] { 0 }, 1)]
        [TestCase(new int[] { 1, 2, 2, 1, 3, 1, 0, 4, 0 }, 5)]
        public void FirstMissingPositiveTests(int[] nums, int expected)
        {
            var solution = new FirstMissingPositiveSolution();
            var result = solution.FirstMissingPositive(nums);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("-1/2+1/2", "0/1")]
        [TestCase("-1/2+1/2+1/3", "1/3")]
        [TestCase("1/3-1/2", "-1/6")]
        [TestCase("7/2+2/3-3/4", "41/12")]
        public void FractionAdditionTests(string expression, string expected)
        {
            var solution = new FractionAdditionSolution();
            var result = solution.FractionAddition(expression);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 4, 2, 1, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { -1, 5, 3, 4, 0 }, new int[] { -1, 0, 3, 4, 5 })]
        public void InsertionSortListTests(int[] unordered, int[] expected)
        {
            var solution = new InsertionSortListSolution();
            var unorderedNodes = solution.ConvertArrayToListNode(unordered);
            var result = solution.InsertionSortList(unorderedNodes);
            var resultArray = solution.ConvertListNodeToArray(result, unordered.Length);
            Assert.That(resultArray, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }, true)]
        [TestCase(new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 0 }, false)]
        public void ValidSquareTests(int[] p1, int[] p2, int[] p3, int[] p4, bool expected)
        {
            var solution = new ValidSquareSolution();
            var result = solution.ValidSquare(p1, p2, p3, p4);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }, true)]
        [TestCase(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 12 }, false)]
        [TestCase(new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 }, true)]
        [TestCase(new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 0 }, false)]
        public void ValidSquare2Tests(int[] p1, int[] p2, int[] p3, int[] p4, bool expected)
        {
            var solution = new ValidSquare2Solution();
            var result = solution.ValidSquare(p1, p2, p3, p4);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(3, new int[] { 1, 3, 3, 1 })]
        [TestCase(0, new int[] { 1 })]
        [TestCase(1, new int[] { 1, 1 })]
        public void PascalsTriangle2Tests(int rowIndex, IList<int> expected)
        {
            var solution = new PascalsTriangle2Solution();
            var result = solution.GetRow(rowIndex);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(0, new int[] { 1 })]
        [TestCase(1, new int[] { 1, 1 })]
        [TestCase(3, new int[] { 1, 3, 3, 1 })]
        public void PascalsTriangle3Tests(int rowIndex, IList<int> expected)
        {
            var solution = new PascalsTriangle3Solution();
            var result = solution.GetRow_TotalArray(rowIndex);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(0, new int[] { 1 })]
        [TestCase(1, new int[] { 1, 1 })]
        [TestCase(3, new int[] { 1, 3, 3, 1 })]
        public void PascalsTriangle3Tests_Half(int rowIndex, IList<int> expected)
        {
            var solution = new PascalsTriangle3Solution();
            var result = solution.GetRow_HalfArray(rowIndex);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}