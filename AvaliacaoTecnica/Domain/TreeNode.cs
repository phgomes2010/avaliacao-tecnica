using System;
using System.Collections.Generic;

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
            {
                new Exception("E1 - Mais de 2 filhos");
            }

            child.Parent = this;
            Children.Add(child);
        }
    }
}
