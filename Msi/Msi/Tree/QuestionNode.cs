using System;

namespace Msi.Tree
{
    public class QuestionNode : IMsiNode
    {
        private IMsiNode _yesNode;
        private IMsiNode _noNode;
        private float _score;


        public QuestionNode(string message)
        {
            Message = message;
            CurrentBranch = Branch.Yes;
        }

        public QuestionNode(string message, IMsiNode yes, IMsiNode no):this(message)
        {
            YesNode = yes;
            NoNode = no;
        }

        private IMsiNode NoNode
        {
            get { return _noNode; }
            set
            {
                if(_noNode != null)
                {
                    _noNode.Parent = null;
                    _noNode.CurrentBranch = Branch.Yes;
                }
                _noNode = value;
                if(_noNode != null)
                {
                    _noNode.Parent = this;
                    _noNode.CurrentBranch = Branch.No;
                }
            }
        }

        private IMsiNode YesNode
        {
            get { return _yesNode; }
            set
            {
                if (_yesNode != null)
                {
                    _yesNode.Parent = null;
                    _yesNode.CurrentBranch = Branch.Yes;
                }
                _yesNode = value;
                if (_yesNode != null)
                {
                    _yesNode.Parent = this;
                    _yesNode.CurrentBranch = Branch.Yes;
                }
            }
        }

        #region Implementation of IMsiNode

        public float Score => _score;
        public Branch CurrentBranch { get; set; }
        public MsiState State => MsiState.Interviewing;
        public string Message { get; }
        public IMsiNode Parent { get; set; }

        public IMsiNode[] Decide(float score)
        {
            if (score < 0.0 || score > 1.0)
                throw new ArgumentOutOfRangeException();
            _score = score;
            if (score <= 0.5)
                return new[] { YesNode, NoNode };
            return new[] { NoNode, YesNode };
        }

        #endregion
    }
}