using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoTecnica.Domain
{
    public class Tree
    {
        public List<TreeNode> Nodes { get; set; } = new List<TreeNode>();
        public TreeNode Root
        {
            get
            {
                var roots = Nodes.FindAll(tn => tn.Parent == null);
                if (roots.Count > 1)
                    throw new System.Exception("E3 - Raízes múltiplas");

                return roots.First();
            }
        }

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

        public TreeNode FindNode(string content)
        {
            foreach (var node in Nodes)
                if (node.Content.Equals(content))
                    return node;

            return null;
        }

        public void Print()
        {

        }
    }
}
