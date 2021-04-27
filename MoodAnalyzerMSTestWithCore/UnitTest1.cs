using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerAppWithCore;

namespace MoodAnalyzerMSTestWithCore
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// UC1: Given a Message, ability to analyse and respond Happy or Sad Mood
        /// </summary>
        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            //Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyser moodAnalyse = new MoodAnalyser(message);

            //Act
            string mood = moodAnalyse.AnalyzeMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// 2.1: Given I am in Happy mood? and null message should return happy
        /// </summary>

        [TestMethod]  
        [DataRow("I am in Happy Mood")]
        [DataRow(null)]
        public void GivenHappyMoodShouldReturnHappy(string message)
        {
            //Arrange
            string expected = "HAPPY";
            MoodAnalyser moodAnalyse = new MoodAnalyser(message);

            //Act
            string mood = moodAnalyse.AnalyzeMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// TC 3.1 Given Mood Should Throw MoodAnalysisException
        /// </summary>
        [TestMethod]
        public void Given_NULL_Mood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyzeMood();
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }
        /// <summary>
        /// TC3.2: Given Empty mood should throw MoodAnalysisException Indicating Empty Mood.
        /// </summary>
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_EmptyMood()
        {
            try
            {
                string message = "";
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyzeMood();
            }
            catch(MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("Mood Should not be empty", e.Message);
            }
        }
        [TestMethod]
        public void Given_MoodAnalyser_ClassName_ShouldReturn_MoodAnalyseObject()
        {
            object expected = new MoodAnalyser("NULL");
            object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyzer.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenInvalidClassName_ShouldThrow_MoodAnalyserException()
        {
            string expected = "Class not Found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyser.sampleClass", "MoodAnalyser");
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        [TestMethod]
        public void GivenClass_WhenNotProper_Constructor_ShouldThrow_MoodAnalyserException()
        {
            string expected = "Constructor is not Found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyzer.MoodAnalyser", "sampleClass");
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}
