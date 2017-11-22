namespace Tutor.ast
{
    public interface IRewriter
    {
        PythonNode Rewrite(PythonNode node);
    }
}
