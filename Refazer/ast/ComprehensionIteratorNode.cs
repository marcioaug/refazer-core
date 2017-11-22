using System;
using IronPython.Compiler.Ast;

namespace Tutor.ast
{
    class ComprehensionIteratorNode : InternalNode
    {
        public ComprehensionIteratorNode(Node innerNode) : base(innerNode)
        {
        }

        protected override bool IsEqualToInnerNode(Node node)
        {
            throw new NotImplementedException();
        }

        public override PythonNode Clone()
        {
            throw new NotImplementedException();
        }
    }
}
