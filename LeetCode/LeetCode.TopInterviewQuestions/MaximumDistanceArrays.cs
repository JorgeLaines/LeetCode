using LeetCode.Common;
using System.Numerics;

namespace LeetCode.TopInterviewQuestions
{
    public class MaximumDistanceArrays : BaseSolution, IBaseSolution
    {
        public MaximumDistanceArrays() : base("https://leetcode.com/problems/maximum-distance-in-arrays")
        {
                
        }

        int[][] arrays;

        public void Execute()
        {
            var result = MaxDistance(arrays);
            Console.WriteLine($"Max distance: {result}");
        }

        public int MaxDistance(IList<IList<int>> arrays)
        {
            // https://walkccc.me/LeetCode/problems/624/

            int maxDistance = 0;
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (var array in arrays)
            {
                maxDistance = Math.Max(maxDistance, Math.Max(array[array.Count - 1] - min, max - array[0]));
                min = Math.Min(min, array[0]);
                max = Math.Max(max, array[array.Count - 1]);
            }

            return maxDistance;
        }
        public int MaxDistanceTooComplex(IList<IList<int>> arrays)
        {
            int maxDistance = int.MinValue;
            int targetDistance, originDistance;
            int arraysCount = arrays.Count;
            int[] arrayOrigin, arrayTarget, arrayCandidate;
            arrayOrigin = arrays[0].ToArray();
            arrayTarget = arrays[1].ToArray();
            maxDistance = Math.Max(maxDistance, Math.Max(
                Math.Abs(arrayTarget[arrayTarget.Count() - 1] - arrayOrigin[0]),
                Math.Abs(arrayOrigin[arrayOrigin.Count() - 1] - arrayTarget[0])));
            for (int i = 2; i < arraysCount; i++)
            {
                arrayCandidate = arrays[i].ToArray();
                targetDistance = Math.Max(maxDistance, Math.Max(
                    Math.Abs(arrayCandidate[arrayCandidate.Count() - 1] - arrayOrigin[0]),
                    Math.Abs(arrayOrigin[arrayOrigin.Count() - 1] - arrayCandidate[0])));
                originDistance = Math.Max(maxDistance, Math.Max(
                Math.Abs(arrayTarget[arrayTarget.Count() - 1] - arrayCandidate[0]),
                Math.Abs(arrayCandidate[arrayCandidate.Count() - 1] - arrayTarget[0])));
                if(targetDistance > originDistance)
                {
                    arrayTarget = arrayCandidate;
                    maxDistance = targetDistance;
                }
                else if (originDistance > targetDistance)
                {
                    arrayTarget = arrayCandidate;
                    maxDistance = originDistance;
                }
                else
                {
                    targetDistance = Math.Abs(arrayTarget[arrayTarget.Count() - 1] - arrayOrigin[0]);
                    originDistance = Math.Abs(arrayOrigin[arrayOrigin.Count() - 1] - arrayTarget[0]);
                    if (targetDistance > originDistance)
                    {
                        if(arrayCandidate[0] < arrayOrigin[0])
                        {
                            arrayOrigin = arrayCandidate;
                        }
                        if(arrayCandidate[arrayCandidate.Count() - 1] > arrayTarget[arrayTarget.Count() - 1])
                        {
                            arrayTarget = arrayCandidate;
                        }
                    }
                    else if (originDistance > targetDistance)
                    {
                        if (arrayCandidate[0] < arrayTarget[0])
                        {
                            arrayTarget = arrayCandidate;
                        }
                        if (arrayCandidate[arrayCandidate.Count() - 1] > arrayOrigin[arrayOrigin.Count() - 1])
                        {
                            arrayOrigin = arrayCandidate;
                        }
                    }
                    maxDistance = Math.Max(maxDistance, Math.Max(
                        Math.Abs(arrayTarget[arrayTarget.Count() - 1] - arrayOrigin[0]),
                        Math.Abs(arrayOrigin[arrayOrigin.Count() - 1] - arrayTarget[0])));
                }
            }
            return maxDistance;
        }

        public int MaxDistanceIterance(IList<IList<int>> arrays)
        {
            int maxDistance = int.MinValue;
            int arraysCount = arrays.Count;
            int[] arrayOrigin, arrayTarget;
            for (int i = 0; i < arraysCount; i++)
            {
                arrayOrigin = arrays[i].ToArray();

                for (int j = i + 1; j < arraysCount; j++)
                {
                    arrayTarget = arrays[j].ToArray();

                    maxDistance = Math.Max(maxDistance, Math.Max(
                        Math.Abs(arrayTarget[arrayTarget.Count() - 1] - arrayOrigin[0]),
                        Math.Abs(arrayOrigin[arrayOrigin.Count() - 1] - arrayTarget[0])));
                }
            }
            return maxDistance;
        }

        public int MaxDistanceEnumrator(IList<IList<int>> arrays)
        {
            int[] arrayOrigin, arrayTarget;
            int maxDistance = int.MinValue;
            var arraysEnumerator = arrays.GetEnumerator();
            arraysEnumerator.MoveNext();
            if (arraysEnumerator.Current != null)
            {
                arrayOrigin = arraysEnumerator.Current.ToArray();
                do
                {
                    arraysEnumerator.MoveNext();
                    if (arraysEnumerator.Current != null)
                    {
                        arrayTarget = arraysEnumerator.Current.ToArray();
                        maxDistance = Math.Max(maxDistance, Math.Max(
                            Math.Abs(arrayTarget[arrayTarget.Count() - 1] - arrayOrigin[0]),
                            Math.Abs(arrayOrigin[arrayOrigin.Count() - 1] - arrayTarget[0])));
                    }
                } while (arraysEnumerator.Current != null);
            }
            return maxDistance;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultExample(int testCase = 0)
        {
            var testCases = new [] {
                new [] {
                    new int [] { -6,-3,-1, 1, 2, 2, 2 },
                    new int [] { -10,-8,-6,-2, 4 },
                    new int [] { -2 },
                    new int [] { -8,-4,-3,-3,-2,-1, 1, 2, 3 },
                    new int [] { -8,-6,-5,-4,-2,-2, 2, 4 }},
                new[] {
                    new int [] { -1, 1 },
                    new int [] { -3, 1, 4 },
                    new int [] { -2,-1,0,2 }},
                new [] {
                    new int [] { 1, 2, 3 },
                    new int [] { 4, 5 },
                    new int [] { 1, 2, 3 }},
                new [] {
                    new int [] { 1 },
                    new int [] { 1 }
                }
            };

            if (testCase < 0 || testCase >= testCases.Length) throw new Exception($"Test case {testCase} doesn't exists!");

            arrays = testCases[testCase];
        }
    }
}
