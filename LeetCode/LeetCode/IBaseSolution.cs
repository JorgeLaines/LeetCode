namespace LeetCode
{
    public interface IBaseSolution
    {
        string ReturnProblemURL();
        void Read();
        void SetDefaultExample(int testCase);
        void Execute();
    }
}
