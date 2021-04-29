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
        //UC5
        [TestMethod]
        public void GivenMoodAnalyser_WhenCorrect_Return_MoodAnalyseObject()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyzer.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenInvalidClassName_ShouldThrow_MoodAnalyserException_Of_ParameterisedConstructor()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyzer.sampleClass", "MoodAnalyser", "HAPPY");
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        // <summary>
        /// This test case is for
        /// TC 5.3 Given Invalid constructor name should throw MoodAnalyserException.
        /// </summary>
        [TestMethod]
        public void GivenInvalidConstructorName_ShouldThrow_MoodAnalyserException_Of_ParameterizedConstructor()
        {
            string expected = "Constructor is not found";
            try
            {
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyzer.MoodAnalyser", "sampleClass", "HAPPY");
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        //UC6
        /// <summary>
        /// Test Case 6.1 
        /// Happy message passing using Reflection when correct
        /// should return HAPPY Mood
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_UsingReflection_IfCorrect_Should_ReturnHappy()
        {
            string message = MoodAnalyserFactory.InvokeMethod("MoodAnalyzer.MoodAnalyser", "GetMood", "HAPPY");
            Assert.AreEqual("HAPPY", message);
        }

        /// <summary>
        /// Test Case 6.2 
        /// Given Happy message when incorrect method 
        /// should throw MoodAnalyserException
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_UsingReflection_WhenIncorrectMethod_shouldThrow_MoodAnayserException()
        {
            try
            {
                string message = MoodAnalyserFactory.InvokeMethod("MoodAnalyzer.MoodAnalyser", "getMethod", "HAPPY");
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual(MoodAnalyzerCustomException.ExceptionType.INVALID_INPUT, e.Message);
            }
        }

        /// <summary>
        /// Test Case 7.1
        /// set Happy message with Reflector 
        /// should return HAPPY
        /// </summary>
        [TestMethod]
        public void ChangeMoodDynamically_WhenHappyMessage_ShouldReturnHappy()
        {
            dynamic result = MoodAnalyserFactory.ChangeMoodDynamically("MoodAnalyser.MoodAnalyserMain", "HAPPY");
            Assert.AreEqual("HAPPY", result);
        }

        /// <summary>
        /// Test Case 7.2 set field when improper should throw Exception 
        /// </summary>
        [TestMethod]
        public void ChangeMoodDynamically_WhenImproperMessage_ShouldThrowException()
        {
            try
            {
                string message = MoodAnalyserFactory.ChangeMoodDynamically("MoodAnalyzer.getMood", "HAPPY");
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual(MoodAnalyzerCustomException.ExceptionType.INVALID_INPUT, e.Message);
            }
        }

        /// <summary>
        /// Test Case 7.3 setting Null message with Reflector should throw Exception
        /// </summary>
        [TestMethod]
        public void ChangeMoodDynamically_WhenNull_ShouldThrowException()
        {
            try
            {
                dynamic result = MoodAnalyserFactory.ChangeMoodDynamically("MoodAnalyzer.MoodAnalyser", null);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual(MoodAnalyzerCustomException.ExceptionType.NULL_EXCEPTION, e.Message);
            }
        }
    }
}
