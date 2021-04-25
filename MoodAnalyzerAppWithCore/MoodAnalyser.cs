using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerAppWithCore
{
    public class MoodAnalyser
    {
        private string message;

        public MoodAnalyser(string message)
        {
            this.message = message;
        }         
        public string AnalyseMood()
        {
            //try
            //{
            //    if (this.message.Contains("Sad"))
            //    {
            //        return "SAD";
            //    }
            //    else
            //    {
            //        return "HAPPY";
            //    }
            //}
            //catch
            //{
            //    return "HAPPY";
            //}
            try
            {
                if(this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.EMPTY_MESSAGE, "Mood Should not be empty");
                }

                if(this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
            
        }
    }
}
