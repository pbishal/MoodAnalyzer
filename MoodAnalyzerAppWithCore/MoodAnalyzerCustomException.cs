using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerAppWithCore
{
    public class MoodAnalyzerCustomException : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE, EMPTY_MESSAGE, NO_SUCH_FIELD, NO_SUCH_METHOD, NO_SUCH_CLASS, OBJECT_CREATION_ISSUE
        }
        ////Creting 'type' variable of ExceptionType
        private readonly ExceptionType type;
        /// <summary>
        /// Parameterized Constructor sets the Exception type message.
        /// The type
        /// </summary>

        public MoodAnalyzerCustomException(ExceptionType Type, string message) : base(message)
        {
            this.type = Type;
        }



    }
}
