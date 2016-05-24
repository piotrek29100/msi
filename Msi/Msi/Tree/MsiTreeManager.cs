using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Msi.Tree
{
    public class MsiTreeManager
    {
        private Dictionary<int, string> messageDict;
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
            foreach(var node in ret)
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
            // reu¿ywanie zmiennych, zmiana kolejnoœci mo¿e to wszystko rozawliæ
            // Od strony "nie", od strony chorób
            ResultNode noR = new ResultNode("Masz hipochondriê");
            ResultNode yesR = new ResultNode("Masz zespó³ Raynauda");
            QuestionNode noQ5 = new QuestionNode("Czy masz bia³¹ skórê?",yesR,noR);
            noR = new ResultNode("Masz chorobê zezow¹");
            yesR = new ResultNode("Masz kataraktê");
            QuestionNode yesQ5 = new QuestionNode("Czy masz oczopl¹s?",yesR,noR);
            QuestionNode noQ4 = new QuestionNode("Czy masz k³opot z widzeniem w nocy?",yesQ5,noQ5);
            noR = new ResultNode("Masz nerwicê depresyjn¹");
            yesR = new ResultNode("Masz depresjê");
            noQ5 = new QuestionNode("Czy odczuwasz sennoœæ?",yesR,noR);
            noR = new ResultNode("Masz chorobê afektywn¹");
            yesR = new ResultNode("Masz pierwotn¹ marskoœæ ¿ó³ciow¹ w¹troby");
            yesQ5 = new QuestionNode("Czy czujesz suchoœæ w ustach?",yesR,noR);
            QuestionNode yesQ4 = new QuestionNode("Czy czujesz os³abienie?",yesQ5,noQ5);
            QuestionNode noQ3 = new QuestionNode("Czy masz myœli samobójcze?",yesQ4,noQ4);
            noR = new ResultNode("Masz bulimiê");
            yesR = new ResultNode("Masz zapalenie ucha œrodkowego");
            noQ5 = new QuestionNode("Czy boli ciê ucho?",yesR,noR);
            noR = new ResultNode("Masz zapalenie otrzewnej");
            yesR = new ResultNode("Masz zawa³ serca");
            yesQ5 = new QuestionNode("Czy odczuwasz lêki?",yesR,noR);
            noQ4 = new QuestionNode("Czy masz dusznoœci?", yesQ5,noQ5);
            noR = new ResultNode("Masz bia³aczkê");
            yesR = new ResultNode("Masz bia³aczkê szpikow¹");
            noQ5 = new QuestionNode("Czy masz niedokrwistoœæ?",yesR,noR);
            noR = new ResultNode("Masz anemiê");
            yesR = new ResultNode("Masz bia³aczkê limfoblastyczn¹");
            yesQ5 = new QuestionNode("Czy krwawi¹ Ci dzi¹s³a?",yesR,noR);
            yesQ4 = new QuestionNode("Czy czyjesz siê sennie?",yesQ5,noQ5);
            QuestionNode yesQ3 = new QuestionNode("Czy czujesz os³abienie?", yesQ4,noQ4);
            QuestionNode noQ2 = new QuestionNode("Czy jesteœ blady/a?",yesQ3,noQ3);

            noR = new ResultNode("Masz tê¿ec");
            yesR = new ResultNode("Masz krwawienie z nosa epistaxis");
            noQ5 = new QuestionNode("Czy masz krwioplucie? ", yesR, noR);
            noR = new ResultNode("Masz katar sienny");
            yesR = new ResultNode("Masz migrenê");
            yesQ5 = new QuestionNode("Czy masz wymioty? ", yesR, noR);
            noQ4 = new QuestionNode("Czy masz œwiat³owstrêt? ", yesQ5, noQ5);
            noR = new ResultNode("Masz kleszczowe zapalenie mózgu");
            yesR = new ResultNode("Masz zapalenie opon mózgowych");
            noQ5 = new QuestionNode("Czy odczuwasz sennoœæ?", yesR, noR);
            noR = new ResultNode("Masz ostry zespó³ oddechowy - sars");
            yesR = new ResultNode("Masz anginê");
            yesQ5 = new QuestionNode("Czy czujesz bóle kostne? ", yesR, noR);
            yesQ4 = new QuestionNode("Czy czujesz ból gard³a? ", yesQ5, noQ5);
            noQ3 = new QuestionNode("Czy masz gor¹czkê? ", yesQ4, noQ4);
            noR = new ResultNode("Masz nadciœnienie têtnicze");
            yesR = new ResultNode("Masz grypê");
            noQ5 = new QuestionNode("Czy odczuwasz nadpobudliwoœæ? ", yesR, noR);
            noR = new ResultNode("Masz uremiê");
            yesR = new ResultNode("Masz przewlek³¹ niewydolnoœæ nerek");
            yesQ5 = new QuestionNode("Czy odczuwasz rozdra¿nienie? ", yesR, noR);
            noQ4 = new QuestionNode("Czy masz œwi¹d skóry? ", yesQ5, noQ5);
            noR = new ResultNode("Masz przewlek³e zapalenie zatok przynosowych");
            yesR = new ResultNode("Masz aids");
            noQ5 = new QuestionNode("Czy masz drgawki? ", yesR, noR);
            noR = new ResultNode("Masz astmê py³kow¹");
            yesR = new ResultNode("Masz przeziêbienie");
            yesQ5 = new QuestionNode("Czy chrapiesz? ", yesR, noR);
            yesQ4 = new QuestionNode("Czy masz katar? ", yesQ5, noQ5);
            yesQ3 = new QuestionNode("Czy masz kaszel? ", yesQ4, noQ4);

            QuestionNode yesQ2 = new QuestionNode("Czy czujesz os³abienie?", yesQ3,noQ3);

            root = new QuestionNode("Czy masz ból g³owy",yesQ2,noQ2);
        }
    }
}