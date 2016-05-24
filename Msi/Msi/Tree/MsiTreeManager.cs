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
                CurrentMessage = "Nie ma wi�cej chor�b";
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
            // reu�ywanie zmiennych, zmiana kolejno�ci mo�e to wszystko rozawli�
            // Od strony "nie", od strony chor�b
            ResultNode noR = new ResultNode("Masz hipochondri�");
            ResultNode yesR = new ResultNode("Masz zesp� Raynauda");
            QuestionNode noQ5 = new QuestionNode("Czy masz bia�� sk�r�?",yesR,noR);
            noR = new ResultNode("Masz chorob� zezow�");
            yesR = new ResultNode("Masz katarakt�");
            QuestionNode yesQ5 = new QuestionNode("Czy masz oczopl�s?",yesR,noR);
            QuestionNode noQ4 = new QuestionNode("Czy masz k�opot z widzeniem w nocy?",yesQ5,noQ5);
            noR = new ResultNode("Masz nerwic� depresyjn�");
            yesR = new ResultNode("Masz depresj�");
            noQ5 = new QuestionNode("Czy odczuwasz senno��?",yesR,noR);
            noR = new ResultNode("Masz chorob� afektywn�");
            yesR = new ResultNode("Masz pierwotn� marsko�� ��ciow� w�troby");
            yesQ5 = new QuestionNode("Czy czujesz sucho�� w ustach?",yesR,noR);
            QuestionNode yesQ4 = new QuestionNode("Czy czujesz os�abienie?",yesQ5,noQ5);
            QuestionNode noQ3 = new QuestionNode("Czy masz my�li samob�jcze?",yesQ4,noQ4);
            noR = new ResultNode("Masz bulimi�");
            yesR = new ResultNode("Masz zapalenie ucha �rodkowego");
            noQ5 = new QuestionNode("Czy boli ci� ucho?",yesR,noR);
            noR = new ResultNode("Masz zapalenie otrzewnej");
            yesR = new ResultNode("Masz zawa� serca");
            yesQ5 = new QuestionNode("Czy odczuwasz l�ki?",yesR,noR);
            noQ4 = new QuestionNode("Czy masz duszno�ci?", yesQ5,noQ5);
            noR = new ResultNode("Masz bia�aczk�");
            yesR = new ResultNode("Masz bia�aczk� szpikow�");
            noQ5 = new QuestionNode("Czy masz niedokrwisto��?",yesR,noR);
            noR = new ResultNode("Masz anemi�");
            yesR = new ResultNode("Masz bia�aczk� limfoblastyczn�");
            yesQ5 = new QuestionNode("Czy krwawi� Ci dzi�s�a?",yesR,noR);
            yesQ4 = new QuestionNode("Czy czyjesz si� sennie?",yesQ5,noQ5);
            QuestionNode yesQ3 = new QuestionNode("Czy czujesz os�abienie?", yesQ4,noQ4);
            QuestionNode noQ2 = new QuestionNode("Czy jeste� blady/a?",yesQ3,noQ3);

            noR = new ResultNode("Masz t�ec");
            yesR = new ResultNode("Masz krwawienie z nosa epistaxis");
            noQ5 = new QuestionNode("Czy masz krwioplucie? ", yesR, noR);
            noR = new ResultNode("Masz katar sienny");
            yesR = new ResultNode("Masz migren�");
            yesQ5 = new QuestionNode("Czy masz wymioty? ", yesR, noR);
            noQ4 = new QuestionNode("Czy masz �wiat�owstr�t? ", yesQ5, noQ5);
            noR = new ResultNode("Masz kleszczowe zapalenie m�zgu");
            yesR = new ResultNode("Masz zapalenie opon m�zgowych");
            noQ5 = new QuestionNode("Czy odczuwasz senno��?", yesR, noR);
            noR = new ResultNode("Masz ostry zesp� oddechowy - sars");
            yesR = new ResultNode("Masz angin�");
            yesQ5 = new QuestionNode("Czy czujesz b�le kostne? ", yesR, noR);
            yesQ4 = new QuestionNode("Czy czujesz b�l gard�a? ", yesQ5, noQ5);
            noQ3 = new QuestionNode("Czy masz gor�czk�? ", yesQ4, noQ4);
            noR = new ResultNode("Masz nadci�nienie t�tnicze");
            yesR = new ResultNode("Masz gryp�");
            noQ5 = new QuestionNode("Czy odczuwasz nadpobudliwo��? ", yesR, noR);
            noR = new ResultNode("Masz uremi�");
            yesR = new ResultNode("Masz przewlek�� niewydolno�� nerek");
            yesQ5 = new QuestionNode("Czy odczuwasz rozdra�nienie? ", yesR, noR);
            noQ4 = new QuestionNode("Czy masz �wi�d sk�ry? ", yesQ5, noQ5);
            noR = new ResultNode("Masz przewlek�e zapalenie zatok przynosowych");
            yesR = new ResultNode("Masz aids");
            noQ5 = new QuestionNode("Czy masz drgawki? ", yesR, noR);
            noR = new ResultNode("Masz astm� py�kow�");
            yesR = new ResultNode("Masz przezi�bienie");
            yesQ5 = new QuestionNode("Czy chrapiesz? ", yesR, noR);
            yesQ4 = new QuestionNode("Czy masz katar? ", yesQ5, noQ5);
            yesQ3 = new QuestionNode("Czy masz kaszel? ", yesQ4, noQ4);

            QuestionNode yesQ2 = new QuestionNode("Czy czujesz os�abienie?", yesQ3,noQ3);

            root = new QuestionNode("Czy masz b�l g�owy",yesQ2,noQ2);
        }
    }
}