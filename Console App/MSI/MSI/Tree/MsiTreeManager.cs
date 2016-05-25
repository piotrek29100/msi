using System.Collections.Generic;

namespace MSI.Tree
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
            if (root != null)
            {
                backLog.Push(root);
                CurrentMessage = root.Message;
                CurrentState = root.State;
            }
        }

        public void AnswerQuestion(float score)
        {
            if (CurrentState != MsiState.Interviewing)
                return;
            IEnumerable<IMsiNode> ret = backLog.Pop().Decide(score);
            foreach (var node in ret)
            {
                backLog.Push(node);
            }
            UpdateResults();
        }

        private void UpdateResults()
        {
            IMsiNode top = null;
            if (backLog.Count > 0)
                top = backLog.Peek();
            if (top != null)
            {
                CurrentMessage = top.Message;
                CurrentScore = top.Score;
                CurrentState = top.State;
            }
            else
            {
                CurrentState = MsiState.RanOutOfQuestions;
                CurrentScore = -1337666;
                CurrentMessage = "Nie ma wiecej chorob";
            }
        }

        public void DiscardAnswer()
        {
            if (CurrentState != MsiState.Answered)
                return;
            backLog.Pop();
            UpdateResults();
        }

        private void MSIInitIllnesses()
        {
            // reuzywanie zmiennych, zmiana kolejnosci moze to wszystko rozawlic
            // Od strony "nie", od strony chorob
            ResultNode noR = new ResultNode("Masz hipochondrie");
            ResultNode yesR = new ResultNode("Masz zespol Raynauda");
            QuestionNode noQ5 = new QuestionNode("Czy masz biala skore?", yesR, noR);
            noR = new ResultNode("Masz chorobe zezowa");
            yesR = new ResultNode("Masz katarakte");
            QuestionNode yesQ5 = new QuestionNode("Czy masz oczoplas?", yesR, noR);
            QuestionNode noQ4 = new QuestionNode("Czy masz klopot z widzeniem w nocy?", yesQ5, noQ5);
            noR = new ResultNode("Masz nerwice depresyjna");
            yesR = new ResultNode("Masz depresje");
            noQ5 = new QuestionNode("Czy odczuwasz sennosc?", yesR, noR);
            noR = new ResultNode("Masz chorobe afektywna");
            yesR = new ResultNode("Masz pierwotna marskosc zolciowa watroby");
            yesQ5 = new QuestionNode("Czy czujesz suchosc w ustach?", yesR, noR);
            QuestionNode yesQ4 = new QuestionNode("Czy czujesz oslabienie?", yesQ5, noQ5);
            QuestionNode noQ3 = new QuestionNode("Czy masz mysli samobojcze?", yesQ4, noQ4);
            noR = new ResultNode("Masz bulimie");
            yesR = new ResultNode("Masz zapalenie ucha srodkowego");
            noQ5 = new QuestionNode("Czy boli cie ucho?", yesR, noR);
            noR = new ResultNode("Masz zapalenie otrzewnej");
            yesR = new ResultNode("Masz zawal serca");
            yesQ5 = new QuestionNode("Czy odczuwasz leki?", yesR, noR);
            noQ4 = new QuestionNode("Czy masz dusznosci?", yesQ5, noQ5);
            noR = new ResultNode("Masz bialaczke");
            yesR = new ResultNode("Masz bialaczke szpikowa");
            noQ5 = new QuestionNode("Czy masz niedokrwistosc?", yesR, noR);
            noR = new ResultNode("Masz anemie");
            yesR = new ResultNode("Masz bialaczke limfoblastyczna");
            yesQ5 = new QuestionNode("Czy krwawia Ci dziasla?", yesR, noR);
            yesQ4 = new QuestionNode("Czy czyjesz sie sennie?", yesQ5, noQ5);
            QuestionNode yesQ3 = new QuestionNode("Czy czujesz oslabienie?", yesQ4, noQ4);
            QuestionNode noQ2 = new QuestionNode("Czy jestes blady/a?", yesQ3, noQ3);

            noR = new ResultNode("Masz tezec");
            yesR = new ResultNode("Masz krwawienie z nosa epistaxis");
            noQ5 = new QuestionNode("Czy masz krwioplucie? ", yesR, noR);
            noR = new ResultNode("Masz katar sienny");
            yesR = new ResultNode("Masz migrene");
            yesQ5 = new QuestionNode("Czy masz wymioty? ", yesR, noR);
            noQ4 = new QuestionNode("Czy masz swiatlowstret? ", yesQ5, noQ5);
            noR = new ResultNode("Masz kleszczowe zapalenie mozgu");
            yesR = new ResultNode("Masz zapalenie opon mozgowych");
            noQ5 = new QuestionNode("Czy odczuwasz sennosc?", yesR, noR);
            noR = new ResultNode("Masz ostry zespol oddechowy - sars");
            yesR = new ResultNode("Masz angine");
            yesQ5 = new QuestionNode("Czy czujesz bole kostne? ", yesR, noR);
            yesQ4 = new QuestionNode("Czy czujesz bol gardla? ", yesQ5, noQ5);
            noQ3 = new QuestionNode("Czy masz goraczke? ", yesQ4, noQ4);
            noR = new ResultNode("Masz nadcisnienie tetnicze");
            yesR = new ResultNode("Masz grype");
            noQ5 = new QuestionNode("Czy odczuwasz nadpobudliwosc? ", yesR, noR);
            noR = new ResultNode("Masz uremie");
            yesR = new ResultNode("Masz przewlekla niewydolnosc nerek");
            yesQ5 = new QuestionNode("Czy odczuwasz rozdraznienie? ", yesR, noR);
            noQ4 = new QuestionNode("Czy masz swiad skory? ", yesQ5, noQ5);
            noR = new ResultNode("Masz przewlekle zapalenie zatok przynosowych");
            yesR = new ResultNode("Masz aids");
            noQ5 = new QuestionNode("Czy masz drgawki? ", yesR, noR);
            noR = new ResultNode("Masz astme pylkowa");
            yesR = new ResultNode("Masz przeziebienie");
            yesQ5 = new QuestionNode("Czy chrapiesz? ", yesR, noR);
            yesQ4 = new QuestionNode("Czy masz katar? ", yesQ5, noQ5);
            yesQ3 = new QuestionNode("Czy masz kaszel? ", yesQ4, noQ4);

            QuestionNode yesQ2 = new QuestionNode("Czy czujesz oslabienie?", yesQ3, noQ3);

            root = new QuestionNode("Czy masz bol glowy", yesQ2, noQ2);
        }
    }
}