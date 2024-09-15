namespace LeetCode.TopInterviewQuestions
{
    public class PascalsTriangle2Solution
    {
        // https://leetcode.com/problems/pascals-triangle-ii
        // TODO: Make a faster using just one array and work mathematically with the indexes

        private Dictionary<int, int> cache = new Dictionary<int, int>();

        public int GetKey(int rowIndex, int index) => rowIndex * 100 + index;

        public int GetNumber(int rowIndex, int index)
        {
            if(cache.TryGetValue(GetKey(rowIndex, index), out var number)) return number;
            if (rowIndex == 0) return 1;
            if (index == 0 || index == rowIndex) return 1;
            var numberValue = GetNumber(rowIndex - 1, index - 1) + GetNumber(rowIndex - 1, index);
            cache.Add(GetKey(rowIndex, index), numberValue);
            return numberValue;
        }

        public IList<int> GetRow(int rowIndex)
        {
            var result = new List<int>();
            for (int i = 0; i <= rowIndex; i++)
            {
                var numberValue = GetNumber(rowIndex, i);
                result.Add(numberValue);
            }
            return result.ToArray();
        }
    }
}
