namespace LeetCode.TopInterviewQuestions
{
    public class ValidSquareSolution
    {
        double tolerance = 0.001;

        public double Distance(int[] p1, int[] p2)
        {
            return Math.Sqrt(Math.Pow(p2[0] - p1[0], 2) + Math.Pow(p2[1] - p1[1], 2));
        }

        public bool AreEqual(double a, double b)
        {
            var result = Math.Abs(a - b) < tolerance;
            return result;
        }

        public bool ValidSquare (int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var result = true;

            var distanceToP2 = Distance(p1, p2);
            var distanceToP3 = Distance(p1, p3);
            var distanceToP4 = Distance(p1, p4);

            var p2p3AreEqual = AreEqual(distanceToP2, distanceToP3) 
                                && AreEqual(distanceToP4 / distanceToP2, Math.Sqrt(2))
                                && AreEqual(Distance(p2, p3) / distanceToP2, Math.Sqrt(2));
            var p2p4AreEqual = AreEqual(distanceToP2, distanceToP4) 
                                && AreEqual(distanceToP3 / distanceToP2, Math.Sqrt(2))
                                && AreEqual(Distance(p2, p4) / distanceToP2, Math.Sqrt(2));
            var p3p4AreEqual = AreEqual(distanceToP3, distanceToP4) 
                                && AreEqual(distanceToP2 / distanceToP3, Math.Sqrt(2))
                                && AreEqual(Distance(p3, p4) / distanceToP3, Math.Sqrt(2));

            if (p2p3AreEqual || p2p4AreEqual || p3p4AreEqual)
            {
                double side;
                if(p2p3AreEqual)
                {
                    side = Distance(p4, p2);
                    if (!AreEqual(side, Distance(p4, p3)) || !AreEqual(side, distanceToP2)) 
                    {
                        return false;
                    }
                }
                else if(p2p4AreEqual)
                {
                    side = Distance(p3, p2);
                    if (!AreEqual(side, Distance(p3, p4)) || !AreEqual(side, distanceToP4))
                    {
                        return false;
                    }
                }
                else // p3p4AreEqual
                {
                    side = Distance(p2, p3);
                    if (!AreEqual(side, Distance(p2, p4)) || !AreEqual(side, distanceToP3))
                    {
                        return false;
                    }
                }
            }
            else 
            {
                return false;
            }
            return result;
        }
    }
}
