using System;

namespace DeployTool.SharedKernel.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message)
            : base(message)
        {
        }
    }
}