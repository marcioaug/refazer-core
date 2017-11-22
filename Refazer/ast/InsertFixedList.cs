using System.Collections.Generic;

namespace Tutor.ast
{
    public class InsertFixedList : InsertStrategy
    {
        public List<PythonNode> Insert(PythonNode context, PythonNode inserted, int index)
        {
            if (index == -1)
                index = context.Children.Count;
            else if ((index + context.Children.Count +1 ) <= 0)
                index += context.Children.Count + 2;
            else if (index < 0)
                index += context.Children.Count + 1;
            var newList = new List<PythonNode>();
            newList.AddRange(context.Children);
            newList.Insert(index, inserted);
            return newList;
        }
    }
}
