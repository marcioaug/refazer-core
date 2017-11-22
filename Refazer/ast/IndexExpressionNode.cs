using System;
using IronPython.Compiler.Ast;

namespace Tutor.ast
{
    class IndexExpressionNode : InternalNode
    {
        public IndexExpressionNode(Node innerNode) : base(innerNode)
        {
        }

        protected override bool IsEqualToInnerNode(Node node)
        {
            throw new NotImplementedException();
        }

        public override PythonNode Clone()
        {
            var pythonNode = new IndexExpressionNode(InnerNode);
            pythonNode.Children = Children;
            pythonNode.Id = Id;
            if (Value != null) pythonNode.Value = Value;
            return pythonNode;
        }
    }
}
