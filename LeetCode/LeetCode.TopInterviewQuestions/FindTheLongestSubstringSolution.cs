namespace LeetCode.TopInterviewQuestions
{
    public class FindTheLongestSubstringSolution
    {
        public int FindTheLongestSubstring(string s)
        {
            int[] vowelsFrequency = new int[] { 0, 0, 0, 0, 0 };
            var maxIndex = 0;

            for (int i = 0; i < s.Length; i++) {
                switch (s[i])
                {
                    case 'a':
                        vowelsFrequency[0]++;
                        break;
                    case 'e':
                        vowelsFrequency[0]++;
                        break;
                    case 'i':
                        vowelsFrequency[0]++;
                        break;
                    case 'o':
                        vowelsFrequency[0]++;
                        break;
                    case 'u':
                        vowelsFrequency[0]++;
                        break;
                }
                if (AreEvenNumbers(vowelsFrequency))
                {
                    maxIndex = i;
                }
            }
            return maxIndex + 1;
        }

        bool AreEvenNumbers(int[] vowelsFrequency)
        {
            var response = true;
            foreach (var vowelFrequency in vowelsFrequency)
            {
                if (vowelFrequency % 2 != 0) return false;
            }
            return response;
        }
    }
}
