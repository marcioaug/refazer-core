using System;
using IronPython.Compiler.Ast;

namespace Tutor.ast
{
    public abstract class LeafNode : PythonNode
    {
        public LeafNode(Node innerNode) : base(innerNode)
        {
        }

        public override Tuple<bool, PythonNode> Match(PythonNode node)
        {
            PythonNode matchResult = null;
            if (!MatchInternalNode(node.InnerNode)) return Tuple.Create<bool, PythonNode>(false, null);

            return Tuple.Create(true, matchResult);
        }
    }
}
