using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerAppWithCore
{
    public class MoodAnalyser
    {
        readonly string message;

        /// <summary>
        /// Take mood message in constructor
        /// </summary>
        public MoodAnalyser()
        {
        }

        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="message"></param>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Ability to analyse and respond Sad or Happy Mood
        /// </summary>
        /// <returns></returns>
        public string AnalyzeMood(string message)
        {
            try
            {
                
                if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be EMPTY");
                }
                if (message.Contains("I am in sad mood"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (MoodAnalyzerCustomException e)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NULL_EXCEPTION, "Mood should not be NULL");
            }
        }
        public string AnalyzeMood()
        {
            return AnalyzeMood(this.message);
        }
    }
}
