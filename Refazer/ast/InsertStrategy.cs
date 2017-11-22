using System.Collections.Generic;

namespace Tutor.ast
{
    public interface InsertStrategy
    {
        List<PythonNode> Insert(PythonNode context, PythonNode inserted, int index); 
    }
}
