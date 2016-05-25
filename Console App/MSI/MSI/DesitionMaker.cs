using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI
{
    public class DesitionMaker
    {
        private readonly TreeNode _treeRoot;
        private Dictionary<TreeNode, double> _dict;
        private readonly double _tolerance;
        private readonly double _cutoff;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeRoot"></param>
        /// <param name="tolerance">Ignoruje sciezke jesli wybor jest zbyt odlegly, dla 1 zawsze oba, dla 0 musi byc dokladnie wybor 0 albo 1</param>
        /// <param name="cutoff">Odcina to co ma % ponizej</param>
        public DesitionMaker(TreeNode treeRoot, double tolerance, double cutoff)
        {
            _treeRoot = treeRoot;
            _tolerance = tolerance;
            _cutoff = cutoff;
        }

        public IEnumerable<string> GetQuestions()
        {
            _dict = new Dictionary<TreeNode, double>();
            return GetQuestions(_treeRoot);
        }

        public void Answer(string question, double value)
        {
            var node = GetNode(question);
            if (node == null) throw new ArgumentException($"There is no question: {question}.", nameof(question));
            if (value < 0 || value > 1) throw new ArgumentOutOfRangeException(nameof(value), value, "Must be between 0-1.");
            if (_dict.ContainsKey(node))
                _dict[node] = value;
            else
                _dict.Add(node, value);

        }

        private TreeNode GetNode(string question)
        {
            return GetNode(_treeRoot, question);
        }

        private TreeNode GetNode(TreeNode node, string question)
        {
            if (node == null) return null;
            if (node.Question == question)
                return node;

            var ret = GetNode(node.Left, question);
            if (ret != null) return ret;

            ret = GetNode(node.Right, question);
            return ret;
        }

        private IEnumerable<string> GetQuestions(TreeNode treeNode)
        {
            if (treeNode.Question == null)
            {
                if (treeNode.Answer != null)
                    _dict.Add(treeNode, 1);
            }
            else
            {
                yield return treeNode.Question;
                
                var nodePair = _dict.SingleOrDefault(p => p.Key.Question == treeNode.Question && p.Key.Answer == treeNode.Answer);
                //czy wystarczająco blisko zera
                // todo: _dict[treeNode] zamiast nodePair.Value
                if (nodePair.Value <= _tolerance && treeNode.Left != null)
                    foreach (string question in GetQuestions(treeNode.Left))
                    {
                        yield return question;
                    }

                //czy blisko jedynki
                // todo: _dict[treeNode] zamiast nodePair.Value
                if (1 - nodePair.Value <= _tolerance && treeNode.Right != null)
                    foreach (string question in GetQuestions(treeNode.Right))
                    {
                        yield return question;
                    }

            }
        }

        public IEnumerable<string> GetResults()
        {
            return MultiplyResults(_treeRoot).Where(pair => pair.Item2 > _cutoff).OrderByDescending(pair => pair.Item2).Select(pair => $"{pair.Item1} {Math.Round(pair.Item2 * 100, 2)}%");
        }

        private IEnumerable<Tuple<string, double>> MultiplyResults(TreeNode node)
        {
            if (node == null || !_dict.ContainsKey(node)) return Enumerable.Empty<Tuple<string, double>>();
            if (node.Answer != null)
                return new List<Tuple<string, double>> { new Tuple<string, double>(node.Answer, 1) };

            var result = new List<Tuple<string, double>>();
            if (node.Left != null && _dict.ContainsKey(node.Left))
                result.AddRange(MultiplyResults(node.Left).Select(r => new Tuple<string, double>(r.Item1, r.Item2 * (1 - _dict[node]))));
            if (node.Right != null && _dict.ContainsKey(node.Right))
                result.AddRange(MultiplyResults(node.Right).Select(r => new Tuple<string, double>(r.Item1, r.Item2 * _dict[node])));

            return result;
        }

        public static TreeNode GetTree()
        {
            // answers
            var node00000 = new TreeNode(null, null, null, "Zdrowy");
            var node00001 = new TreeNode(null, null, null, "Zespół raynauda");
            var node00010 = new TreeNode(null, null, null, "Choroba zezowa");
            var node00011 = new TreeNode(null, null, null, "Katarakta");
            var node00100 = new TreeNode(null, null, null, "Nerwica depresyjna");
            var node00101 = new TreeNode(null, null, null, "Depresja");
            var node00110 = new TreeNode(null, null, null, "Choroba afektywna");
            var node00111 = new TreeNode(null, null, null, "Pierwotna marskość żółciowa wątroby");
            var node01000 = new TreeNode(null, null, null, "Bulimia");
            var node01001 = new TreeNode(null, null, null, "Zapalenie ucha środkowego");
            var node01010 = new TreeNode(null, null, null, "Zapalenie otrzewnej");
            var node01011 = new TreeNode(null, null, null, "Zawał serca");
            var node01100 = new TreeNode(null, null, null, "Białaczka");
            var node01101 = new TreeNode(null, null, null, "Białaczka szpikowa");
            var node01110 = new TreeNode(null, null, null, "Anemia");
            var node01111 = new TreeNode(null, null, null, "Białaczka limfoblastyczna");
            var node10000 = new TreeNode(null, null, null, "Tężec");
            var node10001 = new TreeNode(null, null, null, "Krwawienie z nosa epistaxis");
            var node10010 = new TreeNode(null, null, null, "Katar sienny");
            var node10011 = new TreeNode(null, null, null, "Migrena");
            var node10100 = new TreeNode(null, null, null, "Kleszczowe zapalenie mózgu");
            var node10101 = new TreeNode(null, null, null, "Zapalenie opon mózgowych");
            var node10110 = new TreeNode(null, null, null, "Ostry zespół oddechowy - sars");
            var node10111 = new TreeNode(null, null, null, "Angina");
            var node11000 = new TreeNode(null, null, null, "Nadciśnienie tętnicze");
            var node11001 = new TreeNode(null, null, null, "Grypa");
            var node11010 = new TreeNode(null, null, null, "Mocznica uremia");
            var node11011 = new TreeNode(null, null, null, "Przewlekła niewydolność nerek choroby kłębuszków nerkowych");
            var node11100 = new TreeNode(null, null, null, "Przewlekłe zapalenie zatok przynosowych");
            var node11101 = new TreeNode(null, null, null, "AIDS");
            var node11110 = new TreeNode(null, null, null, "Astma pyłkowa");
            var node11111 = new TreeNode(null, null, null, "Przeziębienie");

            // questions
            var node0000 = new TreeNode(node00000, node00001, "Biała skóra?", null);
            var node0001 = new TreeNode(node00010, node00011, "Oczopląs?", null);
            var node0010 = new TreeNode(node00100, node00101, "Senność?", null);
            var node0011 = new TreeNode(node00110, node00111, "Suchość w ustach?", null);
            var node0100 = new TreeNode(node01000, node01001, "Ból ucha?", null);
            var node0101 = new TreeNode(node01010, node01011, "Lęk?", null);
            var node0110 = new TreeNode(node01100, node01101, "Niedokrwistość?", null);
            var node0111 = new TreeNode(node01110, node01111, "Krwawienie dziąseł?", null);
            var node1000 = new TreeNode(node10000, node10001, "Krwioplucie?", null);
            var node1001 = new TreeNode(node10010, node10011, "Wymioty?", null);
            var node1010 = new TreeNode(node10100, node10101, "Senność?", null);
            var node1011 = new TreeNode(node10110, node10111, "Bóle kostne?", null);
            var node1100 = new TreeNode(node11000, node11001, "Nadpobudliwość?", null);
            var node1101 = new TreeNode(node11010, node11011, "Rozdrażnienie?", null);
            var node1110 = new TreeNode(node11100, node11101, "Drgawki?", null);
            var node1111 = new TreeNode(node11110, node11111, "Chrapanie?", null);

            var node000 = new TreeNode(node0000, node0001, "Kłopot z widzeniem w nocy?", null);
            var node001 = new TreeNode(node0010, node0011, "Osłabienie?", null);
            var node010 = new TreeNode(node0100, node0101, "Duszność?", null);
            var node011 = new TreeNode(node0110, node0111, "Senność?", null);
            var node100 = new TreeNode(node1000, node1001, "Światłowstręt?", null);
            var node101 = new TreeNode(node1010, node1011, "Ból gardła?", null);
            var node110 = new TreeNode(node1100, node1101, "Świąd skóry?", null);
            var node111 = new TreeNode(node1110, node1111, "Katar?", null);

            var node00 = new TreeNode(node000, node001, "Myśli samobójcze?", null);
            var node01 = new TreeNode(node010, node011, "Osłabienie?", null);
            var node10 = new TreeNode(node100, node101, "Gorączka?", null);
            var node11 = new TreeNode(node110, node111, "Kaszel?", null);

            var node0 = new TreeNode(node00, node01, "Bladość?", null);
            var node1 = new TreeNode(node10, node11, "Osłabienie?", null);

            return new TreeNode(node0, node1, "Ból głowy?", null);
        }
    }
}
