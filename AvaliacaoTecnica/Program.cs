using AvaliacaoTecnica.Domain;
using System;
using System.IO;

namespace AvaliacaoTecnica
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testCases = File.ReadAllText("test-cases.txt").Replace("[", "").Replace("]", "").Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var testCase in testCases)
            {
                try
                {
                    Console.WriteLine(ProcessTree(testCase.Split(' ')));
                }
                catch (TreatedException e)
                {
                    Console.WriteLine($"Exceção {e.Code}");
                }
                catch
                {
                    Console.WriteLine($"Exceção E4");
                }
                Console.WriteLine();
            }
        }

        public static string ProcessTree(string[] treeNodes)
        {
            var tree = new Tree();
            foreach (var treeNode in treeNodes)
            {
                var items = treeNode.Split(',');
                tree.AddNodes(items[0], items[1]);
            }
            return tree.Print();
        }
    }
}
