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
                CurrentMessage ="Nie ma wiecej chorob";
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
            // Od strony"nie", od strony chorob
            ResultNode noR = new ResultNode("hipochondria");
            ResultNode yesR = new ResultNode("zespol Raynauda");
            QuestionNode noQ5 = new QuestionNode("Czy masz biala skore?", yesR, noR);
            noR = new ResultNode("choroba zezowa");
            yesR = new ResultNode("katarakta");
            QuestionNode yesQ5 = new QuestionNode("Czy masz oczoplas?", yesR, noR);
            QuestionNode noQ4 = new QuestionNode("Czy masz klopot z widzeniem w nocy?", yesQ5, noQ5);
            noR = new ResultNode("nerwica depresyjna");
            yesR = new ResultNode("depresja");
            noQ5 = new QuestionNode("Czy odczuwasz sennosc?", yesR, noR);
            noR = new ResultNode("choroba afektywna");
            yesR = new ResultNode("pierwotna marskosc zolciowa watroby");
            yesQ5 = new QuestionNode("Czy czujesz suchosc w ustach?", yesR, noR);
            QuestionNode yesQ4 = new QuestionNode("Czy czujesz oslabienie?", yesQ5, noQ5);
            QuestionNode noQ3 = new QuestionNode("Czy masz mysli samobojcze?", yesQ4, noQ4);
            noR = new ResultNode("bulimia");
            yesR = new ResultNode("zapalenie ucha srodkowego");
            noQ5 = new QuestionNode("Czy boli cie ucho?", yesR, noR);
            noR = new ResultNode("zapalenie otrzewnej");
            yesR = new ResultNode("zawal serca");
            yesQ5 = new QuestionNode("Czy odczuwasz leki?", yesR, noR);
            noQ4 = new QuestionNode("Czy masz dusznosci?", yesQ5, noQ5);
            noR = new ResultNode("bialaczka");
            yesR = new ResultNode("bialaczka szpikowa");
            noQ5 = new QuestionNode("Czy masz niedokrwistosc?", yesR, noR);
            noR = new ResultNode("anemia");
            yesR = new ResultNode("bialaczka limfoblastyczna");
            yesQ5 = new QuestionNode("Czy krwawia Ci dziasla?", yesR, noR);
            yesQ4 = new QuestionNode("Czy czyjesz sie sennie?", yesQ5, noQ5);
            QuestionNode yesQ3 = new QuestionNode("Czy czujesz oslabienie?", yesQ4, noQ4);
            QuestionNode noQ2 = new QuestionNode("Czy jestes blady/a?", yesQ3, noQ3);

            noR = new ResultNode("tezec");
            yesR = new ResultNode("krwawienie z nosa - epistaxis");
            noQ5 = new QuestionNode("Czy masz krwioplucie?", yesR, noR);
            noR = new ResultNode("katar sienny");
            yesR = new ResultNode("migrena");
            yesQ5 = new QuestionNode("Czy masz wymioty?", yesR, noR);
            noQ4 = new QuestionNode("Czy masz swiatlowstret?", yesQ5, noQ5);
            noR = new ResultNode("kleszczowe zapalenie mozgu");
            yesR = new ResultNode("zapalenie opon mozgowych");
            noQ5 = new QuestionNode("Czy odczuwasz sennosc?", yesR, noR);
            noR = new ResultNode("ostry zespol oddechowy - sars");
            yesR = new ResultNode("angina");
            yesQ5 = new QuestionNode("Czy czujesz bole kostne?", yesR, noR);
            yesQ4 = new QuestionNode("Czy czujesz bol gardla?", yesQ5, noQ5);
            noQ3 = new QuestionNode("Czy masz goraczke?", yesQ4, noQ4);
            noR = new ResultNode("nadcisnienie tetnicze");
            yesR = new ResultNode("grypa");
            noQ5 = new QuestionNode("Czy odczuwasz nadpobudliwosc?", yesR, noR);
            noR = new ResultNode("uremia");
            yesR = new ResultNode("przewlekla niewydolnosc nerek");
            yesQ5 = new QuestionNode("Czy odczuwasz rozdraznienie?", yesR, noR);
            noQ4 = new QuestionNode("Czy masz swiad skory?", yesQ5, noQ5);
            noR = new ResultNode("przewlekle zapalenie zatok przynosowych");
            yesR = new ResultNode("aids");
            noQ5 = new QuestionNode("Czy masz drgawki?", yesR, noR);
            noR = new ResultNode("astma pylkowa");
            yesR = new ResultNode("przeziebienie");
            yesQ5 = new QuestionNode("Czy chrapiesz?", yesR, noR);
            yesQ4 = new QuestionNode("Czy masz katar?", yesQ5, noQ5);
            yesQ3 = new QuestionNode("Czy masz kaszel?", yesQ4, noQ4);

            QuestionNode yesQ2 = new QuestionNode("Czy czujesz oslabienie?", yesQ3, noQ3);

            root = new QuestionNode("Czy masz bol glowy?", yesQ2, noQ2);
        }
    }
}