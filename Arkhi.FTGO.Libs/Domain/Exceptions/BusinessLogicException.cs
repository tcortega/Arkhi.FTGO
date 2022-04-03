using System;

namespace Arkhi.FTGO.Libs.Domain.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message) : base(message)
        {
        }
    }
}