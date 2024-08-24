using LeetCode.TopInterviewQuestions;

namespace LeetCode.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
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
        public void FractionAdditionTests(string expression, string expected)
        {
            var solution = new FractionAdditionSolution();
            var result = solution.FractionAddition(expression);
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}