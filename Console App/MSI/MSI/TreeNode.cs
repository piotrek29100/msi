using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI
{
    public class TreeNode
    {
        public TreeNode Left { get; }
        public TreeNode Right { get; }
        public string Question { get; }
        public string Answer { get; }

        public TreeNode(TreeNode left, TreeNode right, string question, string answer)
        {
            Left = left;
            Right = right;
            Question = question;
            Answer = answer;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }
    }
}
