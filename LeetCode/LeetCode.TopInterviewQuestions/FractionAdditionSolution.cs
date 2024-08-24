namespace LeetCode.TopInterviewQuestions
{
    public class FractionAdditionSolution
    {
        // https://leetcode.com/problems/fraction-addition-and-subtraction/description/

        public string FractionAddition(string expression)
        {
            int expressionLength = expression.Length;
            int arraySize = (int)Math.Round(expressionLength / 4.0, 0, MidpointRounding.ToPositiveInfinity);
            int[][] fractions = new int[arraySize][];
            int[] denominators = new int[arraySize];
            int fractionCount = 0;
            int fractionFactor = 1;
            int numerator = 0, denominator = 0;
            bool isNumerator = true;
            int commonDenominator = 0;
            for (int i = 0; i < expressionLength; i++)
            {
                switch (expression[i])
                {
                    case '-': case '+':
                        if(i > 2)
                        {
                            fractions[fractionCount] = new int[] { fractionFactor * numerator, denominator };
                            commonDenominator = CalculateCommonDenominator(commonDenominator, denominator);
                            numerator = 0;
                            denominator = 0;
                            isNumerator = true;
                            fractionCount++;
                        }
                        fractionFactor = expression[i] == '-' ? -1 : 1;
                        break;
                    case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                        if(isNumerator)
                        {
                            numerator = numerator * 10 + int.Parse(expression[i].ToString());
                        }
                        else
                        {
                            denominator = denominator * 10 + int.Parse(expression[i].ToString());
                        }
                        break;
                    case '/':
                        isNumerator = false;
                        break;
                    default:
                        break;
                }
            }
            fractions[fractionCount] = new int[] { fractionFactor * numerator, denominator };
            commonDenominator = CalculateCommonDenominator(commonDenominator, denominator);

            numerator = 0;
            for (int i = 0; i <= fractionCount; i++)
            {
                numerator = numerator + fractions[i][0] * (commonDenominator / fractions[i][1]);
            }

            if (numerator == 0) return "0/1";

            int secondDenominator = CalculateCommonDenominator(commonDenominator, numerator, true);

            numerator = numerator / secondDenominator;
            commonDenominator = commonDenominator / secondDenominator;

            return $"{numerator}/{commonDenominator}";
        }

        private int CalculateCommonDenominator(int commonDenominator, int candidate, bool minimum = false)
        {
            if(commonDenominator == 0) return candidate;

            int[] primeNumbers = new int[] { 2, 3, 5, 7, 11, 13 };
            int newCommonDenominator = 1;
            bool commonDenominatorHit;

            for (int i = 0; i < primeNumbers.Length; i++)
            {
                commonDenominatorHit = true;
                while (commonDenominatorHit && (commonDenominator > 1 || candidate > 1))
                {
                    if ((!minimum && (commonDenominator % primeNumbers[i] == 0 || candidate % primeNumbers[i] == 0)) ||
                        (minimum && (commonDenominator % primeNumbers[i] == 0 && candidate % primeNumbers[i] == 0)))
                    {
                        newCommonDenominator = newCommonDenominator * primeNumbers[i];
                        commonDenominator = commonDenominator % primeNumbers[i] == 0 ? commonDenominator / primeNumbers[i] : commonDenominator;
                        candidate = candidate % primeNumbers[i] == 0 ? candidate / primeNumbers[i] : candidate;
                    }
                    else
                    {
                        commonDenominatorHit = false;
                    }
                }
            }

            return newCommonDenominator;
        }
    }
}
