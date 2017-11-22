using System;
using IronPython.Compiler.Ast;

namespace Tutor.ast
{
    class PrintStatementNode : InternalNode
    {
        public PrintStatementNode(Node innerNode) : base(innerNode)
        {
            InsertStrategy = new InsertFixedList();
        }

        protected override bool IsEqualToInnerNode(Node node)
        {
            throw new NotImplementedException();
        }

        public override PythonNode Clone()
        {
            var pythonNode = new PrintStatementNode(InnerNode);
            pythonNode.Children = Children;
            pythonNode.Id = Id;
            if (Value != null) pythonNode.Value = Value;
            return pythonNode;
        }

    }
}
