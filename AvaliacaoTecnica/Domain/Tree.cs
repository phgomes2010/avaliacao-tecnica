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
                    throw new TreatedException("E3");

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

        public string Print()
        {
            return ConvertToPrintableString(Root);
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
                throw new TreatedException("E2");

            currentNode.WasPrinted = true;
            string result;
            if (currentNode == Root)
            {
                result = $"{currentNode.Content}[{ConvertChildrenToPrintableString(currentNode.Children)}{Environment.NewLine}]";
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
            var newLine = string.Empty;
            foreach(var child in children)
            {
                if (child.Parent == Root)
                    newLine = Environment.NewLine;

                result += newLine + ConvertToPrintableString(child);
            }
            return result;
        }
        #endregion Private Methods
    }
}
