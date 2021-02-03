using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoTecnica.Domain
{
    public class TreeNode
    {
        public bool WasPrinted { get; set; }
        public string Content { get; set; }
        public TreeNode Parent { get; set; }
        public List<TreeNode> Children { get; set; } = new List<TreeNode>();

        public TreeNode(string content)
        {
            Content = content;
        }

        public void EstablishRelationship(TreeNode child)
        {
            if(Children.Count == 2)
                throw new TreatedException("E1");

            if (Children.Count == 1 && string.Compare(child.Content, Children.First().Content) < 0)
            {
                Children.Insert(0, child);
            }
            else
            {
                Children.Add(child);
            }

            child.Parent = this;
        }
    }
}
