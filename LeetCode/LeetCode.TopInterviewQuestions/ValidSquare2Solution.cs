namespace LeetCode.TopInterviewQuestions
{
    public class ValidSquare2Solution
    {
        public double Distance(int[] p1, int[] p2)
        {
            return Math.Sqrt(Math.Pow(p2[0] - p1[0], 2) + Math.Pow(p2[1] - p1[1], 2));
        }

        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var distances = new double[6];

            distances[0] = Distance(p1, p2);
            distances[1] = Distance(p1, p3);
            distances[2] = Distance(p1, p4);
            distances[3] = Distance(p2, p3);
            distances[4] = Distance(p2, p4);
            distances[5] = Distance(p3, p4);

            Array.Sort(distances);

            return distances[4] == distances[5] &&
                (distances[0] + distances[1] + distances[2] + distances[3]) / 4 - distances[0] < 0.0001 &&
                distances[4] / distances[0] - Math.Sqrt(2) < 0.0001;
        }
    }   
}
