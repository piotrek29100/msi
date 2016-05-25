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

//        static TreeNode GetTree()
//        {
//            var node4 = new TreeNode(null, null, "Ból oka?", null);
//            var node2 = new TreeNode(null, null, "Nudności?", null);
//            return new TreeNode(node4, node2, "Dreszcze?", null);
//        }
        
        static TreeNode GetTree()
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
        
        //static TreeNode GetTree()
        //{
        //    var left = new TreeNode(new TreeNode(null, null, null, "Przetarcie ud"), new TreeNode(null, null, null, "Rak kosci"), "Boli noga?", null);
        //    var right = new TreeNode(new TreeNode(null, null, null, "Obwisle piersi"), new TreeNode(null, null, null, "Za duzo masturbacji"), "Boli reka?", null);
        //    return new TreeNode(left, right, "Boli u gory?", null);
        //}
    }
}
