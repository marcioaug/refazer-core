using System;

namespace Tutor
{
    public class TestCaseException : Exception
    {
        public TestCaseException(Exception e) : base(e.Message, e)
        {
        }
    }
}
