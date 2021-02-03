using AvaliacaoTecnica.Domain;
using System;
using System.IO;

namespace AvaliacaoTecnica
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = File.ReadAllText("test-cases.txt").Replace("[", "").Replace("]", "").Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var testCase in testCases)
            {
                ProcessTree(testCase.Split(' '));
                Console.WriteLine();
            }
        }

        private static void  ProcessTree(string[] treeNodes)
        {
            try
            {
                var tree = new Tree();
                foreach (var treeNode in treeNodes)
                {
                    var items = treeNode.Split(',');
                    tree.AddNodes(items[0], items[1]);
                }

                tree.Print();
            }
            catch (TreatedException e)
            {
                Console.WriteLine($"Exceção {e.Code}");
            }
            catch
            {
                Console.WriteLine($"Exceção E4");
            }
        }
    }
}
