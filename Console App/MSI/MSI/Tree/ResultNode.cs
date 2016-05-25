namespace MSI.Tree
{
    public class ResultNode : IMsiNode
    {
        public ResultNode(string message) { Message = message; }

        #region Implementation of IMsiNode

        public Branch CurrentBranch { get; set; }
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
                Branch branch = CurrentBranch;
                while(p!=null)
                {
                    if(branch == Branch.Yes)
                    {
                        score += p.Score;
                    }
                    else
                    {
                        score += 1 - p.Score;
                    }
                    steps++;
                    branch = p.CurrentBranch;
                    p = p.Parent;
                }
                return steps == 0 ? 0 : score / steps;
            }
        }
        public IMsiNode[] Decide(float score) { return new IMsiNode[0]; }


        #endregion
    }
}