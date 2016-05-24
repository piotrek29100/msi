using System;

namespace Msi.Tree
{
    public class QuestionNode : IMsiNode
    {
        private IMsiNode yesNode;
        private IMsiNode noNode;
        private float _score;

        public QuestionNode(string message) { Message = message; }

        public IMsiNode NoNode
        {
            get { return noNode; }
            set
            {
                if (noNode != null)
                    noNode.Parent = null;
                noNode = value;
                if (noNode != null)
                    noNode.Parent = this;
            }
        }

        public IMsiNode YesNode
        {
            get { return yesNode; }
            set
            {
                if (yesNode != null)
                    yesNode.Parent = null;
                yesNode = value;
                if (yesNode != null)
                    yesNode.Parent = this;
            }
        }

        #region Implementation of IMsiNode

        public float Score => _score;
        public MsiState State => MsiState.Interviewing;
        public string Message { get; }
        public IMsiNode Parent { get; set; }

        public IMsiNode[] Decide(float score)
        {
            if(score < 0.0 || score > 1.0)
                throw new ArgumentOutOfRangeException();
            _score = score;
            if(score <= 0.5)
                return new[] {noNode, yesNode};
            return new[] { yesNode,noNode };
        }

        #endregion
    }
}