using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSI.Tree;

namespace MSI
{
    static class Program
    {
        static void Main(string[] args)
        {
            var results = new List<Tuple<string, float>>();
            var mtm = new MsiTreeManager();
            Console.WriteLine("Pytania (odpowiedz 0-10):");
            while (mtm.CurrentState != MsiState.RanOutOfQuestions)
            {
                while (mtm.CurrentState == MsiState.Interviewing)
                {
                    Console.WriteLine(mtm.CurrentMessage);
                    string r = Console.ReadLine();
                    mtm.AnswerQuestion(float.Parse(r) / 10); //bo 0-10
                }
                results.Add(new Tuple<string, float>(mtm.CurrentMessage, mtm.CurrentScore));
                mtm.DiscardAnswer();
            }

            Console.WriteLine("Wyniki:");
            foreach (var t in results.OrderBy(r => r.Item2).Where(t => t.Item2 >= 0.2))
            {
                Console.WriteLine($"{t.Item1} {Math.Round(t.Item2 * 100, 2)}%");
            }
            Console.ReadLine();


            //    try
            //    {
            //        var dm = new DesitionMaker(DesitionMaker.GetTree(), 0.49, 0);
            //        Console.WriteLine("Pytania (odpowiedz 1-10):");
            //        foreach (var question in dm.GetQuestions())
            //        {
            //            Console.WriteLine(question);
            //            string r = Console.ReadLine();
            //            dm.Answer(question, (double.Parse(r) / 10); //bo 0-10
            //        }
            //        Console.WriteLine("Wyniki:");
            //        var wyniki = dm.GetResults();
            //        if (wyniki.Any())
            //            foreach (var result in wyniki)
            //                Console.WriteLine(result);
            //        else
            //            Console.WriteLine("Brak diagnozy");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //    Console.ReadLine();
        }
    }
}
