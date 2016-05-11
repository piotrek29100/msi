using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dm = new DesitionMaker(GetTree(), 0.8, 0.1);
                Console.WriteLine("Pytania (odpowiedz 1-10):");
                foreach (var question in dm.GetQuestions())
                {
                    Console.WriteLine(question);
                    string r = Console.ReadLine();
                    dm.Answer(question, (double.Parse(r)-1)/9); //bo 1-10
                }
                Console.WriteLine("Wyniki:");
                foreach (var result in dm.GetResults())
                    Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

        static TreeNode GetTree()
        {
            //answers
            var node19 = new TreeNode(null, null, null, "Jęczmień");
            var node18 = new TreeNode(null, null, null, "Wytrzeszcz");
            var node15 = new TreeNode(null, null, null, "Zapalenie tęczówki");
            var node10 = new TreeNode(null, null, null, "Zapalenie twardówki");
            var node8 = new TreeNode(null, null, null, "Mocznica (uremia)");
            var node7 = new TreeNode(null, null, null, "Żółtaczka");
            var node30 = new TreeNode(null, null, null, "Zatrucie kadmem");
            var node29 = new TreeNode(null, null, null, "Dżuma");
            var nodeZdrowy = new TreeNode(null, null, null, "Zdrowy");
            var node20 = new TreeNode(null, null, null, "Alergia");
            var node12 = new TreeNode(null, null, null, "Oparzenie słoneczne");
            var node11 = new TreeNode(null, null, null, "Kleszczowe zapalenie mózgu");
            var node9 = new TreeNode(null, null, null, "Cukrzyca insulinozależna");
            var node26 = new TreeNode(null, null, null, "Difylobotrioza, Bruzdogłowiec szeroki (tasiemiec)");
            var node25 = new TreeNode(null, null, null, "Malaria");
            var node24 = new TreeNode(null, null, null, "Grypa");
            //questions
            var node17 = new TreeNode(node19, node18, "Wystające gałki oczne?", null);
            var node14 = new TreeNode(node15, node10, "Zniekształcenie gałki ocznej?", null);
            var node6 = new TreeNode(node8, node7, "Wysypka?", null);
            var node28 = new TreeNode(node30, node29, "Białko w moczu?", null);
            var node16 = new TreeNode(nodeZdrowy, node20, "Łzawienie?", null);
            var node13 = new TreeNode(node17, node14, "Zaczerwienienie?", null);
            var node21 = new TreeNode(node12, node11, "Wymioty?", null);
            var node5 = new TreeNode(node9, node6, "Obrzęk?", null);
            var node27 = new TreeNode(node26, node28, "Ból głowy?", null);
            var node23 = new TreeNode(node25, node24, "Ból stawów?", null);
            var node4 = new TreeNode(node16, node13, "Ból oka?", null);
            var node3 = new TreeNode(node21, node5, "Osłabienie?", null);
            var node22 = new TreeNode(node27, node23, "Ból miesni?", null);
            var node2 = new TreeNode(node4, node3, "Nudności?", null);
            return new TreeNode(node2, node22, "Dreszcze?", null);
        }

        //static TreeNode GetTree()
        //{
        //    var left = new TreeNode(new TreeNode(null, null, null, "Przetarcie ud"), new TreeNode(null, null, null, "Rak kosci"), "Boli noga?", null);
        //    var right = new TreeNode(new TreeNode(null, null, null, "Obwisle piersi"), new TreeNode(null, null, null, "Za duzo masturbacji"), "Boli reka?", null);
        //    return new TreeNode(left, right, "Boli u gory?", null);
        //}
    }
}
