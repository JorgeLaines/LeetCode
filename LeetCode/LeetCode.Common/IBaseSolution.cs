﻿namespace LeetCode.Common
{
    public interface IBaseSolution
    {
        string ReturnProblemURL();
        void Read();
        void SetDefaultExample(int testCase = 0);
        void Execute();
    }
}
