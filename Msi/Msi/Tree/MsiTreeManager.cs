using System.Collections.Generic;
using System.Linq;

namespace Msi.Tree
{
    public class MsiTreeManager
    {
        private IMsiNode root;
        private Stack<IMsiNode> backLog;
        private string currentMessage;
        private float currentScore;
        private MsiState currentState;

        public string CurrentMessage
        {
            get { return currentMessage; }
            private set { currentMessage = value; }
        }

        public float CurrentScore
        {
            get { return currentScore; }
            private set { currentScore = value; }
        }

        public MsiState CurrentState
        {
            get { return currentState; }
            private set { currentState = value; }
        }

        public MsiTreeManager()
        {
            backLog = new Stack<IMsiNode>();
            CurrentScore = 0;
            MSIInitIllnesses();
            if(root != null)
            {
                backLog.Push(root);
                CurrentMessage = root.Message;
                CurrentState = root.State;
            }
        }

        public void AnswerQuestion(float score)
        {
            if(CurrentState != MsiState.Interviewing)
                return;
            IEnumerable<IMsiNode> ret = backLog.Pop().Decide(score);
            foreach(var node in ret.Reverse())
            {
                backLog.Push(node);
            }
            UpdateResults();
        }

        private void UpdateResults()
        {
            var top = backLog.Peek();
            if(top != null)
            {
                CurrentMessage = top.Message;
                CurrentScore = top.Score;
                CurrentState = top.State;
            }
            else
            {
                CurrentState = MsiState.RanOutOfQuestions;
                CurrentScore = -1337666;
                CurrentMessage = "Nie ma wiêcej chorób";
            }
        }

        public void DiscardAnswer()
        {
            if(CurrentState != MsiState.Answered)
                return;
            backLog.Pop();
            UpdateResults();
        }

        private void MSIInitIllnesses()
        {
            root = new QuestionNode("Czy masz ból g³owy");
        }
    }
}