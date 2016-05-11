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
                //czy wystarczająco blisko zera
                if (_dict[treeNode] <= _tolerance && treeNode.Left != null)
                    foreach (string question in GetQuestions(treeNode.Left))
                    {
                        yield return question;
                    }

                //czy blisko jedynki
                if (1 - _dict[treeNode] <= _tolerance && treeNode.Right != null)
                    foreach (string question in GetQuestions(treeNode.Right))
                    {
                        yield return question;
                    }
            }
        }

        public IEnumerable<string> GetResults()
        {
            return MultiplyResults(_treeRoot).Where(pair => pair.Item2 > _cutoff).OrderByDescending(pair=>pair.Item2).Select(pair => $"{pair.Item1} {Math.Round(pair.Item2 * 100,2)}%");
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
    }
}
