namespace LeetCode.Common
{
    public abstract class BaseSolution
    {
        private readonly string _problemURL;

        public BaseSolution(string problemURL)
        {
            _problemURL = problemURL;
            this.DebugMode = true;
        }

        public string ReturnProblemURL() => _problemURL;

        public bool DebugMode { get; set; }
    }
}
