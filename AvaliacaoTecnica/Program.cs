﻿using AvaliacaoTecnica.Domain;
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
                var treeNodes = testCase.Split(' ');
                var tree = new Tree();

                foreach (var treeNode in treeNodes)
                {
                    var items = treeNode.Split(',');
                    tree.AddNode(items[0], items[1]);
                }

                tree.Print();
            }
        }
    }
}