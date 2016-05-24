using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Msi.Tree.Tests
{
    [TestClass()]
    public class MsiTreeManagerTests
    {
        [TestMethod()]
        public void Msi_Hipochondria()
        {
            var expectations = new[] { "ból głowy", "blad", "myśli", "nocy", "skór", "hipochon" };
            var answers = new float[] { 0, 0, 0, 0, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Raynaud()
        {
            var expectations = new[] { "ból głowy", "blad", "myśli", "nocy", "skór", "aynaud" };
            var answers = new float[] { 0, 0, 0, 0, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Zez()
        {
            var expectations = new[] { "ból głowy", "blad", "myśli", "nocy", "oczoplą", "zezow" };
            var answers = new float[] { 0, 0, 0, 1, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Katarakta()
        {
            var expectations = new[] { "ból głowy", "blad", "myśli", "nocy", "oczoplą", "katarak" };
            var answers = new float[] { 0, 0, 0, 1, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_NerwicaDepresyjna()
        {
            var expectations = new[] { "ból głowy", "blad", "myśli", "osłab", "senn", "nerwic" };
            var answers = new float[] { 0, 0, 1, 0, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Depresja()
        {
            var expectations = new[] { "ból głowy", "blad", "myśli", "osłab", "senn", "depresj" };
            var answers = new float[] { 0, 0, 1, 0, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Afektywna()
        {
            var expectations = new[] { "ból głowy", "blad", "myśli", "osłab", "such", "afekt" };
            var answers = new float[] { 0, 0, 1, 1, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Watroba()
        {
            var expectations = new[] { "ból głowy", "blad", "myśli", "osłab", "such", "marskość" };
            var answers = new float[] { 0, 0, 1, 1, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Bulimia()
        {
            var expectations = new[] { "ból głowy", "blad", "osłab", "duszn", "ucho", "bulim" };
            var answers = new float[] { 0, 1, 0, 0, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Srodk()
        {
            var expectations = new[] { "ból głowy", "blad", "osłab", "duszn", "ucho", "zapalenie ucha" };
            var answers = new float[] { 0, 1, 0, 0, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Otrzewna()
        {
            var expectations = new[] { "ból głowy", "blad", "osłab", "duszn", "lęk", "zapalenie otrzewnej" };
            var answers = new float[] { 0, 1, 0, 1, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Zawal()
        {
            var expectations = new[] { "ból głowy", "blad", "osłab", "duszn", "lęk", "zawał serca" };
            var answers = new float[] { 0, 1, 0, 1, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Bialaczka()
        {
            var expectations = new[] { "ból głowy", "blad", "osłab", "senn", "niedokrwis", "białacz" };
            var answers = new float[] { 0, 1, 1, 0, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Szpik()
        {
            var expectations = new[] { "ból głowy", "blad", "osłab", "senn", "niedokrwis", "szpik" };
            var answers = new float[] { 0, 1, 1, 0, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Anemia()
        {
            var expectations = new[] { "ból głowy", "blad", "osłab", "senn", "dziąs", "anem" };
            var answers = new float[] { 0, 1, 1, 1, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Limfoblastyczna()
        {
            var expectations = new[] { "ból głowy", "blad", "osłab", "senn", "dziąs", "limfoblast" };
            var answers = new float[] { 0, 1, 1, 1, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Tezec()
        {
            var expectations = new[] { "ból głowy", "osłab", "gorącz", "światło", "plucie", "tężec" };
            var answers = new float[] { 1, 0, 0, 0, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Epistaxis()
        {
            var expectations = new[] { "ból głowy", "osłab", "gorącz", "światło", "plucie", "epistaxis" };
            var answers = new float[] { 1, 0, 0, 0, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Sienny()
        {
            var expectations = new[] { "ból głowy", "osłab", "gorącz", "światło", "wymio", "sienny" };
            var answers = new float[] { 1, 0, 0, 1, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Migrena()
        {
            var expectations = new[] { "ból głowy", "osłab", "gorącz", "światło", "wymio", "migren" };
            var answers = new float[] { 1, 0, 0, 1, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Kleszcz()
        {
            var expectations = new[] { "ból głowy", "osłab", "gorącz", "gardł", "senn", "kleszcz" };
            var answers = new float[] { 1, 0, 1, 0, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Opony()
        {
            var expectations = new[] { "ból głowy", "osłab", "gorącz", "gardł", "senn", "opon" };
            var answers = new float[] { 1, 0, 1, 0, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Sars()
        {
            var expectations = new[] { "ból głowy", "osłab", "gorącz", "gardł", "kostn", "sars" };
            var answers = new float[] { 1, 0, 1, 1, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Angina()
        {
            var expectations = new[] { "ból głowy", "osłab", "gorącz", "gardł", "kostn", "angin" };
            var answers = new float[] { 1, 0, 1, 1, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Nadciśnienie()
        {
            var expectations = new[] { "ból głowy", "osłab", "kasz", "świąd", "nadpobu", "tętnicz" };
            var answers = new float[] { 1, 1, 0, 0, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Grypa()
        {
            var expectations = new[] { "ból głowy", "osłab", "kasz", "świąd", "nadpobu", "gryp" };
            var answers = new float[] { 1, 1, 0, 0, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Uremia()
        {
            var expectations = new[] { "ból głowy", "osłab", "kasz", "świąd", "rozdraż", "uremi" };
            var answers = new float[] { 1, 1, 0, 1, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Nerki()
        {
            var expectations = new[] { "ból głowy", "osłab", "kasz", "świąd", "rozdraż", "ner" };
            var answers = new float[] { 1, 1, 0, 1, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Zatoki()
        {
            var expectations = new[] { "ból głowy", "osłab", "kasz", "katar", "drga", "zatok" };
            var answers = new float[] { 1, 1, 1, 0, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Aids()
        {
            var expectations = new[] { "ból głowy", "osłab", "kasz", "katar", "drga", "aids" };
            var answers = new float[] { 1, 1, 1, 0, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Astma()
        {
            var expectations = new[] { "ból głowy", "osłab", "kasz", "katar", "chrap", "pyłk" };
            var answers = new float[] { 1, 1, 1, 1, 0 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
        [TestMethod()]
        public void Msi_Przeziębienie()
        {
            var expectations = new[] { "ból głowy", "osłab", "kasz", "katar", "chrap", "przezi" };
            var answers = new float[] { 1, 1, 1, 1, 1 };
            var tree = new MsiTreeManager();
            for (int i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(tree.CurrentMessage.Contains(expectations[i]), $"Expected: \"{expectations[i]}\", got: \"{tree.CurrentMessage}\"");
                tree.AnswerQuestion(answers[i]);
            }
            Assert.IsTrue(tree.CurrentMessage.Contains(expectations[5]), $"Expected: \"{expectations[5]}\", got: \"{tree.CurrentMessage}\"");
        }
    }
}