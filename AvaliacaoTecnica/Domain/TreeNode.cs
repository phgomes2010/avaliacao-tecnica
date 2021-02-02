using System.Collections.Generic;

namespace AvaliacaoTecnica.Domain
{
    public class TreeNode
    {
        public char Content { get; set; }
        public TreeNode Parent { get; set; }
        public List<TreeNode> Children { get; set; }
    }
}
