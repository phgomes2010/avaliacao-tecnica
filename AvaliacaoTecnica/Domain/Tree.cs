using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoTecnica.Domain
{
    public class Tree
    {
        private List<TreeNode> Nodes { get; set; } = new List<TreeNode>();
        private TreeNode Root
        {
            get
            {
                var roots = Nodes.FindAll(tn => tn.Parent == null);
                if (roots.Count > 1)
                    throw new Exception("E3 - Raízes múltiplas");

                return roots.First();
            }
        }

        #region Public Methods
        public void AddNodes(string parentContent, string childContent)
        {
            var parent = FindNode(parentContent);
            if (parent == null)
            {
                parent = new TreeNode(parentContent);
                Nodes.Add(parent);
            }

            var child = FindNode(childContent);
            if (child == null)
            {
                child = new TreeNode(childContent);
                Nodes.Add(child);
            }

            parent.EstablishRelationship(child);
        }

        public void Print()
        {
            Console.WriteLine(ConvertToPrintableString(Root));
        }
        #endregion Public Methods

        #region Private Methods
        private TreeNode FindNode(string content)
        {
            foreach (var node in Nodes)
                if (node.Content.Equals(content))
                    return node;

            return null;
        }

        private string ConvertToPrintableString(TreeNode currentNode)
        {
            if(currentNode.WasPrinted)
                throw new Exception("E2 - Ciclo presente");

            currentNode.WasPrinted = true;
            var result = string.Empty;
            if (currentNode == Root)
            {
                if (currentNode.Children.Count == 0)
                    result = currentNode.Content;
                else
                    result = $"{currentNode.Content}[\n{ConvertToPrintableString(currentNode.Children[0])}\n{ConvertToPrintableString(currentNode.Children[1])}\n]";
            }
            else
            {
                if (currentNode.Children.Count == 0)
                    result = $"[{currentNode.Content}]";
                else
                    result = $"[{currentNode.Content}{ConvertChildrenToPrintableString(currentNode.Children)}]";
            }
            return result;
        }

        private string ConvertChildrenToPrintableString(List<TreeNode> children)
        {
            var result = string.Empty;
            foreach(var child in children)
            {
                result += ConvertToPrintableString(child);
            }
            return result;
        }
        #endregion Private Methods
    }
}
