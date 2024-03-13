using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PrincipalDeveloper
{
    [TestClass]
    public class CryptoTest
    {
        //
        //  To run all tests in this class, position your cursor here
        //

        /// <summary>
        /// Test an input string that is null
        /// </summary>
        [TestMethod]
        public void InputStringNull()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                string inputString = null;
                cryptoTest.Scramble(inputString, "ABCDE");
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "The input string cannot be null.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("InputStringNull failed to throw an exception.");
            }
        }
        /// <summary>
        /// Test an input string that is null
        /// </summary>
        [TestMethod]
        public void InputStringNull2()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                string inputString = null;
                cryptoTest.Scramble(inputString);
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "The input string cannot be null.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("InputStringNull2 failed to throw an exception.");
            }
        }
        /// <summary>
        /// Test an key string that is null
        /// </summary>
        [TestMethod]
        public void KeyStringNull()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                string keyString = null;
                cryptoTest.Scramble("ABCDE", keyString);
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "The key string cannot be null.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("KeyStringNull failed to throw an exception.");
            }
        }
        /// <summary>
        /// Test an input string that is only one character
        /// </summary>
        [TestMethod]
        public void InputStringTooShort()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                cryptoTest.Scramble("A", "ABCDE");
                failedTest = true;
            } catch (Exception ex)
            {
                string expected = "The input string must be at least 2 characters in length.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("InputStringTooShort failed to throw an exception.");
            }
        }
        /// <summary>
        /// Test an input string that is only one character
        /// </summary>
        [TestMethod]
        public void InputStringTooShort2()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                cryptoTest.Scramble("A");
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "The input string must be at least 2 characters in length.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("InputStringTooShort2 failed to throw an exception.");
            }
        }
        /// <summary>
        /// Test a key string that is the same length as the input string
        /// </summary>
        [TestMethod]
        public void KeyStringSameSizeAsInput()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                cryptoTest.Scramble("ABC", "ABC");
                failedTest = true;
            } catch (Exception ex)
            {
                string expected = "Your key string must be shorter than your input string";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("KeyStringSameSizeAsInput failed to throw an exception.");
            }
        }
        /// <summary>
        /// Put invalid characters in the input string
        /// </summary>
        [TestMethod]
        public void InvalidCharactersInTheInputString()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                cryptoTest.Scramble((char)8 + "ABC", "ABC");
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "Your input string contains invalid characters.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("InvalidCharactersInTheInputString failed to throw an exception.");
            }
        }
        /// <summary>
        /// Put invalid characters in the key string
        /// </summary>
        [TestMethod]
        public void InvalidCharactersInTheKeyString()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                cryptoTest.Scramble("ABCDEF", "ABC" + (char)8);
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "Your key string contains invalid characters.  " + (char)34 + (char)8 + (char)34;
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("InvalidCharactersInTheKeyString failed to throw an exception.");
            }
        }
        /// <summary>
        /// Test a key string that is all spaces (all spaces would make the scrambled string equal to the input string)
        /// </summary>
        [TestMethod]
        public void KeyStringIsAllSpaces()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                cryptoTest.Scramble("ABCDEF", "     ");
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "A keyString of all spaces will not scramble the input string.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("KeyStringIsAllSpaces failed to throw an exception.");
            }
        }
        /// <summary>
        /// Try scrambling a short string with a short key
        /// </summary>
        [TestMethod]
        public void ScrambleTestShort()
        {
            Crypto cryptoTest = new Crypto();
            string expected = "bc";
            string actual = cryptoTest.Scramble("AB", "A");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Try descrambling a short scrambled string using a short key
        /// </summary>
        [TestMethod]
        public void DescrambleTestShort()
        {
            Crypto cryptoTest = new Crypto();
            string expected = "AB";
            string actual = cryptoTest.Descramble("bc", "A");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test Descramble where the scrambled string is null
        /// </summary>
        [TestMethod]
        public void DescrambleNull()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                cryptoTest.Descramble(null, "abc");
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "The scrambled string cannot be null.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("DescrambleNull failed to throw an exception.");
            }
        }
        /// <summary>
        /// Test descramble where the key is null
        /// </summary>
        [TestMethod]
        public void DescrambleKeyNull()
        {
            Crypto cryptoTest = new Crypto();
            Boolean failedTest = false;
            try
            {
                cryptoTest.Descramble("abc", null);
                failedTest = true;
            }
            catch (Exception ex)
            {
                string expected = "The key string cannot be null.";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            if (failedTest)
            {
                Assert.Fail("DescrambleKeyNull failed to throw an exception.");
            }
        }
        /// <summary>
        /// Try a more complicated input string and key string
        /// </summary>
        [TestMethod]
        public void ScrambleDescramble1()
        {
            Crypto cryptoTest = new Crypto();
            string keyString = "UQi3#(";
            string clear = "DouglasHahn";
            string scrambled = cryptoTest.Scramble(clear, keyString);
            string descrambled = cryptoTest.Descramble(scrambled, keyString);
            Assert.AreEqual(clear, descrambled);
        }
        /// <summary>
        /// Go wild and try 10,000 scramble / descramble tests with a complicated key
        /// </summary>
        [TestMethod]
        public void MultipleScrambleDescramble()
        {
            Crypto cryptoTest = new Crypto();
            string keyString = "&eQj,3";
            string validCharacters = cryptoTest.AllValidCharacters();
            for (int testNo = 1;testNo < 10000; testNo++)
            {
                //
                //  Assemble a random string
                //
                Random rnd = new Random();
                string inputString = "";
                for (int c = 0;c < 25; c++)
                {
                    inputString += validCharacters.Substring(rnd.Next(0, validCharacters.Length - 1), 1);
                }
                string scrambled = cryptoTest.Scramble(inputString, keyString);
                Assert.AreNotEqual(inputString, scrambled);
                string descrambled = cryptoTest.Descramble(scrambled, keyString);
                Assert.AreEqual(inputString, descrambled);
            }
        }
        /// <summary>
        /// Have the function generate a random key, scramble an input string and return both the scrambled string and the key
        /// Then descramble the string using the key
        /// </summary>
        [TestMethod]
        public void GenerateKeyAndScramble()
        {
            Crypto cryptoTest = new Crypto();
            string clearString = "I want to scramble this string";
            Crypto.ScrambledAndKey output = cryptoTest.Scramble(clearString);
            //
            string descrambledString = cryptoTest.Descramble(output.Scrambled, output.Key);
            Assert.AreEqual(clearString, descrambledString);
        }
        /// <summary>
        /// Test the scramble (one parameter) with 10,000 tests
        /// </summary>
        [TestMethod]
        public void GenerateKeyAndScrambleMultiTest()
        {
            Crypto cryptoTest = new Crypto();
            string validCharacters = cryptoTest.AllValidCharacters();
            for (int testNo = 1; testNo < 10000; testNo++)
            {
                //
                //  Assemble a random string
                //
                Random rnd = new Random();
                string inputString = "";
                for (int c = 0; c < 25; c++)
                {
                    inputString += validCharacters.Substring(rnd.Next(0, validCharacters.Length - 1), 1);
                }
                Crypto.ScrambledAndKey scrambledAndKey = cryptoTest.Scramble(inputString);
                string keyString = scrambledAndKey.Key;
                string scrambled = scrambledAndKey.Scrambled;
                Assert.AreNotEqual(inputString, scrambled);
                string descrambled = cryptoTest.Descramble(scrambled, keyString);
                Assert.AreEqual(inputString, descrambled);
            }
        }
    }
}
