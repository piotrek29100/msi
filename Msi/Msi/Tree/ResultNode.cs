namespace Msi.Tree
{
    public class ResultNode : IMsiNode
    {
        public ResultNode(string message) { Message = message; }

        #region Implementation of IMsiNode

        public MsiState State => MsiState.Answered;
        public IMsiNode Parent { get; set; }
        public string Message { get; }

        public float Score
        {
            get
            {
                float score = 0;
                int steps = 0;
                IMsiNode p = Parent;
                while(p!=null)
                {
                    score += p.Score;
                    steps++;
                    p = p.Parent;
                }
                return steps == 0 ? 0 : score / steps;
            }
        }
        public IMsiNode[] Decide(float score) { return new IMsiNode[0]; }


        #endregion
    }
}